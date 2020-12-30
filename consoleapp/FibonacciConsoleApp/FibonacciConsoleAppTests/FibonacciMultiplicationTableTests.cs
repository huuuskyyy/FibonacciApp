using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CustomMath;
using System.Numerics;

namespace FibonacciMultiplicationTableConsoleAppTests
{
    [TestClass]
    public class FibonacciMultiplicationTableTests
    {
        [TestMethod]
        public void FibonacciMultiplicationTableZeroElements()
        {
            Int64 first = 0;
            Int64 second = 1;
            int sequenceLength = 0;
            List<List<Int64>> fibonacciMultiplicationTableActual = new List<List<Int64>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(first, second, sequenceLength);

            Assert.AreEqual(0, fibonacciMultiplicationTableActual.Count, 0, "Count of Fibonacci multiplication table with 0 elements is more than 0. Actual count " + fibonacciMultiplicationTableActual.Count);
        }

        [TestMethod]
        public void FibonacciMultiplicationTableZeroElementsDefaults()
        {
            int sequenceLength = 0;
            List<List<Int64>> fibonacciMultiplicationTableActual = new List<List<Int64>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(sequenceLength);

            Assert.AreEqual(0, fibonacciMultiplicationTableActual.Count, 0, "Count of Fibonacci multiplication table defaults with 0 elements is more than 0. Actual count " + fibonacciMultiplicationTableActual.Count);
        }

        [TestMethod]
        public void FibonacciMultiplicationTableFiveElements()
        {
            Int64 first = 1;
            Int64 second = 1;
            int sequenceLength = 5;
            List<List<Int64>> fibonacciMultiplicationTableActual = new List<List<Int64>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(first, second, sequenceLength);

            List<List<Int64>> fibonacciMultiplicationTableExpected = new List<List<Int64>>()
            { new List<Int64>(){1,1,2,3,5},
            new List<Int64>(){1,1,1,2,3,5},
            new List<Int64>(){1,1,1,2,3,5},
            new List<Int64>(){2,2,2,4,6,10},
            new List<Int64>(){3,3,3,6,9,15},
            new List<Int64>(){5,5,5,10,15,25}};

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<Int64> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<Int64> currentActual = fibonacciMultiplicationTableActual[i];

                CollectionAssert.AreEqual(currentExpected, currentActual,
                "Expected result of Fibonacci multiplication table with 5 elements is not correct at row " + i + ". " +
                "Expected <" + String.Join(", ", currentExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", currentActual.ToArray()) + ">");
            }
        }

        [TestMethod]
        public void FibonacciMultiplicationTableFiveElementsDefaults()
        {
            int sequenceLength = 5;
            List<List<Int64>> fibonacciMultiplicationTableActual = new List<List<Int64>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(sequenceLength);

            List<List<Int64>> fibonacciMultiplicationTableExpected = new List<List<Int64>>()
            { new List<Int64>(){0,1,1,2,3},
            new List<Int64>(){0,0,0,0,0,0},
            new List<Int64>(){1,0,1,1,2,3},
            new List<Int64>(){1,0,1,1,2,3},
            new List<Int64>(){2,0,2,2,4,6},
            new List<Int64>(){3,0,3,3,6,9} };

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<Int64> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<Int64> currentActual = fibonacciMultiplicationTableActual[i];

                CollectionAssert.AreEqual(currentExpected, currentActual,
                "Expected result of Fibonacci multiplication table with 5 elements defaults is not correct at row " + i + ". " +
                "Expected <" + String.Join(", ", currentExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", currentActual.ToArray()) + ">");
            }
        }
    }
}
