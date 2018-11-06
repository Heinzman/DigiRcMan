using System;
using System.Timers;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.Log;
using System.Linq;

namespace Elreg.RaceDebugService
{
    public class RaceDebugger
    {
        private readonly IRaceModel _raceModel;
        private readonly Timer _timer = new Timer();

        public RaceDebugger(IRaceModel raceModel)
        {
            LaneSnapshots = new LaneSnapshots();
            _raceModel = raceModel;
            _timer.Interval = 1000;
            _timer.Elapsed += TimerElapsed;
        }

        public LaneSnapshots LaneSnapshots { get; private set; }

        public void Start()
        {
            _timer.Start();
            LaneSnapshots = new LaneSnapshots();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                _timer.Stop();
                RefreshLaneSnapshots();
                LaneSnapshots.RaiseOnPropertyChanged();
                _timer.Start();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RefreshLaneSnapshots()
        {
            if (_raceModel.Race != null)
            {
                foreach (Lane lane in _raceModel.Race.Lanes)
                {
                    if (lane.IsStarted)
                    {
                        LaneSnapshot laneSnapshot = LaneSnapshots.LaneSnapshotList.First(o => o.LaneId == lane.Id);
                        if (laneSnapshot != null)
                        {
                            laneSnapshot.DriverName = lane.Driver.Name;
                            laneSnapshot.Position = lane.Position;
                        }
                    }
                }
            }
        }
    }
}
