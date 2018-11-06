using System;

namespace Elreg.BusinessObjects.Lanes
{
    [Serializable]
    public class InitialLane
    {
        public InitialLane()
        {
        }

        public InitialLane(LaneId id, Driver driver, Car car)
        {
            Id = id;
            Driver = driver;
            Car = car;
        }

        public LaneId Id { get; set; }

        public Driver Driver { get; set; }

        public Car Car { get; set; }

    }
}
