using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.Log;

namespace Elreg.WindowsFormsApplication.UserControls
{
    public partial class CtlMockController : UserControl
    {
        public event EventHandler<MockControllerSpeedChangedArgs> SpeedChanged;
        public event EventHandler<EventArgs> LapAdded;
        public event EventHandler<MockControllerLaneChangeArgs> LaneChangeButtonPressed;

        public CtlMockController()
        {
            InitializeComponent();
        }

        private void BtnLapClick(object sender, EventArgs e)
        {
            try
            {
                if (LapAdded != null)
                    LapAdded(this, null);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void TrackBar1Scroll(object sender, EventArgs e)
        {
            try
            {
                if (SpeedChanged != null)
                {
                    uint speed = (uint)trackBar1.Value;
                    SpeedChanged(this, new MockControllerSpeedChangedArgs(speed));
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnLaneChangeMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                RaiseEventLaneChangeButtonPressed(true);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaiseEventLaneChangeButtonPressed(bool isPressed)
        {
            if (LaneChangeButtonPressed != null)
                LaneChangeButtonPressed(this, new MockControllerLaneChangeArgs(isPressed));
        }

        private void BtnLaneChangeMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                RaiseEventLaneChangeButtonPressed(false);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}
