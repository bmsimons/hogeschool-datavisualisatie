using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System.IO;

using MongoDB.Bson.IO;

namespace HogeschoolDatavisualisatie.Services
{
    /// <summary>
    /// Write to database based on an imported json file
    /// </summary>
    public class JsonImporter
    {
        public static JsonWriterSettings jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

        public static void ImportMongoCollection(string collectionName, string filePath)
        {
            IMongoCollection<BsonDocument> collection = MongoConnector.Instance.MongoDatabase.GetCollection<BsonDocument>(collectionName);
            string fileContents;

            using (StreamReader sr = new StreamReader(filePath))
            {
                fileContents = sr.ReadToEnd();
            }

            JArray jsonContainer = JArray.Parse(fileContents);

            foreach (JObject jsonObject in jsonContainer)
            {
                MongoConnector.Instance.InsertIntoDatabse(BsonDocument.Parse(jsonObject.ToString()), collectionName);
            }
        }
    }
}
