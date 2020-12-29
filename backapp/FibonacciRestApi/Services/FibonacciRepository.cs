using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using FibonacciRestApi.Models;
using CustomMath;

namespace FibonacciRestApi.Services
{
    public class FibonacciRepository
    {
        public virtual FibonacciModel Get(int? size)
        {
            FibonacciModel result = new FibonacciModel();
            result.MultiplicationTable = CustomMath.Fibonacci.GetMultiplicationTable(size);
            return result;
        }

        public virtual FibonacciModel Post(int? size)
        {
            //FibonacciModel result = new FibonacciModel();
            //return CustomMath.Fibonacci.GetMultiplicationTable(size);
            return this.Get(size);
        }
    }
}