namespace Elreg.WindowsFormsApplication.UserControls
{
    partial class CtlControllerOutput
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
            this.chkButtonPressed = new Elreg.Controls.ColoredCheckbox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.udSpeed = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // chkButtonPressed
            // 
            this.chkButtonPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkButtonPressed.Location = new System.Drawing.Point(19, 25);
            this.chkButtonPressed.Name = "chkButtonPressed";
            this.chkButtonPressed.Size = new System.Drawing.Size(161, 27);
            this.chkButtonPressed.TabIndex = 1;
            this.chkButtonPressed.Text = "Button Pressed";
            this.chkButtonPressed.UseVisualStyleBackColor = true;
            this.chkButtonPressed.CheckedChanged += new System.EventHandler(this.SpeedOrButtonChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Value:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.udSpeed);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkButtonPressed);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 98);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // udSpeed
            // 
            this.udSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udSpeed.Location = new System.Drawing.Point(98, 51);
            this.udSpeed.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.udSpeed.Name = "udSpeed";
            this.udSpeed.Size = new System.Drawing.Size(46, 35);
            this.udSpeed.TabIndex = 2;
            this.udSpeed.ValueChanged += new System.EventHandler(this.SpeedOrButtonChanged);
            // 
            // CtlControllerOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CtlControllerOutput";
            this.Size = new System.Drawing.Size(237, 98);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Elreg.Controls.ColoredCheckbox chkButtonPressed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown udSpeed;
    }
}
