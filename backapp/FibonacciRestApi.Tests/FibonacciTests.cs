using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomMath;
using System.Collections.Generic;
using System;
using System.Numerics;

namespace FibonacciMultiplicationTableConsoleAppTests
{
    [TestClass]
    public class FibonacciTests
    {
        [TestMethod]
        public void FibonacciZeroElements()
        {
            Int64 first = 0;
            Int64 second = 1;
            int sequenceLength = 0;
            List<long?> fibonacciSequenceActual = new List<long?>();
            fibonacciSequenceActual = Fibonacci.GetSequence(first, second, sequenceLength);

            Assert.AreEqual(0, fibonacciSequenceActual.Count, 0, "Count of Fibonacci sequence with 0 elements is more than 0. Actual count " + fibonacciSequenceActual.Count);
        }

        [TestMethod]
        public void FibonacciZeroElementsDefaults()
        {
            int sequenceLength = 0;
            List<long?> fibonacciSequenceActual = new List<long?>();
            fibonacciSequenceActual = Fibonacci.GetSequence(sequenceLength);

            Assert.AreEqual(0, fibonacciSequenceActual.Count, 0, "Count of Fibonacci sequence defaults with 0 elements is more than 0. Actual count " + fibonacciSequenceActual.Count);
        }

        [TestMethod]
        public void FibonacciOneElement()
        {
            Int64 first = 0;
            Int64 second = 1;
            int sequenceLength = 1;
            List<long?> fibonacciSequenceActual = new List<long?>();
            fibonacciSequenceActual = Fibonacci.GetSequence(first, second, sequenceLength);

            List<long?> fibonacciSequenceExpected = new List<long?>() {0};

            CollectionAssert.AreEqual(fibonacciSequenceExpected, fibonacciSequenceActual, 
                "Expected result of Fibonacci sequence with 1 element is not correct. " +
                "Expected <" + String.Join(", ", fibonacciSequenceExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", fibonacciSequenceActual.ToArray()) + ">");
        }

        [TestMethod]
        public void FibonacciOneElementDefaults()
        {
            int sequenceLength = 1;
            List<long?> fibonacciSequenceActual = new List<long?>();
            fibonacciSequenceActual = Fibonacci.GetSequence(sequenceLength);

            List<long?> fibonacciSequenceExpected = new List<long?>() { 0 };

            CollectionAssert.AreEqual(fibonacciSequenceExpected, fibonacciSequenceActual,
                "Expected result of Fibonacci sequence defaults with 1 element is not correct. " +
                "Expected <" + String.Join(", ", fibonacciSequenceExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", fibonacciSequenceActual.ToArray()) + ">");
        }

        [TestMethod]
        public void FibonacciTwoElements()
        {
            Int64 first = 0;
            Int64 second = 1;
            int sequenceLength = 2;
            List<long?> fibonacciSequenceActual = new List<long?>();
            fibonacciSequenceActual = Fibonacci.GetSequence(first, second, sequenceLength);

            List<long?> fibonacciSequenceExpected = new List<long?>() { 0, 1 };

            CollectionAssert.AreEqual(fibonacciSequenceExpected, fibonacciSequenceActual,
                "Expected result of Fibonacci sequence with 2 elements is not correct. " +
                "Expected <" + String.Join(", ", fibonacciSequenceExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", fibonacciSequenceActual.ToArray()) + ">");
        }

        [TestMethod]
        public void FibonacciTwoElementsDefaults()
        {
            int sequenceLength = 2;
            List<long?> fibonacciSequenceActual = new List<long?>();
            fibonacciSequenceActual = Fibonacci.GetSequence(sequenceLength);

            List<long?> fibonacciSequenceExpected = new List<long?>() { 0, 1 };

            CollectionAssert.AreEqual(fibonacciSequenceExpected, fibonacciSequenceActual,
                "Expected result of Fibonacci sequence defaults with 2 elements is not correct. " +
                "Expected <" + String.Join(", ", fibonacciSequenceExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", fibonacciSequenceActual.ToArray()) + ">");
        }

        [TestMethod]
        public void FibonacciTenElements()
        {
            Int64 first = 0;
            Int64 second = 1;
            int sequenceLength = 10;
            List<long?> fibonacciSequenceActual = new List<long?>();
            fibonacciSequenceActual = Fibonacci.GetSequence(first, second, sequenceLength);

            List<long?> fibonacciSequenceExpected = new List<long?>() { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };

            CollectionAssert.AreEqual(fibonacciSequenceExpected, fibonacciSequenceActual,
                "Expected result of Fibonacci sequence with 10 elements is not correct. " +
                "Expected <" + String.Join(", ", fibonacciSequenceExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", fibonacciSequenceActual.ToArray()) + ">");
        }

        [TestMethod]
        public void FibonacciTenElementsDefaults()
        {
            int sequenceLength = 10;
            List<long?> fibonacciSequenceActual = new List<long?>();
            fibonacciSequenceActual = Fibonacci.GetSequence(sequenceLength);

            List<long?> fibonacciSequenceExpected = new List<long?>() { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };

            CollectionAssert.AreEqual(fibonacciSequenceExpected, fibonacciSequenceActual,
                "Expected result of Fibonacci sequence defaults with 10 elements is not correct. " +
                "Expected <" + String.Join(", ", fibonacciSequenceExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", fibonacciSequenceActual.ToArray()) + ">");
        }

        [TestMethod]
        public void FibonacciFiftyElements()
        {
            Int64 first = 0;
            Int64 second = 1;
            int sequenceLength = 50;
            List<long?> fibonacciSequenceActual = new List<long?>();
            fibonacciSequenceActual = Fibonacci.GetSequence(first, second, sequenceLength);

            List<long?> fibonacciSequenceExpected = new List<long?>() {0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903, 2971215073, 4807526976, 7778742049 };

            CollectionAssert.AreEqual(fibonacciSequenceExpected, fibonacciSequenceActual,
                "Expected result of Fibonacci sequence with 50 elements is not correct. " +
                "Expected <" + String.Join(", ", fibonacciSequenceExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", fibonacciSequenceActual.ToArray()) + ">");
        }

        [TestMethod]
        public void FibonacciFiftyElementsDefaults()
        {
            int sequenceLength = 50;
            List<long?> fibonacciSequenceActual = new List<long?>();
            fibonacciSequenceActual = Fibonacci.GetSequence(sequenceLength);

            List<long?> fibonacciSequenceExpected = new List<long?>() { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903, 2971215073, 4807526976, 7778742049 };

            CollectionAssert.AreEqual(fibonacciSequenceExpected, fibonacciSequenceActual,
                "Expected result of Fibonacci sequence defaults with 50 elements is not correct. " +
                "Expected <" + String.Join(", ", fibonacciSequenceExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", fibonacciSequenceActual.ToArray()) + ">");
        }
    }
}
