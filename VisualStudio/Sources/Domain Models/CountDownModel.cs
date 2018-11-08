using System;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;

namespace Elreg.DomainModels
{
    public class CountDownModel : ICountDownModel
    {
        private const int Maxnumber = 5;
        private const int Minnumber = 1;
        private const int IntervalInitInMillisecs = 300;
        private const int IntervalCountdownInMillisecs = 1000;
        private const int IntervalDelayminInMillisecs = 900;
        private const int IntervalDelaymaxInMillisecs = 3000;
        private const int IntervalDelayVanish = 2000;
        private readonly System.Timers.Timer _timerCountdown = new System.Timers.Timer();
        private int _countDownStartWithNo;
        private int _currentCountdownNo;

        public CountDownModel()
        {
            _timerCountdown.Enabled = false;
            _timerCountdown.Elapsed += TimerCountdownElapsed;
        }

        #region ICountDownModel Members

        public event EventHandler<CountDownEventArgs> CountDownChanged;

        #endregion

        public void StartCountDown(int countDownStartWithNo)
        {
            _countDownStartWithNo = countDownStartWithNo;
            _timerCountdown.Interval = IntervalInitInMillisecs;
            RaiseCountDownChanged(CountDownEventArgs.TypeEnum.BeginCountDown);
            InitCountDownNo();
            _timerCountdown.Start();
        }

        public void StopCountDown()
        {
            StopTimer();
            RaiseCountDownChanged(CountDownEventArgs.TypeEnum.Done);
        }

        private void InitCountDownNo()
        {
            if (_countDownStartWithNo > Maxnumber)
                _countDownStartWithNo = Maxnumber;
            else if (_countDownStartWithNo < Minnumber)
                _countDownStartWithNo = Minnumber;
            _currentCountdownNo = _countDownStartWithNo + 1;
        }

        private void TimerCountdownElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                ExecCountDown();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ExecCountDown()
        {
            _currentCountdownNo--;
            CountDownEventArgs.TypeEnum type = GetCountDownType();
            RaiseCountDownChanged(type);

            if (type == CountDownEventArgs.TypeEnum.Count1)
                InitDelayedStart();
            else if (type == CountDownEventArgs.TypeEnum.Go)
                InitDelayedVanish();
            else if (type == CountDownEventArgs.TypeEnum.Done)
                StopTimer();
            else
                _timerCountdown.Interval = IntervalCountdownInMillisecs;
        }

        private CountDownEventArgs.TypeEnum GetCountDownType()
        {
            CountDownEventArgs.TypeEnum type;

            switch (_currentCountdownNo)
            {
                case 5:
                    type = CountDownEventArgs.TypeEnum.Count5;
                    break;
                case 4:
                    type = CountDownEventArgs.TypeEnum.Count4;
                    break;
                case 3:
                    type = CountDownEventArgs.TypeEnum.Count3;
                    break;
                case 2:
                    type = CountDownEventArgs.TypeEnum.Count2;
                    break;
                case 1:
                    type = CountDownEventArgs.TypeEnum.Count1;
                    break;
                case -1:
                    type = CountDownEventArgs.TypeEnum.Done;
                    break;
                default:
                    type = CountDownEventArgs.TypeEnum.Go;
                    break;
            }
            return type;
        }

        private void InitDelayedStart()
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            int interval = random.Next(IntervalDelayminInMillisecs, IntervalDelaymaxInMillisecs);
            _timerCountdown.Interval = interval;
        }

        private void InitDelayedVanish()
        {
            _timerCountdown.Interval = IntervalDelayVanish;
        }

        private void StopTimer()
        {
            _timerCountdown.Stop();
        }

        private void RaiseCountDownChanged(CountDownEventArgs.TypeEnum type)
        {
            CountDownChanged?.Invoke(this, new CountDownEventArgs(type));
        }
    }
}