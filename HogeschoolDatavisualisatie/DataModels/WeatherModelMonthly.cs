using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HogeschoolDatavisualisatie.DataModels
{
    [DataContract]
    public class WeatherModelMonthly
    {
        [DataMember]
        public float averageTemperature;

        [DataMember]
        public DateTime date;
        //Int32 Year, Int32 Month, Int32 Day
    }
}
