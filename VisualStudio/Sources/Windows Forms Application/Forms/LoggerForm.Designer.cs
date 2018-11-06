namespace Elreg.WindowsFormsApplication.Forms
{
    partial class LoggerForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkRaceLoggingActivated = new Elreg.Controls.ColoredCheckbox();
            this.chkPortReaderLoggingActivated = new Elreg.Controls.ColoredCheckbox();
            this.chkPortParserLoggingActivated = new Elreg.Controls.ColoredCheckbox();
            this.btnOpenPortParserLog = new System.Windows.Forms.Button();
            this.btnOpenComPortLog = new System.Windows.Forms.Button();
            this.btnOpenRaceLog = new System.Windows.Forms.Button();
            this.btnOpenRaceDiagram = new System.Windows.Forms.Button();
            this.chkRaceReplayLoggingActivated = new Elreg.Controls.ColoredCheckbox();
            this.btnOpenRaceReplayLog = new System.Windows.Forms.Button();
            this.btnOpenRaceReplayForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(228, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(347, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // chkRaceLoggingActivated
            // 
            this.chkRaceLoggingActivated.AutoSize = true;
            this.chkRaceLoggingActivated.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkRaceLoggingActivated.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkRaceLoggingActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRaceLoggingActivated.Location = new System.Drawing.Point(12, 49);
            this.chkRaceLoggingActivated.Name = "chkRaceLoggingActivated";
            this.chkRaceLoggingActivated.Size = new System.Drawing.Size(147, 28);
            this.chkRaceLoggingActivated.TabIndex = 0;
            this.chkRaceLoggingActivated.Text = "Race Logging";
            this.chkRaceLoggingActivated.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkRaceLoggingActivated.UseVisualStyleBackColor = true;
            // 
            // chkPortReaderLoggingActivated
            // 
            this.chkPortReaderLoggingActivated.AutoSize = true;
            this.chkPortReaderLoggingActivated.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkPortReaderLoggingActivated.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkPortReaderLoggingActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPortReaderLoggingActivated.Location = new System.Drawing.Point(12, 83);
            this.chkPortReaderLoggingActivated.Name = "chkPortReaderLoggingActivated";
            this.chkPortReaderLoggingActivated.Size = new System.Drawing.Size(185, 28);
            this.chkPortReaderLoggingActivated.TabIndex = 1;
            this.chkPortReaderLoggingActivated.Text = "COM Port Logging";
            this.chkPortReaderLoggingActivated.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkPortReaderLoggingActivated.UseVisualStyleBackColor = true;
            // 
            // chkPortParserLoggingActivated
            // 
            this.chkPortParserLoggingActivated.AutoSize = true;
            this.chkPortParserLoggingActivated.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkPortParserLoggingActivated.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkPortParserLoggingActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPortParserLoggingActivated.Location = new System.Drawing.Point(12, 117);
            this.chkPortParserLoggingActivated.Name = "chkPortParserLoggingActivated";
            this.chkPortParserLoggingActivated.Size = new System.Drawing.Size(195, 28);
            this.chkPortParserLoggingActivated.TabIndex = 2;
            this.chkPortParserLoggingActivated.Text = "Port Parser Logging";
            this.chkPortParserLoggingActivated.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkPortParserLoggingActivated.UseVisualStyleBackColor = true;
            // 
            // btnOpenPortParserLog
            // 
            this.btnOpenPortParserLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenPortParserLog.Location = new System.Drawing.Point(228, 117);
            this.btnOpenPortParserLog.Name = "btnOpenPortParserLog";
            this.btnOpenPortParserLog.Size = new System.Drawing.Size(97, 28);
            this.btnOpenPortParserLog.TabIndex = 6;
            this.btnOpenPortParserLog.Text = "Open Log";
            this.btnOpenPortParserLog.UseVisualStyleBackColor = true;
            this.btnOpenPortParserLog.Click += new System.EventHandler(this.BtnOpenPortParserLogClick);
            // 
            // btnOpenComPortLog
            // 
            this.btnOpenComPortLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenComPortLog.Location = new System.Drawing.Point(228, 83);
            this.btnOpenComPortLog.Name = "btnOpenComPortLog";
            this.btnOpenComPortLog.Size = new System.Drawing.Size(97, 28);
            this.btnOpenComPortLog.TabIndex = 7;
            this.btnOpenComPortLog.Text = "Open Log";
            this.btnOpenComPortLog.UseVisualStyleBackColor = true;
            this.btnOpenComPortLog.Click += new System.EventHandler(this.BtnOpenComPortLogClick);
            // 
            // btnOpenRaceLog
            // 
            this.btnOpenRaceLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenRaceLog.Location = new System.Drawing.Point(228, 49);
            this.btnOpenRaceLog.Name = "btnOpenRaceLog";
            this.btnOpenRaceLog.Size = new System.Drawing.Size(97, 28);
            this.btnOpenRaceLog.TabIndex = 8;
            this.btnOpenRaceLog.Text = "Open Log";
            this.btnOpenRaceLog.UseVisualStyleBackColor = true;
            this.btnOpenRaceLog.Click += new System.EventHandler(this.BtnOpenRaceLogClick);
            // 
            // btnOpenRaceDiagram
            // 
            this.btnOpenRaceDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenRaceDiagram.Location = new System.Drawing.Point(331, 49);
            this.btnOpenRaceDiagram.Name = "btnOpenRaceDiagram";
            this.btnOpenRaceDiagram.Size = new System.Drawing.Size(135, 28);
            this.btnOpenRaceDiagram.TabIndex = 8;
            this.btnOpenRaceDiagram.Text = "Open Diagram";
            this.btnOpenRaceDiagram.UseVisualStyleBackColor = true;
            this.btnOpenRaceDiagram.Click += new System.EventHandler(this.BtnOpenRaceDiagramClick);
            // 
            // chkRaceReplayLoggingActivated
            // 
            this.chkRaceReplayLoggingActivated.AutoSize = true;
            this.chkRaceReplayLoggingActivated.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkRaceReplayLoggingActivated.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkRaceReplayLoggingActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRaceReplayLoggingActivated.Location = new System.Drawing.Point(12, 15);
            this.chkRaceReplayLoggingActivated.Name = "chkRaceReplayLoggingActivated";
            this.chkRaceReplayLoggingActivated.Size = new System.Drawing.Size(210, 28);
            this.chkRaceReplayLoggingActivated.TabIndex = 0;
            this.chkRaceReplayLoggingActivated.Text = "Race Replay Logging";
            this.chkRaceReplayLoggingActivated.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkRaceReplayLoggingActivated.UseVisualStyleBackColor = true;
            // 
            // btnOpenRaceReplayLog
            // 
            this.btnOpenRaceReplayLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenRaceReplayLog.Location = new System.Drawing.Point(228, 15);
            this.btnOpenRaceReplayLog.Name = "btnOpenRaceReplayLog";
            this.btnOpenRaceReplayLog.Size = new System.Drawing.Size(97, 28);
            this.btnOpenRaceReplayLog.TabIndex = 8;
            this.btnOpenRaceReplayLog.Text = "Open Log";
            this.btnOpenRaceReplayLog.UseVisualStyleBackColor = true;
            this.btnOpenRaceReplayLog.Click += new System.EventHandler(this.BtnOpenRaceReplayLogClick);
            // 
            // btnOpenRaceReplayForm
            // 
            this.btnOpenRaceReplayForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenRaceReplayForm.Location = new System.Drawing.Point(331, 15);
            this.btnOpenRaceReplayForm.Name = "btnOpenRaceReplayForm";
            this.btnOpenRaceReplayForm.Size = new System.Drawing.Size(135, 28);
            this.btnOpenRaceReplayForm.TabIndex = 8;
            this.btnOpenRaceReplayForm.Text = "Open Form";
            this.btnOpenRaceReplayForm.UseVisualStyleBackColor = true;
            this.btnOpenRaceReplayForm.Click += new System.EventHandler(this.BtnOpenRaceReplayFormClick);
            // 
            // LoggerForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(472, 213);
            this.Controls.Add(this.btnOpenRaceReplayForm);
            this.Controls.Add(this.btnOpenRaceDiagram);
            this.Controls.Add(this.btnOpenRaceReplayLog);
            this.Controls.Add(this.btnOpenRaceLog);
            this.Controls.Add(this.btnOpenComPortLog);
            this.Controls.Add(this.btnOpenPortParserLog);
            this.Controls.Add(this.chkPortParserLoggingActivated);
            this.Controls.Add(this.chkPortReaderLoggingActivated);
            this.Controls.Add(this.chkRaceReplayLoggingActivated);
            this.Controls.Add(this.chkRaceLoggingActivated);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.MinimumSize = new System.Drawing.Size(263, 168);
            this.Name = "LoggerForm";
            this.Text = "Logging";
            this.Load += new System.EventHandler(this.LoggerFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private Elreg.Controls.ColoredCheckbox chkRaceLoggingActivated;
        private Elreg.Controls.ColoredCheckbox chkPortReaderLoggingActivated;
        private Elreg.Controls.ColoredCheckbox chkPortParserLoggingActivated;
        private System.Windows.Forms.Button btnOpenPortParserLog;
        private System.Windows.Forms.Button btnOpenComPortLog;
        private System.Windows.Forms.Button btnOpenRaceLog;
        private System.Windows.Forms.Button btnOpenRaceDiagram;
        private Controls.ColoredCheckbox chkRaceReplayLoggingActivated;
        private System.Windows.Forms.Button btnOpenRaceReplayLog;
        private System.Windows.Forms.Button btnOpenRaceReplayForm;
    }
}