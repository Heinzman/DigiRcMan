using Elreg.WindowsFormsApplication.UserControls;

namespace Elreg.WindowsFormsApplication.Forms
{
    partial class MaintainSoundsForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ctlFinished = new Elreg.WindowsFormsApplication.UserControls.CtlSoundOption();
            this.ctlLap = new Elreg.WindowsFormsApplication.UserControls.CtlSoundOption();
            this.ctlPenalty = new Elreg.WindowsFormsApplication.UserControls.CtlSoundOption();
            this.ctlLapDetectedNotAdded = new Elreg.WindowsFormsApplication.UserControls.CtlSoundOption();
            this.ctlDisqualified = new Elreg.WindowsFormsApplication.UserControls.CtlSoundOption();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreateWavs = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grdCoundDown = new Elreg.WindowsFormsApplication.UserControls.CtlTextToSpeechGrid();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdDrivers = new Elreg.WindowsFormsApplication.UserControls.CtlTextToSpeechGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdSpecialSounds = new Elreg.WindowsFormsApplication.UserControls.CtlTextToSpeechGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumbersPath = new System.Windows.Forms.TextBox();
            this.chkCreateNumbers = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(746, 676);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(627, 676);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 24);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScrollMinSize = new System.Drawing.Size(600, 200);
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ctlFinished, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ctlLap, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ctlPenalty, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ctlLapDetectedNotAdded, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ctlDisqualified, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(845, 642);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ctlFinished
            // 
            this.ctlFinished.Caption = "toolStripLabel1";
            this.ctlFinished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlFinished.Location = new System.Drawing.Point(3, 430);
            this.ctlFinished.Name = "ctlFinished";
            this.ctlFinished.Size = new System.Drawing.Size(416, 209);
            this.ctlFinished.TabIndex = 10;
            // 
            // ctlLap
            // 
            this.ctlLap.Caption = "toolStripLabel1";
            this.ctlLap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlLap.Location = new System.Drawing.Point(3, 3);
            this.ctlLap.Name = "ctlLap";
            this.ctlLap.Size = new System.Drawing.Size(416, 207);
            this.ctlLap.TabIndex = 0;
            // 
            // ctlPenalty
            // 
            this.ctlPenalty.Caption = "toolStripLabel1";
            this.ctlPenalty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlPenalty.Location = new System.Drawing.Point(425, 3);
            this.ctlPenalty.Name = "ctlPenalty";
            this.ctlPenalty.Size = new System.Drawing.Size(417, 207);
            this.ctlPenalty.TabIndex = 1;
            // 
            // ctlLapDetectedNotAdded
            // 
            this.ctlLapDetectedNotAdded.Caption = "toolStripLabel1";
            this.ctlLapDetectedNotAdded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlLapDetectedNotAdded.Location = new System.Drawing.Point(3, 216);
            this.ctlLapDetectedNotAdded.Name = "ctlLapDetectedNotAdded";
            this.ctlLapDetectedNotAdded.Size = new System.Drawing.Size(416, 208);
            this.ctlLapDetectedNotAdded.TabIndex = 8;
            // 
            // ctlDisqualified
            // 
            this.ctlDisqualified.Caption = "toolStripLabel1";
            this.ctlDisqualified.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDisqualified.Location = new System.Drawing.Point(425, 216);
            this.ctlDisqualified.Name = "ctlDisqualified";
            this.ctlDisqualified.Size = new System.Drawing.Size(417, 208);
            this.ctlDisqualified.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(859, 674);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(851, 648);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Action Sounds";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(851, 648);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Wav Creation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel3.Controls.Add(this.btnCreateWavs, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 480);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(745, 30);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // btnCreateWavs
            // 
            this.btnCreateWavs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateWavs.Location = new System.Drawing.Point(251, 3);
            this.btnCreateWavs.Name = "btnCreateWavs";
            this.btnCreateWavs.Size = new System.Drawing.Size(242, 24);
            this.btnCreateWavs.TabIndex = 4;
            this.btnCreateWavs.Text = "C&reate";
            this.btnCreateWavs.UseVisualStyleBackColor = true;
            this.btnCreateWavs.Click += new System.EventHandler(this.BtnCreateWavsClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.grdCoundDown);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(745, 152);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Countdown";
            // 
            // grdCoundDown
            // 
            this.grdCoundDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCoundDown.Location = new System.Drawing.Point(6, 19);
            this.grdCoundDown.Name = "grdCoundDown";
            this.grdCoundDown.Size = new System.Drawing.Size(733, 127);
            this.grdCoundDown.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 155);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(748, 269);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.grdDrivers);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(742, 128);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Driver Names";
            // 
            // grdDrivers
            // 
            this.grdDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDrivers.Location = new System.Drawing.Point(6, 19);
            this.grdDrivers.Name = "grdDrivers";
            this.grdDrivers.Size = new System.Drawing.Size(733, 103);
            this.grdDrivers.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.grdSpecialSounds);
            this.groupBox3.Location = new System.Drawing.Point(3, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(742, 129);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Special Sounds";
            // 
            // grdSpecialSounds
            // 
            this.grdSpecialSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSpecialSounds.Location = new System.Drawing.Point(6, 19);
            this.grdSpecialSounds.Name = "grdSpecialSounds";
            this.grdSpecialSounds.Size = new System.Drawing.Size(730, 104);
            this.grdSpecialSounds.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumbersPath);
            this.groupBox1.Controls.Add(this.chkCreateNumbers);
            this.groupBox1.Location = new System.Drawing.Point(3, 430);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Numbers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path";
            // 
            // txtNumbersPath
            // 
            this.txtNumbersPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumbersPath.Location = new System.Drawing.Point(141, 16);
            this.txtNumbersPath.Name = "txtNumbersPath";
            this.txtNumbersPath.ReadOnly = true;
            this.txtNumbersPath.Size = new System.Drawing.Size(598, 20);
            this.txtNumbersPath.TabIndex = 1;
            // 
            // chkCreateNumbers
            // 
            this.chkCreateNumbers.AutoSize = true;
            this.chkCreateNumbers.Location = new System.Drawing.Point(18, 19);
            this.chkCreateNumbers.Name = "chkCreateNumbers";
            this.chkCreateNumbers.Size = new System.Drawing.Size(57, 17);
            this.chkCreateNumbers.TabIndex = 0;
            this.chkCreateNumbers.Text = "Create";
            this.chkCreateNumbers.UseVisualStyleBackColor = true;
            // 
            // MaintainSoundsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(859, 702);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.MinimumSize = new System.Drawing.Size(700, 507);
            this.Name = "MaintainSoundsForm";
            this.Text = "Sounds";
            this.Load += new System.EventHandler(this.MaintainDriversFormLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private CtlSoundOption ctlLap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CtlSoundOption ctlLapDetectedNotAdded;
        private CtlSoundOption ctlFinished;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCreateNumbers;
        private System.Windows.Forms.GroupBox groupBox3;
        private CtlTextToSpeechGrid grdSpecialSounds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCreateWavs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumbersPath;
        private CtlTextToSpeechGrid grdCoundDown;
        private CtlTextToSpeechGrid grdDrivers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private CtlSoundOption ctlPenalty;
        private CtlSoundOption ctlDisqualified;
    }
}