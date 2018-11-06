using System.Diagnostics;
using System.Timers;

namespace Elreg.HelperClasses
{
    public class PausableTimer
    {
        private readonly Timer _timer = new Timer();
        private readonly Stopwatch _stopWatch = new Stopwatch();
        private double _interval;

        public event ElapsedEventHandler Elapsed;

        public PausableTimer()
        {
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            if (Elapsed != null)
                Elapsed(this, e);
        }

        public double Interval
        {
            get { return _interval; }
            set
            {
                _timer.Interval = value;
                _interval = value;
            }
        }

        public void Start()
        {
            _timer.Interval = Interval;
            _timer.Start();
            _stopWatch.Restart();
            IsPaused = false;
            IsStarted = true;
        }

        public void Start(double interval)
        {
            _timer.Interval = interval;
            Start();
        }

        public void Pause()
        {
            IsPaused = _timer.Enabled;
            _timer.Stop();
            _stopWatch.Stop();
        }

        public void Stop()
        {
            _timer.Stop();
            _stopWatch.Stop();
            IsPaused = false;
            IsStarted = false;
        }

        public void Restart()
        {
            if (IsPaused)
            {
                double intervalAfterPause = Interval - _stopWatch.ElapsedMilliseconds;
                if (intervalAfterPause <= 0)
                    intervalAfterPause = Interval;
                _timer.Interval = intervalAfterPause;
                _timer.Start();
                _stopWatch.Start();
            }
            IsPaused = false;
        }

        public bool IsStarted { get; private set; }

        public bool IsPaused { get; private set; }

    }
}
