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
using FibonacciRestApi.Models;
using System.Net;

namespace FibonacciRestApi.Tests.Controllers

{
    [TestClass]
    public class FibonacciControllerTest
    {

        List<List<Int64>> fibonacciMultiplicationTableFive = new List<List<Int64>>()
            { new List<Int64>(){0,1,1,2,3},
            new List<Int64>(){0,0,0,0,0,0},
            new List<Int64>(){1,0,1,1,2,3},
            new List<Int64>(){1,0,1,1,2,3},
            new List<Int64>(){2,0,2,2,4,6},
            new List<Int64>(){3,0,3,3,6,9} };

        [TestMethod]
        public void GetBySizeInvalid()
        {
            // Arrange
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.Get(-5);

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void GetBySizeFive()
        {
            // Arrange
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            List<List<Int64>> fibonacciMultiplicationTableExpected = fibonacciMultiplicationTableFive;

            // Act
            var response = controller.Get(5);

            List<List<Int64>> fibonacciMultiplicationTableActual = new List<List<Int64>>();
            Assert.IsTrue(response.TryGetContentValue<List<List<Int64>>>(out fibonacciMultiplicationTableActual));

            //Assert
            Assert.IsNotNull(fibonacciMultiplicationTableActual);
            Assert.AreEqual(6, fibonacciMultiplicationTableActual.Count());

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
        public void GetBySizeZero()
        {
            // Arrange
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.Get(0);

            List<List<Int64>> fibonacciMultiplicationTableActual = new List<List<Int64>>();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);

        }

        [TestMethod]
        public void PostNonExistingValue()
        {
            // Arrange
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            List<List<Int64>> fibonacciMultiplicationTableExpected = fibonacciMultiplicationTableFive;

            // Act
            var response = controller.Get(5);

            List<List<Int64>> fibonacciMultiplicationTableActual = new List<List<Int64>>();
            Assert.IsTrue(response.TryGetContentValue<List<List<Int64>>>(out fibonacciMultiplicationTableActual));

            //Assert
            Assert.IsNotNull(fibonacciMultiplicationTableActual);
            Assert.AreEqual(6, fibonacciMultiplicationTableActual.Count());

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<Int64> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<Int64> currentActual = fibonacciMultiplicationTableActual[i];

                CollectionAssert.AreEqual(currentExpected, currentActual,
                "Expected result of POST Fibonacci multiplication table with 5 elements is not correct at row " + i + ". " +
                "Expected <" + String.Join(", ", currentExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", currentActual.ToArray()) + ">");
            }
        }

        [TestMethod]
        public void PostAlreadyExistingValue()
        {
            // Arrange
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            List<List<Int64>> fibonacciMultiplicationTableExpected = fibonacciMultiplicationTableFive;

            // Act
            var response = controller.Get(5);
            response = controller.Get(5);

            List<List<Int64>> fibonacciMultiplicationTableActual = new List<List<Int64>>();
            Assert.IsTrue(response.TryGetContentValue<List<List<Int64>>>(out fibonacciMultiplicationTableActual));

            //Assert
            Assert.IsNotNull(fibonacciMultiplicationTableActual);
            Assert.AreEqual(6, fibonacciMultiplicationTableActual.Count());

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<Int64> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<Int64> currentActual = fibonacciMultiplicationTableActual[i];

                CollectionAssert.AreEqual(currentExpected, currentActual,
                "Expected result of POST Fibonacci multiplication table with 5 elements is not correct at row " + i + ". " +
                "Expected <" + String.Join(", ", currentExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", currentActual.ToArray()) + ">");
            }
        }

    public class FibonacciTestRepository : FibonacciRepository
        {
            public Dictionary<int, List<List<Int64>>> database;
            public FibonacciTestRepository()
            {
                database = new Dictionary<int, List<List<Int64>>>();
            }


            public override FibonacciModelMongoDB Post(int? size)
            {
                List<List<Int64>> result = new List<List<Int64>>();

                if (!database.ContainsKey((int)size))
                {
                    database.Add((int)size, Fibonacci.GetMultiplicationTable(size));
                }

                FibonacciModelMongoDB model = new FibonacciModelMongoDB();
                model.MultiplicationTable = database[(int)size];
                model.Size = (int)size;
                return model;
            }
        }
    }
}
