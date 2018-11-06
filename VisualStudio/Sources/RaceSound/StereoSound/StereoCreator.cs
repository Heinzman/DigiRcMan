using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.RaceSound.StereoSound
{
    public class StereoCreator
    {
        private readonly List<Lane> _lanes;
        private readonly AddHandler _funcAdd;
        private readonly bool _hasSingleSoundListHandler;
        private List<LaneId> _sortedLaneIds;

        public delegate void AddHandler(int stereoPan, LaneId laneId);

        public StereoCreator(List<Lane> lanes, AddHandler funcAdd, bool hasSingleSoundListHandler = false)
        {
            _lanes = lanes;
            _funcAdd = funcAdd;
            _hasSingleSoundListHandler = hasSingleSoundListHandler;
        }

        public void Create()
        {
            if (_hasSingleSoundListHandler)
                CreateSingleSoundListHandler();
            else
                CreateMultipleSoundListHandlers();
        }

        private void CreateSingleSoundListHandler()
        {
            _funcAdd(StereoPan.CenterPosition, LaneId.Lane1);
        }

        private void CreateMultipleSoundListHandlers()
        {
            GetSortedLaneIds();
            int laneCount = _sortedLaneIds.Count;
            switch (laneCount)
            {
                case 1:
                    _funcAdd(StereoPan.CenterPosition, _sortedLaneIds[0]);
                    break;
                case 2:
                    _funcAdd(StereoPan.RightPosition, _sortedLaneIds[0]);
                    _funcAdd(StereoPan.LeftPosition, _sortedLaneIds[1]);
                    break;
                case 3:
                    _funcAdd(StereoPan.RightPosition, _sortedLaneIds[0]);
                    _funcAdd(StereoPan.CenterPosition, _sortedLaneIds[1]);
                    _funcAdd(StereoPan.LeftPosition, _sortedLaneIds[2]);
                    break;
                case 4:
                    _funcAdd(StereoPan.RightPosition, _sortedLaneIds[0]);
                    _funcAdd(StereoPan.RightCenterPosition, _sortedLaneIds[1]);
                    _funcAdd(StereoPan.LeftCenterPosition, _sortedLaneIds[2]);
                    _funcAdd(StereoPan.LeftPosition, _sortedLaneIds[3]);
                    break;
                case 5:
                    _funcAdd(StereoPan.RightPosition, _sortedLaneIds[0]);
                    _funcAdd(StereoPan.RightCenterPosition, _sortedLaneIds[1]);
                    _funcAdd(StereoPan.CenterPosition, _sortedLaneIds[2]);
                    _funcAdd(StereoPan.LeftCenterPosition, _sortedLaneIds[3]);
                    _funcAdd(StereoPan.LeftPosition, _sortedLaneIds[4]);
                    break;
                case 6:
                    _funcAdd(StereoPan.RightPosition, _sortedLaneIds[0]);
                    _funcAdd(StereoPan.RightRightCenterPosition, _sortedLaneIds[1]);
                    _funcAdd(StereoPan.RightCenterCenterPosition, _sortedLaneIds[2]);
                    _funcAdd(StereoPan.LeftCenterCenterPosition, _sortedLaneIds[3]);
                    _funcAdd(StereoPan.LeftLeftCenterPosition, _sortedLaneIds[4]);
                    _funcAdd(StereoPan.LeftPosition, _sortedLaneIds[5]);
                    break;
            }
        }

        private void GetSortedLaneIds()
        {
            _sortedLaneIds = new List<LaneId>();
            foreach (Lane lane in _lanes)
                _sortedLaneIds.Add(lane.Id);
            _sortedLaneIds.Sort();
        }
    }
}
