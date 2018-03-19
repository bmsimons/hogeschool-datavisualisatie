using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
