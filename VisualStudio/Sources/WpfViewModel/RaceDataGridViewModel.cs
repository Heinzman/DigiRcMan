using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Catel.Data;
using Catel.MVVM;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.WpfModelObjects;

namespace Elreg.WpfViewModel
{
    public class RaceDataGridViewModel : ViewModelBase, IRaceObserver, IRaceStatusObserver
    {
        private readonly IRaceModel _raceModel;
        private List<RaceLane> _raceLanes;
        private RaceLane _raceLane;
        private Lane _lane;
        private readonly object _locker = new object();
        private double _headerHeight;
        private readonly LaneStatusCalculator _laneStatusCalculator = new LaneStatusCalculator();

        public static readonly PropertyData RowHeightPercentageProperty = RegisterProperty("RowHeightPercentage", typeof(double));
        public static readonly PropertyData HeaderHeightProperty = RegisterProperty("HeaderHeight", typeof(double));

        public RaceDataGridViewModel(IRaceModel raceModel)
        {
            _raceModel = raceModel;
            AttachToModelAsObserver();
        }

        private void Init()
        {
            RowHeightPercentage = 1f / _raceModel.Race.Lanes.Count * 100; 
            var lanes = new List<RaceLane>();

            if (_raceModel.Race != null)
            {
                foreach (var lane in _raceModel.Race.Lanes)
                {
                    RaceLane raceLane = new RaceLane();
                    raceLane.LaneId = lane.Id;
                    raceLane.Id = (int)lane.Id + 1;
                    raceLane.DriverName = lane.Driver.Name;
                    raceLane.Lap = lane.Lap;
                    raceLane.FuelLevel = CalcFuelLevelOf(lane);
                    raceLane.SpeedSum = (int)lane.SpeedSum;
                    raceLane.SpeedSumAvg = 500;
                    raceLane.FuelLevelToWarnYellow = (int)_raceModel.RaceSettings.FuelLevelInLitresToWarn;
                    raceLane.FuelLevelToWarnRed = raceLane.FuelLevelToWarnYellow/2;
                    raceLane.Position = lane.Position;

                    lanes.Add(raceLane);
                }
            }
            RaceLanes = lanes;
        }

        public List<RaceLane> RaceLanes
        {
            get { return _raceLanes; }
            set
            {
                _raceLanes = value;
                RaisePropertyChanged("RaceLanes");
            }
        }

        public double RowHeightPercentage
        {
            get { return GetValue<double>(RowHeightPercentageProperty); }
            set { SetValue(RowHeightPercentageProperty, value); }
        }

        public double HeaderHeight
        {
            get { return GetValue<double>(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }

        private void AttachToModelAsObserver()
        {
            _raceModel.Attach(this as IRaceObserver);
            _raceModel.Attach(this as IRaceStatusObserver);
        }

        public void LaneChanged(LaneId laneId)
        {
            lock (_locker)
            {
                DetermineLaneAndRaceLaneOf(laneId);
                _raceLane.FuelLevel = CalcFuelLevelOf(_lane);
                _raceLane.SpeedSum = (int)_lane.SpeedSum;
                _raceLane.Lap = _lane.Lap;
                _raceLane.Position = _lane.Position;
                _raceLane.StatusImage = _laneStatusCalculator.CalcLaneStatus(_lane);
                //Application.Current.Dispatcher.Invoke(new Action(() => _raceLane.StatusImage = _laneStatusCalculator.CalcLaneStatus(_lane)));
                GetValue();
            }
        }

        private void GetValue()
        {
            _raceLane.StatusImage = _laneStatusCalculator.CalcLaneStatus(_lane);
        }

        public void RaceStatusChanged(object sender, EventArgs e)
        {
            // todo
        }

        public void PitInDetected(LaneId laneId)
        {
            // todo
        }

        public void Refueled(LaneId laneId)
        {
            // todo
        }

        public void PenaltiesDone(LaneId laneId)
        {
            // todo
        }

        public void Refueling(LaneId laneId)
        {
            // todo
        }

        public void PitOutDetected(LaneId laneId)
        {
            // todo
        }

        public void LapAdded(LaneId laneId)
        {
            lock (_locker)
            {
                DetermineLaneAndRaceLaneOf(laneId);
                _raceLane.Lap = _raceModel.GetLapNumberOf(_lane);

                foreach (var raceLane in _raceLanes)
                {
                    var lane = _raceModel.Race.Lanes.Find(o => o.Id == raceLane.LaneId);
                    raceLane.Position = lane.Position;
                }
            }
        }

        public void LapNotAddedDuePenaltyOrNoFuel(LaneId laneId)
        {
            // todo
        }

        public void LapNotAddedDueMinSeconds(LaneId laneId)
        {
            // todo
        }

        public void AutoDetectedLapAdded(LaneId laneId)
        {
            // todo
        }

        public void Finished(LaneId laneId)
        {
            // todo
        }

        public void RaceChanged(object sender, EventArgs e)
        {
            // todo
        }

        public void PenaltyAdded(LaneId laneId)
        {
            lock (_locker)
            {
                DetermineLaneAndRaceLaneOf(laneId);
                _raceLane.PenaltyCount = _lane.PenaltyCount;
            }
        }

        public void FalseStartDetected(LaneId laneId)
        {
            // todo
        }

        public void LowFuelDetected(LaneId laneId)
        {
            // todo
        }

        public void NoFuelDetected(LaneId laneId)
        {
            // todo
        }

        public void Disqualified(LaneId laneId)
        {
            lock (_locker)
            {
                DetermineLaneAndRaceLaneOf(laneId);

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(@"D:\Tasks\LC2010\Sources\WpfViewModel\Resources\Disqualified.png");
                bitmapImage.EndInit();
                _raceLane.StatusImage = bitmapImage;
            }
        }

        public void RaceStarted(object sender, EventArgs e)
        {
            // todo
        }

        public void RaceRestarted(object sender, EventArgs e)
        {
            // todo
        }

        public void RacePaused(object sender, EventArgs e)
        {
            // todo
        }

        public void RaceBreaked(object sender, EventArgs e)
        {
            // todo
        }

        public void RaceInitialized(object sender, EventArgs e)
        {
            Init();
        }

        private static int CalcFuelLevelOf(Lane lane)
        {
            return (int)(lane.CurrentFuelLevelInLitres / lane.TankMaximumInLitres * 100);
        }

        public void RaceFinished(object sender, EventArgs e)
        {
            // todo
        }

        public void RaceStopped(object sender, EventArgs e)
        {
            // todo
        }

        public void RaceUnbreaked(object sender, EventArgs e)
        {
            // todo
        }

        private void DetermineLaneAndRaceLaneOf(LaneId laneId)
        {
            _raceLane = _raceLanes.Find(o => o.LaneId == laneId);
            _lane = _raceModel.Race.Lanes.Find(o => o.Id == laneId);
        }


    }
}
