using System;
using System.Windows.Media.Imaging;
using Catel.Data;
using Elreg.BusinessObjects;

namespace Elreg.WpfModelObjects
{
    [Serializable]
    public class RaceLane : ModelBase
    {
        private BitmapImage _statusImage;

        public static readonly PropertyData LaneIdProperty = RegisterProperty("LaneId", typeof(LaneId));
        public static readonly PropertyData IdProperty = RegisterProperty("Id", typeof(int));
        public static readonly PropertyData DriverNameProperty = RegisterProperty("DriverName", typeof(string));
        public static readonly PropertyData FuelLevelProperty = RegisterProperty("FuelLevel", typeof(int));
        public static readonly PropertyData LapProperty = RegisterProperty("Lap", typeof(int));
        public static readonly PropertyData PenaltyCountProperty = RegisterProperty("PenaltyCount", typeof(int));
        public static readonly PropertyData PositionProperty = RegisterProperty("Position", typeof(int));
        public static readonly PropertyData SpeedSumProperty = RegisterProperty("SpeedSum", typeof(int));
        public static readonly PropertyData SpeedSumAvgProperty = RegisterProperty("SpeedSumAvg", typeof(int));
        public static readonly PropertyData FuelLevelToWarnYellowProperty = RegisterProperty("FuelLevelToWarnYellow", typeof(int));
        public static readonly PropertyData FuelLevelToWarnRedProperty = RegisterProperty("FuelLevelToWarnRed", typeof(int));

        public BitmapImage StatusImage
        {
            get { return _statusImage; }
            set
            {
                _statusImage = value;
                RaisePropertyChanged("StatusImage");
            }
        }

        public int SpeedSum
        {
            get { return GetValue<int>(SpeedSumProperty); }
            set { SetValue(SpeedSumProperty, value); }
        }

        public int SpeedSumAvg
        {
            get { return GetValue<int>(SpeedSumAvgProperty); }
            set { SetValue(SpeedSumAvgProperty, value); }
        }

        public int Id
        {
            get { return GetValue<int>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public LaneId LaneId
        {
            get { return GetValue<LaneId>(LaneIdProperty); }
            set { SetValue(LaneIdProperty, value); }
        }

        public string DriverName
        {
            get { return GetValue<string>(DriverNameProperty); }
            set { SetValue(DriverNameProperty, value); }
        }

        public int FuelLevel
        {
            get { return GetValue<int>(FuelLevelProperty); }
            set { SetValue(FuelLevelProperty, value); }
        }

        public int Lap
        {
            get { return GetValue<int>(LapProperty); }
            set { SetValue(LapProperty, value); }
        }

        public int PenaltyCount
        {
            get { return GetValue<int>(PenaltyCountProperty); }
            set { SetValue(PenaltyCountProperty, value); }
        }

        public int Position
        {
            get { return GetValue<int>(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        public int FuelLevelToWarnYellow
        {
            get { return GetValue<int>(FuelLevelToWarnYellowProperty); }
            set { SetValue(FuelLevelToWarnYellowProperty, value); }
        }

        public int FuelLevelToWarnRed
        {
            get { return GetValue<int>(FuelLevelToWarnRedProperty); }
            set { SetValue(FuelLevelToWarnRedProperty, value); }
        }

    }
}
