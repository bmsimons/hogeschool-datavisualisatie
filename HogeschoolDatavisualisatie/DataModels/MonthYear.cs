using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace HogeschoolDatavisualisatie.DataModels
{
    public class MonthYear
    {
        private int year = 0;
        private int month = 1;

        public int Year { get => year; set => year = value; }
        public int Month { get => month; set => month = value; }

        public MonthYear(int year, int month)
        {
            this.year = year;
            this.month = month;
        }

        public string GetMonthAsString()
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.month);
        }
        
    }
}
