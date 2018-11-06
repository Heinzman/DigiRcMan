namespace Elreg.WindowsFormsApplication.Forms
{
    partial class RaceSettingsForm
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
            this.udLapsToDrive = new System.Windows.Forms.NumericUpDown();
            this.lblLapsToDrive = new System.Windows.Forms.Label();
            this.grpStartCountDownRace = new System.Windows.Forms.GroupBox();
            this.lblStartCountDownRaceSecs = new System.Windows.Forms.Label();
            this.udStartCountDownInitNoRace = new System.Windows.Forms.NumericUpDown();
            this.chkActivateStartCountDownRace = new Elreg.Controls.ColoredCheckbox();
            this.grpRestartCountDownRace = new System.Windows.Forms.GroupBox();
            this.lblRestartCountDownRaceSecs = new System.Windows.Forms.Label();
            this.udRestartCountDownInitNoRace = new System.Windows.Forms.NumericUpDown();
            this.chkActivateRestartCountDownRace = new Elreg.Controls.ColoredCheckbox();
            this.grpRace = new System.Windows.Forms.GroupBox();
            this.chkCountDescending = new Elreg.Controls.ColoredCheckbox();
            this.grpQualifying = new System.Windows.Forms.GroupBox();
            this.chkActivateQualiTimeBased = new Elreg.Controls.ColoredCheckbox();
            this.lblQualiBreaks = new System.Windows.Forms.Label();
            this.lblQualiMinutes = new System.Windows.Forms.Label();
            this.udQualificationBreakCount = new System.Windows.Forms.NumericUpDown();
            this.udQualificationMinutes = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkActivateQualiLapBased = new Elreg.Controls.ColoredCheckbox();
            this.label4 = new System.Windows.Forms.Label();
            this.udQualificationMaxLaps = new System.Windows.Forms.NumericUpDown();
            this.grpMinLapTime = new System.Windows.Forms.GroupBox();
            this.lblMinLapTimeSecs = new System.Windows.Forms.Label();
            this.udSecondsForValidLap = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.btnSetDateAsEventName = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRaceTrackName = new System.Windows.Forms.TextBox();
            this.grpLanguage = new System.Windows.Forms.GroupBox();
            this.cbxLanguage = new System.Windows.Forms.ComboBox();
            this.tabPageTraining = new System.Windows.Forms.TabPage();
            this.grpStartCountDownTraining = new System.Windows.Forms.GroupBox();
            this.lblStartCountDownTrainingSecs = new System.Windows.Forms.Label();
            this.udStartCountDownInitNoTraining = new System.Windows.Forms.NumericUpDown();
            this.chkActivateStartCountDownTraining = new Elreg.Controls.ColoredCheckbox();
            this.grpRestartCountDownTraining = new System.Windows.Forms.GroupBox();
            this.lblRestartCountDownTrainingSecs = new System.Windows.Forms.Label();
            this.udRestartCountDownInitNoTraining = new System.Windows.Forms.NumericUpDown();
            this.chkActivateRestartCountDownTraining = new Elreg.Controls.ColoredCheckbox();
            this.tabPageQuali = new System.Windows.Forms.TabPage();
            this.grpStartCountDownQuali = new System.Windows.Forms.GroupBox();
            this.lblStartCountDownQualiSecs = new System.Windows.Forms.Label();
            this.udStartCountDownInitNoQuali = new System.Windows.Forms.NumericUpDown();
            this.chkActivateStartCountDownQuali = new Elreg.Controls.ColoredCheckbox();
            this.grpRestartCountDownQuali = new System.Windows.Forms.GroupBox();
            this.lblRestartCountDownQualiSecs = new System.Windows.Forms.Label();
            this.udRestartCountDownInitNoQuali = new System.Windows.Forms.NumericUpDown();
            this.chkActivateRestartCountDownQuali = new Elreg.Controls.ColoredCheckbox();
            this.tabPageRace = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDisqualificationRaceSecsCalced = new System.Windows.Forms.Label();
            this.udDisqualificationRaceSecsFactor = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkActivateDisqualificationRaceSecs = new Elreg.Controls.ColoredCheckbox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDisqualificationLapSecsCalced = new System.Windows.Forms.Label();
            this.udDisqualificationLapSecsFactor = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkActivateDisqualificationLapSecs = new Elreg.Controls.ColoredCheckbox();
            this.grpAutoDisqualificationRace = new System.Windows.Forms.GroupBox();
            this.udAutoDisqualificationRace = new System.Windows.Forms.NumericUpDown();
            this.lblAutoDisqualificationRace = new System.Windows.Forms.Label();
            this.chkActivateAutoDisqualificationRace = new Elreg.Controls.ColoredCheckbox();
            this.tabPageSound = new System.Windows.Forms.TabPage();
            this.grpDistanceBetweenSounds = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDistanceBetweenSounds = new System.Windows.Forms.TrackBar();
            this.grpActivateSplittedActionSounds = new System.Windows.Forms.GroupBox();
            this.chkActivateSplittedActionSounds = new Elreg.Controls.ColoredCheckbox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.udPointsForPosition1 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.udPointsForPosition2 = new System.Windows.Forms.NumericUpDown();
            this.udPointsForPosition3 = new System.Windows.Forms.NumericUpDown();
            this.udPointsForPosition4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.udPointsForPosition5 = new System.Windows.Forms.NumericUpDown();
            this.udPointsForPosition6 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.udLapsToDrive)).BeginInit();
            this.grpStartCountDownRace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udStartCountDownInitNoRace)).BeginInit();
            this.grpRestartCountDownRace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRestartCountDownInitNoRace)).BeginInit();
            this.grpRace.SuspendLayout();
            this.grpQualifying.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udQualificationBreakCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udQualificationMinutes)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udQualificationMaxLaps)).BeginInit();
            this.grpMinLapTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSecondsForValidLap)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpLanguage.SuspendLayout();
            this.tabPageTraining.SuspendLayout();
            this.grpStartCountDownTraining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udStartCountDownInitNoTraining)).BeginInit();
            this.grpRestartCountDownTraining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRestartCountDownInitNoTraining)).BeginInit();
            this.tabPageQuali.SuspendLayout();
            this.grpStartCountDownQuali.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udStartCountDownInitNoQuali)).BeginInit();
            this.grpRestartCountDownQuali.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRestartCountDownInitNoQuali)).BeginInit();
            this.tabPageRace.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDisqualificationRaceSecsFactor)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDisqualificationLapSecsFactor)).BeginInit();
            this.grpAutoDisqualificationRace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAutoDisqualificationRace)).BeginInit();
            this.tabPageSound.SuspendLayout();
            this.grpDistanceBetweenSounds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDistanceBetweenSounds)).BeginInit();
            this.grpActivateSplittedActionSounds.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition6)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1006, 666);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 24);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(887, 666);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 24);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // udLapsToDrive
            // 
            this.udLapsToDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udLapsToDrive.Location = new System.Drawing.Point(286, 29);
            this.udLapsToDrive.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLapsToDrive.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLapsToDrive.Name = "udLapsToDrive";
            this.udLapsToDrive.Size = new System.Drawing.Size(82, 47);
            this.udLapsToDrive.TabIndex = 1;
            this.udLapsToDrive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udLapsToDrive.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udLapsToDrive.ValueChanged += new System.EventHandler(this.UdLapsToDriveValueChanged);
            // 
            // lblLapsToDrive
            // 
            this.lblLapsToDrive.AutoSize = true;
            this.lblLapsToDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.lblLapsToDrive.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblLapsToDrive.Location = new System.Drawing.Point(15, 34);
            this.lblLapsToDrive.Name = "lblLapsToDrive";
            this.lblLapsToDrive.Size = new System.Drawing.Size(265, 39);
            this.lblLapsToDrive.TabIndex = 0;
            this.lblLapsToDrive.Text = "Anzahl Runden";
            // 
            // grpStartCountDownRace
            // 
            this.grpStartCountDownRace.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpStartCountDownRace.Controls.Add(this.lblStartCountDownRaceSecs);
            this.grpStartCountDownRace.Controls.Add(this.udStartCountDownInitNoRace);
            this.grpStartCountDownRace.Controls.Add(this.chkActivateStartCountDownRace);
            this.grpStartCountDownRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStartCountDownRace.Location = new System.Drawing.Point(8, 155);
            this.grpStartCountDownRace.Name = "grpStartCountDownRace";
            this.grpStartCountDownRace.Size = new System.Drawing.Size(382, 86);
            this.grpStartCountDownRace.TabIndex = 1;
            this.grpStartCountDownRace.TabStop = false;
            this.grpStartCountDownRace.Text = "Start CountDown";
            // 
            // lblStartCountDownRaceSecs
            // 
            this.lblStartCountDownRaceSecs.AutoSize = true;
            this.lblStartCountDownRaceSecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartCountDownRaceSecs.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblStartCountDownRaceSecs.Location = new System.Drawing.Point(199, 34);
            this.lblStartCountDownRaceSecs.Name = "lblStartCountDownRaceSecs";
            this.lblStartCountDownRaceSecs.Size = new System.Drawing.Size(91, 39);
            this.lblStartCountDownRaceSecs.TabIndex = 1;
            this.lblStartCountDownRaceSecs.Text = "Sek.";
            // 
            // udStartCountDownInitNoRace
            // 
            this.udStartCountDownInitNoRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udStartCountDownInitNoRace.Location = new System.Drawing.Point(312, 28);
            this.udStartCountDownInitNoRace.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udStartCountDownInitNoRace.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udStartCountDownInitNoRace.Name = "udStartCountDownInitNoRace";
            this.udStartCountDownInitNoRace.Size = new System.Drawing.Size(56, 47);
            this.udStartCountDownInitNoRace.TabIndex = 2;
            this.udStartCountDownInitNoRace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udStartCountDownInitNoRace.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkActivateStartCountDownRace
            // 
            this.chkActivateStartCountDownRace.AutoSize = true;
            this.chkActivateStartCountDownRace.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateStartCountDownRace.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateStartCountDownRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivateStartCountDownRace.Location = new System.Drawing.Point(22, 33);
            this.chkActivateStartCountDownRace.Name = "chkActivateStartCountDownRace";
            this.chkActivateStartCountDownRace.Size = new System.Drawing.Size(171, 43);
            this.chkActivateStartCountDownRace.TabIndex = 0;
            this.chkActivateStartCountDownRace.Text = "Aktiviert";
            this.chkActivateStartCountDownRace.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateStartCountDownRace.UseVisualStyleBackColor = true;
            // 
            // grpRestartCountDownRace
            // 
            this.grpRestartCountDownRace.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpRestartCountDownRace.Controls.Add(this.lblRestartCountDownRaceSecs);
            this.grpRestartCountDownRace.Controls.Add(this.udRestartCountDownInitNoRace);
            this.grpRestartCountDownRace.Controls.Add(this.chkActivateRestartCountDownRace);
            this.grpRestartCountDownRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRestartCountDownRace.Location = new System.Drawing.Point(8, 247);
            this.grpRestartCountDownRace.Name = "grpRestartCountDownRace";
            this.grpRestartCountDownRace.Size = new System.Drawing.Size(381, 86);
            this.grpRestartCountDownRace.TabIndex = 2;
            this.grpRestartCountDownRace.TabStop = false;
            this.grpRestartCountDownRace.Text = "Restart CountDown";
            // 
            // lblRestartCountDownRaceSecs
            // 
            this.lblRestartCountDownRaceSecs.AutoSize = true;
            this.lblRestartCountDownRaceSecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestartCountDownRaceSecs.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblRestartCountDownRaceSecs.Location = new System.Drawing.Point(199, 34);
            this.lblRestartCountDownRaceSecs.Name = "lblRestartCountDownRaceSecs";
            this.lblRestartCountDownRaceSecs.Size = new System.Drawing.Size(91, 39);
            this.lblRestartCountDownRaceSecs.TabIndex = 1;
            this.lblRestartCountDownRaceSecs.Text = "Sek.";
            // 
            // udRestartCountDownInitNoRace
            // 
            this.udRestartCountDownInitNoRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udRestartCountDownInitNoRace.Location = new System.Drawing.Point(312, 29);
            this.udRestartCountDownInitNoRace.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udRestartCountDownInitNoRace.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRestartCountDownInitNoRace.Name = "udRestartCountDownInitNoRace";
            this.udRestartCountDownInitNoRace.Size = new System.Drawing.Size(56, 47);
            this.udRestartCountDownInitNoRace.TabIndex = 2;
            this.udRestartCountDownInitNoRace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udRestartCountDownInitNoRace.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkActivateRestartCountDownRace
            // 
            this.chkActivateRestartCountDownRace.AutoSize = true;
            this.chkActivateRestartCountDownRace.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateRestartCountDownRace.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateRestartCountDownRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivateRestartCountDownRace.Location = new System.Drawing.Point(22, 33);
            this.chkActivateRestartCountDownRace.Name = "chkActivateRestartCountDownRace";
            this.chkActivateRestartCountDownRace.Size = new System.Drawing.Size(171, 43);
            this.chkActivateRestartCountDownRace.TabIndex = 0;
            this.chkActivateRestartCountDownRace.Text = "Aktiviert";
            this.chkActivateRestartCountDownRace.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateRestartCountDownRace.UseVisualStyleBackColor = true;
            // 
            // grpRace
            // 
            this.grpRace.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpRace.Controls.Add(this.udLapsToDrive);
            this.grpRace.Controls.Add(this.lblLapsToDrive);
            this.grpRace.Controls.Add(this.chkCountDescending);
            this.grpRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRace.Location = new System.Drawing.Point(6, 12);
            this.grpRace.Name = "grpRace";
            this.grpRace.Size = new System.Drawing.Size(383, 137);
            this.grpRace.TabIndex = 0;
            this.grpRace.TabStop = false;
            this.grpRace.Text = "Race";
            // 
            // chkCountDescending
            // 
            this.chkCountDescending.AutoSize = true;
            this.chkCountDescending.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkCountDescending.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkCountDescending.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.chkCountDescending.Location = new System.Drawing.Point(22, 82);
            this.chkCountDescending.Name = "chkCountDescending";
            this.chkCountDescending.Size = new System.Drawing.Size(337, 43);
            this.chkCountDescending.TabIndex = 2;
            this.chkCountDescending.Text = "Absteigend zählen";
            this.chkCountDescending.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkCountDescending.UseVisualStyleBackColor = true;
            // 
            // grpQualifying
            // 
            this.grpQualifying.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpQualifying.Controls.Add(this.chkActivateQualiTimeBased);
            this.grpQualifying.Controls.Add(this.lblQualiBreaks);
            this.grpQualifying.Controls.Add(this.lblQualiMinutes);
            this.grpQualifying.Controls.Add(this.udQualificationBreakCount);
            this.grpQualifying.Controls.Add(this.udQualificationMinutes);
            this.grpQualifying.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpQualifying.Location = new System.Drawing.Point(401, 12);
            this.grpQualifying.Name = "grpQualifying";
            this.grpQualifying.Size = new System.Drawing.Size(332, 187);
            this.grpQualifying.TabIndex = 0;
            this.grpQualifying.TabStop = false;
            this.grpQualifying.Text = "Time Based";
            // 
            // chkActivateQualiTimeBased
            // 
            this.chkActivateQualiTimeBased.AutoSize = true;
            this.chkActivateQualiTimeBased.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateQualiTimeBased.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateQualiTimeBased.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivateQualiTimeBased.Location = new System.Drawing.Point(19, 33);
            this.chkActivateQualiTimeBased.Name = "chkActivateQualiTimeBased";
            this.chkActivateQualiTimeBased.Size = new System.Drawing.Size(171, 43);
            this.chkActivateQualiTimeBased.TabIndex = 4;
            this.chkActivateQualiTimeBased.Text = "Aktiviert";
            this.chkActivateQualiTimeBased.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateQualiTimeBased.UseVisualStyleBackColor = true;
            // 
            // lblQualiBreaks
            // 
            this.lblQualiBreaks.AutoSize = true;
            this.lblQualiBreaks.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualiBreaks.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblQualiBreaks.Location = new System.Drawing.Point(15, 132);
            this.lblQualiBreaks.Name = "lblQualiBreaks";
            this.lblQualiBreaks.Size = new System.Drawing.Size(132, 39);
            this.lblQualiBreaks.TabIndex = 2;
            this.lblQualiBreaks.Text = "Breaks";
            // 
            // lblQualiMinutes
            // 
            this.lblQualiMinutes.AutoSize = true;
            this.lblQualiMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualiMinutes.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblQualiMinutes.Location = new System.Drawing.Point(15, 79);
            this.lblQualiMinutes.Name = "lblQualiMinutes";
            this.lblQualiMinutes.Size = new System.Drawing.Size(146, 39);
            this.lblQualiMinutes.TabIndex = 0;
            this.lblQualiMinutes.Text = "Minutes";
            // 
            // udQualificationBreakCount
            // 
            this.udQualificationBreakCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udQualificationBreakCount.Location = new System.Drawing.Point(261, 130);
            this.udQualificationBreakCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udQualificationBreakCount.Name = "udQualificationBreakCount";
            this.udQualificationBreakCount.Size = new System.Drawing.Size(56, 47);
            this.udQualificationBreakCount.TabIndex = 3;
            this.udQualificationBreakCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udQualificationBreakCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // udQualificationMinutes
            // 
            this.udQualificationMinutes.DecimalPlaces = 1;
            this.udQualificationMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udQualificationMinutes.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udQualificationMinutes.Location = new System.Drawing.Point(227, 80);
            this.udQualificationMinutes.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udQualificationMinutes.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.udQualificationMinutes.Name = "udQualificationMinutes";
            this.udQualificationMinutes.Size = new System.Drawing.Size(90, 47);
            this.udQualificationMinutes.TabIndex = 1;
            this.udQualificationMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udQualificationMinutes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.groupBox3.Controls.Add(this.chkActivateQualiLapBased);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.udQualificationMaxLaps);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(401, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 135);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lap Based";
            // 
            // chkActivateQualiLapBased
            // 
            this.chkActivateQualiLapBased.AutoSize = true;
            this.chkActivateQualiLapBased.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateQualiLapBased.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateQualiLapBased.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivateQualiLapBased.Location = new System.Drawing.Point(19, 28);
            this.chkActivateQualiLapBased.Name = "chkActivateQualiLapBased";
            this.chkActivateQualiLapBased.Size = new System.Drawing.Size(171, 43);
            this.chkActivateQualiLapBased.TabIndex = 5;
            this.chkActivateQualiLapBased.Text = "Aktiviert";
            this.chkActivateQualiLapBased.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateQualiLapBased.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 39);
            this.label4.TabIndex = 0;
            this.label4.Text = "Max Laps";
            // 
            // udQualificationMaxLaps
            // 
            this.udQualificationMaxLaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udQualificationMaxLaps.Location = new System.Drawing.Point(224, 66);
            this.udQualificationMaxLaps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udQualificationMaxLaps.Name = "udQualificationMaxLaps";
            this.udQualificationMaxLaps.Size = new System.Drawing.Size(90, 47);
            this.udQualificationMaxLaps.TabIndex = 3;
            this.udQualificationMaxLaps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udQualificationMaxLaps.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // grpMinLapTime
            // 
            this.grpMinLapTime.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpMinLapTime.Controls.Add(this.lblMinLapTimeSecs);
            this.grpMinLapTime.Controls.Add(this.udSecondsForValidLap);
            this.grpMinLapTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMinLapTime.Location = new System.Drawing.Point(356, 98);
            this.grpMinLapTime.Name = "grpMinLapTime";
            this.grpMinLapTime.Size = new System.Drawing.Size(323, 86);
            this.grpMinLapTime.TabIndex = 4;
            this.grpMinLapTime.TabStop = false;
            this.grpMinLapTime.Text = "Min Lap Time";
            // 
            // lblMinLapTimeSecs
            // 
            this.lblMinLapTimeSecs.AutoSize = true;
            this.lblMinLapTimeSecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinLapTimeSecs.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblMinLapTimeSecs.Location = new System.Drawing.Point(15, 31);
            this.lblMinLapTimeSecs.Name = "lblMinLapTimeSecs";
            this.lblMinLapTimeSecs.Size = new System.Drawing.Size(91, 39);
            this.lblMinLapTimeSecs.TabIndex = 0;
            this.lblMinLapTimeSecs.Text = "Sec.";
            // 
            // udSecondsForValidLap
            // 
            this.udSecondsForValidLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udSecondsForValidLap.Location = new System.Drawing.Point(248, 23);
            this.udSecondsForValidLap.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udSecondsForValidLap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udSecondsForValidLap.Name = "udSecondsForValidLap";
            this.udSecondsForValidLap.Size = new System.Drawing.Size(69, 47);
            this.udSecondsForValidLap.TabIndex = 1;
            this.udSecondsForValidLap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udSecondsForValidLap.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udSecondsForValidLap.ValueChanged += new System.EventHandler(this.UdSecondsForValidLapValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageCommon);
            this.tabControl1.Controls.Add(this.tabPageTraining);
            this.tabControl1.Controls.Add(this.tabPageQuali);
            this.tabControl1.Controls.Add(this.tabPageRace);
            this.tabControl1.Controls.Add(this.tabPageSound);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.tabControl1.Location = new System.Drawing.Point(4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1115, 657);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tabPageCommon.Controls.Add(this.groupBox2);
            this.tabPageCommon.Controls.Add(this.groupBox1);
            this.tabPageCommon.Controls.Add(this.grpLanguage);
            this.tabPageCommon.Controls.Add(this.grpMinLapTime);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 33);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommon.Size = new System.Drawing.Size(1107, 620);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = "Allgemein";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.groupBox2.Controls.Add(this.txtEventName);
            this.groupBox2.Controls.Add(this.btnSetDateAsEventName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 131);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Event Name";
            // 
            // txtEventName
            // 
            this.txtEventName.BackColor = System.Drawing.SystemColors.Info;
            this.txtEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.txtEventName.Location = new System.Drawing.Point(15, 25);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(292, 47);
            this.txtEventName.TabIndex = 0;
            // 
            // btnSetDateAsEventName
            // 
            this.btnSetDateAsEventName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetDateAsEventName.Location = new System.Drawing.Point(15, 82);
            this.btnSetDateAsEventName.Name = "btnSetDateAsEventName";
            this.btnSetDateAsEventName.Size = new System.Drawing.Size(292, 34);
            this.btnSetDateAsEventName.TabIndex = 8;
            this.btnSetDateAsEventName.Text = "Set Date as Name";
            this.btnSetDateAsEventName.UseVisualStyleBackColor = true;
            this.btnSetDateAsEventName.Click += new System.EventHandler(this.BtnSetDateAsEventNameClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.groupBox1.Controls.Add(this.txtRaceTrackName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 86);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Race Track Name";
            // 
            // txtRaceTrackName
            // 
            this.txtRaceTrackName.BackColor = System.Drawing.SystemColors.Info;
            this.txtRaceTrackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.txtRaceTrackName.Location = new System.Drawing.Point(15, 25);
            this.txtRaceTrackName.Name = "txtRaceTrackName";
            this.txtRaceTrackName.Size = new System.Drawing.Size(292, 47);
            this.txtRaceTrackName.TabIndex = 0;
            // 
            // grpLanguage
            // 
            this.grpLanguage.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpLanguage.Controls.Add(this.cbxLanguage);
            this.grpLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLanguage.Location = new System.Drawing.Point(356, 6);
            this.grpLanguage.Name = "grpLanguage";
            this.grpLanguage.Size = new System.Drawing.Size(323, 86);
            this.grpLanguage.TabIndex = 2;
            this.grpLanguage.TabStop = false;
            this.grpLanguage.Text = "Sprache";
            // 
            // cbxLanguage
            // 
            this.cbxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLanguage.FormattingEnabled = true;
            this.cbxLanguage.Location = new System.Drawing.Point(9, 28);
            this.cbxLanguage.Name = "cbxLanguage";
            this.cbxLanguage.Size = new System.Drawing.Size(308, 39);
            this.cbxLanguage.TabIndex = 0;
            // 
            // tabPageTraining
            // 
            this.tabPageTraining.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tabPageTraining.Controls.Add(this.grpStartCountDownTraining);
            this.tabPageTraining.Controls.Add(this.grpRestartCountDownTraining);
            this.tabPageTraining.Location = new System.Drawing.Point(4, 33);
            this.tabPageTraining.Name = "tabPageTraining";
            this.tabPageTraining.Size = new System.Drawing.Size(1107, 620);
            this.tabPageTraining.TabIndex = 3;
            this.tabPageTraining.Text = "Training";
            this.tabPageTraining.UseVisualStyleBackColor = true;
            // 
            // grpStartCountDownTraining
            // 
            this.grpStartCountDownTraining.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpStartCountDownTraining.Controls.Add(this.lblStartCountDownTrainingSecs);
            this.grpStartCountDownTraining.Controls.Add(this.udStartCountDownInitNoTraining);
            this.grpStartCountDownTraining.Controls.Add(this.chkActivateStartCountDownTraining);
            this.grpStartCountDownTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStartCountDownTraining.Location = new System.Drawing.Point(4, 3);
            this.grpStartCountDownTraining.Name = "grpStartCountDownTraining";
            this.grpStartCountDownTraining.Size = new System.Drawing.Size(382, 86);
            this.grpStartCountDownTraining.TabIndex = 0;
            this.grpStartCountDownTraining.TabStop = false;
            this.grpStartCountDownTraining.Text = "Start CountDown";
            // 
            // lblStartCountDownTrainingSecs
            // 
            this.lblStartCountDownTrainingSecs.AutoSize = true;
            this.lblStartCountDownTrainingSecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartCountDownTrainingSecs.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblStartCountDownTrainingSecs.Location = new System.Drawing.Point(199, 34);
            this.lblStartCountDownTrainingSecs.Name = "lblStartCountDownTrainingSecs";
            this.lblStartCountDownTrainingSecs.Size = new System.Drawing.Size(91, 39);
            this.lblStartCountDownTrainingSecs.TabIndex = 2;
            this.lblStartCountDownTrainingSecs.Text = "Sek.";
            // 
            // udStartCountDownInitNoTraining
            // 
            this.udStartCountDownInitNoTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udStartCountDownInitNoTraining.Location = new System.Drawing.Point(306, 28);
            this.udStartCountDownInitNoTraining.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udStartCountDownInitNoTraining.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udStartCountDownInitNoTraining.Name = "udStartCountDownInitNoTraining";
            this.udStartCountDownInitNoTraining.Size = new System.Drawing.Size(56, 47);
            this.udStartCountDownInitNoTraining.TabIndex = 0;
            this.udStartCountDownInitNoTraining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udStartCountDownInitNoTraining.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkActivateStartCountDownTraining
            // 
            this.chkActivateStartCountDownTraining.AutoSize = true;
            this.chkActivateStartCountDownTraining.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateStartCountDownTraining.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateStartCountDownTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivateStartCountDownTraining.Location = new System.Drawing.Point(22, 33);
            this.chkActivateStartCountDownTraining.Name = "chkActivateStartCountDownTraining";
            this.chkActivateStartCountDownTraining.Size = new System.Drawing.Size(171, 43);
            this.chkActivateStartCountDownTraining.TabIndex = 0;
            this.chkActivateStartCountDownTraining.Text = "Aktiviert";
            this.chkActivateStartCountDownTraining.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateStartCountDownTraining.UseVisualStyleBackColor = true;
            // 
            // grpRestartCountDownTraining
            // 
            this.grpRestartCountDownTraining.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpRestartCountDownTraining.Controls.Add(this.lblRestartCountDownTrainingSecs);
            this.grpRestartCountDownTraining.Controls.Add(this.udRestartCountDownInitNoTraining);
            this.grpRestartCountDownTraining.Controls.Add(this.chkActivateRestartCountDownTraining);
            this.grpRestartCountDownTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRestartCountDownTraining.Location = new System.Drawing.Point(4, 95);
            this.grpRestartCountDownTraining.Name = "grpRestartCountDownTraining";
            this.grpRestartCountDownTraining.Size = new System.Drawing.Size(381, 86);
            this.grpRestartCountDownTraining.TabIndex = 1;
            this.grpRestartCountDownTraining.TabStop = false;
            this.grpRestartCountDownTraining.Text = "Restart CountDown";
            // 
            // lblRestartCountDownTrainingSecs
            // 
            this.lblRestartCountDownTrainingSecs.AutoSize = true;
            this.lblRestartCountDownTrainingSecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestartCountDownTrainingSecs.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblRestartCountDownTrainingSecs.Location = new System.Drawing.Point(199, 34);
            this.lblRestartCountDownTrainingSecs.Name = "lblRestartCountDownTrainingSecs";
            this.lblRestartCountDownTrainingSecs.Size = new System.Drawing.Size(91, 39);
            this.lblRestartCountDownTrainingSecs.TabIndex = 1;
            this.lblRestartCountDownTrainingSecs.Text = "Sek.";
            // 
            // udRestartCountDownInitNoTraining
            // 
            this.udRestartCountDownInitNoTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udRestartCountDownInitNoTraining.Location = new System.Drawing.Point(306, 28);
            this.udRestartCountDownInitNoTraining.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udRestartCountDownInitNoTraining.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRestartCountDownInitNoTraining.Name = "udRestartCountDownInitNoTraining";
            this.udRestartCountDownInitNoTraining.Size = new System.Drawing.Size(56, 47);
            this.udRestartCountDownInitNoTraining.TabIndex = 2;
            this.udRestartCountDownInitNoTraining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udRestartCountDownInitNoTraining.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkActivateRestartCountDownTraining
            // 
            this.chkActivateRestartCountDownTraining.AutoSize = true;
            this.chkActivateRestartCountDownTraining.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateRestartCountDownTraining.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateRestartCountDownTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivateRestartCountDownTraining.Location = new System.Drawing.Point(22, 33);
            this.chkActivateRestartCountDownTraining.Name = "chkActivateRestartCountDownTraining";
            this.chkActivateRestartCountDownTraining.Size = new System.Drawing.Size(171, 43);
            this.chkActivateRestartCountDownTraining.TabIndex = 0;
            this.chkActivateRestartCountDownTraining.Text = "Aktiviert";
            this.chkActivateRestartCountDownTraining.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateRestartCountDownTraining.UseVisualStyleBackColor = true;
            // 
            // tabPageQuali
            // 
            this.tabPageQuali.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tabPageQuali.Controls.Add(this.groupBox3);
            this.tabPageQuali.Controls.Add(this.grpStartCountDownQuali);
            this.tabPageQuali.Controls.Add(this.grpRestartCountDownQuali);
            this.tabPageQuali.Controls.Add(this.grpQualifying);
            this.tabPageQuali.Location = new System.Drawing.Point(4, 33);
            this.tabPageQuali.Name = "tabPageQuali";
            this.tabPageQuali.Size = new System.Drawing.Size(1107, 620);
            this.tabPageQuali.TabIndex = 2;
            this.tabPageQuali.Text = "Quali.";
            this.tabPageQuali.UseVisualStyleBackColor = true;
            // 
            // grpStartCountDownQuali
            // 
            this.grpStartCountDownQuali.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpStartCountDownQuali.Controls.Add(this.lblStartCountDownQualiSecs);
            this.grpStartCountDownQuali.Controls.Add(this.udStartCountDownInitNoQuali);
            this.grpStartCountDownQuali.Controls.Add(this.chkActivateStartCountDownQuali);
            this.grpStartCountDownQuali.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStartCountDownQuali.Location = new System.Drawing.Point(13, 12);
            this.grpStartCountDownQuali.Name = "grpStartCountDownQuali";
            this.grpStartCountDownQuali.Size = new System.Drawing.Size(382, 86);
            this.grpStartCountDownQuali.TabIndex = 1;
            this.grpStartCountDownQuali.TabStop = false;
            this.grpStartCountDownQuali.Text = "Start CountDown";
            // 
            // lblStartCountDownQualiSecs
            // 
            this.lblStartCountDownQualiSecs.AutoSize = true;
            this.lblStartCountDownQualiSecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartCountDownQualiSecs.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblStartCountDownQualiSecs.Location = new System.Drawing.Point(199, 34);
            this.lblStartCountDownQualiSecs.Name = "lblStartCountDownQualiSecs";
            this.lblStartCountDownQualiSecs.Size = new System.Drawing.Size(91, 39);
            this.lblStartCountDownQualiSecs.TabIndex = 1;
            this.lblStartCountDownQualiSecs.Text = "Sek.";
            // 
            // udStartCountDownInitNoQuali
            // 
            this.udStartCountDownInitNoQuali.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udStartCountDownInitNoQuali.Location = new System.Drawing.Point(306, 28);
            this.udStartCountDownInitNoQuali.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udStartCountDownInitNoQuali.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udStartCountDownInitNoQuali.Name = "udStartCountDownInitNoQuali";
            this.udStartCountDownInitNoQuali.Size = new System.Drawing.Size(56, 47);
            this.udStartCountDownInitNoQuali.TabIndex = 2;
            this.udStartCountDownInitNoQuali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udStartCountDownInitNoQuali.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkActivateStartCountDownQuali
            // 
            this.chkActivateStartCountDownQuali.AutoSize = true;
            this.chkActivateStartCountDownQuali.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateStartCountDownQuali.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateStartCountDownQuali.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivateStartCountDownQuali.Location = new System.Drawing.Point(22, 33);
            this.chkActivateStartCountDownQuali.Name = "chkActivateStartCountDownQuali";
            this.chkActivateStartCountDownQuali.Size = new System.Drawing.Size(171, 43);
            this.chkActivateStartCountDownQuali.TabIndex = 0;
            this.chkActivateStartCountDownQuali.Text = "Aktiviert";
            this.chkActivateStartCountDownQuali.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateStartCountDownQuali.UseVisualStyleBackColor = true;
            // 
            // grpRestartCountDownQuali
            // 
            this.grpRestartCountDownQuali.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpRestartCountDownQuali.Controls.Add(this.lblRestartCountDownQualiSecs);
            this.grpRestartCountDownQuali.Controls.Add(this.udRestartCountDownInitNoQuali);
            this.grpRestartCountDownQuali.Controls.Add(this.chkActivateRestartCountDownQuali);
            this.grpRestartCountDownQuali.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRestartCountDownQuali.Location = new System.Drawing.Point(13, 104);
            this.grpRestartCountDownQuali.Name = "grpRestartCountDownQuali";
            this.grpRestartCountDownQuali.Size = new System.Drawing.Size(381, 86);
            this.grpRestartCountDownQuali.TabIndex = 2;
            this.grpRestartCountDownQuali.TabStop = false;
            this.grpRestartCountDownQuali.Text = "Restart CountDown";
            // 
            // lblRestartCountDownQualiSecs
            // 
            this.lblRestartCountDownQualiSecs.AutoSize = true;
            this.lblRestartCountDownQualiSecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestartCountDownQualiSecs.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblRestartCountDownQualiSecs.Location = new System.Drawing.Point(199, 34);
            this.lblRestartCountDownQualiSecs.Name = "lblRestartCountDownQualiSecs";
            this.lblRestartCountDownQualiSecs.Size = new System.Drawing.Size(91, 39);
            this.lblRestartCountDownQualiSecs.TabIndex = 1;
            this.lblRestartCountDownQualiSecs.Text = "Sek.";
            // 
            // udRestartCountDownInitNoQuali
            // 
            this.udRestartCountDownInitNoQuali.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udRestartCountDownInitNoQuali.Location = new System.Drawing.Point(306, 28);
            this.udRestartCountDownInitNoQuali.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udRestartCountDownInitNoQuali.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRestartCountDownInitNoQuali.Name = "udRestartCountDownInitNoQuali";
            this.udRestartCountDownInitNoQuali.Size = new System.Drawing.Size(56, 47);
            this.udRestartCountDownInitNoQuali.TabIndex = 2;
            this.udRestartCountDownInitNoQuali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udRestartCountDownInitNoQuali.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkActivateRestartCountDownQuali
            // 
            this.chkActivateRestartCountDownQuali.AutoSize = true;
            this.chkActivateRestartCountDownQuali.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateRestartCountDownQuali.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateRestartCountDownQuali.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivateRestartCountDownQuali.Location = new System.Drawing.Point(22, 33);
            this.chkActivateRestartCountDownQuali.Name = "chkActivateRestartCountDownQuali";
            this.chkActivateRestartCountDownQuali.Size = new System.Drawing.Size(171, 43);
            this.chkActivateRestartCountDownQuali.TabIndex = 0;
            this.chkActivateRestartCountDownQuali.Text = "Aktiviert";
            this.chkActivateRestartCountDownQuali.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateRestartCountDownQuali.UseVisualStyleBackColor = true;
            // 
            // tabPageRace
            // 
            this.tabPageRace.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tabPageRace.Controls.Add(this.groupBox6);
            this.tabPageRace.Controls.Add(this.groupBox5);
            this.tabPageRace.Controls.Add(this.groupBox4);
            this.tabPageRace.Controls.Add(this.grpAutoDisqualificationRace);
            this.tabPageRace.Controls.Add(this.grpRace);
            this.tabPageRace.Controls.Add(this.grpStartCountDownRace);
            this.tabPageRace.Controls.Add(this.grpRestartCountDownRace);
            this.tabPageRace.Location = new System.Drawing.Point(4, 33);
            this.tabPageRace.Name = "tabPageRace";
            this.tabPageRace.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRace.Size = new System.Drawing.Size(1107, 620);
            this.tabPageRace.TabIndex = 1;
            this.tabPageRace.Text = "Race";
            this.tabPageRace.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.lblDisqualificationRaceSecsCalced);
            this.groupBox5.Controls.Add(this.udDisqualificationRaceSecsFactor);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.chkActivateDisqualificationRaceSecs);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(395, 298);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(670, 137);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Disqualification max Racetime";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.label8.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label8.Location = new System.Drawing.Point(433, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 39);
            this.label8.TabIndex = 3;
            this.label8.Text = "=";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.label9.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label9.Location = new System.Drawing.Point(556, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 39);
            this.label9.TabIndex = 3;
            this.label9.Text = "Secs";
            // 
            // lblDisqualificationRaceSecsCalced
            // 
            this.lblDisqualificationRaceSecsCalced.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.lblDisqualificationRaceSecsCalced.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblDisqualificationRaceSecsCalced.Location = new System.Drawing.Point(469, 83);
            this.lblDisqualificationRaceSecsCalced.Name = "lblDisqualificationRaceSecsCalced";
            this.lblDisqualificationRaceSecsCalced.Size = new System.Drawing.Size(90, 39);
            this.lblDisqualificationRaceSecsCalced.TabIndex = 3;
            this.lblDisqualificationRaceSecsCalced.Text = "...";
            this.lblDisqualificationRaceSecsCalced.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // udDisqualificationRaceSecsFactor
            // 
            this.udDisqualificationRaceSecsFactor.DecimalPlaces = 1;
            this.udDisqualificationRaceSecsFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udDisqualificationRaceSecsFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udDisqualificationRaceSecsFactor.Location = new System.Drawing.Point(327, 81);
            this.udDisqualificationRaceSecsFactor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udDisqualificationRaceSecsFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udDisqualificationRaceSecsFactor.Name = "udDisqualificationRaceSecsFactor";
            this.udDisqualificationRaceSecsFactor.Size = new System.Drawing.Size(104, 47);
            this.udDisqualificationRaceSecsFactor.TabIndex = 1;
            this.udDisqualificationRaceSecsFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udDisqualificationRaceSecsFactor.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.udDisqualificationRaceSecsFactor.ValueChanged += new System.EventHandler(this.UdDisqualificationRaceSecsFactorValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.label5.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label5.Location = new System.Drawing.Point(11, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(307, 39);
            this.label5.TabIndex = 0;
            this.label5.Text = "Min Secs * Laps *";
            // 
            // chkActivateDisqualificationRaceSecs
            // 
            this.chkActivateDisqualificationRaceSecs.AutoSize = true;
            this.chkActivateDisqualificationRaceSecs.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateDisqualificationRaceSecs.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateDisqualificationRaceSecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.chkActivateDisqualificationRaceSecs.Location = new System.Drawing.Point(18, 33);
            this.chkActivateDisqualificationRaceSecs.Name = "chkActivateDisqualificationRaceSecs";
            this.chkActivateDisqualificationRaceSecs.Size = new System.Drawing.Size(189, 43);
            this.chkActivateDisqualificationRaceSecs.TabIndex = 2;
            this.chkActivateDisqualificationRaceSecs.Text = "Activated";
            this.chkActivateDisqualificationRaceSecs.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateDisqualificationRaceSecs.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lblDisqualificationLapSecsCalced);
            this.groupBox4.Controls.Add(this.udDisqualificationLapSecsFactor);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.chkActivateDisqualificationLapSecs);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(396, 155);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(670, 137);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Disqualification Max Laptime";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.label7.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label7.Location = new System.Drawing.Point(319, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 39);
            this.label7.TabIndex = 3;
            this.label7.Text = "=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.label6.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label6.Location = new System.Drawing.Point(440, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 39);
            this.label6.TabIndex = 3;
            this.label6.Text = "Secs";
            // 
            // lblDisqualificationLapSecsCalced
            // 
            this.lblDisqualificationLapSecsCalced.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.lblDisqualificationLapSecsCalced.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblDisqualificationLapSecsCalced.Location = new System.Drawing.Point(352, 83);
            this.lblDisqualificationLapSecsCalced.Name = "lblDisqualificationLapSecsCalced";
            this.lblDisqualificationLapSecsCalced.Size = new System.Drawing.Size(92, 39);
            this.lblDisqualificationLapSecsCalced.TabIndex = 3;
            this.lblDisqualificationLapSecsCalced.Text = "...";
            this.lblDisqualificationLapSecsCalced.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // udDisqualificationLapSecsFactor
            // 
            this.udDisqualificationLapSecsFactor.DecimalPlaces = 1;
            this.udDisqualificationLapSecsFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udDisqualificationLapSecsFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udDisqualificationLapSecsFactor.Location = new System.Drawing.Point(210, 81);
            this.udDisqualificationLapSecsFactor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udDisqualificationLapSecsFactor.Minimum = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            this.udDisqualificationLapSecsFactor.Name = "udDisqualificationLapSecsFactor";
            this.udDisqualificationLapSecsFactor.Size = new System.Drawing.Size(103, 47);
            this.udDisqualificationLapSecsFactor.TabIndex = 1;
            this.udDisqualificationLapSecsFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udDisqualificationLapSecsFactor.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.udDisqualificationLapSecsFactor.ValueChanged += new System.EventHandler(this.UdDisqualificationLapSecsFactorValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.label3.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label3.Location = new System.Drawing.Point(11, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "Min Secs *";
            // 
            // chkActivateDisqualificationLapSecs
            // 
            this.chkActivateDisqualificationLapSecs.AutoSize = true;
            this.chkActivateDisqualificationLapSecs.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateDisqualificationLapSecs.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateDisqualificationLapSecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.chkActivateDisqualificationLapSecs.Location = new System.Drawing.Point(18, 33);
            this.chkActivateDisqualificationLapSecs.Name = "chkActivateDisqualificationLapSecs";
            this.chkActivateDisqualificationLapSecs.Size = new System.Drawing.Size(189, 43);
            this.chkActivateDisqualificationLapSecs.TabIndex = 2;
            this.chkActivateDisqualificationLapSecs.Text = "Activated";
            this.chkActivateDisqualificationLapSecs.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateDisqualificationLapSecs.UseVisualStyleBackColor = true;
            // 
            // grpAutoDisqualificationRace
            // 
            this.grpAutoDisqualificationRace.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpAutoDisqualificationRace.Controls.Add(this.udAutoDisqualificationRace);
            this.grpAutoDisqualificationRace.Controls.Add(this.lblAutoDisqualificationRace);
            this.grpAutoDisqualificationRace.Controls.Add(this.chkActivateAutoDisqualificationRace);
            this.grpAutoDisqualificationRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAutoDisqualificationRace.Location = new System.Drawing.Point(396, 12);
            this.grpAutoDisqualificationRace.Name = "grpAutoDisqualificationRace";
            this.grpAutoDisqualificationRace.Size = new System.Drawing.Size(670, 137);
            this.grpAutoDisqualificationRace.TabIndex = 0;
            this.grpAutoDisqualificationRace.TabStop = false;
            this.grpAutoDisqualificationRace.Text = "Disqualifikation nach Strafen";
            // 
            // udAutoDisqualificationRace
            // 
            this.udAutoDisqualificationRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udAutoDisqualificationRace.Location = new System.Drawing.Point(248, 81);
            this.udAutoDisqualificationRace.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udAutoDisqualificationRace.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udAutoDisqualificationRace.Name = "udAutoDisqualificationRace";
            this.udAutoDisqualificationRace.Size = new System.Drawing.Size(89, 47);
            this.udAutoDisqualificationRace.TabIndex = 1;
            this.udAutoDisqualificationRace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udAutoDisqualificationRace.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblAutoDisqualificationRace
            // 
            this.lblAutoDisqualificationRace.AutoSize = true;
            this.lblAutoDisqualificationRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.lblAutoDisqualificationRace.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblAutoDisqualificationRace.Location = new System.Drawing.Point(11, 83);
            this.lblAutoDisqualificationRace.Name = "lblAutoDisqualificationRace";
            this.lblAutoDisqualificationRace.Size = new System.Drawing.Size(231, 39);
            this.lblAutoDisqualificationRace.TabIndex = 0;
            this.lblAutoDisqualificationRace.Text = "Nach Strafen";
            // 
            // chkActivateAutoDisqualificationRace
            // 
            this.chkActivateAutoDisqualificationRace.AutoSize = true;
            this.chkActivateAutoDisqualificationRace.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateAutoDisqualificationRace.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateAutoDisqualificationRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.chkActivateAutoDisqualificationRace.Location = new System.Drawing.Point(18, 33);
            this.chkActivateAutoDisqualificationRace.Name = "chkActivateAutoDisqualificationRace";
            this.chkActivateAutoDisqualificationRace.Size = new System.Drawing.Size(171, 43);
            this.chkActivateAutoDisqualificationRace.TabIndex = 2;
            this.chkActivateAutoDisqualificationRace.Text = "Aktiviert";
            this.chkActivateAutoDisqualificationRace.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateAutoDisqualificationRace.UseVisualStyleBackColor = true;
            // 
            // tabPageSound
            // 
            this.tabPageSound.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tabPageSound.Controls.Add(this.grpDistanceBetweenSounds);
            this.tabPageSound.Controls.Add(this.grpActivateSplittedActionSounds);
            this.tabPageSound.Location = new System.Drawing.Point(4, 33);
            this.tabPageSound.Name = "tabPageSound";
            this.tabPageSound.Size = new System.Drawing.Size(1107, 620);
            this.tabPageSound.TabIndex = 7;
            this.tabPageSound.Text = "Sound";
            this.tabPageSound.UseVisualStyleBackColor = true;
            // 
            // grpDistanceBetweenSounds
            // 
            this.grpDistanceBetweenSounds.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpDistanceBetweenSounds.Controls.Add(this.label2);
            this.grpDistanceBetweenSounds.Controls.Add(this.label1);
            this.grpDistanceBetweenSounds.Controls.Add(this.tbDistanceBetweenSounds);
            this.grpDistanceBetweenSounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDistanceBetweenSounds.Location = new System.Drawing.Point(23, 117);
            this.grpDistanceBetweenSounds.Name = "grpDistanceBetweenSounds";
            this.grpDistanceBetweenSounds.Size = new System.Drawing.Size(323, 86);
            this.grpDistanceBetweenSounds.TabIndex = 10;
            this.grpDistanceBetweenSounds.TabStop = false;
            this.grpDistanceBetweenSounds.Text = "Distance between Sounds";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label2.Location = new System.Drawing.Point(267, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Min";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max";
            // 
            // tbDistanceBetweenSounds
            // 
            this.tbDistanceBetweenSounds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDistanceBetweenSounds.AutoSize = false;
            this.tbDistanceBetweenSounds.LargeChange = 1000;
            this.tbDistanceBetweenSounds.Location = new System.Drawing.Point(68, 28);
            this.tbDistanceBetweenSounds.Maximum = 100000;
            this.tbDistanceBetweenSounds.Name = "tbDistanceBetweenSounds";
            this.tbDistanceBetweenSounds.Size = new System.Drawing.Size(193, 41);
            this.tbDistanceBetweenSounds.SmallChange = 200;
            this.tbDistanceBetweenSounds.TabIndex = 6;
            this.tbDistanceBetweenSounds.TickFrequency = 5000;
            this.tbDistanceBetweenSounds.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // grpActivateSplittedActionSounds
            // 
            this.grpActivateSplittedActionSounds.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpActivateSplittedActionSounds.Controls.Add(this.chkActivateSplittedActionSounds);
            this.grpActivateSplittedActionSounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpActivateSplittedActionSounds.Location = new System.Drawing.Point(23, 16);
            this.grpActivateSplittedActionSounds.Name = "grpActivateSplittedActionSounds";
            this.grpActivateSplittedActionSounds.Size = new System.Drawing.Size(323, 86);
            this.grpActivateSplittedActionSounds.TabIndex = 9;
            this.grpActivateSplittedActionSounds.TabStop = false;
            this.grpActivateSplittedActionSounds.Text = "Splitted Action Sounds";
            // 
            // chkActivateSplittedActionSounds
            // 
            this.chkActivateSplittedActionSounds.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateSplittedActionSounds.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal_green;
            this.chkActivateSplittedActionSounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivateSplittedActionSounds.Location = new System.Drawing.Point(22, 28);
            this.chkActivateSplittedActionSounds.Name = "chkActivateSplittedActionSounds";
            this.chkActivateSplittedActionSounds.Size = new System.Drawing.Size(187, 41);
            this.chkActivateSplittedActionSounds.TabIndex = 0;
            this.chkActivateSplittedActionSounds.Text = "Aktiviert";
            this.chkActivateSplittedActionSounds.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivateSplittedActionSounds.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.udPointsForPosition6);
            this.groupBox6.Controls.Add(this.udPointsForPosition5);
            this.groupBox6.Controls.Add(this.numericUpDown4);
            this.groupBox6.Controls.Add(this.udPointsForPosition4);
            this.groupBox6.Controls.Add(this.udPointsForPosition3);
            this.groupBox6.Controls.Add(this.udPointsForPosition2);
            this.groupBox6.Controls.Add(this.udPointsForPosition1);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(8, 339);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(381, 275);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Points";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label10.Location = new System.Drawing.Point(13, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 39);
            this.label10.TabIndex = 1;
            this.label10.Text = "1.";
            // 
            // udPointsForPosition1
            // 
            this.udPointsForPosition1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udPointsForPosition1.Location = new System.Drawing.Point(76, 38);
            this.udPointsForPosition1.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udPointsForPosition1.Name = "udPointsForPosition1";
            this.udPointsForPosition1.Size = new System.Drawing.Size(69, 47);
            this.udPointsForPosition1.TabIndex = 2;
            this.udPointsForPosition1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udPointsForPosition1.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label11.Location = new System.Drawing.Point(13, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 39);
            this.label11.TabIndex = 3;
            this.label11.Text = "2.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label12.Location = new System.Drawing.Point(13, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 39);
            this.label12.TabIndex = 5;
            this.label12.Text = "3.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label13.Location = new System.Drawing.Point(177, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 39);
            this.label13.TabIndex = 7;
            this.label13.Text = "4.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label14.Location = new System.Drawing.Point(177, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 39);
            this.label14.TabIndex = 9;
            this.label14.Text = "5.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label15.Location = new System.Drawing.Point(177, 148);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 39);
            this.label15.TabIndex = 11;
            this.label15.Text = "6.";
            // 
            // udPointsForPosition2
            // 
            this.udPointsForPosition2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udPointsForPosition2.Location = new System.Drawing.Point(76, 91);
            this.udPointsForPosition2.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udPointsForPosition2.Name = "udPointsForPosition2";
            this.udPointsForPosition2.Size = new System.Drawing.Size(69, 47);
            this.udPointsForPosition2.TabIndex = 2;
            this.udPointsForPosition2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udPointsForPosition2.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // udPointsForPosition3
            // 
            this.udPointsForPosition3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udPointsForPosition3.Location = new System.Drawing.Point(76, 144);
            this.udPointsForPosition3.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udPointsForPosition3.Name = "udPointsForPosition3";
            this.udPointsForPosition3.Size = new System.Drawing.Size(69, 47);
            this.udPointsForPosition3.TabIndex = 2;
            this.udPointsForPosition3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udPointsForPosition3.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // udPointsForPosition4
            // 
            this.udPointsForPosition4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udPointsForPosition4.Location = new System.Drawing.Point(241, 40);
            this.udPointsForPosition4.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udPointsForPosition4.Name = "udPointsForPosition4";
            this.udPointsForPosition4.Size = new System.Drawing.Size(69, 47);
            this.udPointsForPosition4.TabIndex = 2;
            this.udPointsForPosition4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udPointsForPosition4.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown4.Location = new System.Drawing.Point(241, 91);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(69, 47);
            this.numericUpDown4.TabIndex = 2;
            this.numericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown4.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // udPointsForPosition5
            // 
            this.udPointsForPosition5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udPointsForPosition5.Location = new System.Drawing.Point(241, 93);
            this.udPointsForPosition5.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udPointsForPosition5.Name = "udPointsForPosition5";
            this.udPointsForPosition5.Size = new System.Drawing.Size(69, 47);
            this.udPointsForPosition5.TabIndex = 2;
            this.udPointsForPosition5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udPointsForPosition5.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // udPointsForPosition6
            // 
            this.udPointsForPosition6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udPointsForPosition6.Location = new System.Drawing.Point(241, 146);
            this.udPointsForPosition6.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.udPointsForPosition6.Name = "udPointsForPosition6";
            this.udPointsForPosition6.Size = new System.Drawing.Size(69, 47);
            this.udPointsForPosition6.TabIndex = 2;
            this.udPointsForPosition6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udPointsForPosition6.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // RaceSettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1122, 694);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.MinimumSize = new System.Drawing.Size(761, 501);
            this.Name = "RaceSettingsForm";
            this.Text = "Race Settings";
            this.Load += new System.EventHandler(this.RaceSettingsFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.udLapsToDrive)).EndInit();
            this.grpStartCountDownRace.ResumeLayout(false);
            this.grpStartCountDownRace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udStartCountDownInitNoRace)).EndInit();
            this.grpRestartCountDownRace.ResumeLayout(false);
            this.grpRestartCountDownRace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRestartCountDownInitNoRace)).EndInit();
            this.grpRace.ResumeLayout(false);
            this.grpRace.PerformLayout();
            this.grpQualifying.ResumeLayout(false);
            this.grpQualifying.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udQualificationBreakCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udQualificationMinutes)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udQualificationMaxLaps)).EndInit();
            this.grpMinLapTime.ResumeLayout(false);
            this.grpMinLapTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSecondsForValidLap)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpLanguage.ResumeLayout(false);
            this.tabPageTraining.ResumeLayout(false);
            this.grpStartCountDownTraining.ResumeLayout(false);
            this.grpStartCountDownTraining.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udStartCountDownInitNoTraining)).EndInit();
            this.grpRestartCountDownTraining.ResumeLayout(false);
            this.grpRestartCountDownTraining.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRestartCountDownInitNoTraining)).EndInit();
            this.tabPageQuali.ResumeLayout(false);
            this.grpStartCountDownQuali.ResumeLayout(false);
            this.grpStartCountDownQuali.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udStartCountDownInitNoQuali)).EndInit();
            this.grpRestartCountDownQuali.ResumeLayout(false);
            this.grpRestartCountDownQuali.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRestartCountDownInitNoQuali)).EndInit();
            this.tabPageRace.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDisqualificationRaceSecsFactor)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDisqualificationLapSecsFactor)).EndInit();
            this.grpAutoDisqualificationRace.ResumeLayout(false);
            this.grpAutoDisqualificationRace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAutoDisqualificationRace)).EndInit();
            this.tabPageSound.ResumeLayout(false);
            this.grpDistanceBetweenSounds.ResumeLayout(false);
            this.grpDistanceBetweenSounds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDistanceBetweenSounds)).EndInit();
            this.grpActivateSplittedActionSounds.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPointsForPosition6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown udLapsToDrive;
        private System.Windows.Forms.Label lblLapsToDrive;
        private System.Windows.Forms.GroupBox grpStartCountDownRace;
        private System.Windows.Forms.Label lblStartCountDownRaceSecs;
        private System.Windows.Forms.NumericUpDown udStartCountDownInitNoRace;
        private Elreg.Controls.ColoredCheckbox chkActivateStartCountDownRace;
        private System.Windows.Forms.GroupBox grpRestartCountDownRace;
        private System.Windows.Forms.Label lblRestartCountDownRaceSecs;
        private System.Windows.Forms.NumericUpDown udRestartCountDownInitNoRace;
        private Elreg.Controls.ColoredCheckbox chkActivateRestartCountDownRace;
        private System.Windows.Forms.GroupBox grpRace;
        private System.Windows.Forms.GroupBox grpQualifying;
        private System.Windows.Forms.Label lblQualiMinutes;
        private System.Windows.Forms.NumericUpDown udQualificationMinutes;
        private System.Windows.Forms.GroupBox grpMinLapTime;
        private System.Windows.Forms.Label lblMinLapTimeSecs;
        private System.Windows.Forms.NumericUpDown udSecondsForValidLap;
        private Controls.ColoredCheckbox chkCountDescending;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.TabPage tabPageRace;
        private System.Windows.Forms.TabPage tabPageQuali;
        private System.Windows.Forms.TabPage tabPageTraining;
        private System.Windows.Forms.GroupBox grpStartCountDownQuali;
        private System.Windows.Forms.Label lblStartCountDownQualiSecs;
        private System.Windows.Forms.NumericUpDown udStartCountDownInitNoQuali;
        private Controls.ColoredCheckbox chkActivateStartCountDownQuali;
        private System.Windows.Forms.GroupBox grpRestartCountDownQuali;
        private System.Windows.Forms.Label lblRestartCountDownQualiSecs;
        private System.Windows.Forms.NumericUpDown udRestartCountDownInitNoQuali;
        private Controls.ColoredCheckbox chkActivateRestartCountDownQuali;
        private System.Windows.Forms.GroupBox grpStartCountDownTraining;
        private System.Windows.Forms.Label lblStartCountDownTrainingSecs;
        private System.Windows.Forms.NumericUpDown udStartCountDownInitNoTraining;
        private Controls.ColoredCheckbox chkActivateStartCountDownTraining;
        private System.Windows.Forms.GroupBox grpRestartCountDownTraining;
        private System.Windows.Forms.Label lblRestartCountDownTrainingSecs;
        private System.Windows.Forms.NumericUpDown udRestartCountDownInitNoTraining;
        private Controls.ColoredCheckbox chkActivateRestartCountDownTraining;
        private System.Windows.Forms.ComboBox cbxLanguage;
        private System.Windows.Forms.GroupBox grpLanguage;
        private System.Windows.Forms.Label lblQualiBreaks;
        private System.Windows.Forms.NumericUpDown udQualificationBreakCount;
        private System.Windows.Forms.GroupBox grpAutoDisqualificationRace;
        private System.Windows.Forms.NumericUpDown udAutoDisqualificationRace;
        private Controls.ColoredCheckbox chkActivateAutoDisqualificationRace;
        private System.Windows.Forms.Label lblAutoDisqualificationRace;
        private System.Windows.Forms.TabPage tabPageSound;
        private System.Windows.Forms.GroupBox grpDistanceBetweenSounds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbDistanceBetweenSounds;
        private System.Windows.Forms.GroupBox grpActivateSplittedActionSounds;
        private Controls.ColoredCheckbox chkActivateSplittedActionSounds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRaceTrackName;
        private System.Windows.Forms.Button btnSetDateAsEventName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private Controls.ColoredCheckbox chkActivateQualiTimeBased;
        private Controls.ColoredCheckbox chkActivateQualiLapBased;
        private System.Windows.Forms.NumericUpDown udQualificationMaxLaps;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown udDisqualificationLapSecsFactor;
        private System.Windows.Forms.Label label3;
        private Controls.ColoredCheckbox chkActivateDisqualificationLapSecs;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown udDisqualificationRaceSecsFactor;
        private System.Windows.Forms.Label label5;
        private Controls.ColoredCheckbox chkActivateDisqualificationRaceSecs;
        private System.Windows.Forms.Label lblDisqualificationRaceSecsCalced;
        private System.Windows.Forms.Label lblDisqualificationLapSecsCalced;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown udPointsForPosition1;
        private System.Windows.Forms.NumericUpDown udPointsForPosition6;
        private System.Windows.Forms.NumericUpDown udPointsForPosition5;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown udPointsForPosition4;
        private System.Windows.Forms.NumericUpDown udPointsForPosition3;
        private System.Windows.Forms.NumericUpDown udPointsForPosition2;
    }
}