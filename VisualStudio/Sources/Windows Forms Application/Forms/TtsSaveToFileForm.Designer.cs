namespace Elreg.WindowsFormsApplication.Forms
{
    partial class TtsSaveToFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TtsSaveToFileForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSpeak = new System.Windows.Forms.Button();
            this.btnSaveAsWav = new System.Windows.Forms.Button();
            this.txtTextToSpeak = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(257, 65);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 24);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Schließen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // btnSpeak
            // 
            this.btnSpeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSpeak.Location = new System.Drawing.Point(12, 65);
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.Size = new System.Drawing.Size(113, 24);
            this.btnSpeak.TabIndex = 3;
            this.btnSpeak.Text = "&Anhören";
            this.btnSpeak.UseVisualStyleBackColor = true;
            this.btnSpeak.Click += new System.EventHandler(this.BtnSpeakClick);
            // 
            // btnSaveAsWav
            // 
            this.btnSaveAsWav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveAsWav.Location = new System.Drawing.Point(131, 65);
            this.btnSaveAsWav.Name = "btnSaveAsWav";
            this.btnSaveAsWav.Size = new System.Drawing.Size(118, 24);
            this.btnSaveAsWav.TabIndex = 3;
            this.btnSaveAsWav.Text = "&Als Wave speichern";
            this.btnSaveAsWav.UseVisualStyleBackColor = true;
            this.btnSaveAsWav.Click += new System.EventHandler(this.BtnSaveAsWavClick);
            // 
            // txtTextToSpeak
            // 
            this.txtTextToSpeak.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextToSpeak.Location = new System.Drawing.Point(12, 6);
            this.txtTextToSpeak.Multiline = true;
            this.txtTextToSpeak.Name = "txtTextToSpeak";
            this.txtTextToSpeak.Size = new System.Drawing.Size(358, 53);
            this.txtTextToSpeak.TabIndex = 4;
            // 
            // TtsSaveToFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 101);
            this.Controls.Add(this.txtTextToSpeak);
            this.Controls.Add(this.btnSaveAsWav);
            this.Controls.Add(this.btnSpeak);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(388, 126);
            this.Name = "TtsSaveToFileForm";
            this.Text = "Create Wav";
            this.Load += new System.EventHandler(this.TtsSaveToFileFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSpeak;
        private System.Windows.Forms.Button btnSaveAsWav;
        private System.Windows.Forms.TextBox txtTextToSpeak;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}