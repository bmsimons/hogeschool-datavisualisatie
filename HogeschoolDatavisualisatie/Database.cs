using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Net.Sockets;

namespace HogeschoolDatavisualisatie
{
    class Database
    {
        private MongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;
        private String address;
        private String port;

        public Database(string address = "127.0.0.1", string port = "27017", string database = "DataAggregation")
        {
            this.address = address;
            this.port = port;
            this.client = new MongoClient("mongodb://"+address+":"+port);
            this.database = this.client.GetDatabase(database);
        }

        private void SetCollection(string collection)
        {
            this.collection = this.database.GetCollection<BsonDocument>(collection);
        }

        private void WriteToDatabase(IEnumerable<BsonDocument> docs)
        {
            this.collection.InsertMany(docs);
        }
    }
}
