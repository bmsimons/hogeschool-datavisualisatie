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
            this.ControlContainer = new System.Windows.Forms.GroupBox();
            this.selectDatasetBox = new System.Windows.Forms.ComboBox();
            this.AggregationButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.anwbStatusBox = new System.Windows.Forms.TextBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.ControlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlContainer
            // 
            this.ControlContainer.Controls.Add(this.selectDatasetBox);
            this.ControlContainer.Controls.Add(this.AggregationButton);
            this.ControlContainer.Controls.Add(this.exportButton);
            this.ControlContainer.Controls.Add(this.ImportButton);
            this.ControlContainer.Location = new System.Drawing.Point(12, 14);
            this.ControlContainer.Name = "ControlContainer";
            this.ControlContainer.Size = new System.Drawing.Size(411, 165);
            this.ControlContainer.TabIndex = 6;
            this.ControlContainer.TabStop = false;
            this.ControlContainer.Text = "Controls";
            // 
            // selectDatasetBox
            // 
            this.selectDatasetBox.AllowDrop = true;
            this.selectDatasetBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectDatasetBox.FormattingEnabled = true;
            this.selectDatasetBox.Items.AddRange(new object[] {
            "Traffic",
            "Weather",
            "WeatherMonth",
            "PopulationChange"});
            this.selectDatasetBox.Location = new System.Drawing.Point(11, 127);
            this.selectDatasetBox.Name = "selectDatasetBox";
            this.selectDatasetBox.Size = new System.Drawing.Size(394, 21);
            this.selectDatasetBox.TabIndex = 3;
            // 
            // AggregationButton
            // 
            this.AggregationButton.Location = new System.Drawing.Point(11, 73);
            this.AggregationButton.Name = "AggregationButton";
            this.AggregationButton.Size = new System.Drawing.Size(395, 37);
            this.AggregationButton.TabIndex = 2;
            this.AggregationButton.Text = "Start data aggregation";
            this.AggregationButton.UseVisualStyleBackColor = true;
            this.AggregationButton.Click += new System.EventHandler(this.AggregationButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(213, 22);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(193, 40);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "Export data";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(11, 22);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(193, 40);
            this.ImportButton.TabIndex = 0;
            this.ImportButton.Text = "Import data";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // anwbStatusBox
            // 
            this.anwbStatusBox.BackColor = System.Drawing.SystemColors.Control;
            this.anwbStatusBox.Location = new System.Drawing.Point(429, 36);
            this.anwbStatusBox.Multiline = true;
            this.anwbStatusBox.Name = "anwbStatusBox";
            this.anwbStatusBox.ReadOnly = true;
            this.anwbStatusBox.Size = new System.Drawing.Size(555, 647);
            this.anwbStatusBox.TabIndex = 7;
            this.anwbStatusBox.Text = "Idle....";
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(429, 14);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(25, 13);
            this.LogLabel.TabIndex = 8;
            this.LogLabel.Text = "Log";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(996, 695);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.anwbStatusBox);
            this.Controls.Add(this.ControlContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hogeschool Datavisualisatie Project";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ControlContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ControlContainer;
        private System.Windows.Forms.Button AggregationButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.TextBox anwbStatusBox;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.ComboBox selectDatasetBox;
    }
}

