using System;
using MongoDB.Bson.Serialization.Attributes;
namespace HogeschoolDatavisualisatie.DataModels
{
    /// <summary>
    /// Data model representing data from CBS statline
    /// </summary>
    class PopulationChangeModel
    {
        [BsonElement("bornAlive")]
        public int bornAlive = 0;

        [BsonElement("totalDeaths")]
        public int totalDeaths = 0;

        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime dateTime;

        [BsonConstructor]
        public PopulationChangeModel(int bornAlive, int totalDeaths, DateTime dateTime)
        {
            this.bornAlive = bornAlive;
            this.totalDeaths = totalDeaths;
            this.dateTime = dateTime;
        }
    }
}
