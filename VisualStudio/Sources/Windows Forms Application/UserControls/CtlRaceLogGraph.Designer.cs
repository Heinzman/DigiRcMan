namespace Elreg.WindowsFormsApplication.UserControls
{
    partial class CtlRaceLogGraph
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnDecreaseY = new System.Windows.Forms.Button();
            this.btnIncreaseY = new System.Windows.Forms.Button();
            this.btnDecreaseX = new System.Windows.Forms.Button();
            this.btnIncreaseX = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnAutoSize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDecreaseY
            // 
            this.btnDecreaseY.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDecreaseY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecreaseY.Location = new System.Drawing.Point(168, 5);
            this.btnDecreaseY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDecreaseY.Name = "btnDecreaseY";
            this.btnDecreaseY.Size = new System.Drawing.Size(43, 27);
            this.btnDecreaseY.TabIndex = 12;
            this.btnDecreaseY.Text = "-Y";
            this.btnDecreaseY.UseVisualStyleBackColor = true;
            this.btnDecreaseY.Click += new System.EventHandler(this.BtnDecreaseYClick);
            // 
            // btnIncreaseY
            // 
            this.btnIncreaseY.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIncreaseY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncreaseY.Location = new System.Drawing.Point(117, 5);
            this.btnIncreaseY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIncreaseY.Name = "btnIncreaseY";
            this.btnIncreaseY.Size = new System.Drawing.Size(43, 27);
            this.btnIncreaseY.TabIndex = 11;
            this.btnIncreaseY.Text = "+Y";
            this.btnIncreaseY.UseVisualStyleBackColor = true;
            this.btnIncreaseY.Click += new System.EventHandler(this.BtnIncreaseYClick);
            // 
            // btnDecreaseX
            // 
            this.btnDecreaseX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDecreaseX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecreaseX.Location = new System.Drawing.Point(55, 5);
            this.btnDecreaseX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDecreaseX.Name = "btnDecreaseX";
            this.btnDecreaseX.Size = new System.Drawing.Size(43, 27);
            this.btnDecreaseX.TabIndex = 10;
            this.btnDecreaseX.Text = "-X";
            this.btnDecreaseX.UseVisualStyleBackColor = true;
            this.btnDecreaseX.Click += new System.EventHandler(this.BtnDecreaseXClick);
            // 
            // btnIncreaseX
            // 
            this.btnIncreaseX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIncreaseX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncreaseX.Location = new System.Drawing.Point(4, 5);
            this.btnIncreaseX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIncreaseX.Name = "btnIncreaseX";
            this.btnIncreaseX.Size = new System.Drawing.Size(43, 27);
            this.btnIncreaseX.TabIndex = 9;
            this.btnIncreaseX.Text = "+X";
            this.btnIncreaseX.UseVisualStyleBackColor = true;
            this.btnIncreaseX.Click += new System.EventHandler(this.BtnIncreaseXClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.btnIncreaseX);
            this.splitContainer1.Panel2.Controls.Add(this.btnAutoSize);
            this.splitContainer1.Panel2.Controls.Add(this.btnDecreaseY);
            this.splitContainer1.Panel2.Controls.Add(this.btnIncreaseY);
            this.splitContainer1.Panel2.Controls.Add(this.btnDecreaseX);
            this.splitContainer1.Size = new System.Drawing.Size(782, 426);
            this.splitContainer1.SplitterDistance = 387;
            this.splitContainer1.TabIndex = 15;
            // 
            // chart1
            // 
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(782, 387);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnAutoSize
            // 
            this.btnAutoSize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAutoSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSize.Location = new System.Drawing.Point(229, 5);
            this.btnAutoSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAutoSize.Name = "btnAutoSize";
            this.btnAutoSize.Size = new System.Drawing.Size(103, 27);
            this.btnAutoSize.TabIndex = 12;
            this.btnAutoSize.Text = "AutoSize";
            this.btnAutoSize.UseVisualStyleBackColor = true;
            this.btnAutoSize.Click += new System.EventHandler(this.BtnAutoSizeClick);
            // 
            // CtlRaceLogGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CtlRaceLogGraph";
            this.Size = new System.Drawing.Size(782, 426);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDecreaseY;
        private System.Windows.Forms.Button btnIncreaseY;
        private System.Windows.Forms.Button btnDecreaseX;
        private System.Windows.Forms.Button btnIncreaseX;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAutoSize;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
