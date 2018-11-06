using System;
using System.Collections.Generic;
using System.Timers;
using Elreg.Log;
using Newtonsoft.Json;

namespace Elreg.BusinessObjects
{
    [Serializable]
    public class RacingTime
    {
        private readonly Timer _timer = new Timer();
        private TimeSpan _grossTimeSpan;
        private bool _isRunning;
        private DateTime? _pauseStartTime;
        public List<PauseTime> Pauses { get; private set; }

        public class PauseTime
        {
            public DateTime Start { get; set; }
            public TimeSpan TimeSpan { get; set; }

            public PauseTime()
            {
                Start = DateTime.Now;
            }
        }

        public RacingTime()
        {
            _timer.Elapsed += TimerElapsed;
            Pauses = new List<PauseTime>();
        }

        [JsonProperty("Tm")]
        public DateTime StartTime { get; private set; }

        public void Start()
        {
            StartTime = DateTime.Now;
            Pauses.Clear();
            NetTimeSpanFromStart = new TimeSpan();
            _timer.Start();
            _isRunning = true;
            _pauseStartTime = null;
        }

        public void Pause()
        {
            _timer.Stop();
            _pauseStartTime = DateTime.Now;
            Pauses.Add(new PauseTime());
        }

        public void Restart()
        {
            _timer.Start();
            AddToPauses();
        }

        private void AddToPauses()
        {
            if (Pauses.Count > 0 && _pauseStartTime != null)
            {
                TimeSpan timeSpan = DateTime.Now - _pauseStartTime.Value;
                Pauses[Pauses.Count - 1].TimeSpan = timeSpan;
                _pauseStartTime = null;
            }
        }

        public void Stop()
        {
            _timer.Stop();
            _grossTimeSpan = DateTime.Now - StartTime;
            _isRunning = false;
        }

        [JsonProperty("TG")]
        public TimeSpan GrossTimeSpanFromStart
        {
            get
            {
                TimeSpan timeSpan = _grossTimeSpan;
                if (_isRunning)
                    timeSpan = DateTime.Now - StartTime;
                return timeSpan;
            }
            set { _grossTimeSpan = value; }
        }

        [JsonProperty("TN")]
        public TimeSpan NetTimeSpanFromStart { get; set; }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var timerTimeSpan = new TimeSpan(0, 0, 0, 0, (int)_timer.Interval);
                NetTimeSpanFromStart = NetTimeSpanFromStart.Add(timerTimeSpan);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Setup()
        {
            Pauses.Clear();
            NetTimeSpanFromStart = new TimeSpan();
            _pauseStartTime = null;
        }
    }
}