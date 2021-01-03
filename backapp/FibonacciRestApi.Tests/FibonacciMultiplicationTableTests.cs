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
            List<List<long?>> fibonacciMultiplicationTableActual = new List<List<long?>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(first, second, sequenceLength);

            Assert.AreEqual(0, fibonacciMultiplicationTableActual.Count, 0, "Count of Fibonacci multiplication table with 0 elements is more than 0. Actual count " + fibonacciMultiplicationTableActual.Count);
        }

        [TestMethod]
        public void FibonacciMultiplicationTableZeroElementsDefaults()
        {
            int sequenceLength = 0;
            List<List<long?>> fibonacciMultiplicationTableActual = new List<List<long?>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(sequenceLength);

            Assert.AreEqual(0, fibonacciMultiplicationTableActual.Count, 0, "Count of Fibonacci multiplication table defaults with 0 elements is more than 0. Actual count " + fibonacciMultiplicationTableActual.Count);
        }

        [TestMethod]
        public void FibonacciMultiplicationTableFiveElements()
        {
            Int64 first = 1;
            Int64 second = 1;
            int sequenceLength = 5;
            List<List<long?>> fibonacciMultiplicationTableActual = new List<List<long?>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(first, second, sequenceLength);

            List<List<long?>> fibonacciMultiplicationTableExpected = new List<List<long?>>()
            { new List<long?>(){null,1,1,2,3,5},
            new List<long?>(){1,1,1,2,3,5},
            new List<long?>(){1,1,1,2,3,5},
            new List<long?>(){2,2,2,4,6,10},
            new List<long?>(){3,3,3,6,9,15},
            new List<long?>(){5,5,5,10,15,25}};

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<long?> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<long?> currentActual = fibonacciMultiplicationTableActual[i];

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
            List<List<long?>> fibonacciMultiplicationTableActual = new List<List<long?>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(sequenceLength);

            List<List<long?>> fibonacciMultiplicationTableExpected = new List<List<long?>>()
            { new List<long?>(){null,0,1,1,2,3},
            new List<long?>(){0,0,0,0,0,0},
            new List<long?>(){1,0,1,1,2,3},
            new List<long?>(){1,0,1,1,2,3},
            new List<long?>(){2,0,2,2,4,6},
            new List<long?>(){3,0,3,3,6,9} };

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<long?> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<long?> currentActual = fibonacciMultiplicationTableActual[i];

                CollectionAssert.AreEqual(currentExpected, currentActual,
                "Expected result of Fibonacci multiplication table with 5 elements defaults is not correct at row " + i + ". " +
                "Expected <" + String.Join(", ", currentExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", currentActual.ToArray()) + ">");
            }
        }
    }
}
