using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HogeschoolDatavisualisatie.DataModels
{
    [DataContract]
    public class WeatherModel : DataModel
    {
        [DataMember]
        public float averageTemperature;

        [DataMember]
        public float lowestTemperature;

        [DataMember]
        public float highestTemperature;

        private int stationNumber;

        [DataMember]
        public string stationName;

        public WeatherModel(float averageTemperature, float lowestTemperature, float highestTemperature, int stationNumber)
        {
            this.averageTemperature = averageTemperature;
            this.lowestTemperature = lowestTemperature;
            this.highestTemperature = highestTemperature;
            this.stationNumber = stationNumber;
        }
    }
}
