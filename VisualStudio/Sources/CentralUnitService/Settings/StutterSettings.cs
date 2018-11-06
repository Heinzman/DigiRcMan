using Elreg.BusinessObjects;

namespace Elreg.CentralUnitService.Settings
{
    public class StutterSettings
    {
        public bool IsActivated { get; set; }
        public int MilliSecsMinDurationNonStuttering { get; set; }
        public int MilliSecsMaxDurationNonStuttering { get; set; }
        public int MilliSecsMinDurationStuttering { get; set; }
        public int MilliSecsMaxDurationStuttering { get; set; }
        public ControllerLevel MinControllerLevel { get; set; }
        public int PercentFuelForStuttering { get; set; }

        public StutterSettings()
        {
            IsActivated = true;
            MilliSecsMinDurationNonStuttering = 200;
            MilliSecsMaxDurationNonStuttering = 2000;
            MilliSecsMinDurationStuttering = 50;
            MilliSecsMaxDurationStuttering = 500;
            MinControllerLevel = ControllerLevel.L2;
            PercentFuelForStuttering = 5;
        }
    }
}