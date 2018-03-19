using System;
using Newtonsoft.Json;

namespace HogeschoolDatavisualisatie.DataModels
{
    /// <summary>
    /// KNMI monthly WeatherData class representation
    /// </summary>
    public class WeatherModelMonthly
    {
        [JsonProperty("averageTemperature")]
        public float averageTemperature;

        [JsonProperty("date")]
        public DateTime date;
        //Int32 Year, Int32 Month, Int32 Day
    }
}
