namespace Elreg.WindowsFormsApplication.Forms
{
    partial class RaceControlForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPauseOrRestart = new Elreg.Controls.VistaButton();
            this.btnStartRace = new Elreg.Controls.VistaButton();
            this.btnStartQualification = new Elreg.Controls.VistaButton();
            this.btnStartTraining = new Elreg.Controls.VistaButton();
            this.btnInit = new Elreg.Controls.VistaButton();
            this.btnStop = new Elreg.Controls.VistaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpRaceControl = new System.Windows.Forms.GroupBox();
            this.btnRaceSettings = new Elreg.Controls.VistaButton();
            this.btnSoundOptions = new Elreg.Controls.VistaButton();
            this.btnCarsOptions = new Elreg.Controls.VistaButton();
            this.btnDriversOptions = new Elreg.Controls.VistaButton();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSoundMixer = new Elreg.Controls.VistaButton();
            this.grpSerialPort = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblComPortStatus = new System.Windows.Forms.Label();
            this._btnConfigureArduino = new Elreg.Controls.VistaButton();
            this.grpRace = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnChangeRace = new Elreg.Controls.VistaButton();
            this.btnShowRaceView = new Elreg.Controls.VistaButton();
            this.btnLogging = new Elreg.Controls.VistaButton();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStatistics = new Elreg.Controls.VistaButton();
            this.btnShowChampionships = new Elreg.Controls.VistaButton();
            this.btnShowRaceResults = new Elreg.Controls.VistaButton();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpRaceControl.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.grpSerialPort.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.grpRace.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.grpResults.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.btnPauseOrRestart, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStartRace, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStartQualification, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStartTraining, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInit, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(895, 172);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnPauseOrRestart
            // 
            this.btnPauseOrRestart.BackColor = System.Drawing.Color.Transparent;
            this.btnPauseOrRestart.BaseColor = System.Drawing.Color.Transparent;
            this.btnPauseOrRestart.ButtonColor = System.Drawing.Color.Orange;
            this.btnPauseOrRestart.ButtonText = "Pause";
            this.btnPauseOrRestart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPauseOrRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseOrRestart.ForeColor = System.Drawing.Color.Black;
            this.btnPauseOrRestart.GlowColor = System.Drawing.Color.White;
            this.btnPauseOrRestart.Location = new System.Drawing.Point(609, 3);
            this.btnPauseOrRestart.Name = "btnPauseOrRestart";
            this.btnPauseOrRestart.Size = new System.Drawing.Size(137, 166);
            this.btnPauseOrRestart.TabIndex = 6;
            this.btnPauseOrRestart.Click += new System.EventHandler(this.BtnPauseOrRestartClick);
            // 
            // btnStartRace
            // 
            this.btnStartRace.BackColor = System.Drawing.Color.Transparent;
            this.btnStartRace.BaseColor = System.Drawing.Color.Transparent;
            this.btnStartRace.ButtonColor = System.Drawing.Color.Green;
            this.btnStartRace.ButtonText = "Start Race";
            this.btnStartRace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartRace.ForeColor = System.Drawing.Color.Black;
            this.btnStartRace.GlowColor = System.Drawing.Color.White;
            this.btnStartRace.Location = new System.Drawing.Point(449, 3);
            this.btnStartRace.Name = "btnStartRace";
            this.btnStartRace.Size = new System.Drawing.Size(137, 166);
            this.btnStartRace.TabIndex = 4;
            this.btnStartRace.Click += new System.EventHandler(this.BtnStartRaceClick);
            // 
            // btnStartQualification
            // 
            this.btnStartQualification.BackColor = System.Drawing.Color.Transparent;
            this.btnStartQualification.BaseColor = System.Drawing.Color.Transparent;
            this.btnStartQualification.ButtonColor = System.Drawing.Color.LimeGreen;
            this.btnStartQualification.ButtonText = "Start Quali.";
            this.btnStartQualification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartQualification.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartQualification.ForeColor = System.Drawing.Color.Black;
            this.btnStartQualification.GlowColor = System.Drawing.Color.White;
            this.btnStartQualification.Location = new System.Drawing.Point(306, 3);
            this.btnStartQualification.Name = "btnStartQualification";
            this.btnStartQualification.Size = new System.Drawing.Size(137, 166);
            this.btnStartQualification.TabIndex = 3;
            this.btnStartQualification.Click += new System.EventHandler(this.BtnStartQualificationClick);
            // 
            // btnStartTraining
            // 
            this.btnStartTraining.BackColor = System.Drawing.Color.Transparent;
            this.btnStartTraining.BaseColor = System.Drawing.Color.Transparent;
            this.btnStartTraining.ButtonColor = System.Drawing.Color.LightGreen;
            this.btnStartTraining.ButtonText = "Start Train.";
            this.btnStartTraining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTraining.ForeColor = System.Drawing.Color.Black;
            this.btnStartTraining.GlowColor = System.Drawing.Color.White;
            this.btnStartTraining.Location = new System.Drawing.Point(163, 3);
            this.btnStartTraining.Name = "btnStartTraining";
            this.btnStartTraining.Size = new System.Drawing.Size(137, 166);
            this.btnStartTraining.TabIndex = 2;
            this.btnStartTraining.Click += new System.EventHandler(this.BtnStartTrainingClick);
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.Color.Transparent;
            this.btnInit.BaseColor = System.Drawing.Color.Transparent;
            this.btnInit.ButtonColor = System.Drawing.Color.Yellow;
            this.btnInit.ButtonText = "Init";
            this.btnInit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInit.ForeColor = System.Drawing.Color.Black;
            this.btnInit.GlowColor = System.Drawing.Color.White;
            this.btnInit.Location = new System.Drawing.Point(3, 3);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(137, 166);
            this.btnInit.TabIndex = 0;
            this.btnInit.Click += new System.EventHandler(this.BtnInitClick);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BaseColor = System.Drawing.Color.Transparent;
            this.btnStop.ButtonColor = System.Drawing.Color.Red;
            this.btnStop.ButtonText = "Stop";
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Black;
            this.btnStop.GlowColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(752, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(140, 166);
            this.btnStop.TabIndex = 7;
            this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(592, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 166);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(146, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 166);
            this.panel2.TabIndex = 1;
            // 
            // grpRaceControl
            // 
            this.grpRaceControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRaceControl.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpRaceControl.Controls.Add(this.tableLayoutPanel1);
            this.grpRaceControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRaceControl.Location = new System.Drawing.Point(12, 1);
            this.grpRaceControl.Name = "grpRaceControl";
            this.grpRaceControl.Size = new System.Drawing.Size(907, 197);
            this.grpRaceControl.TabIndex = 0;
            this.grpRaceControl.TabStop = false;
            this.grpRaceControl.Text = "Race Control";
            // 
            // btnRaceSettings
            // 
            this.btnRaceSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnRaceSettings.BaseColor = System.Drawing.Color.Transparent;
            this.btnRaceSettings.ButtonColor = System.Drawing.Color.LightSkyBlue;
            this.btnRaceSettings.ButtonText = "Settings";
            this.btnRaceSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRaceSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRaceSettings.ForeColor = System.Drawing.Color.Black;
            this.btnRaceSettings.GlowColor = System.Drawing.Color.White;
            this.btnRaceSettings.Location = new System.Drawing.Point(301, 3);
            this.btnRaceSettings.Name = "btnRaceSettings";
            this.btnRaceSettings.Size = new System.Drawing.Size(292, 55);
            this.btnRaceSettings.TabIndex = 0;
            this.btnRaceSettings.Click += new System.EventHandler(this.BtnRaceSettingsClick);
            // 
            // btnSoundOptions
            // 
            this.btnSoundOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnSoundOptions.BaseColor = System.Drawing.Color.Transparent;
            this.btnSoundOptions.ButtonColor = System.Drawing.Color.LightBlue;
            this.btnSoundOptions.ButtonText = "Sound";
            this.btnSoundOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSoundOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoundOptions.ForeColor = System.Drawing.Color.Black;
            this.btnSoundOptions.GlowColor = System.Drawing.Color.White;
            this.btnSoundOptions.Location = new System.Drawing.Point(599, 3);
            this.btnSoundOptions.Name = "btnSoundOptions";
            this.btnSoundOptions.Size = new System.Drawing.Size(293, 55);
            this.btnSoundOptions.TabIndex = 3;
            this.btnSoundOptions.Click += new System.EventHandler(this.BtnSoundOptionsClick);
            // 
            // btnCarsOptions
            // 
            this.btnCarsOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnCarsOptions.BaseColor = System.Drawing.Color.Transparent;
            this.btnCarsOptions.ButtonColor = System.Drawing.Color.LightBlue;
            this.btnCarsOptions.ButtonText = "Cars";
            this.btnCarsOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCarsOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarsOptions.ForeColor = System.Drawing.Color.Black;
            this.btnCarsOptions.GlowColor = System.Drawing.Color.White;
            this.btnCarsOptions.Location = new System.Drawing.Point(3, 64);
            this.btnCarsOptions.Name = "btnCarsOptions";
            this.btnCarsOptions.Size = new System.Drawing.Size(292, 55);
            this.btnCarsOptions.TabIndex = 2;
            this.btnCarsOptions.Click += new System.EventHandler(this.BtnCarsOptionsClick);
            // 
            // btnDriversOptions
            // 
            this.btnDriversOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnDriversOptions.BaseColor = System.Drawing.Color.Transparent;
            this.btnDriversOptions.ButtonColor = System.Drawing.Color.LightBlue;
            this.btnDriversOptions.ButtonText = "Drivers";
            this.btnDriversOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDriversOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDriversOptions.ForeColor = System.Drawing.Color.Black;
            this.btnDriversOptions.GlowColor = System.Drawing.Color.White;
            this.btnDriversOptions.Location = new System.Drawing.Point(301, 64);
            this.btnDriversOptions.Name = "btnDriversOptions";
            this.btnDriversOptions.Size = new System.Drawing.Size(292, 55);
            this.btnDriversOptions.TabIndex = 1;
            this.btnDriversOptions.Click += new System.EventHandler(this.BtnDriversOptionsClick);
            // 
            // grpOptions
            // 
            this.grpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOptions.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpOptions.Controls.Add(this.tableLayoutPanel2);
            this.grpOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOptions.Location = new System.Drawing.Point(12, 384);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(907, 147);
            this.grpOptions.TabIndex = 3;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnLogging, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnSoundMixer, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRaceSettings, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDriversOptions, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnCarsOptions, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnSoundOptions, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(895, 122);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnSoundMixer
            // 
            this.btnSoundMixer.BackColor = System.Drawing.Color.Transparent;
            this.btnSoundMixer.BaseColor = System.Drawing.Color.Transparent;
            this.btnSoundMixer.ButtonColor = System.Drawing.Color.LightBlue;
            this.btnSoundMixer.ButtonText = "Mixer";
            this.btnSoundMixer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSoundMixer.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoundMixer.ForeColor = System.Drawing.Color.Black;
            this.btnSoundMixer.GlowColor = System.Drawing.Color.White;
            this.btnSoundMixer.Location = new System.Drawing.Point(3, 3);
            this.btnSoundMixer.Name = "btnSoundMixer";
            this.btnSoundMixer.Size = new System.Drawing.Size(292, 55);
            this.btnSoundMixer.TabIndex = 4;
            this.btnSoundMixer.Click += new System.EventHandler(this.BtnSoundMixerClick);
            // 
            // grpSerialPort
            // 
            this.grpSerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSerialPort.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpSerialPort.Controls.Add(this.tableLayoutPanel4);
            this.grpSerialPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSerialPort.Location = new System.Drawing.Point(3, 3);
            this.grpSerialPort.Name = "grpSerialPort";
            this.grpSerialPort.Size = new System.Drawing.Size(447, 89);
            this.grpSerialPort.TabIndex = 0;
            this.grpSerialPort.TabStop = false;
            this.grpSerialPort.Text = "Arduino";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lblComPortStatus, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this._btnConfigureArduino, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 25);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(435, 58);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lblComPortStatus
            // 
            this.lblComPortStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblComPortStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComPortStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComPortStatus.Location = new System.Drawing.Point(220, 0);
            this.lblComPortStatus.Name = "lblComPortStatus";
            this.lblComPortStatus.Size = new System.Drawing.Size(212, 58);
            this.lblComPortStatus.TabIndex = 2;
            this.lblComPortStatus.Text = "____";
            this.lblComPortStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _btnConfigureArduino
            // 
            this._btnConfigureArduino.BackColor = System.Drawing.Color.Transparent;
            this._btnConfigureArduino.BaseColor = System.Drawing.Color.Transparent;
            this._btnConfigureArduino.ButtonColor = System.Drawing.Color.MediumSlateBlue;
            this._btnConfigureArduino.ButtonText = "Config.";
            this._btnConfigureArduino.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnConfigureArduino.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnConfigureArduino.ForeColor = System.Drawing.Color.Black;
            this._btnConfigureArduino.GlowColor = System.Drawing.Color.White;
            this._btnConfigureArduino.Location = new System.Drawing.Point(3, 3);
            this._btnConfigureArduino.Name = "_btnConfigureArduino";
            this._btnConfigureArduino.Size = new System.Drawing.Size(211, 52);
            this._btnConfigureArduino.TabIndex = 0;
            this._btnConfigureArduino.Click += new System.EventHandler(this.BtnConfigureArduinoClick);
            // 
            // grpRace
            // 
            this.grpRace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRace.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpRace.Controls.Add(this.tableLayoutPanel3);
            this.grpRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRace.Location = new System.Drawing.Point(12, 198);
            this.grpRace.Name = "grpRace";
            this.grpRace.Size = new System.Drawing.Size(907, 93);
            this.grpRace.TabIndex = 1;
            this.grpRace.TabStop = false;
            this.grpRace.Text = "Race";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.btnChangeRace, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnShowRaceView, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(895, 68);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnChangeRace
            // 
            this.btnChangeRace.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeRace.BaseColor = System.Drawing.Color.Transparent;
            this.btnChangeRace.ButtonColor = System.Drawing.Color.PaleGoldenrod;
            this.btnChangeRace.ButtonText = "Change Race Data";
            this.btnChangeRace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeRace.ForeColor = System.Drawing.Color.Black;
            this.btnChangeRace.GlowColor = System.Drawing.Color.White;
            this.btnChangeRace.Location = new System.Drawing.Point(450, 3);
            this.btnChangeRace.Name = "btnChangeRace";
            this.btnChangeRace.Size = new System.Drawing.Size(442, 62);
            this.btnChangeRace.TabIndex = 1;
            this.btnChangeRace.Click += new System.EventHandler(this.BtnChangeRaceClick);
            // 
            // btnShowRaceView
            // 
            this.btnShowRaceView.BackColor = System.Drawing.Color.Transparent;
            this.btnShowRaceView.BaseColor = System.Drawing.Color.Transparent;
            this.btnShowRaceView.ButtonColor = System.Drawing.Color.LemonChiffon;
            this.btnShowRaceView.ButtonText = "Show Race View";
            this.btnShowRaceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowRaceView.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowRaceView.ForeColor = System.Drawing.Color.Black;
            this.btnShowRaceView.GlowColor = System.Drawing.Color.White;
            this.btnShowRaceView.Location = new System.Drawing.Point(3, 3);
            this.btnShowRaceView.Name = "btnShowRaceView";
            this.btnShowRaceView.Size = new System.Drawing.Size(441, 62);
            this.btnShowRaceView.TabIndex = 0;
            this.btnShowRaceView.Click += new System.EventHandler(this.BtnShowRaceViewClick);
            // 
            // btnLogging
            // 
            this.btnLogging.BackColor = System.Drawing.Color.Transparent;
            this.btnLogging.BaseColor = System.Drawing.Color.Transparent;
            this.btnLogging.ButtonColor = System.Drawing.Color.LightCyan;
            this.btnLogging.ButtonText = "Logging";
            this.btnLogging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogging.ForeColor = System.Drawing.Color.Black;
            this.btnLogging.GlowColor = System.Drawing.Color.White;
            this.btnLogging.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogging.Location = new System.Drawing.Point(599, 64);
            this.btnLogging.Name = "btnLogging";
            this.btnLogging.Size = new System.Drawing.Size(293, 55);
            this.btnLogging.TabIndex = 1;
            this.btnLogging.Click += new System.EventHandler(this.BtnLoggingClick);
            // 
            // grpResults
            // 
            this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResults.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpResults.Controls.Add(this.tableLayoutPanel6);
            this.grpResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResults.Location = new System.Drawing.Point(12, 291);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(907, 93);
            this.grpResults.TabIndex = 2;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Race Results /Championships";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel6.Controls.Add(this.btnStatistics, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnShowChampionships, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnShowRaceResults, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(895, 68);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.Color.Transparent;
            this.btnStatistics.BaseColor = System.Drawing.Color.Transparent;
            this.btnStatistics.ButtonColor = System.Drawing.Color.Goldenrod;
            this.btnStatistics.ButtonText = "Statistics";
            this.btnStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.ForeColor = System.Drawing.Color.Black;
            this.btnStatistics.GlowColor = System.Drawing.Color.White;
            this.btnStatistics.Location = new System.Drawing.Point(599, 3);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(293, 62);
            this.btnStatistics.TabIndex = 2;
            this.btnStatistics.Click += new System.EventHandler(this.BtnStatisticsClick);
            // 
            // btnShowChampionships
            // 
            this.btnShowChampionships.BackColor = System.Drawing.Color.Transparent;
            this.btnShowChampionships.BaseColor = System.Drawing.Color.Transparent;
            this.btnShowChampionships.ButtonColor = System.Drawing.Color.Gold;
            this.btnShowChampionships.ButtonText = "Championships";
            this.btnShowChampionships.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowChampionships.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowChampionships.ForeColor = System.Drawing.Color.Black;
            this.btnShowChampionships.GlowColor = System.Drawing.Color.White;
            this.btnShowChampionships.Location = new System.Drawing.Point(301, 3);
            this.btnShowChampionships.Name = "btnShowChampionships";
            this.btnShowChampionships.Size = new System.Drawing.Size(292, 62);
            this.btnShowChampionships.TabIndex = 1;
            this.btnShowChampionships.Click += new System.EventHandler(this.BtnShowChampionshipsClick);
            // 
            // btnShowRaceResults
            // 
            this.btnShowRaceResults.BackColor = System.Drawing.Color.Transparent;
            this.btnShowRaceResults.BaseColor = System.Drawing.Color.Transparent;
            this.btnShowRaceResults.ButtonColor = System.Drawing.Color.Moccasin;
            this.btnShowRaceResults.ButtonText = "Race Results";
            this.btnShowRaceResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowRaceResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowRaceResults.ForeColor = System.Drawing.Color.Black;
            this.btnShowRaceResults.GlowColor = System.Drawing.Color.White;
            this.btnShowRaceResults.Location = new System.Drawing.Point(3, 3);
            this.btnShowRaceResults.Name = "btnShowRaceResults";
            this.btnShowRaceResults.Size = new System.Drawing.Size(292, 62);
            this.btnShowRaceResults.TabIndex = 0;
            this.btnShowRaceResults.Click += new System.EventHandler(this.BtnShowRaceResultsClick);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.grpSerialPort, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(12, 537);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(907, 95);
            this.tableLayoutPanel8.TabIndex = 7;
            // 
            // RaceControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.ClientSize = new System.Drawing.Size(931, 646);
            this.Controls.Add(this.tableLayoutPanel8);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.grpRace);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.grpRaceControl);
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(2939, 2655);
            this.MinimumSize = new System.Drawing.Size(939, 673);
            this.Name = "RaceControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Race Control {Pos 1}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RaceControlFormFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RaceControlFormFormClosed);
            this.Load += new System.EventHandler(this.RaceControlFormLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RaceControlFormKeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpRaceControl.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grpSerialPort.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.grpRace.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.grpResults.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Elreg.Controls.VistaButton btnPauseOrRestart;
        private Elreg.Controls.VistaButton btnStartRace;
        private Elreg.Controls.VistaButton btnStartQualification;
        private Elreg.Controls.VistaButton btnStartTraining;
        private Elreg.Controls.VistaButton btnInit;
        private Elreg.Controls.VistaButton btnStop;
        private System.Windows.Forms.GroupBox grpRaceControl;
        private Elreg.Controls.VistaButton btnRaceSettings;
        private Elreg.Controls.VistaButton btnSoundOptions;
        private Elreg.Controls.VistaButton btnCarsOptions;
        private Elreg.Controls.VistaButton btnDriversOptions;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox grpSerialPort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblComPortStatus;
        private Elreg.Controls.VistaButton _btnConfigureArduino;
        private System.Windows.Forms.GroupBox grpRace;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Elreg.Controls.VistaButton btnShowRaceView;
        private Elreg.Controls.VistaButton btnChangeRace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Elreg.Controls.VistaButton btnLogging;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private Elreg.Controls.VistaButton btnShowChampionships;
        private Elreg.Controls.VistaButton btnShowRaceResults;
        private Controls.VistaButton btnSoundMixer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private Controls.VistaButton btnStatistics;
    }
}