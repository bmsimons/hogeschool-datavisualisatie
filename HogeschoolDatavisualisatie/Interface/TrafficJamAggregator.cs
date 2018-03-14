using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Net.Sockets;
using System.Net;

namespace HogeschoolDatavisualisatie
{
    public partial class TrafficJamAggregator : Form
    {
        static MongoClient mongoClient;
        static IMongoDatabase mongoDatabase;
        static IMongoCollection<BsonDocument> mongoCollection;
        static Database database;

        public TrafficJamAggregator()
        {
            InitializeComponent();

            database = new Database();
        }

        private void TrafficJamAggregator_Load(object sender, EventArgs e)
        {
            
        }

        private void anwbAggregateButton_Click(object sender, EventArgs e)
        {
            if (anwbAggregateButton.Text == "Start data aggregation")
            {
                anwbAggregateButton.Text = "Stop data aggregation";
                anwbAggregateButton.Enabled = false;

                Task AggregateTask = Task.Run(() =>
                {
                    database.SetCollection("anwb");

                    using (WebClient webClient = new WebClient())
                    {
                        string anwbJsonString = webClient.DownloadString("https://www.anwb.nl/feeds/gethf");

                        AnwbObject anwbObject = AnwbObject.FromJson(anwbJsonString);

                        string DateTime = anwbObject.DateTime;

                        foreach (RoadEntry iterationObject in anwbObject.RoadEntries)
                        {
                            string road = iterationObject.Road;
                            string roadType = iterationObject.RoadType;

                            foreach (TrafficJam trafficJam in iterationObject.Events.TrafficJams)
                            {
                                string jamFrom = trafficJam.From;
                                string jamTo = trafficJam.To;

                                string jamLocation = trafficJam.Location;

                                string segmentStart = trafficJam.SegStart;
                                string segmentEnd = trafficJam.SegEnd;

                                string jamReason = trafficJam.Reason;
                                string jamDescription = trafficJam.Description;

                                database.WriteOneToDatabase(new BsonDocument { { "datetime", DateTime }, { "type", "jam" }, { "jamfrom", jamFrom }, { "jamto", jamTo }, { "jamlocation", jamLocation }, { "segmentstart", segmentStart }, { "segmentend", segmentEnd }, { "jamreason", jamReason }, { "jamdescription", jamDescription } });
                            }

                            foreach (RoadWork roadWork in iterationObject.Events.RoadWorks)
                            {
                                string roadWorkFrom = roadWork.From;
                                string roadWorkTo = roadWork.To;

                                string roadWorkLocation = roadWork.Location;

                                string segmentStart = roadWork.SegStart;
                                string segmentEnd = roadWork.SegEnd;

                                string roadWorkReason = roadWork.Reason;
                                string roadWorkDescription = roadWork.Description;

                                database.WriteOneToDatabase(new BsonDocument { { "datetime", DateTime }, { "type", "roadwork" }, { "roadworkfrom", roadWorkFrom }, { "roadworkto", roadWorkTo }, { "roadworklocation", roadWorkLocation }, { "segmentstart", segmentStart }, { "segmentend", segmentEnd }, { "roadworkreason", roadWorkReason }, { "roadworkdescription", roadWorkDescription } });
                            }
                        }
                    }
                });

                AggregateTask.Wait();

                anwbAggregateButton.Text = "Start data aggregation";
                anwbAggregateButton.Enabled = true;
            }
            else
            {
                anwbAggregateButton.Text = "Start data aggregation";
            }
        }

        private void anwbExportDataButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON (*.json)|*.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database.ExportCollection("anwb", saveFileDialog.FileName);
            }
        }

        private void anwbRestoreDataButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON (*.json)|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database.ImportCollection("anwb", openFileDialog.FileName);
            }
        }
    }
}
