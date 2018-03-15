using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using HogeschoolDatavisualisatie.DataModels;
using HogeschoolDatavisualisatie.Helpers;

namespace HogeschoolDatavisualisatie.DataRepository
{
    /// <summary>
    /// Object encapsulating operations to convert KNMI data text file to Weather Models
    /// </summary>
    class WeatherDataParser : IDataParser<WeatherModel, List<int?>>
    {
        private string sourceFilePath = null;
        private List<string> textLines = null;
        private List<int?>[] dataPoints = null;
        public List<int?>[] DataPoints { get { return dataPoints; } }

        public WeatherDataParser(string sourceFilePath)
        {
            this.sourceFilePath = sourceFilePath;
            ParseData();
        }

        public void ParseData()
        {
            textLines = ReadLinesOfDataFile();
            dataPoints = ConvertStringList(textLines);
        }

        public List<int?> GetDataPoint(int index)
        {
            return dataPoints[index];
        }

        public WeatherModel ConvertDataToModel(List<int?> dataPoint)
        {
            throw new NotImplementedException();
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