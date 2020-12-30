using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace FibonacciRestApi.Models
{
    public class FibonacciModelMongoDB
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Size")]
        public int Size { get; set; }

        [BsonElement("MultiplicationTable")]
        public List<List<Int64>> MultiplicationTable { get; set; }
    }
}