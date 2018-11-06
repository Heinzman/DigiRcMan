namespace Elreg.WindowsFormsApplication.UserControls
{
    partial class CtlMockSsdController
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
            this.chkBtnA = new System.Windows.Forms.CheckBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.chkActivated = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(6, 63);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(6);
            this.trackBar1.Maximum = 15;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(42, 305);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Scroll += new System.EventHandler(this.DataOfControlChanged);
            // 
            // chkBtnA
            // 
            this.chkBtnA.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkBtnA.Location = new System.Drawing.Point(6, 29);
            this.chkBtnA.Margin = new System.Windows.Forms.Padding(6);
            this.chkBtnA.Name = "chkBtnA";
            this.chkBtnA.Size = new System.Drawing.Size(95, 31);
            this.chkBtnA.TabIndex = 1;
            this.chkBtnA.Text = "Btn A";
            this.chkBtnA.UseVisualStyleBackColor = true;
            this.chkBtnA.CheckedChanged += new System.EventHandler(this.DataOfControlChanged);
            // 
            // lblCaption
            // 
            this.lblCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaption.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(139, 30);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Label";
            // 
            // chkActivated
            // 
            this.chkActivated.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivated.Location = new System.Drawing.Point(7, 375);
            this.chkActivated.Margin = new System.Windows.Forms.Padding(6);
            this.chkActivated.Name = "chkActivated";
            this.chkActivated.Size = new System.Drawing.Size(130, 31);
            this.chkActivated.TabIndex = 3;
            this.chkActivated.Text = "Activated";
            this.chkActivated.UseVisualStyleBackColor = true;
            this.chkActivated.CheckedChanged += new System.EventHandler(this.DataOfControlChanged);
            // 
            // CtlMockSsdController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.Controls.Add(this.chkActivated);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.chkBtnA);
            this.Controls.Add(this.trackBar1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CtlMockSsdController";
            this.Size = new System.Drawing.Size(141, 416);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox chkBtnA;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.CheckBox chkActivated;
    }
}
