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
using HogeschoolDatavisualisatie.Services;

namespace HogeschoolDatavisualisatie
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MakeConnection();
        }

        private void MakeConnection()
        {
            try
            {
                MongoConnector.Instance.Connect();
                listBox1.Items.Add("Succesfully connected to Mongo Database");
            }
            catch (Exception exception)
            {
                listBox1.Items.Add(exception.Message);
            }
        }

        /// <summary>
        /// Handle Export Button Click: call jsonexporter given correct prevariants
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            bool boxItemSelected = (selectDatasetBox.SelectedIndex != -1);
            if (boxItemSelected)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON (*.json)|*.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    JsonExporter.ExportMongoCollection(GetSelectedBoxAsCollectionName(), saveFileDialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("Please make a selection in the drop down menu");
            }
        }

        /// <summary>
        /// Handle Import Button Click: call jsonimporter given correct prevariants
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportButton_Click(object sender, EventArgs e)
        {
            bool boxItemSelected = (selectDatasetBox.SelectedIndex != -1);
            if (boxItemSelected)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JSON (*.json)|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    JsonImporter.ImportMongoCollection(GetSelectedBoxAsCollectionName(), openFileDialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("Please make a selection in the drop down menu");
            }
        }

        private string GetSelectedBoxAsCollectionName()
        {
            switch (selectDatasetBox.Items[selectDatasetBox.SelectedIndex].ToString())
            {
                case "Traffic":
                    return "rijkswaterstaat";
                case "Weather":
                    return "weather-day";
                case "WeatherMonth":
                    return "weather-month";
                case "PopulationChange":
                    return "population";
                default:
                    return null;
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
                                Aggregator.AggregateTrafficModel(openFileDialog.FileName);
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
                    case "PopulationChange":
                        {
                            openFileDialog.Filter = "JSOn (*.json)|*.json";
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                PopulationChangeParser parser = new PopulationChangeParser(openFileDialog.FileName);
                                parser.ParseData();
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

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            if(MongoConnector.Instance.MongoClient.Cluster.Description.State == MongoDB.Driver.Core.Clusters.ClusterState.Connected)
            {
                listBox1.Items.Add("Already connected to database");
            }
            else
            {
                MakeConnection();
            }
        }
    }
}
