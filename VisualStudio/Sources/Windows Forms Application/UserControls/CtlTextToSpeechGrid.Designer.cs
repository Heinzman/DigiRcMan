using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsApplication.UserControls
{
    partial class CtlTextToSpeechGrid : ITextToSpeechGrid
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
            this.grdTextToSpeach = new System.Windows.Forms.DataGridView();
            this.ColumnIsToCreate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTextToSpeak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSpeak = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdTextToSpeach)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTextToSpeach
            // 
            this.grdTextToSpeach.AllowUserToAddRows = false;
            this.grdTextToSpeach.AllowUserToDeleteRows = false;
            this.grdTextToSpeach.AllowUserToResizeRows = false;
            this.grdTextToSpeach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTextToSpeach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIsToCreate,
            this.ColumnDisplayName,
            this.ColumnTextToSpeak,
            this.ColumnPath,
            this.ColumnSpeak});
            this.grdTextToSpeach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTextToSpeach.Location = new System.Drawing.Point(0, 0);
            this.grdTextToSpeach.Name = "grdTextToSpeach";
            this.grdTextToSpeach.RowHeadersVisible = false;
            this.grdTextToSpeach.Size = new System.Drawing.Size(962, 368);
            this.grdTextToSpeach.TabIndex = 3;
            this.grdTextToSpeach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdTextToSpeachCellContentClick);
            this.grdTextToSpeach.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdTextToSpeachCellContentDoubleClick);
            // 
            // ColumnIsToCreate
            // 
            this.ColumnIsToCreate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnIsToCreate.DataPropertyName = "IsToCreate";
            this.ColumnIsToCreate.HeaderText = "Create";
            this.ColumnIsToCreate.Name = "ColumnIsToCreate";
            this.ColumnIsToCreate.Width = 44;
            // 
            // ColumnDisplayName
            // 
            this.ColumnDisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnDisplayName.DataPropertyName = "DisplayName";
            this.ColumnDisplayName.HeaderText = "Name";
            this.ColumnDisplayName.MinimumWidth = 100;
            this.ColumnDisplayName.Name = "ColumnDisplayName";
            this.ColumnDisplayName.ReadOnly = true;
            // 
            // ColumnTextToSpeak
            // 
            this.ColumnTextToSpeak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTextToSpeak.DataPropertyName = "Text";
            this.ColumnTextToSpeak.FillWeight = 35F;
            this.ColumnTextToSpeak.HeaderText = "Text To Speak";
            this.ColumnTextToSpeak.Name = "ColumnTextToSpeak";
            // 
            // ColumnPath
            // 
            this.ColumnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPath.DataPropertyName = "Path";
            this.ColumnPath.FillWeight = 65F;
            this.ColumnPath.HeaderText = "Path";
            this.ColumnPath.Name = "ColumnPath";
            this.ColumnPath.ReadOnly = true;
            // 
            // ColumnSpeak
            // 
            this.ColumnSpeak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnSpeak.HeaderText = "Speak";
            this.ColumnSpeak.Name = "ColumnSpeak";
            this.ColumnSpeak.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSpeak.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSpeak.Text = "Speak";
            this.ColumnSpeak.UseColumnTextForButtonValue = true;
            this.ColumnSpeak.Width = 63;
            // 
            // CtlTextToSpeechGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdTextToSpeach);
            this.Name = "CtlTextToSpeechGrid";
            this.Size = new System.Drawing.Size(962, 368);
            ((System.ComponentModel.ISupportInitialize)(this.grdTextToSpeach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTextToSpeach;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsToCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTextToSpeak;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPath;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSpeak;
    }
}
