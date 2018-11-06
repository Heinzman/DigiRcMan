using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;

namespace Elreg.WpfEvalApp.ViewModels
{
    public class PositionsViewModel
    {
        private double _heightPercentage;

        const int LanesCount = 6;
        const int LapsCount = 50;

        public PositionsViewModel()
        {
            Init();
        }

        private void Init()
        {
            CalcHeightPercentage();
            InitLaneLines();
            InitLaneCars();
            InitLapLines();
        }

        private void CalcHeightPercentage()
        {
            _heightPercentage = 1f/LanesCount*100;
        }

        private void InitLaneLines()
        {
            LaneLines = new ObservableCollection<LaneLine>();
            for (int lane = 0; lane < LanesCount; lane++)
            {
                double line1YPercentage = (double) lane/LanesCount*100;
                double line2YPercentage = line1YPercentage + _heightPercentage;

                const int fontSize = 24;
                Brush brush = new SolidColorBrush(Colors.LightGray);
                if (lane%2 == 1)
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
            LaneCars = new ObservableCollection<LaneCar>();
            for (int lane = 0; lane < LanesCount; lane++)
            {
                double line1YPercentage = (double) lane/LanesCount*100;

                double carImageHeightPercentage = _heightPercentage*0.8;
                double carImageTopPercentage = line1YPercentage + (_heightPercentage - carImageHeightPercentage)/2;

                LaneCars.Add(new LaneCar
                {
                    CarImageHeightPercentage = carImageHeightPercentage,
                    CarImageTopPercentage = carImageTopPercentage
                });
            }
        }

        private void InitLapLines()
        {
            LapLines = new ObservableCollection<LapLine>();
            for (int lap = 0; lap < LapsCount + 1; lap++)
            {
                double lapPosition = -lap;
                double xPercentage = CalcXPercentage(lapPosition);
                bool isVisible = CalcIsVisible(xPercentage);
                LapLine lapline = new LapLine
                {
                    XPercentage = xPercentage,
                    LapPosition = lapPosition,
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
            int yAbsoluteOffset = -25;
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
            double xPercentage = Math.Log10(lapPosition * 7 + 1) * 60;
            if (double.IsNaN(xPercentage))
                xPercentage = -100;
            return xPercentage;
        }

        public void CalcCarXPercentages()
        {
            LaneCar laneCarWithFirstPos = LaneCars.OrderByDescending(i => i.Laps).FirstOrDefault();

            if (laneCarWithFirstPos != null)
            {
                laneCarWithFirstPos.CarImageXPercentage = 0;

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
    }
}
