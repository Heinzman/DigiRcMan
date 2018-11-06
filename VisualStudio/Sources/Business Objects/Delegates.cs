using System;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.BusinessObjects
{
    public static class Delegates
    {
        public delegate void GetLaneByIdHandler(LaneId laneId, out Lane lane);
        public delegate void LaneHandler(LaneId laneId);
        public delegate void LaneAdditionHandler(LaneId laneId, DateTime? timeStamp);
        public delegate void DataReceivedAsTextHandler(object sender, string text);
        public delegate void SsdControllerHandler(object sender, LaneId laneId);
    }
}
