using Newtonsoft.Json;

namespace HogeschoolDatavisualisatie.DataModels
{
    class PopulationChangeModel : DataModel
    {
        [JsonProperty("bornAlive")]
        public int bornAlive = 0;

        [JsonProperty("totalDeaths")]
        public int totalDeaths = 0;

        [JsonProperty("monthYear")]
        public MonthYear monthYear;

        public PopulationChangeModel(int bornAlive, int totalDeaths, MonthYear monthYear)
        {
            this.bornAlive = bornAlive;
            this.totalDeaths = totalDeaths;
            this.monthYear = monthYear;
        }
    }
}
