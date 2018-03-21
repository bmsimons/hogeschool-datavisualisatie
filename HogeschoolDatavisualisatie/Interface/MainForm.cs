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

namespace HogeschoolDatavisualisatie
{
    public partial class MainForm : Form
    {
        static MongoClient mongoClient;
        static IMongoDatabase mongoDatabase;
        static IMongoCollection<BsonDocument> mongoCollection;
        static Database database;

        public MainForm()
        {
            InitializeComponent();

            database = new Database();
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

        private void weatherAggregatorButton_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
    }
}
