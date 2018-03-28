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

        private void MainForm_Load(object sender, EventArgs e) { }

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
                    case "Population":
                        {
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
