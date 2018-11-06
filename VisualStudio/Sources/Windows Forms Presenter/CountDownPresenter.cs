using System;
using System.Drawing;
using System.Windows.Forms;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.DomainModels.RaceModel;
using Elreg.Log;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter
{
    public class CountDownPresenter
    {
        private readonly ICountDownView _countDownView;
        private readonly ICountDownModel _countDownModel;
        private readonly System.Timers.Timer _timerChangeSize = new System.Timers.Timer();
        private readonly RaceSettings _raceSettings;
        private string _textGo = "Go!";

        private const float Initalfontsize = 500.0f;
        private const float Gofontsize = 300.0f;
        private const float Minimumfontsize = 5.0f;
        private const int DecFontSize = 15;

        private delegate void VoidHandler();

        public CountDownPresenter(ICountDownView countDownView, RaceModel raceModel)
        {
            try
            {
                _countDownView = countDownView;
                _raceSettings = raceModel.RaceSettings;
                _countDownModel = raceModel.CountDownModel;
                _countDownModel.CountDownChanged += CountDownModelCountDownChanged;
                LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void InitAfterLoad()
        {
            try
            {
                _countDownView.CountDownText = string.Empty;
                _countDownView.Form.Size = new Size(0, 0);
                _countDownView.Form.Opacity = 0.6f;
                _countDownView.Form.WindowState = FormWindowState.Maximized;
                if (_raceSettings.CountDownCharsAnimated)
                    InitTimer();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void InitTimer()
        {
            _timerChangeSize.Interval = 100;
            _timerChangeSize.Elapsed += TimerChangeSizeElapsed;
            _timerChangeSize.Enabled = true;
        }

        private void TimerChangeSizeElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                FontSize -= DecFontSize;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CountDownModelCountDownChanged(object sender, CountDownEventArgs e)
        {
            try
            {
                SetCountDownText(e.Type);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SetCountDownText(CountDownEventArgs.TypeEnum type)
        {
            switch (type)
            {
                case CountDownEventArgs.TypeEnum.Count5:
                    _countDownView.CountDownText = "5";
                    FontSize = Initalfontsize;
                    break;
                case CountDownEventArgs.TypeEnum.Count4:
                    _countDownView.CountDownText = "4";
                    FontSize = Initalfontsize;
                    break;
                case CountDownEventArgs.TypeEnum.Count3:
                    _countDownView.CountDownText = "3";
                    FontSize = Initalfontsize;
                    break;
                case CountDownEventArgs.TypeEnum.Count2:
                    _countDownView.CountDownText = "2";
                    FontSize = Initalfontsize;
                    break;
                case CountDownEventArgs.TypeEnum.Count1:
                    _countDownView.CountDownText = "1";
                    FontSize = Initalfontsize;
                    break;
                case CountDownEventArgs.TypeEnum.Go:
                    ClearCountDownText();
                    FontSize = Gofontsize;
                    _countDownView.CountDownText = _textGo;
                    _timerChangeSize.Enabled = false;
                    break;
                case CountDownEventArgs.TypeEnum.Done:
                    ClearCountDownText();
                    FontSize = Initalfontsize;
                    _countDownView.Invoke(new VoidHandler(_countDownView.Hide));
                    break;
                default:
                    ClearCountDownText();
                    break;
            }
        }

        private void ClearCountDownText()
        {
            _countDownView.CountDownText = string.Empty;
        }

        private float FontSize
        {
            get { return _countDownView.CountDownFont.Size; }
            set
            {
                if (value >= Minimumfontsize)
                {
                    Font font = new Font(_countDownView.CountDownFont.Name, value,
                                        _countDownView.CountDownFont.Style, _countDownView.CountDownFont.Unit,
                                        _countDownView.CountDownFont.GdiCharSet,
                                        _countDownView.CountDownFont.GdiVerticalFont);
                    _countDownView.CountDownFont = font;
                }
                else
                    _countDownView.CountDownText = string.Empty;
            }
        }

        private void LanguageManagerLanguageChanged(object sender, System.EventArgs e)
        {
            try
            {
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            _textGo = LanguageManager.GetString("CountDownFormGo");
        }

    }
}
