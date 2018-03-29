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
    public class TrafficParser
    {
        private List<TrafficModel> trafficModelList = new List<TrafficModel>();
        private List<TrafficDataModel> realTrafficModel = new List<TrafficDataModel>();

        public TrafficParser(string csvPath)
        {
            trafficModelList = ParseCSV(csvPath);
            ParseList(trafficModelList);
        }

        public List<TrafficDataModel> RealTrafficModel { get => realTrafficModel; set => realTrafficModel = value; }

        public List<TrafficModel> ParseCSV(String absoluteCsvPath)
        {
            List<TrafficModel> list = new List<TrafficModel>();
            using (TextReader reader = File.OpenText(absoluteCsvPath))
            {
                CsvReader csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ";";
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.HeaderValidated = null;
                while (csv.Read())
                {
                    TrafficModel Record = csv.GetRecord<TrafficModel>();
                    list.Add(Record);
                }
            }
            return list;
        }

        private void ParseList(List<TrafficModel> list)
        {
            string date = list[0].Datum;
            float totalLength = 0;
            float totalZwaarte = 0;
            float totalDuration = 0;
            float count = 1;

            foreach (TrafficModel model in list)
            {
                if(model.Datum == null || model.G_L == null || model.Zwaarte == null || model.Duur == null )
                {
                    continue;
                }
                if (model.Datum == "" || model.G_L == "" || model.Zwaarte == "" || model.Duur == "")
                {
                    continue;
                }
                if (!(model.Datum.Length > 4) || model.Datum == "") { continue; }

                string dateString = model.Datum;
                if (dateString == date)
                {
                    totalLength += (float.Parse(model.G_L));
                    totalZwaarte += (float.Parse(model.Zwaarte));
                    totalDuration += (float.Parse(model.Duur));
                    count++;
                }
                else
                {
                    DateTime realDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture,
                          DateTimeStyles.None);
                    float averageLength = totalLength / count;
                    float averageZwaarte = totalZwaarte / count;
                    float averagteDuration = totalDuration / count;
                    TrafficDataModel dataPoint = new TrafficDataModel(
                        averageLength, totalLength, averageZwaarte, averagteDuration, realDate);

                    totalLength = 0;
                    totalZwaarte = 0;
                    totalDuration = 0;
                    count = 1;
                    date = dateString;

                    realTrafficModel.Add(dataPoint);
                }
            }
        }
    }
}
