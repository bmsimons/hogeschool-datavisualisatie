using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HogeschoolDatavisualisatie.DataModels
{
    [DataContract]
    class WeatherModel
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
