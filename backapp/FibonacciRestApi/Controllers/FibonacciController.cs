using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Web.Http;

namespace FibonacciRestApi.Controllers
{
    public class FibonacciController : ApiController
    {
/*        // GET api/values
        public List<List<BigInteger>> Get()
        {
            return new List<List<BigInteger>>() { new List<BigInteger>(){1,2,3 }, new List<BigInteger>(){3,2,1} };
        }*/

        // GET fibonacci/N
        public List<List<BigInteger>> Get(int size)
        {
            return new List<List<BigInteger>>() { new List<BigInteger>() { 0,0,0 }, new List<BigInteger>() { 3, 3, 3 } };
        }

        // POST api/values
        public void Post([FromBody] string value)
        {

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
