using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HogeschoolDatavisualisatie.DataModels;

namespace HogeschoolDatavisualisatie.DataRepository
{
    class WeatherDataParserMonth : IDataParser<WeatherModelMonthly, List<float>, float>
    {
        public WeatherModelMonthly ConvertDataToModel(List<float> data)
        {
            throw new NotImplementedException();
        }

        public List<float> GetDataPoint(float i)
        {
            throw new NotImplementedException();
        }

        public void ParseData()
        {
            throw new NotImplementedException();
        }
    }
}
