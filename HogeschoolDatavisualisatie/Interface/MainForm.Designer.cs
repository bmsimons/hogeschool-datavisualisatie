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
            this.AggregationButton = new System.Windows.Forms.Button();
            this.anwbExportDataButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.anwbStatusBox = new System.Windows.Forms.TextBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ControlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlContainer
            // 
            this.ControlContainer.Controls.Add(this.comboBox1);
            this.ControlContainer.Controls.Add(this.AggregationButton);
            this.ControlContainer.Controls.Add(this.anwbExportDataButton);
            this.ControlContainer.Controls.Add(this.ImportButton);
            this.ControlContainer.Location = new System.Drawing.Point(12, 14);
            this.ControlContainer.Name = "ControlContainer";
            this.ControlContainer.Size = new System.Drawing.Size(411, 165);
            this.ControlContainer.TabIndex = 6;
            this.ControlContainer.TabStop = false;
            this.ControlContainer.Text = "Controls";
            // 
            // AggregationButton
            // 
            this.AggregationButton.Location = new System.Drawing.Point(11, 73);
            this.AggregationButton.Name = "AggregationButton";
            this.AggregationButton.Size = new System.Drawing.Size(395, 37);
            this.AggregationButton.TabIndex = 2;
            this.AggregationButton.Text = "Start data aggregation";
            this.AggregationButton.UseVisualStyleBackColor = true;
            // 
            // anwbExportDataButton
            // 
            this.anwbExportDataButton.Location = new System.Drawing.Point(213, 22);
            this.anwbExportDataButton.Name = "anwbExportDataButton";
            this.anwbExportDataButton.Size = new System.Drawing.Size(193, 40);
            this.anwbExportDataButton.TabIndex = 1;
            this.anwbExportDataButton.Text = "Export data";
            this.anwbExportDataButton.UseVisualStyleBackColor = true;
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(11, 22);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(193, 40);
            this.ImportButton.TabIndex = 0;
            this.ImportButton.Text = "Import data";
            this.ImportButton.UseVisualStyleBackColor = true;
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
            this.LogLabel.Size = new System.Drawing.Size(25, 15);
            this.LogLabel.TabIndex = 8;
            this.LogLabel.Text = "Log";
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Traffic",
            "Weather",
            "WeatherMonth",
            "PopulationChange"});
            this.comboBox1.Location = new System.Drawing.Point(11, 127);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(394, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(996, 695);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.anwbStatusBox);
            this.Controls.Add(this.ControlContainer);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.Button anwbExportDataButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.TextBox anwbStatusBox;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

