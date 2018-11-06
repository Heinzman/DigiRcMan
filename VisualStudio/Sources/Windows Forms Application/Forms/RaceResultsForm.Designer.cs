namespace Elreg.WindowsFormsApplication.Forms
{
    partial class RaceResultsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyTableToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ColumnPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDriver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCar = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnCarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLapCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBestLapTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPenalties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRaceTimeNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLanes)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdLanes
            // 
            this.grdLanes.AllowUserToAddRows = false;
            this.grdLanes.AllowUserToDeleteRows = false;
            this.grdLanes.AllowUserToOrderColumns = true;
            this.grdLanes.AllowUserToResizeRows = false;
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
            this.ColumnPosition,
            this.ColumnDriver,
            this.ColumnCar,
            this.ColumnCarName,
            this.ColumnPoints,
            this.ColumnLapCount,
            this.ColumnBestLapTime,
            this.ColumnPenalties,
            this.ColumnRaceTimeNet});
            this.grdLanes.ContextMenuStrip = this.contextMenuStripGrid;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdLanes.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdLanes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdLanes.Location = new System.Drawing.Point(12, 12);
            this.grdLanes.Name = "grdLanes";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLanes.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdLanes.RowHeadersVisible = false;
            this.grdLanes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLanes.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.grdLanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdLanes.Size = new System.Drawing.Size(639, 351);
            this.grdLanes.TabIndex = 0;
            this.grdLanes.ColumnHeadersHeightChanged += new System.EventHandler(this.GrdLanesColumnHeadersHeightChanged);
            this.grdLanes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdLanesCellValueChanged);
            this.grdLanes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GrdLanesDataError);
            this.grdLanes.SizeChanged += new System.EventHandler(this.GrdLanesSizeChanged);
            this.grdLanes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdLanesKeyDown);
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
            this.toolStripMenuItemLoadSettings,
            this.toolStripSeparator1,
            this.copyTableToClipboardToolStripMenuItem});
            this.contextMenuStripGrid.Name = "contextMenuStrip1";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(221, 204);
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
            this.FuelLevelMenuItem.Tag = "ColumnCarFuelLevel";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // copyTableToClipboardToolStripMenuItem
            // 
            this.copyTableToClipboardToolStripMenuItem.Name = "copyTableToClipboardToolStripMenuItem";
            this.copyTableToClipboardToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.copyTableToClipboardToolStripMenuItem.Text = "Copy Table to Clipboard";
            this.copyTableToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyTableToClipboardToolStripMenuItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(474, 377);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(177, 38);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Schließen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Position";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Driver";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn2.HeaderText = "Driver";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 115;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Points";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Lap";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn4.HeaderText = "# Laps";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 78;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn5.HeaderText = "# Penalties";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "# Pitstops";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn7.HeaderText = "Factor Fuel Consumption";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(12, 377);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(177, 38);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "&Löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(291, 377);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 38);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "S&peichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // ColumnPosition
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.ColumnPosition.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnPosition.HeaderText = "Position";
            this.ColumnPosition.Name = "ColumnPosition";
            this.ColumnPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.ColumnDriver.ReadOnly = true;
            this.ColumnDriver.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDriver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnDriver.Width = 115;
            // 
            // ColumnCar
            // 
            this.ColumnCar.HeaderText = "Car";
            this.ColumnCar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.ColumnCar.Name = "ColumnCar";
            this.ColumnCar.ReadOnly = true;
            // 
            // ColumnCarName
            // 
            this.ColumnCarName.HeaderText = "Car";
            this.ColumnCarName.Name = "ColumnCarName";
            this.ColumnCarName.ReadOnly = true;
            // 
            // ColumnPoints
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.ColumnPoints.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnPoints.HeaderText = "Points";
            this.ColumnPoints.Name = "ColumnPoints";
            this.ColumnPoints.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnLapCount
            // 
            this.ColumnLapCount.DataPropertyName = "Lap";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLapCount.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnLapCount.HeaderText = "# Laps";
            this.ColumnLapCount.Name = "ColumnLapCount";
            this.ColumnLapCount.ReadOnly = true;
            this.ColumnLapCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLapCount.Width = 78;
            // 
            // ColumnBestLapTime
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.ColumnBestLapTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnBestLapTime.HeaderText = "Best Laptime";
            this.ColumnBestLapTime.Name = "ColumnBestLapTime";
            this.ColumnBestLapTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPenalties
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnPenalties.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnPenalties.HeaderText = "# Penalties";
            this.ColumnPenalties.Name = "ColumnPenalties";
            this.ColumnPenalties.ReadOnly = true;
            this.ColumnPenalties.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnRaceTimeNet
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnRaceTimeNet.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnRaceTimeNet.HeaderText = "Race Time";
            this.ColumnRaceTimeNet.Name = "ColumnRaceTimeNet";
            this.ColumnRaceTimeNet.ReadOnly = true;
            this.ColumnRaceTimeNet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RaceResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(663, 427);
            this.Controls.Add(this.grdLanes);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.KeyPreview = true;
            this.Name = "RaceResultsForm";
            this.Text = "Race Results";
            this.Load += new System.EventHandler(this.RaceResultsFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.grdLanes)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdLanes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem copyTableToClipboardToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDriver;
        private System.Windows.Forms.DataGridViewImageColumn ColumnCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLapCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBestLapTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPenalties;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRaceTimeNet;
    }
}