using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Options;
using Elreg.Log;
using Elreg.RaceControlService;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework;
using Form = Elreg.Controls.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class PauseForm : Form, IPauseView
    {
        private const int AlphaInitial = 30;
        private const int AlphaMax = 30;
        private const int AlphaMin = 20;
        private const int AlphaStep = 3;
        private const int TimerInterval = 50;
        private readonly RaceKeyController _raceKeyController;
        private int _alpha = AlphaInitial;
        private bool _alphaGetsSmaller = true;

        public PauseForm(RaceKeyController raceKeyController, RaceSettings raceSettings)
        {
            SetOpacity();
            InitializeComponent();
            timer1.Interval = TimerInterval;
            _raceKeyController = raceKeyController;
            if (raceSettings.PauseCharsAnimated)
                InitTimer();
        }

        public string DriverWhoPausedByArduino { get; set; }

        private void InitTimer()
        {
            timer1.Interval = TimerInterval;
            timer1.Enabled = true;
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            try
            {
                CalcAlpha();
                SetOpacity();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SetOpacity()
        {
            Opacity = (float) _alpha/100;
        }

        private void CalcAlpha()
        {
            if (_alphaGetsSmaller)
            {
                _alpha -= AlphaStep;
                if (_alpha <= AlphaMin)
                {
                    _alpha = AlphaMin;
                    _alphaGetsSmaller = false;
                }
            }
            else
            {
                _alpha += AlphaStep;
                if (_alpha >= AlphaMax)
                {
                    _alpha = AlphaMax;
                    _alphaGetsSmaller = true;
                }
            }
        }

        private void PauseFormKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                _raceKeyController.HandleKey(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void PauseFormFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason != CloseReason.ApplicationExitCall)
                {
                    e.Cancel = true;
                    Visible = false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected override void LoadSettings()
        {
        }

        protected override void SaveSettings()
        {
        }

        protected override string RegkeyPath
        {
            get { return Constants.RegkeyPath; }
        }

    }
}