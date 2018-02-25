namespace HogeschoolDatavisualisatie
{
    partial class TrafficJamAggregator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrafficJamAggregator));
            this.anwbContainer = new System.Windows.Forms.GroupBox();
            this.anwbRestoreDataButton = new System.Windows.Forms.Button();
            this.anwbExportDataButton = new System.Windows.Forms.Button();
            this.anwbAggregateButton = new System.Windows.Forms.Button();
            this.anwbStatusBox = new System.Windows.Forms.TextBox();
            this.anwbContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // anwbContainer
            // 
            this.anwbContainer.Controls.Add(this.anwbStatusBox);
            this.anwbContainer.Controls.Add(this.anwbAggregateButton);
            this.anwbContainer.Controls.Add(this.anwbExportDataButton);
            this.anwbContainer.Controls.Add(this.anwbRestoreDataButton);
            this.anwbContainer.Location = new System.Drawing.Point(13, 13);
            this.anwbContainer.Name = "anwbContainer";
            this.anwbContainer.Size = new System.Drawing.Size(419, 196);
            this.anwbContainer.TabIndex = 0;
            this.anwbContainer.TabStop = false;
            this.anwbContainer.Text = "ANWB";
            // 
            // anwbRestoreDataButton
            // 
            this.anwbRestoreDataButton.Location = new System.Drawing.Point(11, 19);
            this.anwbRestoreDataButton.Name = "anwbRestoreDataButton";
            this.anwbRestoreDataButton.Size = new System.Drawing.Size(193, 35);
            this.anwbRestoreDataButton.TabIndex = 0;
            this.anwbRestoreDataButton.Text = "Restore data";
            this.anwbRestoreDataButton.UseVisualStyleBackColor = true;
            // 
            // anwbExportDataButton
            // 
            this.anwbExportDataButton.Location = new System.Drawing.Point(213, 19);
            this.anwbExportDataButton.Name = "anwbExportDataButton";
            this.anwbExportDataButton.Size = new System.Drawing.Size(193, 35);
            this.anwbExportDataButton.TabIndex = 1;
            this.anwbExportDataButton.Text = "Export data";
            this.anwbExportDataButton.UseVisualStyleBackColor = true;
            // 
            // anwbAggregateButton
            // 
            this.anwbAggregateButton.Location = new System.Drawing.Point(11, 63);
            this.anwbAggregateButton.Name = "anwbAggregateButton";
            this.anwbAggregateButton.Size = new System.Drawing.Size(395, 30);
            this.anwbAggregateButton.TabIndex = 2;
            this.anwbAggregateButton.Text = "Start data aggregation";
            this.anwbAggregateButton.UseVisualStyleBackColor = true;
            this.anwbAggregateButton.Click += new System.EventHandler(this.anwbAggregateButton_Click);
            // 
            // anwbStatusBox
            // 
            this.anwbStatusBox.Location = new System.Drawing.Point(11, 100);
            this.anwbStatusBox.Multiline = true;
            this.anwbStatusBox.Name = "anwbStatusBox";
            this.anwbStatusBox.ReadOnly = true;
            this.anwbStatusBox.Size = new System.Drawing.Size(395, 85);
            this.anwbStatusBox.TabIndex = 3;
            this.anwbStatusBox.Text = "Idle....";
            // 
            // TrafficJamAggregator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 634);
            this.Controls.Add(this.anwbContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrafficJamAggregator";
            this.Text = "Traffic Jam Data Aggregator";
            this.Load += new System.EventHandler(this.TrafficJamAggregator_Load);
            this.anwbContainer.ResumeLayout(false);
            this.anwbContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox anwbContainer;
        private System.Windows.Forms.Button anwbExportDataButton;
        private System.Windows.Forms.Button anwbRestoreDataButton;
        private System.Windows.Forms.TextBox anwbStatusBox;
        private System.Windows.Forms.Button anwbAggregateButton;
    }
}