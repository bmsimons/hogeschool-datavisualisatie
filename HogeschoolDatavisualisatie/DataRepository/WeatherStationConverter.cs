using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace HogeschoolDatavisualisatie.DataRepository
{
    public sealed class WeatherStationConverter
    {
        private static WeatherStationConverter instance = null;
        private static readonly object padlock = new object();
        private Dictionary<int, string> weatherStations = null;
        private const string FileName = "stations.txt";

        public WeatherStationConverter()
        {
            try
            {
                weatherStations = GetWeatherStationDictionary();
            }
            catch (Exception e)
            {
                //TODO handle exception
            }
        }

        public static WeatherStationConverter Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new WeatherStationConverter();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Create a weatherstation code and name mapping 
        /// </summary>
        /// <returns>Dictionary mapping of weatherstation and its name</returns>
        private Dictionary<int, string> GetWeatherStationDictionary()
        {
            Dictionary<int, string> weatherStations = new Dictionary<int, string>();

            //TODO - Make use of an alternative way
            using (StreamReader streamReader = new StreamReader(@"C:\Users\Maikel\Source\Repos\hogeschool-datavisualisatie\HogeschoolDatavisualisatie\Data\stations.txt"))
            {
                string nextLine = "";
                while ((nextLine = streamReader.ReadLine()) != null)
                {
                    string[] values = nextLine.Split(',');
                    Console.WriteLine(values);
                    weatherStations.Add(Int32.Parse(values[0]), values[1]);
                }
            }
            return weatherStations;
        }

        [Obsolete]
        private string GetFilePath()
        {
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string[] files = Directory.GetFiles(folder);
            return files[0];
        }

        public string GetWeatherStationName(int weatherStationCode)
        {
            if (this.weatherStations.ContainsKey(weatherStationCode))
            {
                return this.weatherStations[weatherStationCode];
            }
            else return "";
        }
    }
}
