using System;
using System.ComponentModel;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.Log;

namespace Elreg.WindowsFormsApplication.UserControls
{
    public partial class CtlMockSsdController : UserControl
    {
        private bool _suppressEventDataChanged;

        public event EventHandler DataChanged;

        public CtlMockSsdController()
        {
            InitializeComponent();
        }

        private void RaiseEventDataChanged()
        {
            if (DataChanged != null)
                DataChanged(this, null);
        }

        public bool IsActivated
        {
            get { return chkActivated.Checked; }
            set { chkActivated.Checked = value; }
        }

        [Description("Sets the Caption"),
         Category("Values"),
         DefaultValue("--"),
         Browsable(true)]
        public string Caption
        {
            get { return lblCaption.Text; }
            set { lblCaption.Text = value; }
        }

        public bool IsBtnPressed
        {
            get { return chkBtnA.Checked; }
            private set { chkBtnA.Checked = value; }
        }

        public ControllerLevel ControllerLevel
        {
            get { return (ControllerLevel) trackBar1.Value; }
            private set { trackBar1.Value = (int)value; }
        }

        public LaneId LaneId { get; set; }

        private void DataOfControlChanged(object sender, EventArgs e)
        {
            try
            {
                if (!_suppressEventDataChanged)
                    RaiseEventDataChanged();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void UpdateData(bool isBtnPressed, ControllerLevel controllerLevel)
        {
            try
            {
                _suppressEventDataChanged = true;
                IsBtnPressed = isBtnPressed;
                ControllerLevel = controllerLevel;
            }
            finally
            {
                _suppressEventDataChanged = false;
            }
        }
    }
}
