using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System.IO;

using MongoDB.Bson.IO;

namespace HogeschoolDatavisualisatie.Services
{
    /// <summary>
    /// Class that exports a Bson Collection from Mongo to a local json file
    /// </summary>
    public class JsonExporter
    {
        public static JsonWriterSettings jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

        public static void ExportMongoCollection(string collectionName, string filePath)
        {
            IMongoCollection<BsonDocument> collection = MongoConnector.Instance.MongoDatabase.GetCollection<BsonDocument>(collectionName);
            JArray jsonContainer = new JArray();

            foreach (BsonDocument item in collection.AsQueryable())
            {
                JObject jsonObject = JObject.Parse(item.ToJson(JsonExporter.jsonWriterSettings));
                jsonObject.Property("_id").Remove();
                jsonContainer.Add(jsonObject);
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, jsonContainer.ToString());
            }
        }
    }
}
