namespace Elreg.WindowsFormsApplication.Forms
{
    partial class UpdateLanesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdLanes = new System.Windows.Forms.DataGridView();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ColumnsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnIDMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DriverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CarPictureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FuelLevelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LapsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BestLapTimeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LapTimeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LapTimeBestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuelConsumptionWithAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FuelConsumptionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemLargerFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSmallerFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemLargerHeaderFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSmallerHeaderFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSaveSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDriver = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnCar = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnLapCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOverallPenalties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLanes)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdLanes
            // 
            this.grdLanes.AllowUserToAddRows = false;
            this.grdLanes.AllowUserToDeleteRows = false;
            this.grdLanes.AllowUserToOrderColumns = true;
            this.grdLanes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Candara", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLanes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnDriver,
            this.ColumnCar,
            this.ColumnLapCount,
            this.ColumnOverallPenalties,
            this.ColumnStatus});
            this.grdLanes.ContextMenuStrip = this.contextMenuStripGrid;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdLanes.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdLanes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdLanes.Location = new System.Drawing.Point(12, 12);
            this.grdLanes.Name = "grdLanes";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLanes.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdLanes.RowHeadersVisible = false;
            this.grdLanes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLanes.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.grdLanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdLanes.Size = new System.Drawing.Size(1060, 342);
            this.grdLanes.TabIndex = 0;
            this.grdLanes.ColumnHeadersHeightChanged += new System.EventHandler(this.GrdLanesColumnHeadersHeightChanged);
            this.grdLanes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdLanesCellValueChanged);
            this.grdLanes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GrdLanesDataError);
            this.grdLanes.SizeChanged += new System.EventHandler(this.GrdLanesSizeChanged);
            // 
            // contextMenuStripGrid
            // 
            this.contextMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColumnsMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItemLargerFont,
            this.toolStripMenuItemSmallerFont,
            this.toolStripMenuItem1,
            this.toolStripMenuItemLargerHeaderFont,
            this.toolStripMenuItemSmallerHeaderFont,
            this.toolStripMenuItem3,
            this.toolStripMenuItemSaveSettings,
            this.toolStripMenuItemLoadSettings});
            this.contextMenuStripGrid.Name = "contextMenuStrip1";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(221, 176);
            // 
            // ColumnsMenuItem
            // 
            this.ColumnsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColumnIDMenuItem,
            this.DriverMenuItem,
            this.CarPictureMenuItem,
            this.FuelLevelMenuItem,
            this.LapsMenuItem,
            this.PosMenuItem,
            this.BestLapTimeMenuItem,
            this.LapTimeMenuItem,
            this.LapTimeBestMenuItem,
            this.fuelConsumptionWithAverageToolStripMenuItem,
            this.FuelConsumptionMenuItem,
            this.StatusMenuItem});
            this.ColumnsMenuItem.Name = "ColumnsMenuItem";
            this.ColumnsMenuItem.Size = new System.Drawing.Size(220, 22);
            this.ColumnsMenuItem.Text = "Spalten";
            this.ColumnsMenuItem.Visible = false;
            // 
            // ColumnIDMenuItem
            // 
            this.ColumnIDMenuItem.Checked = true;
            this.ColumnIDMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ColumnIDMenuItem.Name = "ColumnIDMenuItem";
            this.ColumnIDMenuItem.Size = new System.Drawing.Size(244, 22);
            this.ColumnIDMenuItem.Tag = "ColumnID";
            this.ColumnIDMenuItem.Text = "SCX-ID";
            // 
            // DriverMenuItem
            // 
            this.DriverMenuItem.Checked = true;
            this.DriverMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DriverMenuItem.Name = "DriverMenuItem";
            this.DriverMenuItem.Size = new System.Drawing.Size(244, 22);
            this.DriverMenuItem.Tag = "ColumnDriver";
            this.DriverMenuItem.Text = "Driver";
            // 
            // CarPictureMenuItem
            // 
            this.CarPictureMenuItem.Checked = true;
            this.CarPictureMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CarPictureMenuItem.Name = "CarPictureMenuItem";
            this.CarPictureMenuItem.Size = new System.Drawing.Size(244, 22);
            this.CarPictureMenuItem.Tag = "ColumnCar";
            this.CarPictureMenuItem.Text = "Car";
            // 
            // FuelLevelMenuItem
            // 
            this.FuelLevelMenuItem.Checked = true;
            this.FuelLevelMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FuelLevelMenuItem.Name = "FuelLevelMenuItem";
            this.FuelLevelMenuItem.Size = new System.Drawing.Size(244, 22);
            this.FuelLevelMenuItem.Tag = "ColumnFuelLevel";
            this.FuelLevelMenuItem.Text = "Fuel Level";
            // 
            // LapsMenuItem
            // 
            this.LapsMenuItem.Checked = true;
            this.LapsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LapsMenuItem.Name = "LapsMenuItem";
            this.LapsMenuItem.Size = new System.Drawing.Size(244, 22);
            this.LapsMenuItem.Tag = "ColumnLapCount";
            this.LapsMenuItem.Text = "Laps";
            // 
            // PosMenuItem
            // 
            this.PosMenuItem.Checked = true;
            this.PosMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PosMenuItem.Name = "PosMenuItem";
            this.PosMenuItem.Size = new System.Drawing.Size(244, 22);
            this.PosMenuItem.Tag = "ColumnPosition";
            this.PosMenuItem.Text = "Position";
            // 
            // BestLapTimeMenuItem
            // 
            this.BestLapTimeMenuItem.Checked = true;
            this.BestLapTimeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BestLapTimeMenuItem.Name = "BestLapTimeMenuItem";
            this.BestLapTimeMenuItem.Size = new System.Drawing.Size(244, 22);
            this.BestLapTimeMenuItem.Tag = "ColumnBestLapTime";
            this.BestLapTimeMenuItem.Text = "Best Lap Time";
            // 
            // LapTimeMenuItem
            // 
            this.LapTimeMenuItem.Checked = true;
            this.LapTimeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LapTimeMenuItem.Name = "LapTimeMenuItem";
            this.LapTimeMenuItem.Size = new System.Drawing.Size(244, 22);
            this.LapTimeMenuItem.Tag = "ColumnLapTime";
            this.LapTimeMenuItem.Text = "Lap Time";
            // 
            // LapTimeBestMenuItem
            // 
            this.LapTimeBestMenuItem.Checked = true;
            this.LapTimeBestMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LapTimeBestMenuItem.Name = "LapTimeBestMenuItem";
            this.LapTimeBestMenuItem.Size = new System.Drawing.Size(244, 22);
            this.LapTimeBestMenuItem.Tag = "ColumnLapTimeBestLapTime";
            this.LapTimeBestMenuItem.Text = "Lap Time / Best";
            // 
            // fuelConsumptionWithAverageToolStripMenuItem
            // 
            this.fuelConsumptionWithAverageToolStripMenuItem.Checked = true;
            this.fuelConsumptionWithAverageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fuelConsumptionWithAverageToolStripMenuItem.Name = "fuelConsumptionWithAverageToolStripMenuItem";
            this.fuelConsumptionWithAverageToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.fuelConsumptionWithAverageToolStripMenuItem.Tag = "ColumnFuelConsumptionwithAverage";
            this.fuelConsumptionWithAverageToolStripMenuItem.Text = "Fuel Consumption Factor / Average";
            // 
            // FuelConsumptionMenuItem
            // 
            this.FuelConsumptionMenuItem.Checked = true;
            this.FuelConsumptionMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FuelConsumptionMenuItem.Name = "FuelConsumptionMenuItem";
            this.FuelConsumptionMenuItem.Size = new System.Drawing.Size(244, 22);
            this.FuelConsumptionMenuItem.Tag = "ColumnFuelConsumption";
            this.FuelConsumptionMenuItem.Text = "FuelConsumptionFactor";
            // 
            // StatusMenuItem
            // 
            this.StatusMenuItem.Checked = true;
            this.StatusMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StatusMenuItem.Name = "StatusMenuItem";
            this.StatusMenuItem.Size = new System.Drawing.Size(244, 22);
            this.StatusMenuItem.Tag = "ColumnStatus";
            this.StatusMenuItem.Text = "Status";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 6);
            this.toolStripMenuItem2.Visible = false;
            // 
            // toolStripMenuItemLargerFont
            // 
            this.toolStripMenuItemLargerFont.Name = "toolStripMenuItemLargerFont";
            this.toolStripMenuItemLargerFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.toolStripMenuItemLargerFont.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemLargerFont.Text = "Spaltenschrift größer";
            this.toolStripMenuItemLargerFont.Click += new System.EventHandler(this.ToolStripMenuItemLargerFontClick);
            // 
            // toolStripMenuItemSmallerFont
            // 
            this.toolStripMenuItemSmallerFont.Name = "toolStripMenuItemSmallerFont";
            this.toolStripMenuItemSmallerFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Y)));
            this.toolStripMenuItemSmallerFont.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemSmallerFont.Text = "Spaltenschrift kleiner";
            this.toolStripMenuItemSmallerFont.Click += new System.EventHandler(this.ToolStripMenuItemSmallerFontClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 6);
            // 
            // toolStripMenuItemLargerHeaderFont
            // 
            this.toolStripMenuItemLargerHeaderFont.Name = "toolStripMenuItemLargerHeaderFont";
            this.toolStripMenuItemLargerHeaderFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.toolStripMenuItemLargerHeaderFont.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemLargerHeaderFont.Text = "Headerschrift größer";
            this.toolStripMenuItemLargerHeaderFont.Click += new System.EventHandler(this.ToolStripMenuItemLargerHeaderFontClick);
            // 
            // toolStripMenuItemSmallerHeaderFont
            // 
            this.toolStripMenuItemSmallerHeaderFont.Name = "toolStripMenuItemSmallerHeaderFont";
            this.toolStripMenuItemSmallerHeaderFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItemSmallerHeaderFont.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemSmallerHeaderFont.Text = "Headerschrift kleiner";
            this.toolStripMenuItemSmallerHeaderFont.Click += new System.EventHandler(this.ToolStripMenuItemSmallerHeaderFontClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(217, 6);
            // 
            // toolStripMenuItemSaveSettings
            // 
            this.toolStripMenuItemSaveSettings.Name = "toolStripMenuItemSaveSettings";
            this.toolStripMenuItemSaveSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSaveSettings.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemSaveSettings.Text = "Einstellungen speichern";
            this.toolStripMenuItemSaveSettings.Click += new System.EventHandler(this.ToolStripMenuItemSaveSettingsClick);
            // 
            // toolStripMenuItemLoadSettings
            // 
            this.toolStripMenuItemLoadSettings.Name = "toolStripMenuItemLoadSettings";
            this.toolStripMenuItemLoadSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.toolStripMenuItemLoadSettings.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemLoadSettings.Text = "Einstellungen laden";
            this.toolStripMenuItemLoadSettings.Click += new System.EventHandler(this.ToolStripMenuItemLoadSettingsClick);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(750, 368);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(167, 38);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(923, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(149, 38);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(12, 368);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(149, 38);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefreshClick);
            // 
            // ColumnID
            // 
            this.ColumnID.DataPropertyName = "ScxId";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnID.Width = 66;
            // 
            // ColumnDriver
            // 
            this.ColumnDriver.DataPropertyName = "Driver";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDriver.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnDriver.HeaderText = "Driver";
            this.ColumnDriver.Name = "ColumnDriver";
            this.ColumnDriver.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDriver.Width = 115;
            // 
            // ColumnCar
            // 
            this.ColumnCar.DataPropertyName = "Car";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.ColumnCar.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnCar.HeaderText = "Car";
            this.ColumnCar.Name = "ColumnCar";
            this.ColumnCar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCar.Width = 81;
            // 
            // ColumnLapCount
            // 
            this.ColumnLapCount.DataPropertyName = "Lap";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLapCount.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnLapCount.HeaderText = "Laps";
            this.ColumnLapCount.Name = "ColumnLapCount";
            this.ColumnLapCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLapCount.Width = 78;
            // 
            // ColumnOverallPenalties
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnOverallPenalties.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnOverallPenalties.HeaderText = "Overall Penalties #";
            this.ColumnOverallPenalties.Name = "ColumnOverallPenalties";
            // 
            // ColumnStatus
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnStatus.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.Name = "ColumnStatus";
            // 
            // UpdateLanesForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1084, 418);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grdLanes);
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.KeyPreview = true;
            this.Name = "UpdateLanesForm";
            this.Text = "Update Lanes";
            this.Load += new System.EventHandler(this.UpdateLanesFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.grdLanes)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdLanes;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem ColumnsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColumnIDMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DriverMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CarPictureMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FuelLevelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LapsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BestLapTimeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LapTimeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LapTimeBestMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuelConsumptionWithAverageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FuelConsumptionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StatusMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLargerFont;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSmallerFont;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLargerHeaderFont;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSmallerHeaderFont;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnDriver;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLapCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOverallPenalties;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnStatus;
    }
}