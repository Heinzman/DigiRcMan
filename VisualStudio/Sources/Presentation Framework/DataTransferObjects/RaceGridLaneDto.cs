using System.Collections.Generic;
using System.Drawing;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.WinFormsPresentationFramework.DataTransferObjects
{
    public class RaceGridLaneDto
    {
        public LaneId LaneId;
        public string ScxId;
        public string Driver;
        public Image Car;
        public string CarName;
        public string LapTime;
        public string LapTimeBestLapTime;
        public string BestLapTime;
        public string Position;
        public string Lap;
        public Color Color;
        public Image StatusImage;
        public LaneStatus LaneStatus = LaneStatus.Normal;
        public string PenaltiesText;
        public int PenaltiesCount;
        public Lane.LaneStatusEnum Status;
    }
}
