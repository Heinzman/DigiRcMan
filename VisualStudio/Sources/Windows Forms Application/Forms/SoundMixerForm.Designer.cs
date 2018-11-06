namespace Elreg.WindowsFormsApplication.Forms
{
    partial class SoundMixerForm
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
            this.components = new System.ComponentModel.Container();
            this.grpActionSounds = new System.Windows.Forms.GroupBox();
            this.lblActionSoundFade = new System.Windows.Forms.Label();
            this.tbActionFade = new System.Windows.Forms.TrackBar();
            this.lblActionSoundAction = new System.Windows.Forms.Label();
            this.tbActionSound = new System.Windows.Forms.TrackBar();
            this.lblMiscCountDown = new System.Windows.Forms.Label();
            this.tbCoundDown = new System.Windows.Forms.TrackBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grpMusic = new System.Windows.Forms.GroupBox();
            this.lblMusicHymn = new System.Windows.Forms.Label();
            this.tbMusicHymn = new System.Windows.Forms.TrackBar();
            this.lblMusicPause = new System.Windows.Forms.Label();
            this.tbMusicPause = new System.Windows.Forms.TrackBar();
            this.lblMusicRace = new System.Windows.Forms.Label();
            this.tbMusicRace = new System.Windows.Forms.TrackBar();
            this.lblMusicMain = new System.Windows.Forms.Label();
            this.tbMusicMain = new System.Windows.Forms.TrackBar();
            this.grpMisc = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpActionSounds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbActionFade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbActionSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCoundDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.grpMusic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicHymn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicRace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicMain)).BeginInit();
            this.grpMisc.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpActionSounds
            // 
            this.grpActionSounds.Controls.Add(this.lblActionSoundFade);
            this.grpActionSounds.Controls.Add(this.tbActionFade);
            this.grpActionSounds.Controls.Add(this.lblActionSoundAction);
            this.grpActionSounds.Controls.Add(this.tbActionSound);
            this.grpActionSounds.Cursor = System.Windows.Forms.Cursors.Default;
            this.grpActionSounds.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpActionSounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpActionSounds.Location = new System.Drawing.Point(403, 6);
            this.grpActionSounds.Name = "grpActionSounds";
            this.grpActionSounds.Size = new System.Drawing.Size(154, 250);
            this.grpActionSounds.TabIndex = 2;
            this.grpActionSounds.TabStop = false;
            this.grpActionSounds.Text = "Action Sound";
            // 
            // lblActionSoundFade
            // 
            this.lblActionSoundFade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionSoundFade.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblActionSoundFade.Location = new System.Drawing.Point(76, 184);
            this.lblActionSoundFade.Name = "lblActionSoundFade";
            this.lblActionSoundFade.Size = new System.Drawing.Size(67, 53);
            this.lblActionSoundFade.TabIndex = 3;
            this.lblActionSoundFade.Text = "Fade";
            this.lblActionSoundFade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbActionFade
            // 
            this.tbActionFade.AutoSize = false;
            this.tbActionFade.LargeChange = 100;
            this.tbActionFade.Location = new System.Drawing.Point(88, 30);
            this.tbActionFade.Maximum = 0;
            this.tbActionFade.Minimum = -5000;
            this.tbActionFade.Name = "tbActionFade";
            this.tbActionFade.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbActionFade.Size = new System.Drawing.Size(56, 161);
            this.tbActionFade.TabIndex = 2;
            this.tbActionFade.TickFrequency = 100;
            this.tbActionFade.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // lblActionSoundAction
            // 
            this.lblActionSoundAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionSoundAction.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblActionSoundAction.Location = new System.Drawing.Point(3, 184);
            this.lblActionSoundAction.Name = "lblActionSoundAction";
            this.lblActionSoundAction.Size = new System.Drawing.Size(67, 53);
            this.lblActionSoundAction.TabIndex = 1;
            this.lblActionSoundAction.Text = "Action";
            this.lblActionSoundAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbActionSound
            // 
            this.tbActionSound.AutoSize = false;
            this.tbActionSound.LargeChange = 100;
            this.tbActionSound.Location = new System.Drawing.Point(14, 30);
            this.tbActionSound.Maximum = 0;
            this.tbActionSound.Minimum = -5000;
            this.tbActionSound.Name = "tbActionSound";
            this.tbActionSound.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbActionSound.Size = new System.Drawing.Size(56, 161);
            this.tbActionSound.TabIndex = 0;
            this.tbActionSound.TickFrequency = 100;
            this.tbActionSound.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbActionSound.Scroll += new System.EventHandler(this.TrackbarScroll);
            // 
            // lblMiscCountDown
            // 
            this.lblMiscCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiscCountDown.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblMiscCountDown.Location = new System.Drawing.Point(13, 183);
            this.lblMiscCountDown.Name = "lblMiscCountDown";
            this.lblMiscCountDown.Size = new System.Drawing.Size(67, 53);
            this.lblMiscCountDown.TabIndex = 1;
            this.lblMiscCountDown.Text = "Count Down";
            this.lblMiscCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCoundDown
            // 
            this.tbCoundDown.AutoSize = false;
            this.tbCoundDown.LargeChange = 100;
            this.tbCoundDown.Location = new System.Drawing.Point(24, 29);
            this.tbCoundDown.Maximum = 0;
            this.tbCoundDown.Minimum = -5000;
            this.tbCoundDown.Name = "tbCoundDown";
            this.tbCoundDown.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbCoundDown.Size = new System.Drawing.Size(56, 161);
            this.tbCoundDown.TabIndex = 0;
            this.tbCoundDown.TickFrequency = 100;
            this.tbCoundDown.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbCoundDown.Scroll += new System.EventHandler(this.TrackbarScroll);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(221, 323);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(177, 38);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Schließen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // grpMusic
            // 
            this.grpMusic.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpMusic.Controls.Add(this.lblMusicHymn);
            this.grpMusic.Controls.Add(this.tbMusicHymn);
            this.grpMusic.Controls.Add(this.lblMusicPause);
            this.grpMusic.Controls.Add(this.tbMusicPause);
            this.grpMusic.Controls.Add(this.lblMusicRace);
            this.grpMusic.Controls.Add(this.tbMusicRace);
            this.grpMusic.Controls.Add(this.lblMusicMain);
            this.grpMusic.Controls.Add(this.tbMusicMain);
            this.grpMusic.Cursor = System.Windows.Forms.Cursors.Default;
            this.grpMusic.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMusic.Location = new System.Drawing.Point(3, 6);
            this.grpMusic.Name = "grpMusic";
            this.grpMusic.Size = new System.Drawing.Size(298, 250);
            this.grpMusic.TabIndex = 0;
            this.grpMusic.TabStop = false;
            this.grpMusic.Text = "Music";
            // 
            // lblMusicHymn
            // 
            this.lblMusicHymn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusicHymn.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblMusicHymn.Location = new System.Drawing.Point(224, 184);
            this.lblMusicHymn.Name = "lblMusicHymn";
            this.lblMusicHymn.Size = new System.Drawing.Size(68, 53);
            this.lblMusicHymn.TabIndex = 7;
            this.lblMusicHymn.Text = "Hymn";
            this.lblMusicHymn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMusicHymn
            // 
            this.tbMusicHymn.AutoSize = false;
            this.tbMusicHymn.LargeChange = 100;
            this.tbMusicHymn.Location = new System.Drawing.Point(242, 30);
            this.tbMusicHymn.Maximum = 0;
            this.tbMusicHymn.Minimum = -5000;
            this.tbMusicHymn.Name = "tbMusicHymn";
            this.tbMusicHymn.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbMusicHymn.Size = new System.Drawing.Size(40, 161);
            this.tbMusicHymn.TabIndex = 6;
            this.tbMusicHymn.TickFrequency = 100;
            this.tbMusicHymn.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbMusicHymn.Scroll += new System.EventHandler(this.TrackbarScroll);
            // 
            // lblMusicPause
            // 
            this.lblMusicPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusicPause.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblMusicPause.Location = new System.Drawing.Point(150, 184);
            this.lblMusicPause.Name = "lblMusicPause";
            this.lblMusicPause.Size = new System.Drawing.Size(68, 53);
            this.lblMusicPause.TabIndex = 5;
            this.lblMusicPause.Text = "Pause";
            this.lblMusicPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMusicPause
            // 
            this.tbMusicPause.AutoSize = false;
            this.tbMusicPause.LargeChange = 100;
            this.tbMusicPause.Location = new System.Drawing.Point(168, 30);
            this.tbMusicPause.Maximum = 0;
            this.tbMusicPause.Minimum = -5000;
            this.tbMusicPause.Name = "tbMusicPause";
            this.tbMusicPause.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbMusicPause.Size = new System.Drawing.Size(40, 161);
            this.tbMusicPause.TabIndex = 4;
            this.tbMusicPause.TickFrequency = 100;
            this.tbMusicPause.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbMusicPause.Scroll += new System.EventHandler(this.TrackbarScroll);
            // 
            // lblMusicRace
            // 
            this.lblMusicRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusicRace.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblMusicRace.Location = new System.Drawing.Point(76, 184);
            this.lblMusicRace.Name = "lblMusicRace";
            this.lblMusicRace.Size = new System.Drawing.Size(68, 53);
            this.lblMusicRace.TabIndex = 3;
            this.lblMusicRace.Text = "Race";
            this.lblMusicRace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMusicRace
            // 
            this.tbMusicRace.AutoSize = false;
            this.tbMusicRace.LargeChange = 100;
            this.tbMusicRace.Location = new System.Drawing.Point(94, 30);
            this.tbMusicRace.Maximum = 0;
            this.tbMusicRace.Minimum = -5000;
            this.tbMusicRace.Name = "tbMusicRace";
            this.tbMusicRace.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbMusicRace.Size = new System.Drawing.Size(40, 161);
            this.tbMusicRace.TabIndex = 2;
            this.tbMusicRace.TickFrequency = 100;
            this.tbMusicRace.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbMusicRace.Scroll += new System.EventHandler(this.TrackbarScroll);
            // 
            // lblMusicMain
            // 
            this.lblMusicMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusicMain.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblMusicMain.Location = new System.Drawing.Point(3, 184);
            this.lblMusicMain.Name = "lblMusicMain";
            this.lblMusicMain.Size = new System.Drawing.Size(67, 53);
            this.lblMusicMain.TabIndex = 1;
            this.lblMusicMain.Text = "Main";
            this.lblMusicMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMusicMain
            // 
            this.tbMusicMain.AutoSize = false;
            this.tbMusicMain.LargeChange = 100;
            this.tbMusicMain.Location = new System.Drawing.Point(14, 30);
            this.tbMusicMain.Maximum = 0;
            this.tbMusicMain.Minimum = -5000;
            this.tbMusicMain.Name = "tbMusicMain";
            this.tbMusicMain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbMusicMain.Size = new System.Drawing.Size(56, 161);
            this.tbMusicMain.TabIndex = 0;
            this.tbMusicMain.TickFrequency = 100;
            this.tbMusicMain.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbMusicMain.Scroll += new System.EventHandler(this.TrackbarScroll);
            // 
            // grpMisc
            // 
            this.grpMisc.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpMisc.Controls.Add(this.lblMiscCountDown);
            this.grpMisc.Controls.Add(this.tbCoundDown);
            this.grpMisc.Cursor = System.Windows.Forms.Cursors.Default;
            this.grpMisc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMisc.Location = new System.Drawing.Point(309, 6);
            this.grpMisc.Name = "grpMisc";
            this.grpMisc.Size = new System.Drawing.Size(88, 250);
            this.grpMisc.TabIndex = 1;
            this.grpMisc.TabStop = false;
            this.grpMisc.Text = "Misc.";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(5, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(573, 305);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpMisc);
            this.tabPage1.Controls.Add(this.grpMusic);
            this.tabPage1.Controls.Add(this.grpActionSounds);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(565, 267);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sounds";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SoundMixerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(580, 367);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 396);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(590, 396);
            this.Name = "SoundMixerForm";
            this.Text = "Mixer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SoundMixerFormFormClosing);
            this.Load += new System.EventHandler(this.SoundMixerFormLoad);
            this.grpActionSounds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbActionFade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbActionSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCoundDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.grpMusic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicHymn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicRace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicMain)).EndInit();
            this.grpMisc.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpActionSounds;
        private System.Windows.Forms.Label lblActionSoundAction;
        private System.Windows.Forms.TrackBar tbActionSound;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMiscCountDown;
        private System.Windows.Forms.TrackBar tbCoundDown;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.GroupBox grpMusic;
        private System.Windows.Forms.Label lblMusicPause;
        private System.Windows.Forms.TrackBar tbMusicPause;
        private System.Windows.Forms.Label lblMusicRace;
        private System.Windows.Forms.TrackBar tbMusicRace;
        private System.Windows.Forms.Label lblMusicMain;
        private System.Windows.Forms.TrackBar tbMusicMain;
        private System.Windows.Forms.Label lblMusicHymn;
        private System.Windows.Forms.TrackBar tbMusicHymn;
        private System.Windows.Forms.Label lblActionSoundFade;
        private System.Windows.Forms.TrackBar tbActionFade;
        private System.Windows.Forms.GroupBox grpMisc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;

    }
}