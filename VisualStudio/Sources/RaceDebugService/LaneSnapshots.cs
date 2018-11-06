using System;
using System.Collections.ObjectModel;
using Elreg.BusinessObjects;

namespace Elreg.RaceDebugService
{
    public class LaneSnapshots : Notifier
    {
        private bool _isPropertyChanged;
        public ObservableCollection<LaneSnapshot> LaneSnapshotList { get; private set; }

        public LaneSnapshots()
        {
            LaneSnapshotList = new ObservableCollection<LaneSnapshot>();
            foreach (var value in Enum.GetValues(typeof(LaneId)))
            {
                LaneSnapshot laneSnapshot = new LaneSnapshot {LaneId = (LaneId) value};
                laneSnapshot.PropertyChanged += LaneSnapshotPropertyChanged;
                LaneSnapshotList.Add(laneSnapshot);
            }
        }

        private void LaneSnapshotPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _isPropertyChanged = true;
        }

        public void RaiseOnPropertyChanged()
        {
            if (_isPropertyChanged)
            {
                _isPropertyChanged = false;
                OnPropertyChanged("LaneSnapshotList");
            }
        }

    }
}
