using FibonacciRestApi;
using FibonacciRestApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Web.Http;
using CustomMath;
using FibonacciRestApi.Services;

namespace FibonacciRestApi.Tests.Controllers
{
    [TestClass]
    public class FibonacciControllerTest
    {

        [TestMethod]
        public void GetBySizeInvalid()
        {
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());

            List<List<BigInteger>> fibonacciMultiplicationTableActual = controller.Get(-5);

            Assert.IsNotNull(fibonacciMultiplicationTableActual);
            Assert.AreEqual(0, fibonacciMultiplicationTableActual.Count());
        }

        [TestMethod]
        public void GetBySizeZero()
        {
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());

            List<List<BigInteger>> fibonacciMultiplicationTableActual = controller.Get(0);

            Assert.IsNotNull(fibonacciMultiplicationTableActual);
            Assert.AreEqual(0, fibonacciMultiplicationTableActual.Count());
        }

        [TestMethod]
        public void GetBySizeFive()
        {
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());

            List<List<BigInteger>> fibonacciMultiplicationTableExpected = new List<List<BigInteger>>()
            { new List<BigInteger>(){1,1,2,3,5},
            new List<BigInteger>(){1,1,1,2,3,5},
            new List<BigInteger>(){1,1,1,2,3,5},
            new List<BigInteger>(){2,2,2,4,6,10},
            new List<BigInteger>(){3,3,3,6,9,15},
            new List<BigInteger>(){5,5,5,10,15,25}};

            List<List<BigInteger>> fibonacciMultiplicationTableActual = controller.Get(5);

            Assert.IsNotNull(fibonacciMultiplicationTableActual);
            Assert.AreEqual(6, fibonacciMultiplicationTableActual.Count());

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
        public void PostNonExistingValue()
        {
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());

            List<List<BigInteger>> fibonacciMultiplicationTableExpected = new List<List<BigInteger>>()
            { new List<BigInteger>(){1,1,2,3,5},
            new List<BigInteger>(){1,1,1,2,3,5},
            new List<BigInteger>(){1,1,1,2,3,5},
            new List<BigInteger>(){2,2,2,4,6,10},
            new List<BigInteger>(){3,3,3,6,9,15},
            new List<BigInteger>(){5,5,5,10,15,25}};

            List<List<BigInteger>> fibonacciMultiplicationTableActual = controller.Post(5);

            Assert.IsNotNull(fibonacciMultiplicationTableActual);
            Assert.AreEqual(6, fibonacciMultiplicationTableActual.Count());

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<BigInteger> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<BigInteger> currentActual = fibonacciMultiplicationTableActual[i];

                CollectionAssert.AreEqual(currentExpected, currentActual,
                "Expected result of POST Fibonacci multiplication table with 5 elements is not correct at row " + i + ". " +
                "Expected <" + String.Join(", ", currentExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", currentActual.ToArray()) + ">");
            }
        }

        [TestMethod]
        public void PostAlreadyExistingValue()
        {
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());

            List<List<BigInteger>> fibonacciMultiplicationTableExpected = new List<List<BigInteger>>()
            { new List<BigInteger>(){1,1,2,3,5},
            new List<BigInteger>(){1,1,1,2,3,5},
            new List<BigInteger>(){1,1,1,2,3,5},
            new List<BigInteger>(){2,2,2,4,6,10},
            new List<BigInteger>(){3,3,3,6,9,15},
            new List<BigInteger>(){5,5,5,10,15,25}};

            List<List<BigInteger>> fibonacciMultiplicationTableActual = controller.Post(5);
            fibonacciMultiplicationTableActual = controller.Post(5);

            Assert.IsNotNull(fibonacciMultiplicationTableActual);
            Assert.AreEqual(6, fibonacciMultiplicationTableActual.Count());

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<BigInteger> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<BigInteger> currentActual = fibonacciMultiplicationTableActual[i];

                CollectionAssert.AreEqual(currentExpected, currentActual,
                "Expected result of POST Fibonacci multiplication table with 5 elements is not correct at row " + i + ". " +
                "Expected <" + String.Join(", ", currentExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", currentActual.ToArray()) + ">");
            }
        }

    }

    public class FibonacciTestRepository: FibonacciRepository
    {
        public Dictionary<BigInteger, List<List<BigInteger>>> database;
        public FibonacciTestRepository()
        {
            database = new Dictionary<int, List<List<BigInteger>>>;
    }
        public override List<List<BigInteger>> GetFibonacciMultiplicationTableBySize(int size)
        {
            return Fibonacci.GetMultiplicationTable(size);
        }

        public override List<List<BigInteger>> PostFibonacciSequence(int size)
        {
            List<List<BigInteger>> result = new List<List<BigInteger>>();
            if (!database.ContainsKey(size))
            {
                database.Add(size, Fibonacci.GetMultiplicationTable(size));
            }
            return database[size];
        }
    }
}
