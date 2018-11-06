using Elreg.Controls.ProgressColumns;

namespace Elreg.WindowsFormsApplication.Forms
{
    partial class RaceGridWithPositionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceGridWithPositionForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdLanes = new System.Windows.Forms.DataGridView();
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
            this.PenaltiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemLargerFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSmallerFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemLargerHeaderFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSmallerHeaderFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSaveSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStripRaceStatus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemLargerStatusFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSmallerStatusFont = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRaceTime = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblRaceType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowRaceControlForm = new System.Windows.Forms.Button();
            this.btnNormalize = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStripPosition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemPositionsfontLarger = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPositionsfontSmaller = new System.Windows.Forms.ToolStripMenuItem();
            this.tblPosition2 = new System.Windows.Forms.TableLayoutPanel();
            this.picPosition2 = new System.Windows.Forms.PictureBox();
            this.lblPosition2 = new System.Windows.Forms.Label();
            this.tblPosition1 = new System.Windows.Forms.TableLayoutPanel();
            this.picPosition1 = new System.Windows.Forms.PictureBox();
            this.lblPosition1 = new System.Windows.Forms.Label();
            this.tblPosition3 = new System.Windows.Forms.TableLayoutPanel();
            this.picPosition3 = new System.Windows.Forms.PictureBox();
            this.lblPosition3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.picPosition4 = new System.Windows.Forms.PictureBox();
            this.lblPosition4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.picPosition5 = new System.Windows.Forms.PictureBox();
            this.lblPosition5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.picPosition6 = new System.Windows.Forms.PictureBox();
            this.lblPosition6 = new System.Windows.Forms.Label();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDriver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPenalties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLapCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCar = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBestLapTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLapTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLapTimeBestLapTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLanes)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStripRaceStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuStripPosition.SuspendLayout();
            this.tblPosition2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPosition2)).BeginInit();
            this.tblPosition1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPosition1)).BeginInit();
            this.tblPosition3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPosition3)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPosition4)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPosition5)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPosition6)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLanes
            // 
            this.grdLanes.AllowUserToAddRows = false;
            this.grdLanes.AllowUserToDeleteRows = false;
            this.grdLanes.AllowUserToOrderColumns = true;
            this.grdLanes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Candara", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLanes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnDriver,
            this.ColumnPenalties,
            this.ColumnLapCount,
            this.ColumnCar,
            this.ColumnPosition,
            this.ColumnBestLapTime,
            this.ColumnLapTime,
            this.ColumnLapTimeBestLapTime,
            this.ColumnStatus});
            this.grdLanes.ContextMenuStrip = this.contextMenuStripGrid;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdLanes.DefaultCellStyle = dataGridViewCellStyle12;
            this.grdLanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLanes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdLanes.Location = new System.Drawing.Point(0, 0);
            this.grdLanes.Margin = new System.Windows.Forms.Padding(0);
            this.grdLanes.Name = "grdLanes";
            this.grdLanes.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLanes.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.grdLanes.RowHeadersVisible = false;
            this.grdLanes.RowHeadersWidth = 99;
            this.grdLanes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLanes.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.grdLanes.Size = new System.Drawing.Size(915, 330);
            this.grdLanes.TabIndex = 0;
            this.grdLanes.ColumnHeadersHeightChanged += new System.EventHandler(this.GrdLanesColumnHeadersHeightChanged);
            this.grdLanes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GrdLanesCellFormatting);
            this.grdLanes.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GrdLanesDataError);
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
            this.toolStripMenuItemLoadSettings});
            this.contextMenuStripGrid.Name = "contextMenuStrip1";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(221, 198);
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
            this.StatusMenuItem,
            this.PenaltiesMenuItem});
            this.ColumnsMenuItem.Name = "ColumnsMenuItem";
            this.ColumnsMenuItem.Size = new System.Drawing.Size(220, 22);
            this.ColumnsMenuItem.Text = "Spalten";
            // 
            // ColumnIDMenuItem
            // 
            this.ColumnIDMenuItem.Checked = true;
            this.ColumnIDMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ColumnIDMenuItem.Name = "ColumnIDMenuItem";
            this.ColumnIDMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ColumnIDMenuItem.Tag = "ColumnID";
            this.ColumnIDMenuItem.Text = "SCX-ID";
            this.ColumnIDMenuItem.Click += new System.EventHandler(this.ColumnMenuItemClick);
            // 
            // DriverMenuItem
            // 
            this.DriverMenuItem.Checked = true;
            this.DriverMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DriverMenuItem.Name = "DriverMenuItem";
            this.DriverMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DriverMenuItem.Tag = "ColumnDriver";
            this.DriverMenuItem.Text = "Driver";
            this.DriverMenuItem.Click += new System.EventHandler(this.ColumnMenuItemClick);
            // 
            // CarPictureMenuItem
            // 
            this.CarPictureMenuItem.Checked = true;
            this.CarPictureMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CarPictureMenuItem.Name = "CarPictureMenuItem";
            this.CarPictureMenuItem.Size = new System.Drawing.Size(152, 22);
            this.CarPictureMenuItem.Tag = "ColumnCar";
            this.CarPictureMenuItem.Text = "Car";
            this.CarPictureMenuItem.Click += new System.EventHandler(this.ColumnMenuItemClick);
            // 
            // LapsMenuItem
            // 
            this.LapsMenuItem.Checked = true;
            this.LapsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LapsMenuItem.Name = "LapsMenuItem";
            this.LapsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LapsMenuItem.Tag = "ColumnLapCount";
            this.LapsMenuItem.Text = "Laps";
            this.LapsMenuItem.Click += new System.EventHandler(this.ColumnMenuItemClick);
            // 
            // PosMenuItem
            // 
            this.PosMenuItem.Checked = true;
            this.PosMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PosMenuItem.Name = "PosMenuItem";
            this.PosMenuItem.Size = new System.Drawing.Size(152, 22);
            this.PosMenuItem.Tag = "ColumnPosition";
            this.PosMenuItem.Text = "Position";
            this.PosMenuItem.Click += new System.EventHandler(this.ColumnMenuItemClick);
            // 
            // BestLapTimeMenuItem
            // 
            this.BestLapTimeMenuItem.Checked = true;
            this.BestLapTimeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BestLapTimeMenuItem.Name = "BestLapTimeMenuItem";
            this.BestLapTimeMenuItem.Size = new System.Drawing.Size(152, 22);
            this.BestLapTimeMenuItem.Tag = "ColumnBestLapTime";
            this.BestLapTimeMenuItem.Text = "Best Lap Time";
            this.BestLapTimeMenuItem.Click += new System.EventHandler(this.ColumnMenuItemClick);
            // 
            // LapTimeMenuItem
            // 
            this.LapTimeMenuItem.Checked = true;
            this.LapTimeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LapTimeMenuItem.Name = "LapTimeMenuItem";
            this.LapTimeMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LapTimeMenuItem.Tag = "ColumnLapTime";
            this.LapTimeMenuItem.Text = "Lap Time";
            this.LapTimeMenuItem.Click += new System.EventHandler(this.ColumnMenuItemClick);
            // 
            // LapTimeBestMenuItem
            // 
            this.LapTimeBestMenuItem.Checked = true;
            this.LapTimeBestMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LapTimeBestMenuItem.Name = "LapTimeBestMenuItem";
            this.LapTimeBestMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LapTimeBestMenuItem.Tag = "ColumnLapTimeBestLapTime";
            this.LapTimeBestMenuItem.Text = "Lap Time / Best";
            this.LapTimeBestMenuItem.Click += new System.EventHandler(this.ColumnMenuItemClick);
            // 
            // StatusMenuItem
            // 
            this.StatusMenuItem.Checked = true;
            this.StatusMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StatusMenuItem.Name = "StatusMenuItem";
            this.StatusMenuItem.Size = new System.Drawing.Size(152, 22);
            this.StatusMenuItem.Tag = "ColumnStatus";
            this.StatusMenuItem.Text = "Status";
            this.StatusMenuItem.Click += new System.EventHandler(this.ColumnMenuItemClick);
            // 
            // PenaltiesMenuItem
            // 
            this.PenaltiesMenuItem.Checked = true;
            this.PenaltiesMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PenaltiesMenuItem.Name = "PenaltiesMenuItem";
            this.PenaltiesMenuItem.Size = new System.Drawing.Size(152, 22);
            this.PenaltiesMenuItem.Tag = "ColumnPenalties";
            this.PenaltiesMenuItem.Text = "Penalties";
            this.PenaltiesMenuItem.Click += new System.EventHandler(this.ColumnMenuItemClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 6);
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ScxId";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn1.FillWeight = 12.5F;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Driver";
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn2.FillWeight = 12.5F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Driver";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Lap";
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn3.FillWeight = 12.5F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Laps";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.DataPropertyName = "Car";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewImageColumn1.FillWeight = 20.5F;
            this.dataGridViewImageColumn1.HeaderText = "Car";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Position";
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn4.FillWeight = 12.5F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Pos";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "BestLapTime";
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn5.FillWeight = 12.5F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Best Lap Time";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "LapTime";
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn6.FillWeight = 12.5F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Lap Time";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(915, 501);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1SplitterMoved);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ContextMenuStrip = this.contextMenuStripRaceStatus;
            this.tableLayoutPanel1.Controls.Add(this.lblRaceTime, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRaceType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 25);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // contextMenuStripRaceStatus
            // 
            this.contextMenuStripRaceStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLargerStatusFont,
            this.toolStripMenuItemSmallerStatusFont});
            this.contextMenuStripRaceStatus.Name = "contextMenuStripRaceStatus";
            this.contextMenuStripRaceStatus.Size = new System.Drawing.Size(211, 48);
            // 
            // toolStripMenuItemLargerStatusFont
            // 
            this.toolStripMenuItemLargerStatusFont.Name = "toolStripMenuItemLargerStatusFont";
            this.toolStripMenuItemLargerStatusFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.J)));
            this.toolStripMenuItemLargerStatusFont.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItemLargerStatusFont.Text = "Status-Schrift größer";
            this.toolStripMenuItemLargerStatusFont.Click += new System.EventHandler(this.ToolStripMenuItemLargerStatusFontClick);
            // 
            // toolStripMenuItemSmallerStatusFont
            // 
            this.toolStripMenuItemSmallerStatusFont.Name = "toolStripMenuItemSmallerStatusFont";
            this.toolStripMenuItemSmallerStatusFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.toolStripMenuItemSmallerStatusFont.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItemSmallerStatusFont.Text = "Status-Schrift kleiner";
            this.toolStripMenuItemSmallerStatusFont.Click += new System.EventHandler(this.ToolStripMenuItemSmallerStatusFontClick);
            // 
            // lblRaceTime
            // 
            this.lblRaceTime.ContextMenuStrip = this.contextMenuStripRaceStatus;
            this.lblRaceTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRaceTime.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceTime.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblRaceTime.Location = new System.Drawing.Point(456, 0);
            this.lblRaceTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblRaceTime.Name = "lblRaceTime";
            this.lblRaceTime.Size = new System.Drawing.Size(228, 25);
            this.lblRaceTime.TabIndex = 2;
            this.lblRaceTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.ContextMenuStrip = this.contextMenuStripRaceStatus;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblStatus.Location = new System.Drawing.Point(228, 0);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(228, 25);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRaceType
            // 
            this.lblRaceType.ContextMenuStrip = this.contextMenuStripRaceStatus;
            this.lblRaceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRaceType.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceType.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblRaceType.Location = new System.Drawing.Point(0, 0);
            this.lblRaceType.Margin = new System.Windows.Forms.Padding(0);
            this.lblRaceType.Name = "lblRaceType";
            this.lblRaceType.Size = new System.Drawing.Size(228, 25);
            this.lblRaceType.TabIndex = 0;
            this.lblRaceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.panel1.Controls.Add(this.btnShowRaceControlForm);
            this.panel1.Controls.Add(this.btnNormalize);
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(684, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 25);
            this.panel1.TabIndex = 2;
            // 
            // btnShowRaceControlForm
            // 
            this.btnShowRaceControlForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowRaceControlForm.BackColor = System.Drawing.SystemColors.Control;
            this.btnShowRaceControlForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowRaceControlForm.Location = new System.Drawing.Point(0, 0);
            this.btnShowRaceControlForm.Margin = new System.Windows.Forms.Padding(0);
            this.btnShowRaceControlForm.Name = "btnShowRaceControlForm";
            this.btnShowRaceControlForm.Size = new System.Drawing.Size(201, 27);
            this.btnShowRaceControlForm.TabIndex = 5;
            this.btnShowRaceControlForm.Text = "Hauptfenster {Pos1}";
            this.btnShowRaceControlForm.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnShowRaceControlForm.UseVisualStyleBackColor = false;
            this.btnShowRaceControlForm.Click += new System.EventHandler(this.BtnShowRaceControlFormClick);
            // 
            // btnNormalize
            // 
            this.btnNormalize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNormalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNormalize.Location = new System.Drawing.Point(143, 49);
            this.btnNormalize.Name = "btnNormalize";
            this.btnNormalize.Size = new System.Drawing.Size(26, 26);
            this.btnNormalize.TabIndex = 4;
            this.btnNormalize.Text = "=";
            this.btnNormalize.UseVisualStyleBackColor = true;
            this.btnNormalize.Visible = false;
            this.btnNormalize.Click += new System.EventHandler(this.BtnNormalizeClick);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(155, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(26, 26);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Visible = false;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimizeClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(205, 0);
            this.btnClose.MaximumSize = new System.Drawing.Size(26, 26);
            this.btnClose.MinimumSize = new System.Drawing.Size(26, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grdLanes);
            this.splitContainer2.Size = new System.Drawing.Size(915, 472);
            this.splitContainer2.SplitterDistance = 138;
            this.splitContainer2.TabIndex = 2;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer2SplitterMoved);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.ContextMenuStrip = this.contextMenuStripPosition;
            this.tableLayoutPanel2.Controls.Add(this.tblPosition2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tblPosition1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tblPosition3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 5, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(915, 138);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // contextMenuStripPosition
            // 
            this.contextMenuStripPosition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemPositionsfontLarger,
            this.toolStripMenuItemPositionsfontSmaller});
            this.contextMenuStripPosition.Name = "contextMenuStripRaceStatus";
            this.contextMenuStripPosition.Size = new System.Drawing.Size(217, 48);
            // 
            // toolStripMenuItemPositionsfontLarger
            // 
            this.toolStripMenuItemPositionsfontLarger.Name = "toolStripMenuItemPositionsfontLarger";
            this.toolStripMenuItemPositionsfontLarger.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.toolStripMenuItemPositionsfontLarger.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemPositionsfontLarger.Text = "Positionsschrift größer";
            this.toolStripMenuItemPositionsfontLarger.Click += new System.EventHandler(this.ToolStripMenuItemPositionsfontLargerClick);
            // 
            // toolStripMenuItemPositionsfontSmaller
            // 
            this.toolStripMenuItemPositionsfontSmaller.Name = "toolStripMenuItemPositionsfontSmaller";
            this.toolStripMenuItemPositionsfontSmaller.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.toolStripMenuItemPositionsfontSmaller.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItemPositionsfontSmaller.Text = "Positionsschrift kleiner";
            this.toolStripMenuItemPositionsfontSmaller.Click += new System.EventHandler(this.ToolStripMenuItemPositionsfontSmallerClick);
            // 
            // tblPosition2
            // 
            this.tblPosition2.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tblPosition2, 2);
            this.tblPosition2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblPosition2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblPosition2.Controls.Add(this.picPosition2, 0, 0);
            this.tblPosition2.Controls.Add(this.lblPosition2, 1, 0);
            this.tblPosition2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPosition2.Location = new System.Drawing.Point(130, 69);
            this.tblPosition2.Margin = new System.Windows.Forms.Padding(0);
            this.tblPosition2.Name = "tblPosition2";
            this.tblPosition2.RowCount = 1;
            this.tblPosition2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPosition2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tblPosition2.Size = new System.Drawing.Size(260, 69);
            this.tblPosition2.TabIndex = 9;
            // 
            // picPosition2
            // 
            this.picPosition2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPosition2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPosition2.BackgroundImage")));
            this.picPosition2.Location = new System.Drawing.Point(0, 0);
            this.picPosition2.Margin = new System.Windows.Forms.Padding(0);
            this.picPosition2.Name = "picPosition2";
            this.picPosition2.Size = new System.Drawing.Size(78, 69);
            this.picPosition2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPosition2.TabIndex = 7;
            this.picPosition2.TabStop = false;
            // 
            // lblPosition2
            // 
            this.lblPosition2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosition2.ContextMenuStrip = this.contextMenuStripPosition;
            this.lblPosition2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition2.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblPosition2.Location = new System.Drawing.Point(78, 0);
            this.lblPosition2.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosition2.Name = "lblPosition2";
            this.lblPosition2.Size = new System.Drawing.Size(182, 69);
            this.lblPosition2.TabIndex = 1;
            this.lblPosition2.Text = "1.Heinz";
            this.lblPosition2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblPosition1
            // 
            this.tblPosition1.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tblPosition1, 2);
            this.tblPosition1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblPosition1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblPosition1.Controls.Add(this.picPosition1, 0, 0);
            this.tblPosition1.Controls.Add(this.lblPosition1, 1, 0);
            this.tblPosition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPosition1.Location = new System.Drawing.Point(0, 0);
            this.tblPosition1.Margin = new System.Windows.Forms.Padding(0);
            this.tblPosition1.Name = "tblPosition1";
            this.tblPosition1.RowCount = 1;
            this.tblPosition1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPosition1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tblPosition1.Size = new System.Drawing.Size(260, 69);
            this.tblPosition1.TabIndex = 7;
            // 
            // picPosition1
            // 
            this.picPosition1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPosition1.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.picPosition1.Location = new System.Drawing.Point(0, 0);
            this.picPosition1.Margin = new System.Windows.Forms.Padding(0);
            this.picPosition1.Name = "picPosition1";
            this.picPosition1.Size = new System.Drawing.Size(78, 69);
            this.picPosition1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPosition1.TabIndex = 7;
            this.picPosition1.TabStop = false;
            // 
            // lblPosition1
            // 
            this.lblPosition1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosition1.ContextMenuStrip = this.contextMenuStripPosition;
            this.lblPosition1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition1.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblPosition1.Location = new System.Drawing.Point(78, 0);
            this.lblPosition1.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosition1.Name = "lblPosition1";
            this.lblPosition1.Size = new System.Drawing.Size(182, 69);
            this.lblPosition1.TabIndex = 1;
            this.lblPosition1.Text = "1.Heinz";
            this.lblPosition1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblPosition3
            // 
            this.tblPosition3.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tblPosition3, 2);
            this.tblPosition3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblPosition3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tblPosition3.Controls.Add(this.picPosition3, 0, 0);
            this.tblPosition3.Controls.Add(this.lblPosition3, 1, 0);
            this.tblPosition3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPosition3.Location = new System.Drawing.Point(260, 0);
            this.tblPosition3.Margin = new System.Windows.Forms.Padding(0);
            this.tblPosition3.Name = "tblPosition3";
            this.tblPosition3.RowCount = 1;
            this.tblPosition3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPosition3.Size = new System.Drawing.Size(260, 69);
            this.tblPosition3.TabIndex = 8;
            // 
            // picPosition3
            // 
            this.picPosition3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPosition3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPosition3.BackgroundImage")));
            this.picPosition3.Location = new System.Drawing.Point(0, 0);
            this.picPosition3.Margin = new System.Windows.Forms.Padding(0);
            this.picPosition3.Name = "picPosition3";
            this.picPosition3.Size = new System.Drawing.Size(78, 69);
            this.picPosition3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPosition3.TabIndex = 8;
            this.picPosition3.TabStop = false;
            // 
            // lblPosition3
            // 
            this.lblPosition3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosition3.ContextMenuStrip = this.contextMenuStripPosition;
            this.lblPosition3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition3.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblPosition3.Location = new System.Drawing.Point(78, 0);
            this.lblPosition3.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosition3.Name = "lblPosition3";
            this.lblPosition3.Size = new System.Drawing.Size(182, 69);
            this.lblPosition3.TabIndex = 2;
            this.lblPosition3.Text = "3.Mannie";
            this.lblPosition3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.picPosition4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblPosition4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(390, 69);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(260, 69);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // picPosition4
            // 
            this.picPosition4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPosition4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPosition4.BackgroundImage")));
            this.picPosition4.Location = new System.Drawing.Point(0, 0);
            this.picPosition4.Margin = new System.Windows.Forms.Padding(0);
            this.picPosition4.Name = "picPosition4";
            this.picPosition4.Size = new System.Drawing.Size(78, 69);
            this.picPosition4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPosition4.TabIndex = 7;
            this.picPosition4.TabStop = false;
            // 
            // lblPosition4
            // 
            this.lblPosition4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosition4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition4.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblPosition4.Location = new System.Drawing.Point(78, 0);
            this.lblPosition4.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosition4.Name = "lblPosition4";
            this.lblPosition4.Size = new System.Drawing.Size(182, 69);
            this.lblPosition4.TabIndex = 1;
            this.lblPosition4.Text = "1.Heinz";
            this.lblPosition4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.Controls.Add(this.picPosition5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblPosition5, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(520, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(260, 69);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // picPosition5
            // 
            this.picPosition5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPosition5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPosition5.BackgroundImage")));
            this.picPosition5.Location = new System.Drawing.Point(0, 0);
            this.picPosition5.Margin = new System.Windows.Forms.Padding(0);
            this.picPosition5.Name = "picPosition5";
            this.picPosition5.Size = new System.Drawing.Size(78, 69);
            this.picPosition5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPosition5.TabIndex = 7;
            this.picPosition5.TabStop = false;
            // 
            // lblPosition5
            // 
            this.lblPosition5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosition5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition5.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblPosition5.Location = new System.Drawing.Point(78, 0);
            this.lblPosition5.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosition5.Name = "lblPosition5";
            this.lblPosition5.Size = new System.Drawing.Size(182, 69);
            this.lblPosition5.TabIndex = 1;
            this.lblPosition5.Text = "1.Heinz";
            this.lblPosition5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel5, 2);
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.Controls.Add(this.picPosition6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblPosition6, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(650, 69);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(265, 69);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // picPosition6
            // 
            this.picPosition6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPosition6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPosition6.BackgroundImage")));
            this.picPosition6.Location = new System.Drawing.Point(0, 0);
            this.picPosition6.Margin = new System.Windows.Forms.Padding(0);
            this.picPosition6.Name = "picPosition6";
            this.picPosition6.Size = new System.Drawing.Size(79, 69);
            this.picPosition6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPosition6.TabIndex = 7;
            this.picPosition6.TabStop = false;
            // 
            // lblPosition6
            // 
            this.lblPosition6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosition6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition6.Image = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.lblPosition6.Location = new System.Drawing.Point(79, 0);
            this.lblPosition6.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosition6.Name = "lblPosition6";
            this.lblPosition6.Size = new System.Drawing.Size(186, 69);
            this.lblPosition6.TabIndex = 1;
            this.lblPosition6.Text = "1.Heinz";
            this.lblPosition6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.ColumnDriver.ReadOnly = true;
            this.ColumnDriver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnDriver.Width = 115;
            // 
            // ColumnPenalties
            // 
            this.ColumnPenalties.DataPropertyName = "Penalties";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPenalties.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnPenalties.HeaderText = "# Penalties";
            this.ColumnPenalties.Name = "ColumnPenalties";
            this.ColumnPenalties.ReadOnly = true;
            this.ColumnPenalties.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.ColumnLapCount.ReadOnly = true;
            this.ColumnLapCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLapCount.Width = 78;
            // 
            // ColumnCar
            // 
            this.ColumnCar.DataPropertyName = "Car";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.NullValue = "null";
            this.ColumnCar.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnCar.HeaderText = "Car";
            this.ColumnCar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.ColumnCar.Name = "ColumnCar";
            this.ColumnCar.ReadOnly = true;
            this.ColumnCar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCar.Width = 81;
            // 
            // ColumnPosition
            // 
            this.ColumnPosition.DataPropertyName = "Position";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPosition.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnPosition.HeaderText = "Pos";
            this.ColumnPosition.Name = "ColumnPosition";
            this.ColumnPosition.ReadOnly = true;
            this.ColumnPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPosition.Width = 65;
            // 
            // ColumnBestLapTime
            // 
            this.ColumnBestLapTime.DataPropertyName = "BestLapTime";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnBestLapTime.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnBestLapTime.HeaderText = "Best Lap Time";
            this.ColumnBestLapTime.Name = "ColumnBestLapTime";
            this.ColumnBestLapTime.ReadOnly = true;
            this.ColumnBestLapTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnBestLapTime.Width = 192;
            // 
            // ColumnLapTime
            // 
            this.ColumnLapTime.DataPropertyName = "LapTime";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLapTime.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnLapTime.HeaderText = "Lap Time";
            this.ColumnLapTime.Name = "ColumnLapTime";
            this.ColumnLapTime.ReadOnly = true;
            this.ColumnLapTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLapTime.Width = 132;
            // 
            // ColumnLapTimeBestLapTime
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLapTimeBestLapTime.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColumnLapTimeBestLapTime.HeaderText = "Lap Time / Best";
            this.ColumnLapTimeBestLapTime.Name = "ColumnLapTimeBestLapTime";
            this.ColumnLapTimeBestLapTime.ReadOnly = true;
            // 
            // ColumnStatus
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.NullValue = "null";
            this.ColumnStatus.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            // 
            // RaceGridWithPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Elreg.WindowsFormsApplication.Properties.Resources.glossymetal;
            this.ClientSize = new System.Drawing.Size(915, 501);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::Elreg.WindowsFormsApplication.Properties.Resources.Classic_car_red;
            this.KeyPreview = true;
            this.Name = "RaceGridWithPositionForm";
            this.Text = "Race View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RaceGridFormFormClosing);
            this.Load += new System.EventHandler(this.RaceGridFormLoad);
            this.SizeChanged += new System.EventHandler(this.RaceGridWithPositionFormSizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RaceGridFormKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdLanes)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStripRaceStatus.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.contextMenuStripPosition.ResumeLayout(false);
            this.tblPosition2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPosition2)).EndInit();
            this.tblPosition1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPosition1)).EndInit();
            this.tblPosition3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPosition3)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPosition4)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPosition5)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPosition6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdLanes;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLargerFont;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSmallerFont;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLargerHeaderFont;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSmallerHeaderFont;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRaceTime;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblRaceType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRaceStatus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLargerStatusFont;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSmallerStatusFont;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNormalize;
        private System.Windows.Forms.Button btnShowRaceControlForm;
        private System.Windows.Forms.ToolStripMenuItem PenaltiesMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPosition;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPositionsfontLarger;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPositionsfontSmaller;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tblPosition2;
        private System.Windows.Forms.PictureBox picPosition2;
        private System.Windows.Forms.Label lblPosition2;
        private System.Windows.Forms.TableLayoutPanel tblPosition1;
        private System.Windows.Forms.PictureBox picPosition1;
        private System.Windows.Forms.Label lblPosition1;
        private System.Windows.Forms.TableLayoutPanel tblPosition3;
        private System.Windows.Forms.PictureBox picPosition3;
        private System.Windows.Forms.Label lblPosition3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox picPosition4;
        private System.Windows.Forms.Label lblPosition4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.PictureBox picPosition5;
        private System.Windows.Forms.Label lblPosition5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox picPosition6;
        private System.Windows.Forms.Label lblPosition6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDriver;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPenalties;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLapCount;
        private System.Windows.Forms.DataGridViewImageColumn ColumnCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBestLapTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLapTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLapTimeBestLapTime;
        private System.Windows.Forms.DataGridViewImageColumn ColumnStatus;
    }
}