using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HogeschoolDatavisualisatie.DataModels;

namespace HogeschoolDatavisualisatie.DataRepository
{
    class PopulationChangeParser : IDataParser<PopulationChangeModel, Tuple<int, int, MonthYear>, object>
    {
        public PopulationChangeModel ConvertDataToModel(Tuple<int, int, MonthYear> data)
        {
            throw new NotImplementedException();
        }

        public Tuple<int, int, MonthYear> GetDataPoint(object i)
        {
            throw new NotImplementedException();
        }

        public void ParseData()
        {
            throw new NotImplementedException();
        }
    }
}
