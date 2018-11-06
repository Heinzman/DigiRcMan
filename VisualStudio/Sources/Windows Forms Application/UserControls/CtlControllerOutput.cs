using System;
using System.Windows.Forms;
using Elreg.Log;

namespace Elreg.WindowsFormsApplication.UserControls
{
    public partial class CtlControllerOutput : UserControl
    {
        private bool _isChangedByUser = true;

        public event EventHandler ValueChanged;

        public CtlControllerOutput()
        {
            InitializeComponent();
        }

        public bool ButtonPressed
        {
            get { return chkButtonPressed.Checked;  }
            set
            {
                _isChangedByUser = false;
                if (InvokeRequired)
                    Invoke((MethodInvoker) (() => chkButtonPressed.Checked = value));
                else
                    chkButtonPressed.Checked = value;
                _isChangedByUser = true;
            }
        }

        public decimal Speed
        {
            get { return udSpeed.Value; }
            set
            {
                _isChangedByUser = false;
                if (InvokeRequired)
                    Invoke((MethodInvoker)(() => udSpeed.Value = value));
                else
                    udSpeed.Value = value;
                _isChangedByUser = true;
            }
        }

        public string Caption
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }

        private void SpeedOrButtonChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isChangedByUser && ValueChanged != null)
                    ValueChanged(this, null);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}
