using System;

namespace HogeschoolDatavisualisatie.DataModels
{
    /// <summary>
    /// Class representation of traffic incident data and traffic jam data from Rijskwaterstaat
    /// </summary>
    public class TrafficModel 
    {
        public String Datum        { get; set; }
        public String Jaar         { get; set; }
        public String Mnd          { get; set; }
        public String Dag          { get; set; }
        public String Ticvanri     { get; set; }
        public String Ticvan       { get; set; }
        public String Richt        { get; set; }
        public String Hm           { get; set; }
        public String Oorz         { get; set; }
        public String Begt         { get; set; }
        public String StUur        { get; set; }
        public String StMin        { get; set; }
        public String Eindt        { get; set; }
        public String EindUur      { get; set; }
        public String EindMin      { get; set; }
        public String Zwaarte      { get; set; }
        public String GemLeng      { get; set; }
        public String Duur         { get; set; }
        public String Dagnr        { get; set; }
        public String Weeknr       { get; set; }
        public String Dagsoort     { get; set; }
        public String G_L          { get; set; }
        public String Provinci     { get; set; }
        public String Routelet     { get; set; }
        public String Routenum     { get; set; }
        public String Routeoms     { get; set; }
        public String Naam_Van     { get; set; }
        public String Naam_Naa     { get; set; }
        public String Hm_Van       { get; set; }
        public String Hm_Naar      { get; set; }
        public String Traj_Van     { get; set; }
        public String Traj_Naa     { get; set; }
        public String Flricht      { get; set; }
        public String FilesAgvWerk { get; set; }
        public String IdWerk       { get; set; }
    }
}
