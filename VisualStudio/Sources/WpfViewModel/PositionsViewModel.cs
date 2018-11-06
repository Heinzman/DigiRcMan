using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using Catel.MVVM;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.WpfModelObjects;

namespace Elreg.WpfViewModel
{
    public class PositionsViewModel : ViewModelBase, IRaceObserver, IRaceStatusObserver
    {
        private double _heightPercentage;
        private readonly IRaceModel _raceModel;
        private readonly object _locker = new object();
        private Lane _lane;

        private const double StartLapOffsetInPercent = 2;
        private const double OffsetToNextLap = 0.01;
        private const double GlobalXPercentageOffset = 5;

        public PositionsViewModel(IRaceModel raceModel)
        {
            _raceModel = raceModel;
            LaneLines = new ObservableCollection<LaneLine>();
            LapLines = new ObservableCollection<LapLine>();
            LaneCars = new ObservableCollection<LaneCar>();

            AttachToModelAsObserver();
        }

        private void AttachToModelAsObserver()
        {
            _raceModel.Attach(this as IRaceObserver);
            _raceModel.Attach(this as IRaceStatusObserver);
        }

        private int LanesCount
        {
            get { return _raceModel.Race.Lanes.Count; }
        }

        private int LapsCount
        {
            get { return _raceModel.Race.LapsToDrive; }
        }

        private void Init()
        {
            CalcHeightPercentage();
            InitLaneLines();
            InitLaneCars();
            InitLapLines();
            CalcCarXPercentages();
        }

        private void CalcHeightPercentage()
        {
            _heightPercentage = 1f / LanesCount * 100;
        }

        private void InitLaneLines()
        {
            LaneLines.Clear();
            for (int lane = 0; lane < LanesCount; lane++)
            {
                double line1YPercentage = (double)lane / LanesCount * 100;
                double line2YPercentage = line1YPercentage + _heightPercentage;

                const int fontSize = 24;
                Brush brush = new SolidColorBrush(Colors.LightGray);
                if (lane % 2 == 1)
                    brush = new SolidColorBrush(Colors.DarkGray);
                LaneLines.Add(new LaneLine
                {
                    Line1YPercentage = line1YPercentage,
                    Line2YPercentage = line2YPercentage,
                    HeightPercentage = _heightPercentage,
                    Caption = CreateCaption(lane),
                    FontSize = fontSize,
                    BackgroundBrush = brush
                });
            }
        }

        private void InitLaneCars()
        {
            LaneCars.Clear();
            for (int lane = 0; lane < LanesCount; lane++)
            {
                double line1YPercentage = (double)lane / LanesCount * 100;

                double carImageHeightPercentage = _heightPercentage * 0.8;
                double carImageTopPercentage = line1YPercentage + (_heightPercentage - carImageHeightPercentage) / 2;

                LaneCars.Add(new LaneCar
                {
                    CarImageHeightPercentage = carImageHeightPercentage,
                    CarImageTopPercentage = carImageTopPercentage,
                    Laps = (lane+1) * -StartLapOffsetInPercent / 100,
                    CarImage = _raceModel.Race.Lanes[lane].Car.Image
                });
            }
        }

        private void InitLapLines()
        {
            LapLines.Clear();
            for (int lap = 0; lap < LapsCount + 1; lap++)
            {
                double xPercentage = CalcXPercentage(-lap);
                bool isVisible = CalcIsVisible(xPercentage);
                LapLine lapline = new LapLine
                {
                    XPercentage = xPercentage,
                    Caption = lap.ToString(),
                    IsVisible = isVisible
                };
                LapLines.Add(lapline);
                InitLapLineCaptions(lapline);
            }
        }

        private void InitLapLineCaptions(LapLine lapline)
        {
            const int fontSize = 40;
            const int yAbsoluteOffset = -25;
            lapline.LapLineCaptions = new ObservableCollection<LapLineCaption>();

            lapline.LapLineCaptions.Add(new LapLineCaption
            {
                YPercentage = 100,
                XPercentage = lapline.XPercentage,
                Caption = lapline.Caption,
                FontSize = fontSize,
                YAbsoluteOffset = yAbsoluteOffset
            });

            for (int lane = 0; lane < LanesCount; lane++)
            {
                double yPercentage = (double)lane / LanesCount * 100;

                lapline.LapLineCaptions.Add(new LapLineCaption
                {
                    YPercentage = yPercentage,
                    XPercentage = lapline.XPercentage,
                    Caption = lapline.Caption,
                    FontSize = fontSize,
                    YAbsoluteOffset = yAbsoluteOffset
                });
            }
        }

        public ObservableCollection<LapLine> LapLines { get; private set; }

        public ObservableCollection<LaneLine> LaneLines { get; private set; }

        public ObservableCollection<LaneCar> LaneCars { get; private set; }

        private bool CalcIsVisible(double xPercentage)
        {
            return xPercentage >= 0;
        }

        private static string CreateCaption(int lane)
        {
            string captionTemplate = "Driver" + lane;
            string caption = string.Empty;

            for (int i = 0; i < 10; i++)
                caption += captionTemplate + "                ";

            return caption;
        }

        private static double CalcXPercentage(double lapPosition)
        {
            double xPercentage = Math.Log10(lapPosition * 7 + 1) * 60 + GlobalXPercentageOffset;
            if (double.IsNaN(xPercentage))
                xPercentage = -100;
            return xPercentage;
        }

        public void LaneChanged(LaneId laneId)
        {
            lock (_locker)
            {
                DetermineLaneOf(laneId);
                double estimatedPosition = _lane.SpeedSum / 500;

                double lapPosition;

                if (_lane.Lap < 0)
                {
                    lapPosition = LaneCars[(int)laneId].Laps + estimatedPosition;
                    if (lapPosition > -OffsetToNextLap)
                        lapPosition = -OffsetToNextLap;
                    LaneCars[(int)laneId].Laps = lapPosition;
                }
                else
                {
                    if (estimatedPosition > 1 - OffsetToNextLap)
                        estimatedPosition = 1 - OffsetToNextLap;
                    lapPosition = _lane.Lap + estimatedPosition;
                    LaneCars[(int)laneId].Laps = lapPosition;
                }
                CalcCarXPercentages();
            }
        }

        private void CalcCarXPercentages()
        {
            LaneCar laneCarWithFirstPos = LaneCars.OrderByDescending(i => i.Laps).FirstOrDefault();

            if (laneCarWithFirstPos != null)
            {
                laneCarWithFirstPos.CarImageXPercentage = GlobalXPercentageOffset;

                for (int lap = 0; lap < LapsCount + 1; lap++)
                {
                    double lapPosition = laneCarWithFirstPos.Laps - lap;
                    double xPercentage = CalcXPercentage(lapPosition);
                    LapLines[lap].XPercentage = xPercentage;
                    LapLines[lap].IsVisible = CalcIsVisible(xPercentage);
                    foreach (var lapLineCaption in LapLines[lap].LapLineCaptions)
                        lapLineCaption.XPercentage = xPercentage;
                }

                foreach (var laneCar in LaneCars)
                {
                    if (laneCar != laneCarWithFirstPos)
                    {
                        double lapPosition = laneCarWithFirstPos.Laps - laneCar.Laps;
                        double xPercentage = CalcXPercentage(lapPosition);
                        laneCar.CarImageXPercentage = xPercentage;
                    }
                }
            }
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
            // todo
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
            // todo
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
            // todo
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

        private void DetermineLaneOf(LaneId laneId)
        {
            _lane = _raceModel.Race.Lanes.Find(o => o.Id == laneId);
        }

    }
}
