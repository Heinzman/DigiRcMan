using Elreg.WindowsFormsApplication.UserControls;

namespace Elreg.WindowsFormsApplication.Forms
{
    partial class MaintainDriversForm
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
            this.components = new System.ComponentModel.Container();
            this.grpDrivers = new System.Windows.Forms.GroupBox();
            this.grdDrivers = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnActivated = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingNavigatorDrivers = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.ctlLap = new Elreg.WindowsFormsApplication.UserControls.CtlSoundOption();
            this.chkActivated = new Elreg.Controls.ColoredCheckbox();
            this.btnOpenHymnFilename = new System.Windows.Forms.Button();
            this.btnCreateWav = new System.Windows.Forms.Button();
            this.btnOpenFileWavName = new System.Windows.Forms.Button();
            this.txtHymnFilename = new System.Windows.Forms.TextBox();
            this.lblHymn = new System.Windows.Forms.Label();
            this.txtWavName = new System.Windows.Forms.TextBox();
            this.lblWavName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrivers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorDrivers)).BeginInit();
            this.bindingNavigatorDrivers.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDrivers
            // 
            this.grpDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpDrivers.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpDrivers.Controls.Add(this.grdDrivers);
            this.grpDrivers.Controls.Add(this.bindingNavigatorDrivers);
            this.grpDrivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDrivers.Location = new System.Drawing.Point(12, 12);
            this.grpDrivers.Name = "grpDrivers";
            this.grpDrivers.Size = new System.Drawing.Size(283, 496);
            this.grpDrivers.TabIndex = 0;
            this.grpDrivers.TabStop = false;
            this.grpDrivers.Text = "Fahrer";
            // 
            // grdDrivers
            // 
            this.grdDrivers.AllowUserToDeleteRows = false;
            this.grdDrivers.AllowUserToResizeColumns = false;
            this.grdDrivers.AllowUserToResizeRows = false;
            this.grdDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDrivers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnActivated});
            this.grdDrivers.Location = new System.Drawing.Point(6, 44);
            this.grdDrivers.Name = "grdDrivers";
            this.grdDrivers.RowHeadersWidth = 30;
            this.grdDrivers.Size = new System.Drawing.Size(271, 446);
            this.grdDrivers.TabIndex = 1;
            this.grdDrivers.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.GrdDriversDefaultValuesNeeded);
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnId.DataPropertyName = "Id";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Width = 43;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.DataPropertyName = "Name";
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnActivated
            // 
            this.ColumnActivated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnActivated.DataPropertyName = "Activated";
            this.ColumnActivated.HeaderText = "Aktiviert";
            this.ColumnActivated.Name = "ColumnActivated";
            this.ColumnActivated.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnActivated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnActivated.Width = 79;
            // 
            // bindingNavigatorDrivers
            // 
            this.bindingNavigatorDrivers.AddNewItem = null;
            this.bindingNavigatorDrivers.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorDrivers.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorDrivers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingNavigatorDrivers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigatorDrivers.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigatorDrivers.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorDrivers.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorDrivers.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorDrivers.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorDrivers.Name = "bindingNavigatorDrivers";
            this.bindingNavigatorDrivers.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorDrivers.Size = new System.Drawing.Size(277, 25);
            this.bindingNavigatorDrivers.TabIndex = 0;
            this.bindingNavigatorDrivers.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(42, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Die Gesamtanzahl der Elemente.";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.bindingNavigatorDeleteItem;
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Löschen";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.BindingNavigatorMoveFirstItem;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Erste verschieben";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.BindingNavigatorMovePreviousItem;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Vorherige verschieben";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(21, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Aktuelle Position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.BindingNavigatorMoveNextItem;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Nächste verschieben";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.BindingNavigatorMoveLastItem;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Letzte verschieben";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.BindingNavigatorAddNewItem;
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Neu hinzufügen";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.BindingNavigatorAddNewItemClick);
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.grpDetails.Controls.Add(this.ctlLap);
            this.grpDetails.Controls.Add(this.chkActivated);
            this.grpDetails.Controls.Add(this.btnOpenHymnFilename);
            this.grpDetails.Controls.Add(this.btnCreateWav);
            this.grpDetails.Controls.Add(this.btnOpenFileWavName);
            this.grpDetails.Controls.Add(this.txtHymnFilename);
            this.grpDetails.Controls.Add(this.lblHymn);
            this.grpDetails.Controls.Add(this.txtWavName);
            this.grpDetails.Controls.Add(this.lblWavName);
            this.grpDetails.Controls.Add(this.txtName);
            this.grpDetails.Controls.Add(this.lblName);
            this.grpDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetails.Location = new System.Drawing.Point(301, 12);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(557, 496);
            this.grpDetails.TabIndex = 1;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Details";
            // 
            // ctlLap
            // 
            this.ctlLap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlLap.Caption = "Runde gezählt";
            this.ctlLap.Location = new System.Drawing.Point(6, 126);
            this.ctlLap.Name = "ctlLap";
            this.ctlLap.Size = new System.Drawing.Size(542, 364);
            this.ctlLap.TabIndex = 15;
            // 
            // chkActivated
            // 
            this.chkActivated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActivated.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivated.CheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivated.Location = new System.Drawing.Point(6, 15);
            this.chkActivated.Name = "chkActivated";
            this.chkActivated.Size = new System.Drawing.Size(545, 17);
            this.chkActivated.TabIndex = 9;
            this.chkActivated.Text = "Aktiviert";
            this.chkActivated.UncheckedBackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.chkActivated.UseVisualStyleBackColor = true;
            // 
            // btnOpenHymnFilename
            // 
            this.btnOpenHymnFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenHymnFilename.Location = new System.Drawing.Point(523, 90);
            this.btnOpenHymnFilename.Name = "btnOpenHymnFilename";
            this.btnOpenHymnFilename.Size = new System.Drawing.Size(28, 20);
            this.btnOpenHymnFilename.TabIndex = 8;
            this.btnOpenHymnFilename.Text = "...";
            this.btnOpenHymnFilename.UseVisualStyleBackColor = true;
            this.btnOpenHymnFilename.Click += new System.EventHandler(this.BtnOpenHymnFilenameClick);
            // 
            // btnCreateWav
            // 
            this.btnCreateWav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateWav.Location = new System.Drawing.Point(444, 64);
            this.btnCreateWav.Name = "btnCreateWav";
            this.btnCreateWav.Size = new System.Drawing.Size(107, 20);
            this.btnCreateWav.TabIndex = 5;
            this.btnCreateWav.Text = "Wav erzeugen";
            this.btnCreateWav.UseVisualStyleBackColor = true;
            this.btnCreateWav.Click += new System.EventHandler(this.BtnCreateWavClick);
            // 
            // btnOpenFileWavName
            // 
            this.btnOpenFileWavName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFileWavName.Location = new System.Drawing.Point(410, 64);
            this.btnOpenFileWavName.Name = "btnOpenFileWavName";
            this.btnOpenFileWavName.Size = new System.Drawing.Size(28, 20);
            this.btnOpenFileWavName.TabIndex = 4;
            this.btnOpenFileWavName.Text = "...";
            this.btnOpenFileWavName.UseVisualStyleBackColor = true;
            this.btnOpenFileWavName.Click += new System.EventHandler(this.BtnOpenFileWavNameClick);
            // 
            // txtHymnFilename
            // 
            this.txtHymnFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHymnFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHymnFilename.Location = new System.Drawing.Point(100, 90);
            this.txtHymnFilename.Name = "txtHymnFilename";
            this.txtHymnFilename.Size = new System.Drawing.Size(417, 20);
            this.txtHymnFilename.TabIndex = 7;
            // 
            // lblHymn
            // 
            this.lblHymn.AutoSize = true;
            this.lblHymn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHymn.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblHymn.Location = new System.Drawing.Point(6, 93);
            this.lblHymn.Name = "lblHymn";
            this.lblHymn.Size = new System.Drawing.Size(73, 13);
            this.lblHymn.TabIndex = 6;
            this.lblHymn.Text = "Mp3 Hymne";
            // 
            // txtWavName
            // 
            this.txtWavName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWavName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWavName.Location = new System.Drawing.Point(100, 64);
            this.txtWavName.Name = "txtWavName";
            this.txtWavName.Size = new System.Drawing.Size(304, 20);
            this.txtWavName.TabIndex = 3;
            // 
            // lblWavName
            // 
            this.lblWavName.AutoSize = true;
            this.lblWavName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWavName.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblWavName.Location = new System.Drawing.Point(6, 67);
            this.lblWavName.Name = "lblWavName";
            this.lblWavName.Size = new System.Drawing.Size(88, 13);
            this.lblWavName.TabIndex = 2;
            this.lblWavName.Text = "Wav für Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(100, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(451, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblName.Location = new System.Drawing.Point(6, 41);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(745, 514);
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
            this.btnOK.Location = new System.Drawing.Point(626, 514);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 24);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // MaintainDriversForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(870, 541);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpDrivers);
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.MinimumSize = new System.Drawing.Size(700, 507);
            this.Name = "MaintainDriversForm";
            this.Text = "Drivers";
            this.Load += new System.EventHandler(this.MaintainDriversFormLoad);
            this.grpDrivers.ResumeLayout(false);
            this.grpDrivers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrivers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorDrivers)).EndInit();
            this.bindingNavigatorDrivers.ResumeLayout(false);
            this.bindingNavigatorDrivers.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDrivers;
        private System.Windows.Forms.DataGridView grdDrivers;
        private System.Windows.Forms.BindingNavigator bindingNavigatorDrivers;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnOpenFileWavName;
        private System.Windows.Forms.TextBox txtWavName;
        private System.Windows.Forms.Label lblWavName;
        private System.Windows.Forms.Button btnOK;
        private CtlSoundOption ctlLap;
        private System.Windows.Forms.Button btnOpenHymnFilename;
        private System.Windows.Forms.TextBox txtHymnFilename;
        private System.Windows.Forms.Label lblHymn;
        private System.Windows.Forms.Button btnCreateWav;
        private Controls.ColoredCheckbox chkActivated;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnActivated;
    }
}