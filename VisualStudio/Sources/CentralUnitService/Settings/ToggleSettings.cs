namespace Heinzman.CentralUnitService.Settings
{
    public class ToggleSettings
    {
        public bool IsActivated { get; set; }
        public int MilliSecsToToggleSpeed { get; set; }

        public ToggleSettings()
        {
            IsActivated = true;
            MilliSecsToToggleSpeed = 30;
        }
    }
}
