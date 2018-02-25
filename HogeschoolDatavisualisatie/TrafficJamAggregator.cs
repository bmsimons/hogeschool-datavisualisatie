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

        public TrafficJamAggregator()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                mongoClient = new MongoClient("mongodb://localhost:27017");
                mongoDatabase = mongoClient.GetDatabase("DataAggregation");
                mongoCollection = mongoDatabase.GetCollection<BsonDocument>("anwb");

                var docs = Enumerable.Range(0, 10).Select(i => new BsonDocument("x", i));
                mongoCollection.InsertManyAsync(docs);
            });
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

                                mongoCollection.InsertOne(new BsonDocument { { "datetime", DateTime }, { "type", "jam" }, { "jamfrom", jamFrom }, { "jamto", jamTo }, { "jamlocation", jamLocation }, { "segmentstart", segmentStart }, { "segmentend", segmentEnd }, { "jamreason", jamReason }, { "jamdescription", jamDescription } });
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

                                mongoCollection.InsertOne(new BsonDocument { { "datetime", DateTime }, { "type", "roadwork" }, { "roadworkfrom", roadWorkFrom }, { "roadworkto", roadWorkTo }, { "roadworklocation", roadWorkLocation }, { "segmentstart", segmentStart }, { "segmentend", segmentEnd }, { "roadworkreason", roadWorkReason }, { "roadworkdescription", roadWorkDescription } });
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
    }
}
