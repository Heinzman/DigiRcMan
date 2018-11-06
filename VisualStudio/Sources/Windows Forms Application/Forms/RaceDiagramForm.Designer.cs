namespace Elreg.WindowsFormsApplication.Forms
{
    partial class RaceDiagramForm
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
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemLargerFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSmallerFont = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.optTable = new System.Windows.Forms.RadioButton();
            this.optGraph = new System.Windows.Forms.RadioButton();
            this.ctlRaceLogGraph1 = new Elreg.WindowsFormsApplication.UserControls.CtlRaceLogGraph();
            this.ctlRaceLogTable1 = new Elreg.WindowsFormsApplication.UserControls.CtlRaceLogTable();
            this.contextMenuStripGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripGrid
            // 
            this.contextMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLargerFont,
            this.toolStripMenuItemSmallerFont});
            this.contextMenuStripGrid.Name = "contextMenuStrip1";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(211, 48);
            // 
            // toolStripMenuItemLargerFont
            // 
            this.toolStripMenuItemLargerFont.Name = "toolStripMenuItemLargerFont";
            this.toolStripMenuItemLargerFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.toolStripMenuItemLargerFont.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItemLargerFont.Text = "Spaltenschrift größer";
            // 
            // toolStripMenuItemSmallerFont
            // 
            this.toolStripMenuItemSmallerFont.Name = "toolStripMenuItemSmallerFont";
            this.toolStripMenuItemSmallerFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Y)));
            this.toolStripMenuItemSmallerFont.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItemSmallerFont.Text = "Spaltenschrift kleiner";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(691, 435);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 27);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.Location = new System.Drawing.Point(571, 435);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(112, 27);
            this.btnOpenFile.TabIndex = 5;
            this.btnOpenFile.Text = "&Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFileClick);
            // 
            // optTable
            // 
            this.optTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.optTable.AutoSize = true;
            this.optTable.Location = new System.Drawing.Point(79, 436);
            this.optTable.Name = "optTable";
            this.optTable.Size = new System.Drawing.Size(66, 24);
            this.optTable.TabIndex = 6;
            this.optTable.Text = "Table";
            this.optTable.UseVisualStyleBackColor = true;
            this.optTable.CheckedChanged += new System.EventHandler(this.OptCheckedChanged);
            // 
            // optGraph
            // 
            this.optGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.optGraph.AutoSize = true;
            this.optGraph.Checked = true;
            this.optGraph.Location = new System.Drawing.Point(1, 436);
            this.optGraph.Name = "optGraph";
            this.optGraph.Size = new System.Drawing.Size(72, 24);
            this.optGraph.TabIndex = 7;
            this.optGraph.TabStop = true;
            this.optGraph.Text = "Graph";
            this.optGraph.UseVisualStyleBackColor = true;
            this.optGraph.CheckedChanged += new System.EventHandler(this.OptCheckedChanged);
            // 
            // ctlRaceLogGraph1
            // 
            this.ctlRaceLogGraph1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlRaceLogGraph1.BackColor = System.Drawing.SystemColors.Control;
            this.ctlRaceLogGraph1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctlRaceLogGraph1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlRaceLogGraph1.Location = new System.Drawing.Point(1, 1);
            this.ctlRaceLogGraph1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlRaceLogGraph1.Name = "ctlRaceLogGraph1";
            this.ctlRaceLogGraph1.Size = new System.Drawing.Size(802, 433);
            this.ctlRaceLogGraph1.TabIndex = 8;
            // 
            // ctlRaceLogTable1
            // 
            this.ctlRaceLogTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlRaceLogTable1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctlRaceLogTable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctlRaceLogTable1.Location = new System.Drawing.Point(1, 1);
            this.ctlRaceLogTable1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlRaceLogTable1.Name = "ctlRaceLogTable1";
            this.ctlRaceLogTable1.RaceDataConsolidator = null;
            this.ctlRaceLogTable1.Size = new System.Drawing.Size(802, 433);
            this.ctlRaceLogTable1.TabIndex = 4;
            // 
            // RaceDiagramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.optGraph);
            this.Controls.Add(this.optTable);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctlRaceLogGraph1);
            this.Controls.Add(this.ctlRaceLogTable1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RaceDiagramForm";
            this.Text = "Race Log Diagram";
            this.Load += new System.EventHandler(this.RaceDiagramFormLoad);
            this.contextMenuStripGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLargerFont;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSmallerFont;
        private UserControls.CtlRaceLogTable ctlRaceLogTable1;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.RadioButton optTable;
        private System.Windows.Forms.RadioButton optGraph;
        private UserControls.CtlRaceLogGraph ctlRaceLogGraph1;
    }
}