using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using HogeschoolDatavisualisatie.DataModels;
using HogeschoolDatavisualisatie.Helpers;
using System.Globalization;

namespace HogeschoolDatavisualisatie.DataRepository
{
    /// <summary>
    /// Object encapsulating operations to convert KNMI data text file to Weather Models
    /// </summary>
    class WeatherDataParser : IDataParser<WeatherModel, List<int?>, int>
    {
        private string sourceFilePath = null;
        private List<string> textLines = null;
        private List<int?>[] dataPoints = null;
        public List<int?>[] DataPoints { get => dataPoints; set => dataPoints = value; }

        public WeatherDataParser(string sourceFilePath)
        {
            this.sourceFilePath = sourceFilePath;
            ParseData();
        }

        public void ParseData()
        {
            textLines = ReadLinesOfDataFile();
            DataPoints = ConvertStringList(textLines);
        }

        public List<int?> GetDataPoint(int index)
        {
            return DataPoints[index];
        }

        /// <summary>
        /// Creates a WeatherModel instance based on intermediary data structure
        /// </summary>
        /// <param name="dataPoint"></param>
        /// <returns></returns>
        public WeatherModel ConvertDataToModel(List<int?> dataPoint)
        {
            if (dataPoint[11] != null && dataPoint[12] != null && dataPoint[14] != null && dataPoint[1] != null)
            {
                return new WeatherModel(ConvertDataPointToFloat(dataPoint[11]),
                    ConvertDataPointToFloat(dataPoint[12]),
                    ConvertDataPointToFloat(dataPoint[14]),
                    WeatherStationConverter.Instance.GetWeatherStationName(dataPoint[0].Value),
                    DateTime.ParseExact(dataPoint[1].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture,
                          DateTimeStyles.None));
            }
            else return null;
        }

        private float ConvertDataPointToFloat(int? nullableDataPointInt)
        {
            int value = nullableDataPointInt.Value;
            return (float)value / 10;
        }

        /// <summary>
        /// Read through every line of file.
        /// Ignores lines commented with '#'
        /// </summary>
        /// <returns>List of strings</returns>
        private List<string> ReadLinesOfDataFile()
        {
            List<string> textLines = new List<string>();
            using (StreamReader streamReader = new StreamReader(this.sourceFilePath))
            {
                string nextLine = "";
                while ((nextLine = streamReader.ReadLine()) != null)
                {
                    // In this particular data text file comments start with '#'
                    if (nextLine[0] != '#')
                    {
                        textLines.Add(nextLine);
                    }
                }
            }
            return textLines;
        }

        private List<int?>[] ConvertStringList(List<string> lines)
        {
            List<int?>[] dataPoints = new List<int?>[textLines.Count];
            for(int i = 0; i < textLines.Count; i++)
            {
                List<int?> weatherDataIntegerValues = ParseTextLine(lines[i]);
                dataPoints[i] = weatherDataIntegerValues;
            }
            return dataPoints;
        }

        private List<int?> ParseTextLine(string line)
        {
            List<int?> data = line.Split(',').Select(s => s.TryGetInt32()).ToList();
            return data;
        }
    }
}