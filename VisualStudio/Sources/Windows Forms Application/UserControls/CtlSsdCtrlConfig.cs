using System;
using System.ComponentModel;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsApplication.UserControls
{
    public partial class CtlSsdCtrlConfig : UserControl, ICtlSsdCtrlConfig
    {
        private bool _areChecked;

        public event EventHandler SendClicked;

        public CtlSsdCtrlConfig()
        {
            InitializeComponent();
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

        public bool IsSelected(ControllerLevel controllerLevel)
        {
            bool isSelected = false;

            CheckBox checkBox = GetCheckbox(controllerLevel);
            if (checkBox != null)
                isSelected = checkBox.Checked;

            return isSelected;
        }

        public int GetValueOf(ControllerLevel controllerLevel)
        {
            int value = 0;

            var numericUpDown = GetUdControl(controllerLevel);
            if (numericUpDown != null)
                value = (int)numericUpDown.Value;
            
            return value;
        }

        public void SetValueOf(ControllerLevel controllerLevel, int value)
        {
            var numericUpDown = GetUdControl(controllerLevel);
            if (numericUpDown != null)
                numericUpDown.Value = value;
        }

        public SsdButtons SsdButtons { get; set; }

        private NumericUpDown GetUdControl(ControllerLevel controllerLevel)
        {
            string controlName = "updSsdCtrlConfigNoBtnsVal" + ((int) controllerLevel).ToString();
            NumericUpDown numericUpDown = null;

            foreach (Control control in Controls)
            {
                if (control is NumericUpDown && control.Name == controlName)
                {
                    numericUpDown = control as NumericUpDown;
                    break;
                }
            }
            return numericUpDown;
        }

        private CheckBox GetCheckbox(ControllerLevel controllerLevel)
        {
            string controlName = "chkSelected" + ((int)controllerLevel).ToString();
            CheckBox checkBox = null;

            foreach (Control control in Controls)
            {
                if (control is CheckBox && control.Name == controlName)
                {
                    checkBox = control as CheckBox;
                    break;
                }
            }
            return checkBox;
        }

        private void LblCaptionClick(object sender, EventArgs e)
        {
            _areChecked = !_areChecked;

            foreach (var controllerLevel in Enum.GetValues(typeof(ControllerLevel)))
            {
                CheckBox checkBox = GetCheckbox((ControllerLevel)controllerLevel);
                if (checkBox != null)
                    checkBox.Checked = _areChecked;
            }
        }

        private void BtnSendSsdCtrlConfigNoBtnsClick(object sender, EventArgs e)
        {
            if (SendClicked != null)
                SendClicked(this, null);
        }
    }
}
