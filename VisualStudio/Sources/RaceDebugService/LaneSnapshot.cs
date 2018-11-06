using Elreg.BusinessObjects;

namespace Elreg.RaceDebugService
{
    public class LaneSnapshot : Notifier
    {
        private string _driverName;
        private LaneId _laneId;
        private int _position;

        public LaneId LaneId
        {
            get { return _laneId; }
            set
            {
                if (_laneId != value)
                    OnPropertyChanged("LaneId");
                _laneId = value;
            }
        }

        public string DriverName
        {
            get { return _driverName; }
            set
            {
                if (_driverName != value)
                    OnPropertyChanged("DriverName");
                _driverName = value;
            }
        }

        public int Position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                    OnPropertyChanged("Position");
                _position = value;
            }
        }

    }
}
