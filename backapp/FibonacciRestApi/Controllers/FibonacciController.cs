using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Web.Http;
using CustomMath;
using FibonacciRestApi.Models;
using FibonacciRestApi.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FibonacciRestApi.Controllers
{
    public class FibonacciController : ApiController
    {

        private FibonacciRepository fibonacciRepository;

        public FibonacciController()
        {
            this.fibonacciRepository = new FibonacciRepository();
        }

        public FibonacciController(FibonacciRepository customRepository)
        {
            this.fibonacciRepository = customRepository;
        }

        public virtual HttpResponseMessage Get(int? size)
        {
            //const string MongoDBConnectionString = "mongodb+srv://angel-test:91tOfHpG5v13wENd@cluster0.x937i.mongodb.net/TestDatabase?retryWrites=true&w=majority";
            //var client = new MongoClient(MongoDBConnectionString);
            // Create the collection object that represents the "products" collection
            //var database = client.GetDatabase("TestDatabase");
            //var entries = MongoDbService.GetDatabase().GetCollection<FibonacciModelMongoDB>("Fibonacci");
            //FilterDefinition<FibonacciModelMongoDB> filter = FilterDefinition<FibonacciModelMongoDB>.Empty;
            //var count = entries.CountDocuments(filter);
            //var dataFromDb = entries.Find(x => x.Size == 4).ToList();

            List<List<Int64>> multiplicationTable = this.fibonacciRepository.Get(size).MultiplicationTable;

            if (multiplicationTable.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(multiplicationTable);
        }

/*        public void Post([FromBody] int value)
        {
            this.fibonacciRepository.PostFibonacciSequence(value);
        }*/

        public virtual HttpResponseMessage Post([FromBody] int? size)
        {
            FibonacciModelMongoDB fibonacci = this.fibonacciRepository.Post(size);

            var response = Request.CreateResponse(HttpStatusCode.Created, fibonacci.MultiplicationTable);
            //string uri = Url.Link("DefaultApi", new { id = product.Id });
            //response.Headers.Location = new Uri(uri);

            return response;
        }

    }
}
