using System;
using Elreg.Log;

namespace Elreg.UnitTests.MockObjects
{
    public partial class ParallelPortForm : Controls.Forms.Form
    {
        public delegate void PortDataReceivedHandler(object sender, int value);
        public event PortDataReceivedHandler PortDataReceived;

        public ParallelPortForm()
        {
            InitializeComponent();
        }

        private void BtnSendClick(object sender, EventArgs e)
        {
            try
            {
                if (PortDataReceived != null)
                    PortDataReceived(this, PortValue);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private int PortValue
        {
            get
            {
                int currentPortValue = 120;
                int portValue;
                if (int.TryParse(txtPortValue.Text, out portValue))
                    currentPortValue = portValue;
                return currentPortValue;
            }
        }
    }
}