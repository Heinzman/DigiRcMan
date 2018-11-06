namespace Elreg.WindowsFormsApplication.UserControls
{
    partial class CtlMockController
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnLaneChange = new System.Windows.Forms.Button();
            this.btnLap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackBar1.LargeChange = 4;
            this.trackBar1.Location = new System.Drawing.Point(10, 29);
            this.trackBar1.Maximum = 12;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(42, 154);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
            // 
            // btnLaneChange
            // 
            this.btnLaneChange.Location = new System.Drawing.Point(3, 3);
            this.btnLaneChange.Name = "btnLaneChange";
            this.btnLaneChange.Size = new System.Drawing.Size(57, 20);
            this.btnLaneChange.TabIndex = 1;
            this.btnLaneChange.Text = "Button";
            this.btnLaneChange.UseVisualStyleBackColor = true;
            this.btnLaneChange.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnLaneChangeMouseDown);
            this.btnLaneChange.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnLaneChangeMouseUp);
            // 
            // btnLap
            // 
            this.btnLap.Location = new System.Drawing.Point(3, 189);
            this.btnLap.Name = "btnLap";
            this.btnLap.Size = new System.Drawing.Size(57, 20);
            this.btnLap.TabIndex = 1;
            this.btnLap.Text = "Lap";
            this.btnLap.UseVisualStyleBackColor = true;
            this.btnLap.Click += new System.EventHandler(this.BtnLapClick);
            // 
            // CtlMockController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLap);
            this.Controls.Add(this.btnLaneChange);
            this.Controls.Add(this.trackBar1);
            this.Name = "CtlMockController";
            this.Size = new System.Drawing.Size(78, 237);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btnLaneChange;
        private System.Windows.Forms.Button btnLap;
    }
}
