using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CustomMath;

namespace FibonacciMultiplicationTableConsoleAppTests
{
    [TestClass]
    public class FibonacciMultiplicationTableTests
    {
        [TestMethod]
        public void FibonacciMultiplicationTableZeroElements()
        {
            double first = 0;
            double second = 1;
            int sequenceLength = 0;
            List<List<double>> fibonacciMultiplicationTableActual = new List<List<double>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(first, second, sequenceLength);

            Assert.AreEqual(0, fibonacciMultiplicationTableActual.Count, 0, "Count of Fibonacci multiplication table with 0 elements is more than 0. Actual count " + fibonacciMultiplicationTableActual.Count);
        }

        [TestMethod]
        public void FibonacciMultiplicationTableZeroElementsDefaults()
        {
            int sequenceLength = 0;
            List<List<double>> fibonacciMultiplicationTableActual = new List<List<double>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(sequenceLength);

            Assert.AreEqual(0, fibonacciMultiplicationTableActual.Count, 0, "Count of Fibonacci multiplication table defaults with 0 elements is more than 0. Actual count " + fibonacciMultiplicationTableActual.Count);
        }

        [TestMethod]
        public void FibonacciMultiplicationTableFiveElements()
        {
            double first = 1;
            double second = 1;
            int sequenceLength = 5;
            List<List<double>> fibonacciMultiplicationTableActual = new List<List<double>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(first, second, sequenceLength);

            List<List<double>> fibonacciMultiplicationTableExpected = new List<List<double>>()
            { new List<double>(){1,1,2,3,5},
            new List<double>(){1,1,1,2,3,5},
            new List<double>(){1,1,1,2,3,5},
            new List<double>(){2,2,2,4,6,10},
            new List<double>(){3,3,3,6,9,15},
            new List<double>(){5,5,5,10,15,25}};

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<double> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<double> currentActual = fibonacciMultiplicationTableActual[i];

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
            List<List<double>> fibonacciMultiplicationTableActual = new List<List<double>>();
            fibonacciMultiplicationTableActual = Fibonacci.GetMultiplicationTable(sequenceLength);

            List<List<double>> fibonacciMultiplicationTableExpected = new List<List<double>>()
            { new List<double>(){0,1,1,2,3},
            new List<double>(){0,0,0,0,0,0},
            new List<double>(){1,0,1,1,2,3},
            new List<double>(){1,0,1,1,2,3},
            new List<double>(){2,0,2,2,4,6},
            new List<double>(){3,0,3,3,6,9} };

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<double> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<double> currentActual = fibonacciMultiplicationTableActual[i];

                CollectionAssert.AreEqual(currentExpected, currentActual,
                "Expected result of Fibonacci multiplication table with 5 elements defaults is not correct at row " + i + ". " +
                "Expected <" + String.Join(", ", currentExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", currentActual.ToArray()) + ">");
            }
        }
    }
}
