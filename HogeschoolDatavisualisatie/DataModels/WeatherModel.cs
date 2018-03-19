﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HogeschoolDatavisualisatie.DataModels
{
    /// <summary>
    /// KNMI daily weather data class representation
    /// </summary>
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

        [JsonProperty("dateTime")]
        public DateTime dateTime;

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
