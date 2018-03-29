using System;
using MongoDB.Bson.Serialization.Attributes;


namespace HogeschoolDatavisualisatie.DataModels
{
    /// <summary>
    /// Daily average traffic data
    /// </summary>
    public class TrafficDataModel
    {
        [BsonElement("averageLength")]
        public float averageLength;

        [BsonElement("totalLength")]
        public float totalLength;

        [BsonElement("averageZwaarte")]
        public float averageZwaarte;

        [BsonElement("averageDuration")]
        public float averageDuration;

        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime dateTime;

        [BsonConstructor]
        public TrafficDataModel(float averageLength, float totalLength, float averageZwaarte, float averageDuration, DateTime dateTime)
        {
            this.averageLength = averageLength;
            this.totalLength = totalLength;
            this.averageZwaarte = averageZwaarte;
            this.averageDuration = averageDuration;
            this.dateTime = dateTime;
        }
    }
}
