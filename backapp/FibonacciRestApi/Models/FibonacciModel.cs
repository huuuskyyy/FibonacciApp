﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace FibonacciRestApi.Models
{
    public class FibonacciModel
    {
        public int Id { get; set; }

        public List<List<BigInteger>> MultiplicationTable { get; set; }
    }
}