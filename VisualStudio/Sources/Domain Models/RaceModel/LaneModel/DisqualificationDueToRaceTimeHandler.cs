using System;
using System.Timers;
using Elreg.BusinessObjects.Options;

namespace Elreg.DomainModels.RaceModel.LaneModel
{
    internal class DisqualificationDueToRaceTimeHandler
    {
        private readonly RaceLaneModel _raceLaneModel;
        private readonly RaceSettings _raceSettings;
        private Timer _timer;

        public event EventHandler Disqualified;

        public DisqualificationDueToRaceTimeHandler(RaceLaneModel raceLaneModel, RaceSettings raceSettings)
        {
            _raceLaneModel = raceLaneModel;
            _raceSettings = raceSettings;
            InitTimer();
        }

        private void RaiseDisqualified()
        {
            EventHandler handler = Disqualified;
            if (handler != null) 
                handler(this, EventArgs.Empty);
        }

        private void InitTimer()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_raceSettings.DisqualificationRaceSecsActivated)
                CheckDisqualification();
        }

        private void CheckDisqualification()
        {
            if (_raceLaneModel.CurrentLane.IsStarted && _raceLaneModel.RaceModel.StatusHandler.IsRaceStarted)
            {
                var secs = (decimal)_raceSettings.SecondsForValidLap * (decimal)_raceSettings.LapsToDrive * _raceSettings.DisqualificationRaceSecsFactor;

                if ((decimal)_raceLaneModel.RaceModel.Race.RacingTime.NetTimeSpanFromStart.TotalSeconds > secs)
                {
                    _timer.Stop();
                    RaiseDisqualified();                    
                }
            }
        }
    }
}
