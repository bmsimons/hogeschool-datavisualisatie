using Newtonsoft.Json;
using System;

namespace HogeschoolDatavisualisatie.DataModels
{
    /// <summary>
    /// Data model representing data from CBS statline
    /// </summary>
    class PopulationChangeModel
    {
        [JsonProperty("Levendgeborenen_2")]
        public string bornAlive = null;

        [JsonProperty("Overledenen_3")]
        public string totalDeaths = null;

        [JsonProperty("Perioden")]
        public DateTime date;
    }
}
