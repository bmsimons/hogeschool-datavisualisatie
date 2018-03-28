using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using HogeschoolDatavisualisatie.DataModels;
using HogeschoolDatavisualisatie.Helpers;
using System.Globalization;
using CsvHelper;

namespace HogeschoolDatavisualisatie.DataRepository
{
    class TrafficParser
    {
        public List<TrafficModel> ListTraffic = null;

        public void ParseData(String absoluteCsvPath)
        {
            ListTraffic = new List<TrafficModel>();

            using (TextReader reader = File.OpenText(absoluteCsvPath))
            {
                CsvReader csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ";";
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.HeaderValidated = null;
                while (csv.Read())
                {
                    TrafficModel Record = csv.GetRecord<TrafficModel>();
                    ListTraffic.Add(Record);
                }
            }
        }
    }
}
