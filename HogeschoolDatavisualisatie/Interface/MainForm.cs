using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Windows.Forms;
using HogeschoolDatavisualisatie.DataRepository;
using HogeschoolDatavisualisatie.DataModels;
using HogeschoolDatavisualisatie.Core;

namespace HogeschoolDatavisualisatie
{
    public partial class MainForm : Form
    {
        static MongoClient mongoClient;
        static IMongoDatabase mongoDatabase;
        static IMongoCollection<BsonDocument> mongoCollection;
        static Database database;

        TrafficParser trafficParser = new TrafficParser();

        public MainForm()
        {
            InitializeComponent();

            //database = new Database();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void trafficJamAggregatorButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<TrafficJamAggregator>().Count() == 0)
            {
                TrafficJamAggregator trafficJamAggregator = new TrafficJamAggregator();
                trafficJamAggregator.Show();
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON (*.json)|*.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database.ExportCollection("anwb", saveFileDialog.FileName);
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON (*.json)|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database.ImportCollection("anwb", openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Handle button click and start aggregation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AggregationButton_Click(object sender, EventArgs e)
        {
            if (selectDatasetBox.SelectedIndex != -1)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                switch (selectDatasetBox.Items[selectDatasetBox.SelectedIndex].ToString())
                {
                    case "Traffic":
                        {
                            openFileDialog.Filter = "CSV (*.csv)|*.csv";

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                trafficParser.ParseData(openFileDialog.FileName);

                                database.SetCollection("rijkswaterstaat");

                                foreach (TrafficModel trafficResultItem in trafficParser.ListTraffic)
                                {
                                    database.WriteOneToDatabase(new BsonDocument
                                {
                                    {"datum",        trafficResultItem.Datum ?? ""},
                                    {"jaar",         trafficResultItem.Jaar ?? ""},
                                    {"mnd",          trafficResultItem.Mnd ?? ""},
                                    {"dag",          trafficResultItem.Dag ?? ""},
                                    {"ticvanri",     trafficResultItem.Ticvanri ?? ""},
                                    {"ticvan",       trafficResultItem.Ticvan ?? ""},
                                    {"richt",        trafficResultItem.Richt ?? ""},
                                    {"hm",           trafficResultItem.Hm ?? ""},
                                    {"oorz",         trafficResultItem.Oorz ?? ""},
                                    {"begt",         trafficResultItem.Begt ?? ""},
                                    {"stuur",        trafficResultItem.StUur ?? ""},
                                    {"stmin",        trafficResultItem.StMin ?? ""},
                                    {"eindt",        trafficResultItem.Eindt ?? ""},
                                    {"einduur",      trafficResultItem.EindUur ?? ""},
                                    {"eindmin",      trafficResultItem.EindMin ?? ""},
                                    {"zwaarte",      trafficResultItem.Zwaarte ?? ""},
                                    {"gemleng",      trafficResultItem.GemLeng ?? ""},
                                    {"duur",         trafficResultItem.Duur ?? ""},
                                    {"dagnr",        trafficResultItem.Dagnr ?? ""},
                                    {"weeknr",       trafficResultItem.Weeknr ?? ""},
                                    {"dagsoort",     trafficResultItem.Dagsoort ?? ""},
                                    {"g_l",          trafficResultItem.G_L ?? ""},
                                    {"provincie",    trafficResultItem.Provinci ?? ""},
                                    {"routelet",     trafficResultItem.Routelet ?? ""},
                                    {"routenum",     trafficResultItem.Routenum ?? ""},
                                    {"routeoms",     trafficResultItem.Routeoms ?? ""},
                                    {"naam_van",     trafficResultItem.Naam_Van ?? ""},
                                    {"naam_naa",     trafficResultItem.Naam_Naa ?? ""},
                                    {"hm_van",       trafficResultItem.Hm_Van ?? ""},
                                    {"hm_naar",      trafficResultItem.Hm_Naar ?? ""},
                                    {"traj_van",     trafficResultItem.Traj_Van ?? ""},
                                    {"traj_naa",     trafficResultItem.Traj_Naa ?? ""},
                                    {"flricht",      trafficResultItem.Flricht ?? ""},
                                    {"filesagvwerk", trafficResultItem.FilesAgvWerk ?? ""},
                                    {"idwerk",       trafficResultItem.IdWerk ?? ""}
                                });
                                }
                            }

                            break;
                        }
                    case "Weather":
                        {
                            openFileDialog.Filter = "Text files (*.txt)|*.txt";
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                Aggregator.AggregateWeatherModel(openFileDialog.FileName);
                            }
                            break;
                        }

                    case "WeatherMonth":
                        {
                            openFileDialog.Filter = "Text files (*.txt)|*.txt";
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                Aggregator.AggregateWeatherModelMonthly(openFileDialog.FileName);
                            }
                            break;
                        }

                    default:
                        MessageBox.Show("This option is not supported/implemented at the moment!");
                        break;
                }
            }
            else
            {
                MessageBox.Show("You forgot to make a selection in the dropdown menu.");
            }
        }
    }
}
