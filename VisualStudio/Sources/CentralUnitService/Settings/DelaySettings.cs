namespace Elreg.CentralUnitService.Settings
{
    public class DelaySettings
    {
        public bool IsActivated { get; set; }
        public int PercentFuelForZeroDelay { get; set; }
        public int MilliSecsAccelerationDelayAtFullTank { get; set; }
        public int MilliSecsBrakeDelayAtFullTank { get; set; }
        public int AccelerationFactor { get; set; }
        public int BrakeFactor { get; set; }

        public DelaySettings()
        {
            IsActivated = true;
            MilliSecsAccelerationDelayAtFullTank = 50;
            MilliSecsBrakeDelayAtFullTank = 25;
            PercentFuelForZeroDelay = 20;
            AccelerationFactor = 10;
            BrakeFactor = 4;
        }
    }
}