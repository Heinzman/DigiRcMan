namespace Heinzman.CentralUnitService.LevelModifier.Turbo
{
    public class TurboHandlerNullObject : ITurboHandler
    {
        public bool IsTurboActivated
        {
            get { return false; }
        }

        public bool IsButtonSuppressed
        {
            get { return false; }
        }

        public void DoWork(LaneController laneController)
        {}
    }
}
