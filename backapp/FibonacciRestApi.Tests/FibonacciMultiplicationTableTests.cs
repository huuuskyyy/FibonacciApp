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
            BigInteger first = 0;
            BigInteger second = 1;
            int sequenceLength = 0;
            List<List<BigInteger>> fibonacciMultiplicationTableActual = new List<List<BigInteger>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(first, second, sequenceLength);

            Assert.AreEqual(0, fibonacciMultiplicationTableActual.Count, 0, "Count of Fibonacci multiplication table with 0 elements is more than 0. Actual count " + fibonacciMultiplicationTableActual.Count);
        }

        [TestMethod]
        public void FibonacciMultiplicationTableZeroElementsDefaults()
        {
            int sequenceLength = 0;
            List<List<BigInteger>> fibonacciMultiplicationTableActual = new List<List<BigInteger>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(sequenceLength);

            Assert.AreEqual(0, fibonacciMultiplicationTableActual.Count, 0, "Count of Fibonacci multiplication table defaults with 0 elements is more than 0. Actual count " + fibonacciMultiplicationTableActual.Count);
        }

        [TestMethod]
        public void FibonacciMultiplicationTableFiveElements()
        {
            BigInteger first = 1;
            BigInteger second = 1;
            int sequenceLength = 5;
            List<List<BigInteger>> fibonacciMultiplicationTableActual = new List<List<BigInteger>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(first, second, sequenceLength);

            List<List<BigInteger>> fibonacciMultiplicationTableExpected = new List<List<BigInteger>>()
            { new List<BigInteger>(){1,1,2,3,5},
            new List<BigInteger>(){1,1,1,2,3,5},
            new List<BigInteger>(){1,1,1,2,3,5},
            new List<BigInteger>(){2,2,2,4,6,10},
            new List<BigInteger>(){3,3,3,6,9,15},
            new List<BigInteger>(){5,5,5,10,15,25}};

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<BigInteger> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<BigInteger> currentActual = fibonacciMultiplicationTableActual[i];

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
            List<List<BigInteger>> fibonacciMultiplicationTableActual = new List<List<BigInteger>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(sequenceLength);

            List<List<BigInteger>> fibonacciMultiplicationTableExpected = new List<List<BigInteger>>()
            { new List<BigInteger>(){0,1,1,2,3},
            new List<BigInteger>(){0,0,0,0,0,0},
            new List<BigInteger>(){1,0,1,1,2,3},
            new List<BigInteger>(){1,0,1,1,2,3},
            new List<BigInteger>(){2,0,2,2,4,6},
            new List<BigInteger>(){3,0,3,3,6,9} };

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<BigInteger> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<BigInteger> currentActual = fibonacciMultiplicationTableActual[i];

                CollectionAssert.AreEqual(currentExpected, currentActual,
                "Expected result of Fibonacci multiplication table with 5 elements defaults is not correct at row " + i + ". " +
                "Expected <" + String.Join(", ", currentExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", currentActual.ToArray()) + ">");
            }
        }
    }
}
