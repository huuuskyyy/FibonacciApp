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
            List<List<BigInteger>> multiplicationTable = this.fibonacciRepository.Get(size).MultiplicationTable;

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
            FibonacciModel fibonacci = this.fibonacciRepository.Post(size);

            var response = Request.CreateResponse(HttpStatusCode.Created, fibonacci.MultiplicationTable);
            //string uri = Url.Link("DefaultApi", new { id = product.Id });
            //response.Headers.Location = new Uri(uri);

            return response;
        }

    }
}
