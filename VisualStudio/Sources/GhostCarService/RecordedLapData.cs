using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.PortActions;

namespace Elreg.GhostCarService
{
    [Serializable]
    public class RecordedLapData
    {
        public RecordedLapData()
        {
            CarControllers = new List<CarController>();
        }

        public DateTime EndTime { get; set; }

        public DateTime StartTime { get; set; }

        public bool Valid { get; set; }

        public List<CarController> CarControllers { get; set; }

    }
}