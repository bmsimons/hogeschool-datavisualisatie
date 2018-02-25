using System;
using System.Collections.Generic;
using System.Net;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HogeschoolDatavisualisatie
{
    public partial class AnwbObject
    {
        [JsonProperty("dateTime")]
        public string DateTime { get; set; }

        [JsonProperty("roadEntries")]
        public RoadEntry[] RoadEntries { get; set; }
    }

    public partial class RoadEntry
    {
        [JsonProperty("road")]
        public string Road { get; set; }

        [JsonProperty("roadType")]
        public string RoadType { get; set; }

        [JsonProperty("events")]
        public Events Events { get; set; }
    }

    public partial class Events
    {
        [JsonProperty("trafficJams")]
        public TrafficJam[] TrafficJams { get; set; }

        [JsonProperty("roadWorks")]
        public RoadWork[] RoadWorks { get; set; }

        [JsonProperty("radars")]
        public object[] Radars { get; set; }
    }

    public partial class RoadWork
    {
        [JsonProperty("msgNr")]
        public string MsgNr { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("fromLoc")]
        public Loc FromLoc { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("toLoc")]
        public Loc ToLoc { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("segStart")]
        public string SegStart { get; set; }

        [JsonProperty("segEnd")]
        public string SegEnd { get; set; }

        [JsonProperty("start")]
        public System.DateTimeOffset Start { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("stop")]
        public System.DateTimeOffset Stop { get; set; }

        [JsonProperty("stopDate")]
        public string StopDate { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("events")]
        public Event[] Events { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("alertC")]
        public string AlertC { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class Loc
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public partial class TrafficJam
    {
        [JsonProperty("msgNr")]
        public string MsgNr { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("fromLoc")]
        public Loc FromLoc { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("toLoc")]
        public Loc ToLoc { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("segStart")]
        public string SegStart { get; set; }

        [JsonProperty("segEnd")]
        public string SegEnd { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("events")]
        public Event[] Events { get; set; }
    }

    public partial class AnwbObject
    {
        public static AnwbObject FromJson(string json) => JsonConvert.DeserializeObject<AnwbObject>(json, HogeschoolDatavisualisatie.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this AnwbObject self) => JsonConvert.SerializeObject(self, HogeschoolDatavisualisatie.Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter()
                {
                    DateTimeStyles = DateTimeStyles.AssumeUniversal,
                },
            },
        };
    }
}
