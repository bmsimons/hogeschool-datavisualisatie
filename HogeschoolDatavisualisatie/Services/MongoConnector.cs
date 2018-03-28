using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace HogeschoolDatavisualisatie.Services
{
    public class MongoConnector
    {
        private const string DatabaseName = "hogeschool";

        private static MongoConnector instance = null;
        private static readonly object padlock = new object();

        private MongoClient mongoClient = null;
        private IMongoDatabase mongoDatabase = null;
        private string ipAddress = null;
        private string port = null;

        public MongoConnector(string ipAddress = "127.0.0.1", string port = "27017")
        {
            this.ipAddress = ipAddress;
            this.port = port;
        }

        public void Connect()
        {
            this.mongoClient = new MongoClient("mongodb://" + ipAddress + ":" + port);
            this.mongoDatabase = this.mongoClient.GetDatabase(DatabaseName);
        }

        public static MongoConnector Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MongoConnector();
                    }
                    return instance;
                }
            }
        }

        public IMongoDatabase MongoDatabase { get => mongoDatabase; set => mongoDatabase = value; }
        public MongoClient MongoClient { get => mongoClient; set => mongoClient = value; }

        public void InsertIntoDatabase(List<BsonDocument> documents, string collectionName)
        {
            IMongoCollection<BsonDocument> collection = this.mongoDatabase.GetCollection<BsonDocument>(collectionName);
            collection.InsertMany(documents);
        }

        public void InsertIntoDatabase(BsonDocument document, string collectionName)
        {
            IMongoCollection<BsonDocument> collection = this.mongoDatabase.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(document);
        }
    }
}
