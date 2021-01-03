require 'sinatra'
require 'net/http'
require 'uri'
require 'json'

set :public_folder, 'public'

get '/fibonacci' do
  table = nil
  size = params[:n];
  
  if size != nil
	uri = URI.parse("http://localhost:44331/fibonacci/" + size)
	http = Net::HTTP.new(uri.host, uri.port)
	request = Net::HTTP::Get.new(uri.request_uri)

	response = http.request(request)
	
	if response.kind_of? Net::HTTPSuccess 
		table = JSON.parse(response.body)
	end
  end
	
  erb :fibonacci, locals: {size: params[:n], table: table, saved: false}, layout: :application
end

post '/fibonacci' do
  table = nil   
  saved = false 
  size = nil
	
	if params[:size] != nil
		uri = URI('http://localhost:44331/fibonacci')
		response = Net::HTTP.post_form(uri, 'Size' => params[:size])
		if response.kind_of? Net::HTTPSuccess 
			table = JSON.parse(response.body)
			if table.count > 0
				saved = true
			end
		end
	end

  erb :fibonacci, locals: {size: size, table: table, saved: saved}, layout: :application
end
