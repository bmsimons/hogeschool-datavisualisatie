using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HogeschoolDatavisualisatie.DataModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HogeschoolDatavisualisatie.Core;
using MongoDB.Bson;
using HogeschoolDatavisualisatie.Services;

namespace HogeschoolDatavisualisatie.DataRepository
{
    class PopulationChangeParser : IDataParser<PopulationChangeModel, Tuple<int, int, MonthYear>, object>
    {
        private string sourceFilePath = null;

        public PopulationChangeParser(string sourceFilePath)
        {
            this.sourceFilePath = sourceFilePath;
        }

        public PopulationChangeModel ConvertDataToModel(Tuple<int, int, MonthYear> data)
        {
            throw new NotImplementedException();
        }

        public Tuple<int, int, MonthYear> GetDataPoint(object i)
        {
            throw new NotImplementedException();
        }

        public void ParseData()
        {
            string json = File.ReadAllText(sourceFilePath);
            JToken outer = JToken.Parse(json);
            List<BsonDocument> allItems = new List<BsonDocument>();
            var test = outer.Children();
            foreach(var item in test)
            {
                PopulationChangeModel model = item.First.ToObject<PopulationChangeModel>();
                string json_inner = JsonConvert.SerializeObject(model);
                BsonDocument document = BsonDocument.Parse(json_inner);
                MongoConnector.Instance.InsertIntoDatabase(document, "population-change");
            }
            
        }
    }
}
