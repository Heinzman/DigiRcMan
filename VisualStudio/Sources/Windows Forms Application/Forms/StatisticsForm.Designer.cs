namespace Elreg.WindowsFormsApplication.Forms
{
    partial class StatisticsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this._grdStatistics = new System.Windows.Forms.DataGridView();
            this.ColumnDriver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCar = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnCarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBestLapTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAvgLapTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTrackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRaceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.toolStripMenuItemcopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbxGroupBy = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGasWarning = new System.Windows.Forms.Label();
            this.cbxTrackName = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxSortBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxEventNames = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxRaceTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._grdStatistics)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grdStatistics
            // 
            this._grdStatistics.AllowUserToAddRows = false;
            this._grdStatistics.AllowUserToDeleteRows = false;
            this._grdStatistics.AllowUserToOrderColumns = true;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._grdStatistics.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this._grdStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Candara", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._grdStatistics.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this._grdStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDriver,
            this.ColumnCar,
            this.ColumnCarName,
            this.ColumnBestLapTime,
            this.ColumnAvgLapTime,
            this.ColumnTrackName,
            this.ColumnEventName,
            this.ColumnTimeStamp,
            this.ColumnRaceType});
            this._grdStatistics.ContextMenuStrip = this.contextMenuStripGrid;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grdStatistics.DefaultCellStyle = dataGridViewCellStyle23;
            this._grdStatistics.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this._grdStatistics.Location = new System.Drawing.Point(12, 12);
            this._grdStatistics.Name = "_grdStatistics";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._grdStatistics.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this._grdStatistics.RowHeadersVisible = false;
            this._grdStatistics.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._grdStatistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._grdStatistics.Size = new System.Drawing.Size(842, 330);
            this._grdStatistics.StandardTab = true;
            this._grdStatistics.TabIndex = 0;
            this._grdStatistics.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GrdLanesDataError);
            // 
            // ColumnDriver
            // 
            this.ColumnDriver.DataPropertyName = "DriverName";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDriver.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColumnDriver.HeaderText = "Driver";
            this.ColumnDriver.Name = "ColumnDriver";
            this.ColumnDriver.ReadOnly = true;
            this.ColumnDriver.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDriver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnDriver.Width = 115;
            // 
            // ColumnCar
            // 
            this.ColumnCar.DataPropertyName = "CarImage";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle16.NullValue = null;
            this.ColumnCar.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColumnCar.HeaderText = "Car";
            this.ColumnCar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.ColumnCar.Name = "ColumnCar";
            this.ColumnCar.ReadOnly = true;
            this.ColumnCar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCar.Width = 81;
            // 
            // ColumnCarName
            // 
            this.ColumnCarName.DataPropertyName = "CarName";
            this.ColumnCarName.HeaderText = "Car";
            this.ColumnCarName.Name = "ColumnCarName";
            this.ColumnCarName.ReadOnly = true;
            // 
            // ColumnBestLapTime
            // 
            this.ColumnBestLapTime.DataPropertyName = "BestLapTimeString";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnBestLapTime.DefaultCellStyle = dataGridViewCellStyle17;
            this.ColumnBestLapTime.HeaderText = "Best Lap Time";
            this.ColumnBestLapTime.Name = "ColumnBestLapTime";
            this.ColumnBestLapTime.ReadOnly = true;
            // 
            // ColumnAvgLapTime
            // 
            this.ColumnAvgLapTime.DataPropertyName = "AvgLapTimeString";
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnAvgLapTime.DefaultCellStyle = dataGridViewCellStyle18;
            this.ColumnAvgLapTime.HeaderText = "Avg Lap Time";
            this.ColumnAvgLapTime.Name = "ColumnAvgLapTime";
            this.ColumnAvgLapTime.ReadOnly = true;
            // 
            // ColumnTrackName
            // 
            this.ColumnTrackName.DataPropertyName = "TrackName";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnTrackName.DefaultCellStyle = dataGridViewCellStyle19;
            this.ColumnTrackName.HeaderText = "Track Name";
            this.ColumnTrackName.Name = "ColumnTrackName";
            this.ColumnTrackName.ReadOnly = true;
            // 
            // ColumnEventName
            // 
            this.ColumnEventName.DataPropertyName = "EventName";
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.ColumnEventName.DefaultCellStyle = dataGridViewCellStyle20;
            this.ColumnEventName.HeaderText = "Event Name";
            this.ColumnEventName.Name = "ColumnEventName";
            this.ColumnEventName.ReadOnly = true;
            // 
            // ColumnTimeStamp
            // 
            this.ColumnTimeStamp.DataPropertyName = "TimeStamp";
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.ColumnTimeStamp.DefaultCellStyle = dataGridViewCellStyle21;
            this.ColumnTimeStamp.HeaderText = "Time Stamp";
            this.ColumnTimeStamp.Name = "ColumnTimeStamp";
            this.ColumnTimeStamp.ReadOnly = true;
            this.ColumnTimeStamp.Visible = false;
            // 
            // ColumnRaceType
            // 
            this.ColumnRaceType.DataPropertyName = "RaceType";
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.ColumnRaceType.DefaultCellStyle = dataGridViewCellStyle22;
            this.ColumnRaceType.HeaderText = "Race Type";
            this.ColumnRaceType.Name = "ColumnRaceType";
            this.ColumnRaceType.ReadOnly = true;
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
            this.toolStripMenuItemcopyToClipboard});
            this.contextMenuStripGrid.Name = "contextMenuStrip1";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(249, 226);
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
            this.ColumnsMenuItem.Size = new System.Drawing.Size(248, 22);
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
            this.toolStripMenuItem2.Size = new System.Drawing.Size(245, 6);
            this.toolStripMenuItem2.Visible = false;
            // 
            // toolStripMenuItemLargerFont
            // 
            this.toolStripMenuItemLargerFont.Name = "toolStripMenuItemLargerFont";
            this.toolStripMenuItemLargerFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.toolStripMenuItemLargerFont.Size = new System.Drawing.Size(248, 22);
            this.toolStripMenuItemLargerFont.Text = "Spaltenschrift größer";
            this.toolStripMenuItemLargerFont.Click += new System.EventHandler(this.ToolStripMenuItemLargerFontClick);
            // 
            // toolStripMenuItemSmallerFont
            // 
            this.toolStripMenuItemSmallerFont.Name = "toolStripMenuItemSmallerFont";
            this.toolStripMenuItemSmallerFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Y)));
            this.toolStripMenuItemSmallerFont.Size = new System.Drawing.Size(248, 22);
            this.toolStripMenuItemSmallerFont.Text = "Spaltenschrift kleiner";
            this.toolStripMenuItemSmallerFont.Click += new System.EventHandler(this.ToolStripMenuItemSmallerFontClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(245, 6);
            // 
            // toolStripMenuItemLargerHeaderFont
            // 
            this.toolStripMenuItemLargerHeaderFont.Name = "toolStripMenuItemLargerHeaderFont";
            this.toolStripMenuItemLargerHeaderFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.toolStripMenuItemLargerHeaderFont.Size = new System.Drawing.Size(248, 22);
            this.toolStripMenuItemLargerHeaderFont.Text = "Headerschrift größer";
            this.toolStripMenuItemLargerHeaderFont.Click += new System.EventHandler(this.ToolStripMenuItemLargerHeaderFontClick);
            // 
            // toolStripMenuItemSmallerHeaderFont
            // 
            this.toolStripMenuItemSmallerHeaderFont.Name = "toolStripMenuItemSmallerHeaderFont";
            this.toolStripMenuItemSmallerHeaderFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItemSmallerHeaderFont.Size = new System.Drawing.Size(248, 22);
            this.toolStripMenuItemSmallerHeaderFont.Text = "Headerschrift kleiner";
            this.toolStripMenuItemSmallerHeaderFont.Click += new System.EventHandler(this.ToolStripMenuItemSmallerHeaderFontClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(245, 6);
            // 
            // toolStripMenuItemSaveSettings
            // 
            this.toolStripMenuItemSaveSettings.Name = "toolStripMenuItemSaveSettings";
            this.toolStripMenuItemSaveSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSaveSettings.Size = new System.Drawing.Size(248, 22);
            this.toolStripMenuItemSaveSettings.Text = "Einstellungen speichern als...";
            this.toolStripMenuItemSaveSettings.Click += new System.EventHandler(this.ToolStripMenuItemSaveSettingsClick);
            // 
            // toolStripMenuItemLoadSettings
            // 
            this.toolStripMenuItemLoadSettings.Name = "toolStripMenuItemLoadSettings";
            this.toolStripMenuItemLoadSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.toolStripMenuItemLoadSettings.Size = new System.Drawing.Size(248, 22);
            this.toolStripMenuItemLoadSettings.Text = "Einstellungen laden...";
            this.toolStripMenuItemLoadSettings.Click += new System.EventHandler(this.ToolStripMenuItemLoadSettingsClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // toolStripMenuItemcopyToClipboard
            // 
            this.toolStripMenuItemcopyToClipboard.Name = "toolStripMenuItemcopyToClipboard";
            this.toolStripMenuItemcopyToClipboard.Size = new System.Drawing.Size(248, 22);
            this.toolStripMenuItemcopyToClipboard.Text = "Copy Table to Clipboard";
            this.toolStripMenuItemcopyToClipboard.Click += new System.EventHandler(this.ToolStripMenuItemcopyToClipboardClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(129, 50);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // cbxGroupBy
            // 
            this.cbxGroupBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGroupBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGroupBy.FormattingEnabled = true;
            this.cbxGroupBy.Location = new System.Drawing.Point(145, 45);
            this.cbxGroupBy.Name = "cbxGroupBy";
            this.cbxGroupBy.Size = new System.Drawing.Size(131, 39);
            this.cbxGroupBy.TabIndex = 3;
            this.cbxGroupBy.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 348);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(842, 122);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(830, 88);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.panel3.Controls.Add(this.lblGasWarning);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.cbxTrackName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(552, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(278, 88);
            this.panel3.TabIndex = 2;
            // 
            // lblGasWarning
            // 
            this.lblGasWarning.AutoSize = true;
            this.lblGasWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGasWarning.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblGasWarning.Location = new System.Drawing.Point(6, 3);
            this.lblGasWarning.Name = "lblGasWarning";
            this.lblGasWarning.Size = new System.Drawing.Size(88, 31);
            this.lblGasWarning.TabIndex = 0;
            this.lblGasWarning.Text = "Track";
            // 
            // cbxTrackName
            // 
            this.cbxTrackName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxTrackName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTrackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTrackName.FormattingEnabled = true;
            this.cbxTrackName.Location = new System.Drawing.Point(146, 0);
            this.cbxTrackName.Name = "cbxTrackName";
            this.cbxTrackName.Size = new System.Drawing.Size(132, 39);
            this.cbxTrackName.TabIndex = 1;
            this.cbxTrackName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbxSortBy);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbxEventNames);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(276, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 88);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label3.Location = new System.Drawing.Point(6, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Event";
            // 
            // cbxSortBy
            // 
            this.cbxSortBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSortBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSortBy.FormattingEnabled = true;
            this.cbxSortBy.Location = new System.Drawing.Point(145, 49);
            this.cbxSortBy.Name = "cbxSortBy";
            this.cbxSortBy.Size = new System.Drawing.Size(131, 39);
            this.cbxSortBy.TabIndex = 3;
            this.cbxSortBy.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 31);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sort By";
            // 
            // cbxEventNames
            // 
            this.cbxEventNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxEventNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEventNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEventNames.FormattingEnabled = true;
            this.cbxEventNames.Location = new System.Drawing.Point(145, 0);
            this.cbxEventNames.Name = "cbxEventNames";
            this.cbxEventNames.Size = new System.Drawing.Size(131, 39);
            this.cbxEventNames.TabIndex = 1;
            this.cbxEventNames.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxRaceTypes);
            this.panel1.Controls.Add(this.cbxGroupBy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 88);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label2.Location = new System.Drawing.Point(0, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Type";
            // 
            // cbxRaceTypes
            // 
            this.cbxRaceTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRaceTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRaceTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRaceTypes.FormattingEnabled = true;
            this.cbxRaceTypes.Location = new System.Drawing.Point(145, 0);
            this.cbxRaceTypes.Name = "cbxRaceTypes";
            this.cbxRaceTypes.Size = new System.Drawing.Size(131, 39);
            this.cbxRaceTypes.TabIndex = 1;
            this.cbxRaceTypes.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.label1.Location = new System.Drawing.Point(0, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Group By";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(866, 482);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._grdStatistics);
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.MinimumSize = new System.Drawing.Size(867, 407);
            this.Name = "StatisticsForm";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.StatisticsFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this._grdStatistics)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _grdStatistics;
        private System.Windows.Forms.Button btnClose;
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
        private System.Windows.Forms.ComboBox cbxGroupBy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxRaceTypes;
        private System.Windows.Forms.Label lblGasWarning;
        private System.Windows.Forms.ComboBox cbxEventNames;
        private System.Windows.Forms.ComboBox cbxTrackName;
        private System.Windows.Forms.ComboBox cbxSortBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemcopyToClipboard;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDriver;
        private System.Windows.Forms.DataGridViewImageColumn ColumnCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBestLapTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAvgLapTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTrackName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRaceType;
    }
}