using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Net.Sockets;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using MongoDB.Bson.IO;

class Database
{
    private JsonWriterSettings jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<BsonDocument> collection;
    private String address;
    private String port;

    public Database(string address = "127.0.0.1", string port = "27017", string database = "DataAggregation")
    {
        this.address = address;
        this.port = port;
        this.client = new MongoClient("mongodb://" + address + ":" + port);
        this.database = this.client.GetDatabase(database);
    }

    public void SetCollection(string collection)
    {
        this.collection = this.database.GetCollection<BsonDocument>(collection);
    }

    public void WriteManyToDatabase(IEnumerable<BsonDocument> docs)
    {
        this.collection.InsertMany(docs);
    }

    public void WriteOneToDatabase(BsonDocument doc)
    {
        this.collection.InsertOne(doc);
    }

    public void ExportCollection(string collection, string filePath)
    {
        this.SetCollection(collection);

        JArray jsonContainer = new JArray();

        foreach (BsonDocument item in this.collection.AsQueryable())
        {
            JObject jsonObject = JObject.Parse(item.ToJson(this.jsonWriterSettings));
            jsonObject.Property("_id").Remove();

            jsonContainer.Add(jsonObject);
        }

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, jsonContainer.ToString());
        }
        else
        {
            MessageBox.Show("File already exists");
        }
    }

    public void ImportCollection(string collection, string filePath)
    {
        this.SetCollection(collection);

        String fileContents;

        using (StreamReader sr = new StreamReader(filePath))
        {
            fileContents = sr.ReadToEnd();
        }

        JArray jsonContainer = JArray.Parse(fileContents);

        foreach (JObject jsonObject in jsonContainer)
        {
            this.WriteOneToDatabase(BsonDocument.Parse(jsonObject.ToString()));
        }
    }
}

