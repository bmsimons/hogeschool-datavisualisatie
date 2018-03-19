using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HogeschoolDatavisualisatie.DataModels
{
    public class WeatherModel : DataModel
    {
        [JsonProperty("averageTemperature")]
        public float averageTemperature;

        [JsonProperty("lowestTemperature")]
        public float lowestTemperature;

        [JsonProperty("highestTemperature")]
        public float highestTemperature;

        [JsonProperty("stationName")]
        public string stationName;

        public WeatherModel(float averageTemperature, float lowestTemperature, float highestTemperature, string stationName)
        {
            this.averageTemperature = averageTemperature;
            this.lowestTemperature = lowestTemperature;
            this.highestTemperature = highestTemperature;
            this.stationName = stationName;
        }
    }
}
