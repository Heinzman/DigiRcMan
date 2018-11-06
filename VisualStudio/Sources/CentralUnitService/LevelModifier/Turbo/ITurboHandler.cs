namespace Heinzman.CentralUnitService.LevelModifier.Turbo
{
    public interface ITurboHandler
    {
        bool IsTurboActivated { get; }
        bool IsButtonSuppressed { get; }
        void DoWork(LaneController laneController);
    }
}