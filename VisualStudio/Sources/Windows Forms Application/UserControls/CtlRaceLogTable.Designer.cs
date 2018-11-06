namespace Elreg.WindowsFormsApplication.UserControls
{
    partial class CtlRaceLogTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkShowDetails = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemLargerFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSmallerFont = new System.Windows.Forms.ToolStripMenuItem();
            this.chkShowEmptyRows = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkShowDetails
            // 
            this.chkShowDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowDetails.AutoSize = true;
            this.chkShowDetails.Checked = true;
            this.chkShowDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowDetails.Location = new System.Drawing.Point(0, 310);
            this.chkShowDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkShowDetails.Name = "chkShowDetails";
            this.chkShowDetails.Size = new System.Drawing.Size(121, 24);
            this.chkShowDetails.TabIndex = 7;
            this.chkShowDetails.Text = "Show Details";
            this.chkShowDetails.UseVisualStyleBackColor = true;
            this.chkShowDetails.CheckedChanged += new System.EventHandler(this.ChkCheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStripGrid;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(517, 308);
            this.dataGridView1.TabIndex = 5;
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
            this.toolStripMenuItemLargerFont.Click += new System.EventHandler(this.ToolStripMenuItemLargerFontClick);
            // 
            // toolStripMenuItemSmallerFont
            // 
            this.toolStripMenuItemSmallerFont.Name = "toolStripMenuItemSmallerFont";
            this.toolStripMenuItemSmallerFont.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Y)));
            this.toolStripMenuItemSmallerFont.Size = new System.Drawing.Size(210, 22);
            this.toolStripMenuItemSmallerFont.Text = "Spaltenschrift kleiner";
            this.toolStripMenuItemSmallerFont.Click += new System.EventHandler(this.ToolStripMenuItemSmallerFontClick);
            // 
            // chkShowEmptyRows
            // 
            this.chkShowEmptyRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowEmptyRows.AutoSize = true;
            this.chkShowEmptyRows.Location = new System.Drawing.Point(129, 310);
            this.chkShowEmptyRows.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkShowEmptyRows.Name = "chkShowEmptyRows";
            this.chkShowEmptyRows.Size = new System.Drawing.Size(161, 24);
            this.chkShowEmptyRows.TabIndex = 6;
            this.chkShowEmptyRows.Text = "Show Empty Rows";
            this.chkShowEmptyRows.UseVisualStyleBackColor = true;
            this.chkShowEmptyRows.CheckedChanged += new System.EventHandler(this.ChkCheckedChanged);
            // 
            // CtlRaceLogTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkShowDetails);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chkShowEmptyRows);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CtlRaceLogTable";
            this.Size = new System.Drawing.Size(517, 334);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowDetails;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chkShowEmptyRows;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLargerFont;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSmallerFont;
    }
}
