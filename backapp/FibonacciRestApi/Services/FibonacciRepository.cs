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
        public virtual FibonacciModelMongoDB Get(int? size)
        {
            FibonacciModelMongoDB result = this.GetEntryForSize((int)size);

            if(result == null)
            {
                result = new FibonacciModelMongoDB();
                result.MultiplicationTable = CustomMath.Fibonacci.GetMultiplicationTable(size);
                result.Size = (int)size;
                this.AddEntry(result);
            }

            return result;
        }

        public virtual FibonacciModelMongoDB Post(int? size)
        {
            //FibonacciModel result = new FibonacciModel();
            //return CustomMath.Fibonacci.GetMultiplicationTable(size);
            return this.Get(size);
        }

        private void AddEntry(FibonacciModelMongoDB entry)
        {
            var entries = MongoDbService.GetDatabase().GetCollection<FibonacciModelMongoDB>("Fibonacci");
            entries.InsertOne(entry);
        }

        private Boolean EntryForSizeExists(int size)
        {
            //Boolean result = false;

            var entries = MongoDbService.GetDatabase().GetCollection<FibonacciModelMongoDB>("Fibonacci");
            FilterDefinition<FibonacciModelMongoDB> filter = FilterDefinition<FibonacciModelMongoDB>.Empty;
            //var count = entries.CountDocuments(filter);
            var dataFromDb = entries.Find(x => x.Size == size).ToList();

            return dataFromDb.Count > 0;
        }

        private FibonacciModelMongoDB GetEntryForSize(int size)
        {
            FibonacciModelMongoDB result = null;
            var entries = MongoDbService.GetDatabase().GetCollection<FibonacciModelMongoDB>("Fibonacci");
            FilterDefinition<FibonacciModelMongoDB> filter = FilterDefinition<FibonacciModelMongoDB>.Empty;
            //var count = entries.CountDocuments(filter);
            var dataFromDb = entries.Find(x => x.Size == size).ToList();

            if(dataFromDb.Count == 1)
            {
                result = dataFromDb[0];
            }

            return result;
        }
    }
}