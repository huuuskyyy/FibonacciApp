using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using FibonacciRestApi.Models;
using CustomMath;
using MongoDB.Driver;

namespace FibonacciRestApi.Services
{
    public class FibonacciRepository
    {
        public virtual FibonacciModelMongoDB Get(int size)
        {
            FibonacciModelMongoDB result = this.GetEntryForSizeFromDb(size);

            if (result == null)
            {
                result = new FibonacciModelMongoDB();
                result.MultiplicationTable = CustomMath.Fibonacci.GetMultiplicationTable(size);
                result.Size = size;
            }

            return result;
        }

        public virtual FibonacciModelMongoDB Post(int size)
        {
            FibonacciModelMongoDB result = null;

            result = this.Get(size);

            if (result != null & !EntryForSizeExists(size))
            {
                this.AddEntry(result);
            }


            return result;
        }

        private void AddEntry(FibonacciModelMongoDB entry)
        {
            var entries = MongoDbService.GetDatabase().GetCollection<FibonacciModelMongoDB>("Fibonacci");
            entries.InsertOne(entry);
        }

        private Boolean EntryForSizeExists(int size)
        {
            var entries = MongoDbService.GetDatabase().GetCollection<FibonacciModelMongoDB>("Fibonacci");
            FilterDefinition<FibonacciModelMongoDB> filter = FilterDefinition<FibonacciModelMongoDB>.Empty;
            var dataFromDb = entries.Find(x => x.Size == size).ToList();

            return dataFromDb.Count > 0;
        }

        private FibonacciModelMongoDB GetEntryForSizeFromDb(int size)
        {
            FibonacciModelMongoDB result = null;
            var entries = MongoDbService.GetDatabase().GetCollection<FibonacciModelMongoDB>("Fibonacci");
            FilterDefinition<FibonacciModelMongoDB> filter = FilterDefinition<FibonacciModelMongoDB>.Empty;
            var dataFromDb = entries.Find(x => x.Size == size).ToList();

            if (dataFromDb.Count == 1)
            {
                result = dataFromDb[0];
            }

            return result;
        }
    }
}