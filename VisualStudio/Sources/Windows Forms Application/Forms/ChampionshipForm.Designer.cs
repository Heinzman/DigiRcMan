namespace Elreg.WindowsFormsApplication.Forms
{
    partial class ChampionshipForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdLanes = new Elreg.Controls.PrettyGrid();
            this.ColumnPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDriver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ColumnsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnIDMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DriverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CarPictureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LapsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BestLapTimeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LapTimeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LapTimeBestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
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
            this.ColumnPosition,
            this.ColumnDriver,
            this.ColumnPoints});
            this.grdLanes.ContextMenuStrip = this.contextMenuStripGrid;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdLanes.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdLanes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdLanes.Location = new System.Drawing.Point(12, 12);
            this.grdLanes.Name = "grdLanes";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLanes.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
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
            this.grdLanes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrdLanesKeyDown);
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
            this.ColumnPosition.ReadOnly = true;
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
            this.toolStripMenuItem4,
            this.toolStripMenuItemCopyToClipboard});
            this.contextMenuStripGrid.Name = "contextMenuStrip1";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(221, 226);
            // 
            // ColumnsMenuItem
            // 
            this.ColumnsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColumnIDMenuItem,
            this.DriverMenuItem,
            this.CarPictureMenuItem,
            this.LapsMenuItem,
            this.PosMenuItem,
            this.BestLapTimeMenuItem,
            this.LapTimeMenuItem,
            this.LapTimeBestMenuItem,
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
            this.ColumnIDMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ColumnIDMenuItem.Tag = "ColumnID";
            this.ColumnIDMenuItem.Text = "SCX-ID";
            // 
            // DriverMenuItem
            // 
            this.DriverMenuItem.Checked = true;
            this.DriverMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DriverMenuItem.Name = "DriverMenuItem";
            this.DriverMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DriverMenuItem.Tag = "ColumnDriver";
            this.DriverMenuItem.Text = "Driver";
            // 
            // CarPictureMenuItem
            // 
            this.CarPictureMenuItem.Checked = true;
            this.CarPictureMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CarPictureMenuItem.Name = "CarPictureMenuItem";
            this.CarPictureMenuItem.Size = new System.Drawing.Size(152, 22);
            this.CarPictureMenuItem.Tag = "ColumnCar";
            this.CarPictureMenuItem.Text = "Car";
            // 
            // LapsMenuItem
            // 
            this.LapsMenuItem.Checked = true;
            this.LapsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LapsMenuItem.Name = "LapsMenuItem";
            this.LapsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LapsMenuItem.Tag = "ColumnLapCount";
            this.LapsMenuItem.Text = "Laps";
            // 
            // PosMenuItem
            // 
            this.PosMenuItem.Checked = true;
            this.PosMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PosMenuItem.Name = "PosMenuItem";
            this.PosMenuItem.Size = new System.Drawing.Size(152, 22);
            this.PosMenuItem.Tag = "ColumnPosition";
            this.PosMenuItem.Text = "Position";
            // 
            // BestLapTimeMenuItem
            // 
            this.BestLapTimeMenuItem.Checked = true;
            this.BestLapTimeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BestLapTimeMenuItem.Name = "BestLapTimeMenuItem";
            this.BestLapTimeMenuItem.Size = new System.Drawing.Size(152, 22);
            this.BestLapTimeMenuItem.Tag = "ColumnBestLapTime";
            this.BestLapTimeMenuItem.Text = "Best Lap Time";
            // 
            // LapTimeMenuItem
            // 
            this.LapTimeMenuItem.Checked = true;
            this.LapTimeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LapTimeMenuItem.Name = "LapTimeMenuItem";
            this.LapTimeMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LapTimeMenuItem.Tag = "ColumnLapTime";
            this.LapTimeMenuItem.Text = "Lap Time";
            // 
            // LapTimeBestMenuItem
            // 
            this.LapTimeBestMenuItem.Checked = true;
            this.LapTimeBestMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LapTimeBestMenuItem.Name = "LapTimeBestMenuItem";
            this.LapTimeBestMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LapTimeBestMenuItem.Tag = "ColumnLapTimeBestLapTime";
            this.LapTimeBestMenuItem.Text = "Lap Time / Best";
            // 
            // StatusMenuItem
            // 
            this.StatusMenuItem.Checked = true;
            this.StatusMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StatusMenuItem.Name = "StatusMenuItem";
            this.StatusMenuItem.Size = new System.Drawing.Size(152, 22);
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
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(217, 6);
            // 
            // toolStripMenuItemCopyToClipboard
            // 
            this.toolStripMenuItemCopyToClipboard.Name = "toolStripMenuItemCopyToClipboard";
            this.toolStripMenuItemCopyToClipboard.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemCopyToClipboard.Text = "Copy Table to Clipboard";
            this.toolStripMenuItemCopyToClipboard.Click += new System.EventHandler(this.ToolStripMenuItemCopyToClipboardClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(712, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 38);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Position";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Driver";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.HeaderText = "# Laps";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 78;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle9;
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn7.HeaderText = "Factor Fuel Consumption";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(895, 368);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(177, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Schließen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // ChampionshipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1084, 418);
            this.Controls.Add(this.grdLanes);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.KeyPreview = true;
            this.Name = "ChampionshipForm";
            this.Text = "Championship";
            this.Load += new System.EventHandler(this.ChampionshipFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.grdLanes)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Elreg.Controls.PrettyGrid grdLanes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDriver;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPoints;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem ColumnsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColumnIDMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DriverMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CarPictureMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LapsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BestLapTimeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LapTimeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LapTimeBestMenuItem;
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyToClipboard;
    }
}