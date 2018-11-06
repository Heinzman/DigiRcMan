using System.Collections.Generic;

namespace Elreg.BusinessObjects.Lanes
{
    public class ChangedLane : InitialLane
    {
        public int? Lap;
        public Lane.LaneStatusEnum Status;
        public int PenaltyCount { get; set; }

        public ChangedLane(Lane lane)
        {
            Id = lane.Id;
            Car = lane.Car;
            Driver = lane.Driver;
            Lap = lane.Lap;
            Status = lane.Status;
            PenaltyCount = lane.PenaltyCount;
        }

        public ChangedLane(LaneId id, Driver driver, Car car, int? lap,
                           Lane.LaneStatusEnum status, int? overallPenaltyCount)
            : base(id, driver, car)
        {
            Lap = lap;
            Status = status;
            PenaltyCount = overallPenaltyCount ?? 0;
        }
    }
}