using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using HogeschoolDatavisualisatie.DataModels;
using HogeschoolDatavisualisatie.Helpers;
using System.Globalization;
using CsvHelper;
using System.Text.RegularExpressions;

namespace HogeschoolDatavisualisatie.DataRepository
{
    class PopulationChangeParser 
    {
        private List<Population> inter = new List<Population>();
        private List<PopulationChangeModel> data = new List<PopulationChangeModel>();

        public PopulationChangeParser(string sourceFilePath)
        {
            inter = ParseData(sourceFilePath);
            ParseList(inter);
        }

        internal List<PopulationChangeModel> Data { get => data; set => data = value; }

        private List<Population> ParseData(String absoluteCsvPath)
        {
            List<Population> list = new List<Population>();
            using (TextReader reader = File.OpenText(absoluteCsvPath))
            {
                CsvReader csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ";";
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.HeaderValidated = null;
                while (csv.Read())
                {
                    Population Record = csv.GetRecord<Population>();
                    list.Add(Record);
                }
            }
            return list;
        }

        private void ParseList(List<Population> pop)
        {
            foreach(Population model in pop)
            {
                if(Regex.Matches(model.Perioden, @"[JK]").Count > 0)
                {
                    continue;
                }
                string date = Regex.Replace(model.Perioden, "[^0-9.]", "");
                date += "01";
                DateTime realDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture,
                         DateTimeStyles.None);

                int death = Int32.Parse(model.Overledenen_2);
                int born = Int32.Parse(model.Levendgeborenen_1);

                PopulationChangeModel dataPoint = new PopulationChangeModel(born, death, realDate);
                data.Add(dataPoint);
            }
        }

    }
}
