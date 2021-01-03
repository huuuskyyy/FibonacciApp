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

        List<List<long?>> fibonacciMultiplicationTableFive = new List<List<long?>>()
            { new List<long?>(){null,0,1,1,2,3},
            new List<long?>(){0,0,0,0,0,0},
            new List<long?>(){1,0,1,1,2,3},
            new List<long?>(){1,0,1,1,2,3},
            new List<long?>(){2,0,2,2,4,6},
            new List<long?>(){3,0,3,3,6,9} };

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
            List<List<long?>> fibonacciMultiplicationTableExpected = fibonacciMultiplicationTableFive;

            // Act
            var response = controller.Get(5);

            List<List<long?>> fibonacciMultiplicationTableActual = new List<List<long?>>();
            Assert.IsTrue(response.TryGetContentValue<List<List<long?>>>(out fibonacciMultiplicationTableActual));

            //Assert
            Assert.IsNotNull(fibonacciMultiplicationTableActual);
            Assert.AreEqual(6, fibonacciMultiplicationTableActual.Count());

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
        public void GetBySizeZero()
        {
            // Arrange
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.Get(0);

            List<List<long?>> fibonacciMultiplicationTableActual = new List<List<long?>>();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);

        }

        [TestMethod]
        public void PostNonExistingValue()
        {
            // Arrange
            FibonacciController controller = new FibonacciController(new FibonacciTestRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            List<List<long?>> fibonacciMultiplicationTableExpected = fibonacciMultiplicationTableFive;

            // Act
            var response = controller.Get(5);

            List<List<long?>> fibonacciMultiplicationTableActual = new List<List<long?>>();
            Assert.IsTrue(response.TryGetContentValue<List<List<long?>>>(out fibonacciMultiplicationTableActual));

            //Assert
            Assert.IsNotNull(fibonacciMultiplicationTableActual);
            Assert.AreEqual(6, fibonacciMultiplicationTableActual.Count());

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<long?> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<long?> currentActual = fibonacciMultiplicationTableActual[i];

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
            List<List<long?>> fibonacciMultiplicationTableExpected = fibonacciMultiplicationTableFive;

            // Act
            var response = controller.Get(5);
            response = controller.Get(5);

            List<List<long?>> fibonacciMultiplicationTableActual = new List<List<long?>>();
            Assert.IsTrue(response.TryGetContentValue<List<List<long?>>>(out fibonacciMultiplicationTableActual));

            //Assert
            Assert.IsNotNull(fibonacciMultiplicationTableActual);
            Assert.AreEqual(6, fibonacciMultiplicationTableActual.Count());

            for (int i = 0; i < fibonacciMultiplicationTableExpected.Count; i++)
            {
                List<long?> currentExpected = fibonacciMultiplicationTableExpected[i];
                List<long?> currentActual = fibonacciMultiplicationTableActual[i];

                CollectionAssert.AreEqual(currentExpected, currentActual,
                "Expected result of POST Fibonacci multiplication table with 5 elements is not correct at row " + i + ". " +
                "Expected <" + String.Join(", ", currentExpected.ToArray()) + ">. " +
                "Actual <" + String.Join(", ", currentActual.ToArray()) + ">");
            }
        }

    public class FibonacciTestRepository : FibonacciRepository
        {
            public Dictionary<int, List<List<long?>>> database;
            public FibonacciTestRepository()
            {
                database = new Dictionary<int, List<List<long?>>>();
            }

            public override FibonacciModelMongoDB Get(int size)
            {
                FibonacciModelMongoDB result = new FibonacciModelMongoDB();
                if (!database.ContainsKey(size))
                {
                    result.MultiplicationTable = CustomMath.Fibonacci.GetMultiplicationTable(size);
                    result.Size = size;
                }
                else
                {
                    result.MultiplicationTable = database[size];
                }

                return result;
            }


            public override FibonacciModelMongoDB Post(int size)
            {
                List<List<long?>> result = new List<List<long?>>();

                if (!database.ContainsKey(size))
                {
                    database.Add(size, Fibonacci.GetMultiplicationTable(size));
                }

                FibonacciModelMongoDB model = new FibonacciModelMongoDB();
                model.MultiplicationTable = database[size];
                model.Size = size;
                return model;
            }
        }
    }
}
