namespace HogeschoolDatavisualisatie
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.creditsContainer = new System.Windows.Forms.GroupBox();
            this.creditsLabel = new System.Windows.Forms.Label();
            this.catImageContainer = new System.Windows.Forms.GroupBox();
            this.catImageBox = new System.Windows.Forms.PictureBox();
            this.dataAggregatorContainer = new System.Windows.Forms.GroupBox();
            this.randomButtonLol = new System.Windows.Forms.Button();
            this.weatherAggregatorButton = new System.Windows.Forms.Button();
            this.trafficJamAggregatorButton = new System.Windows.Forms.Button();
            this.creditsContainer.SuspendLayout();
            this.catImageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.catImageBox)).BeginInit();
            this.dataAggregatorContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // creditsContainer
            // 
            this.creditsContainer.Controls.Add(this.creditsLabel);
            this.creditsContainer.Location = new System.Drawing.Point(12, 215);
            this.creditsContainer.Name = "creditsContainer";
            this.creditsContainer.Size = new System.Drawing.Size(182, 170);
            this.creditsContainer.TabIndex = 0;
            this.creditsContainer.TabStop = false;
            this.creditsContainer.Text = "Credits";
            // 
            // creditsLabel
            // 
            this.creditsLabel.AutoSize = true;
            this.creditsLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditsLabel.Location = new System.Drawing.Point(6, 16);
            this.creditsLabel.Name = "creditsLabel";
            this.creditsLabel.Size = new System.Drawing.Size(105, 140);
            this.creditsLabel.TabIndex = 0;
            this.creditsLabel.Text = "Developed by:\r\n\r\n - Bart\r\n - Maikel\r\n - Tim\r\n - Vincent\r\n - Jasper";
            // 
            // catImageContainer
            // 
            this.catImageContainer.Controls.Add(this.catImageBox);
            this.catImageContainer.Location = new System.Drawing.Point(200, 215);
            this.catImageContainer.Name = "catImageContainer";
            this.catImageContainer.Size = new System.Drawing.Size(312, 170);
            this.catImageContainer.TabIndex = 1;
            this.catImageContainer.TabStop = false;
            this.catImageContainer.Text = "Random stretched cat image";
            // 
            // catImageBox
            // 
            this.catImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catImageBox.Location = new System.Drawing.Point(3, 16);
            this.catImageBox.Name = "catImageBox";
            this.catImageBox.Size = new System.Drawing.Size(306, 151);
            this.catImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.catImageBox.TabIndex = 0;
            this.catImageBox.TabStop = false;
            // 
            // dataAggregatorContainer
            // 
            this.dataAggregatorContainer.Controls.Add(this.randomButtonLol);
            this.dataAggregatorContainer.Controls.Add(this.weatherAggregatorButton);
            this.dataAggregatorContainer.Controls.Add(this.trafficJamAggregatorButton);
            this.dataAggregatorContainer.Location = new System.Drawing.Point(12, 12);
            this.dataAggregatorContainer.Name = "dataAggregatorContainer";
            this.dataAggregatorContainer.Size = new System.Drawing.Size(497, 197);
            this.dataAggregatorContainer.TabIndex = 2;
            this.dataAggregatorContainer.TabStop = false;
            this.dataAggregatorContainer.Text = "Data aggregation";
            // 
            // randomButtonLol
            // 
            this.randomButtonLol.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomButtonLol.Location = new System.Drawing.Point(12, 142);
            this.randomButtonLol.Name = "randomButtonLol";
            this.randomButtonLol.Size = new System.Drawing.Size(471, 35);
            this.randomButtonLol.TabIndex = 2;
            this.randomButtonLol.Text = "Random button with no function";
            this.randomButtonLol.UseVisualStyleBackColor = true;
            // 
            // weatherAggregatorButton
            // 
            this.weatherAggregatorButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weatherAggregatorButton.Location = new System.Drawing.Point(12, 70);
            this.weatherAggregatorButton.Name = "weatherAggregatorButton";
            this.weatherAggregatorButton.Size = new System.Drawing.Size(471, 35);
            this.weatherAggregatorButton.TabIndex = 1;
            this.weatherAggregatorButton.Text = "Weather aggregator (KNMI, Buienradar)";
            this.weatherAggregatorButton.UseVisualStyleBackColor = true;
            // 
            // trafficJamAggregatorButton
            // 
            this.trafficJamAggregatorButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trafficJamAggregatorButton.Location = new System.Drawing.Point(12, 23);
            this.trafficJamAggregatorButton.Name = "trafficJamAggregatorButton";
            this.trafficJamAggregatorButton.Size = new System.Drawing.Size(471, 35);
            this.trafficJamAggregatorButton.TabIndex = 0;
            this.trafficJamAggregatorButton.Text = "Traffic jam data aggregator (HERE, Bing Maps, ANWB)";
            this.trafficJamAggregatorButton.UseVisualStyleBackColor = true;
            this.trafficJamAggregatorButton.Click += new System.EventHandler(this.trafficJamAggregatorButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 397);
            this.Controls.Add(this.dataAggregatorContainer);
            this.Controls.Add(this.catImageContainer);
            this.Controls.Add(this.creditsContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Hogeschool Datavisualisatie Project";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.creditsContainer.ResumeLayout(false);
            this.creditsContainer.PerformLayout();
            this.catImageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.catImageBox)).EndInit();
            this.dataAggregatorContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox creditsContainer;
        private System.Windows.Forms.Label creditsLabel;
        private System.Windows.Forms.GroupBox catImageContainer;
        private System.Windows.Forms.PictureBox catImageBox;
        private System.Windows.Forms.GroupBox dataAggregatorContainer;
        private System.Windows.Forms.Button weatherAggregatorButton;
        private System.Windows.Forms.Button trafficJamAggregatorButton;
        private System.Windows.Forms.Button randomButtonLol;
    }
}

