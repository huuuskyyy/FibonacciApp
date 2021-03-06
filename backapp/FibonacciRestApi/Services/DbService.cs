﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FibonacciRestApi.Services
{
    public static class MongoDbService
    {
        private static readonly string MongoDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MongoDBConnection"].ConnectionString;
        private static readonly string databaseName = MongoUrl.Create(MongoDBConnectionString).DatabaseName;
        private static MongoClient client; 

        private static MongoClient GetClient()
        {
            if(client == null)
            {
                client = new MongoClient(MongoDBConnectionString);
            }

            return client;
        }

        public static IMongoDatabase GetDatabase()
        {
            return MongoDbService.GetClient().GetDatabase(databaseName);
        }
    }
}