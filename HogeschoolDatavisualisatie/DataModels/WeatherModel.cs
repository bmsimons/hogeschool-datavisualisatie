using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;

namespace HogeschoolDatavisualisatie.DataModels
{
    /// <summary>
    /// KNMI daily weather data class representation
    /// </summary>
    public class WeatherModel
    {
        [BsonElement("averageTemperature")]
        public float averageTemperature { get; set; }

        [BsonElement("lowestTemperature")]
        public float lowestTemperature { get; set; }

        [BsonElement("highestTemperature")]
        public float highestTemperature { get; set; }

        [BsonElement("stationName")]
        public string stationName { get; set; }

        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime dateTime;

        [BsonConstructor]
        public WeatherModel(float averageTemperature, float lowestTemperature, float highestTemperature, string stationName, DateTime dateTime)
        {
            this.averageTemperature = averageTemperature;
            this.lowestTemperature = lowestTemperature;
            this.highestTemperature = highestTemperature;
            this.stationName = stationName;
            this.dateTime = dateTime;
        }
    }
}
