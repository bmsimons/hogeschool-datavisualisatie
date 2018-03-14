﻿using System;
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
            catImageBox.Image = new System.Drawing.Bitmap(new System.IO.MemoryStream(new System.Net.WebClient().DownloadData("http://thecatapi.com/api/images/get?type=gif")));
        }

        private void trafficJamAggregatorButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<TrafficJamAggregator>().Count() == 0)
            {
                TrafficJamAggregator trafficJamAggregator = new TrafficJamAggregator();
                trafficJamAggregator.Show();
            }
        }
    }
}