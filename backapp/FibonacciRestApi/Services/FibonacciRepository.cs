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
        public virtual List<List<BigInteger>> GetFibonacciMultiplicationTableBySize(int size)
        {
            return Fibonacci.GetMultiplicationTable(size);
        }

        public virtual List<List<BigInteger>> PostFibonacciSequence(int size)
        {
            return Fibonacci.GetMultiplicationTable(size);
        }
    }
}