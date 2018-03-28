using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HogeschoolDatavisualisatie.DataRepository;
using HogeschoolDatavisualisatie.DataModels;
using HogeschoolDatavisualisatie.Services;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace HogeschoolDatavisualisatie.Core
{
    /// <summary>
    /// Class that functions as wrapper bewteen data models, their parsers and the database connection
    /// </summary>
    public static class Aggregator
    {
        /// <summary>
        /// Data Aggregation Sequence of WeatherModel
        /// </summary>
        public static void AggregateWeatherModel(string filePath)
        {
            WeatherDataParser weatherDataParser = new WeatherDataParser(filePath);
            List<WeatherModel> weatherModels = new List<WeatherModel>();
            foreach (List<int?> dataPoint in weatherDataParser.DataPoints)
            {
                WeatherModel model = weatherDataParser.ConvertDataToModel(dataPoint);
                if (model != null) weatherModels.Add(model);
            }

            AddToDatabase<WeatherModel>(weatherModels, "weather-day");
        }

        /// <summary>
        /// Data Aggregation Sequence of Monthly WeatherModel
        /// </summary>
        public static void AggregateWeatherModelMonthly(string filePath)
        {
            WeatherDataParserMonth weatherDataParserMonth = new WeatherDataParserMonth(filePath);
            List<WeatherModelMonthly> weatherModelMonthlies = new List<WeatherModelMonthly>();
            foreach (Tuple<float, DateTime> dataPoint in weatherDataParserMonth.DataPoints)
            {
                WeatherModelMonthly model = weatherDataParserMonth.ConvertDataToModel(dataPoint);
                weatherModelMonthlies.Add(model);
            }

            AddToDatabase<WeatherModelMonthly>(weatherModelMonthlies, "weather-month");
        }

        public static void AddToDatabase<T>(List<T> modelList, string collection)
        {
            foreach (T model in modelList)
            {
                MongoConnector.Instance.InsertIntoDatabse(ConvertModelToBsonDocument<T>(model), collection);
            }
        }

        public static BsonDocument ConvertModelToBsonDocument<T>(T model)
        {
            string json = JsonConvert.SerializeObject(model);
            return BsonDocument.Parse(json);
        }
    }
}
