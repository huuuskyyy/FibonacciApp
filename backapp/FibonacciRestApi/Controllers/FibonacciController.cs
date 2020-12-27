using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Web.Http;
using CustomMath;
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
        /*        // GET api/values
                public List<List<BigInteger>> Get()
                {
                    return new List<List<BigInteger>>() { new List<BigInteger>(){1,2,3 }, new List<BigInteger>(){3,2,1} };
                }*/

        // GET fibonacci/N
        public List<List<BigInteger>> Get(int size)
        {
            return this.fibonacciRepository.GetFibonacciMultiplicationTableBySize(size);
        }

        // POST api/values
        public List<List<BigInteger>> Post([FromBody] int value)
        {
            return this.fibonacciRepository.PostFibonacciSequence(value);
        }

/*        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }*/
    }
}
