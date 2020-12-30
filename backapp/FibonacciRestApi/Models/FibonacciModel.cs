using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace FibonacciRestApi.Models
{
    public class FibonacciModel
    {
        public int Id { get; set; }

        public int Size { get; set; }

        public List<List<Int64>> MultiplicationTable { get; set; }
    }
}