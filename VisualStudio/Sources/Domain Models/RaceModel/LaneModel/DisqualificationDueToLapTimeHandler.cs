using System;
using System.Timers;
using Elreg.BusinessObjects.Options;

namespace Elreg.DomainModels.RaceModel.LaneModel
{
    internal class DisqualificationDueToLapTimeHandler
    {
        private readonly RaceLaneModel _raceLaneModel;
        private readonly RaceSettings _raceSettings;
        private Timer _timer;

        public event EventHandler Disqualified;

        public DisqualificationDueToLapTimeHandler(RaceLaneModel raceLaneModel, RaceSettings raceSettings)
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
            _timer = new Timer(500);
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_raceSettings.DisqualificationLapSecsActivated)
                CheckDisqualification();
        }

        private void CheckDisqualification()
        {
            if (_raceLaneModel.CurrentLane.IsStarted && _raceLaneModel.RaceModel.StatusHandler.IsRaceStarted)
            {
                var secs = _raceSettings.SecondsForValidLap*_raceSettings.DisqualificationLapSecsFactor;
                
                if (_raceLaneModel.SecondsSinceLastDetectedLap > secs)
                {
                    _timer.Stop();
                    RaiseDisqualified();                    
                }
            }
        }
    }
}
