using System;
using System.Collections.Generic;
using HogeschoolDatavisualisatie.DataModels;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace HogeschoolDatavisualisatie.DataRepository
{
    public class WeatherDataParserMonth : IDataParser<WeatherModelMonthly, Tuple<float,DateTime>, int>
    {
        private const string RegexPattern = @"([0-9]{3})\s([0-9]{8})\s*(.*)";

        private string sourceFilePath = null;
        private List<Tuple<float,DateTime>> dataPoints = new List<Tuple<float,DateTime>>();
        public List<Tuple<float, DateTime>> DataPoints { get => dataPoints; set => dataPoints = value; }

        public WeatherDataParserMonth(string sourceFilePath)
        {
            this.sourceFilePath = sourceFilePath;
            ParseData();
        }

        public WeatherModelMonthly ConvertDataToModel(Tuple<float,DateTime> data)
        {
            return new WeatherModelMonthly(data.Item1, data.Item2);
        }

        public Tuple<float, DateTime> GetDataPoint(int i)
        {
            return dataPoints[i];
        }

        public void ParseData()
        {
            string fileContent = File.ReadAllText(sourceFilePath);
            MatchCollection matches = Regex.Matches(fileContent,RegexPattern);
            foreach (Match match in matches)
            {
                float averageTemperature = ParseMatchToFloat(match.Groups[3].Value);
                DateTime dateTime = DateTime.ParseExact(match.Groups[2].Value.ToString(), 
                    "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);

                Tuple<float, DateTime> dataPoint = new Tuple<float, DateTime>(averageTemperature, dateTime);
                dataPoints.Add(dataPoint);
            }
        }

        private float ParseMatchToFloat(string match)
        {
            if(match[0] == '.')
            {
                match.Insert(0, "0");
            }
            else if(match[0] == '-' && match[1] == '.')
            {
                match.Insert(1, "0");
            }

            return float.Parse(match, CultureInfo.InvariantCulture);
        }
    }
}
