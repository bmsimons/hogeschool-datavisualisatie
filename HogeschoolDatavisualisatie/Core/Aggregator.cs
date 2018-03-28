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

        public static void AggregateTrafficModel(string filePath)
        {
            TrafficParser trafficParser = new TrafficParser();
            trafficParser.ParseData(filePath);

            foreach (TrafficModel trafficResultItem in trafficParser.ListTraffic)
            {
                MongoConnector.Instance.InsertIntoDatabse(new BsonDocument {
                                    {"datum",        trafficResultItem.Datum ?? ""},
                                    {"jaar",         trafficResultItem.Jaar ?? ""},
                                    {"mnd",          trafficResultItem.Mnd ?? ""},
                                    {"dag",          trafficResultItem.Dag ?? ""},
                                    {"ticvanri",     trafficResultItem.Ticvanri ?? ""},
                                    {"ticvan",       trafficResultItem.Ticvan ?? ""},
                                    {"richt",        trafficResultItem.Richt ?? ""},
                                    {"hm",           trafficResultItem.Hm ?? ""},
                                    {"oorz",         trafficResultItem.Oorz ?? ""},
                                    {"begt",         trafficResultItem.Begt ?? ""},
                                    {"stuur",        trafficResultItem.StUur ?? ""},
                                    {"stmin",        trafficResultItem.StMin ?? ""},
                                    {"eindt",        trafficResultItem.Eindt ?? ""},
                                    {"einduur",      trafficResultItem.EindUur ?? ""},
                                    {"eindmin",      trafficResultItem.EindMin ?? ""},
                                    {"zwaarte",      trafficResultItem.Zwaarte ?? ""},
                                    {"gemleng",      trafficResultItem.GemLeng ?? ""},
                                    {"duur",         trafficResultItem.Duur ?? ""},
                                    {"dagnr",        trafficResultItem.Dagnr ?? ""},
                                    {"weeknr",       trafficResultItem.Weeknr ?? ""},
                                    {"dagsoort",     trafficResultItem.Dagsoort ?? ""},
                                    {"g_l",          trafficResultItem.G_L ?? ""},
                                    {"provincie",    trafficResultItem.Provinci ?? ""},
                                    {"routelet",     trafficResultItem.Routelet ?? ""},
                                    {"routenum",     trafficResultItem.Routenum ?? ""},
                                    {"routeoms",     trafficResultItem.Routeoms ?? ""},
                                    {"naam_van",     trafficResultItem.Naam_Van ?? ""},
                                    {"naam_naa",     trafficResultItem.Naam_Naa ?? ""},
                                    {"hm_van",       trafficResultItem.Hm_Van ?? ""},
                                    {"hm_naar",      trafficResultItem.Hm_Naar ?? ""},
                                    {"traj_van",     trafficResultItem.Traj_Van ?? ""},
                                    {"traj_naa",     trafficResultItem.Traj_Naa ?? ""},
                                    {"flricht",      trafficResultItem.Flricht ?? ""},
                                    {"filesagvwerk", trafficResultItem.FilesAgvWerk ?? ""},
                                    {"idwerk",       trafficResultItem.IdWerk ?? ""}
                                }, "rijkswaterstaat");

            }
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
