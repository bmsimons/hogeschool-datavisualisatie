using Newtonsoft.Json;

namespace HogeschoolDatavisualisatie.DataModels
{
    /// <summary>
    /// Data model representing data from CBS statline
    /// </summary>
    class PopulationChangeModel : DataModel
    {
        [JsonProperty("Levendgeborenen_2")]
        public string bornAlive = null;

        [JsonProperty("Overledenen_3")]
        public string totalDeaths = null;

        [JsonProperty("Perioden")]
        public string monthYear;

        [JsonProperty("ID")]
        public string id;

        [JsonProperty("RegioS")]
        public string regios;

    }
}
