using System;

namespace Elreg.BusinessObjects.PortActions
{
    [Serializable]
    public class CarController
    {
        public CarController(CarController carController)
        {
            Speed = carController.Speed;
            LaneChange = carController.LaneChange;
            TimeStamp = DateTime.Now;
        }

        public CarController() {}

        public DateTime TimeStamp { get; set; }

        public uint Speed { get; set; }

        public bool LaneChange { get; set; }
    }
}
