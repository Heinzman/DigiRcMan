namespace Elreg.WindowsFormsApplication.Forms
{
    partial class VcuSettingsForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxComPort = new System.Windows.Forms.ComboBox();
            this.txtLogReceived = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPauseStart = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLapOfId6 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblLapOfId5 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblLapOfId4 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblLapOfId3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblLapOfId2 = new System.Windows.Forms.Label();
            this.lblLapOfId1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblButton = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(941, 651);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(170, 33);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "&Schließen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(356, 8);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(81, 29);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
            // 
            // btnStart
            // 
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStart.Location = new System.Drawing.Point(265, 8);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(83, 29);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "COM Port:";
            // 
            // cbxComPort
            // 
            this.cbxComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxComPort.FormattingEnabled = true;
            this.cbxComPort.Location = new System.Drawing.Point(111, 10);
            this.cbxComPort.Margin = new System.Windows.Forms.Padding(4);
            this.cbxComPort.Name = "cbxComPort";
            this.cbxComPort.Size = new System.Drawing.Size(146, 26);
            this.cbxComPort.TabIndex = 7;
            // 
            // txtLogReceived
            // 
            this.txtLogReceived.AcceptsReturn = true;
            this.txtLogReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogReceived.Location = new System.Drawing.Point(0, 37);
            this.txtLogReceived.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogReceived.Multiline = true;
            this.txtLogReceived.Name = "txtLogReceived";
            this.txtLogReceived.ReadOnly = true;
            this.txtLogReceived.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogReceived.Size = new System.Drawing.Size(1084, 507);
            this.txtLogReceived.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1094, 553);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtLogReceived);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 545);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1078, 32);
            this.label2.TabIndex = 12;
            this.label2.Text = "Received";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1098, 630);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1090, 599);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Buttons Detections";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 599F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 599F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 599F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 599F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 599F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 599F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 599F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 599F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 599F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 599F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1090, 599);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.lblPauseStart);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lblLapOfId6);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.lblLapOfId5);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.lblLapOfId4);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.lblLapOfId3);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.lblLapOfId2);
            this.panel3.Controls.Add(this.lblLapOfId1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblSpeed);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lblButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1084, 593);
            this.panel3.TabIndex = 0;
            // 
            // lblPauseStart
            // 
            this.lblPauseStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPauseStart.BackColor = System.Drawing.Color.White;
            this.lblPauseStart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPauseStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPauseStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPauseStart.Location = new System.Drawing.Point(74, 504);
            this.lblPauseStart.Name = "lblPauseStart";
            this.lblPauseStart.Size = new System.Drawing.Size(997, 52);
            this.lblPauseStart.TabIndex = 53;
            this.lblPauseStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label8.Location = new System.Drawing.Point(77, 462);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(417, 39);
            this.label8.TabIndex = 52;
            this.label8.Text = "Pause/Restart Detection";
            // 
            // lblLapOfId6
            // 
            this.lblLapOfId6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLapOfId6.BackColor = System.Drawing.Color.White;
            this.lblLapOfId6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLapOfId6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLapOfId6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapOfId6.Location = new System.Drawing.Point(74, 384);
            this.lblLapOfId6.Name = "lblLapOfId6";
            this.lblLapOfId6.Size = new System.Drawing.Size(997, 52);
            this.lblLapOfId6.TabIndex = 51;
            this.lblLapOfId6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label25.Location = new System.Drawing.Point(9, 392);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 37);
            this.label25.TabIndex = 50;
            this.label25.Text = "6";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLapOfId5
            // 
            this.lblLapOfId5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLapOfId5.BackColor = System.Drawing.Color.White;
            this.lblLapOfId5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLapOfId5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLapOfId5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapOfId5.Location = new System.Drawing.Point(74, 326);
            this.lblLapOfId5.Name = "lblLapOfId5";
            this.lblLapOfId5.Size = new System.Drawing.Size(997, 52);
            this.lblLapOfId5.TabIndex = 48;
            this.lblLapOfId5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label21.Location = new System.Drawing.Point(9, 334);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 37);
            this.label21.TabIndex = 47;
            this.label21.Text = "5";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLapOfId4
            // 
            this.lblLapOfId4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLapOfId4.BackColor = System.Drawing.Color.White;
            this.lblLapOfId4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLapOfId4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLapOfId4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapOfId4.Location = new System.Drawing.Point(74, 268);
            this.lblLapOfId4.Name = "lblLapOfId4";
            this.lblLapOfId4.Size = new System.Drawing.Size(997, 52);
            this.lblLapOfId4.TabIndex = 45;
            this.lblLapOfId4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label17.Location = new System.Drawing.Point(9, 276);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 37);
            this.label17.TabIndex = 44;
            this.label17.Text = "4";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLapOfId3
            // 
            this.lblLapOfId3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLapOfId3.BackColor = System.Drawing.Color.White;
            this.lblLapOfId3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLapOfId3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLapOfId3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapOfId3.Location = new System.Drawing.Point(74, 210);
            this.lblLapOfId3.Name = "lblLapOfId3";
            this.lblLapOfId3.Size = new System.Drawing.Size(997, 52);
            this.lblLapOfId3.TabIndex = 42;
            this.lblLapOfId3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label13.Location = new System.Drawing.Point(9, 218);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 37);
            this.label13.TabIndex = 41;
            this.label13.Text = "3";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLapOfId2
            // 
            this.lblLapOfId2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLapOfId2.BackColor = System.Drawing.Color.White;
            this.lblLapOfId2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLapOfId2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLapOfId2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapOfId2.Location = new System.Drawing.Point(74, 152);
            this.lblLapOfId2.Name = "lblLapOfId2";
            this.lblLapOfId2.Size = new System.Drawing.Size(997, 52);
            this.lblLapOfId2.TabIndex = 39;
            this.lblLapOfId2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLapOfId1
            // 
            this.lblLapOfId1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLapOfId1.BackColor = System.Drawing.Color.White;
            this.lblLapOfId1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLapOfId1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLapOfId1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapOfId1.Location = new System.Drawing.Point(74, 94);
            this.lblLapOfId1.Name = "lblLapOfId1";
            this.lblLapOfId1.Size = new System.Drawing.Size(997, 52);
            this.lblLapOfId1.TabIndex = 36;
            this.lblLapOfId1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label4.Location = new System.Drawing.Point(0, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(452, 39);
            this.label4.TabIndex = 34;
            this.label4.Text = "Buttons";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblSpeed.Location = new System.Drawing.Point(77, 52);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(243, 39);
            this.lblSpeed.TabIndex = 34;
            this.lblSpeed.Text = "Lap Detection";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label5.Location = new System.Drawing.Point(9, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 37);
            this.label5.TabIndex = 38;
            this.label5.Text = "2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label6.Location = new System.Drawing.Point(9, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 37);
            this.label6.TabIndex = 35;
            this.label6.Text = "1";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblButton
            // 
            this.lblButton.AutoSize = true;
            this.lblButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblButton.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblButton.Location = new System.Drawing.Point(9, 52);
            this.lblButton.Name = "lblButton";
            this.lblButton.Size = new System.Drawing.Size(53, 39);
            this.lblButton.TabIndex = 33;
            this.lblButton.Text = "ID";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.btnStop);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbxComPort);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1090, 599);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Serial Monitor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // VcuSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 701);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VcuSettingsForm";
            this.Text = "TestForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestFormFormClosed);
            this.Load += new System.EventHandler(this.TestFormLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxComPort;
        private System.Windows.Forms.TextBox txtLogReceived;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPauseStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblLapOfId6;
        private System.Windows.Forms.Label lblLapOfId5;
        private System.Windows.Forms.Label lblLapOfId4;
        private System.Windows.Forms.Label lblLapOfId3;
        private System.Windows.Forms.Label lblLapOfId2;
        private System.Windows.Forms.Label lblLapOfId1;
    }
}