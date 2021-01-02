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

        public virtual HttpResponseMessage Get(int size)
        {
            HttpResponseMessage response;

            List<List<Int64>> multiplicationTable = this.fibonacciRepository.Get(size).MultiplicationTable;

            if (multiplicationTable.Count == 0)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                response = Request.CreateResponse(multiplicationTable);
            }


            return response;
        }

        public virtual HttpResponseMessage Post([FromBody] FibonacciModelMongoDB model)
        {
            HttpResponseMessage response;
            if (model == null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                int size = model.Size;
                if (size != null)
                {
                    FibonacciModelMongoDB fibonacci = this.fibonacciRepository.Post(size);

                    response = Request.CreateResponse(HttpStatusCode.Created, fibonacci.MultiplicationTable);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }

            return response;
        }

    }
}
