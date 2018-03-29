using System;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;

namespace HogeschoolDatavisualisatie.DataModels
{
    /// <summary>
    /// KNMI monthly WeatherData class representation
    /// </summary>
    public class WeatherModelMonthly
    {
        [BsonElement("averageTemperature")]
        public float averageTemperature;

        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime dateTime;

        [BsonConstructor]
        public WeatherModelMonthly(float averageTemperature, DateTime dateTime)
        {
            this.averageTemperature = averageTemperature;
            this.dateTime = dateTime;
        }
    }
}
