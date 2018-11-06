using Heinzman.BusinessObjects;

namespace Heinzman.CentralUnitService.LevelModifier.Stutter
{
    public interface IStutterHandler
    {
        ControllerLevel DoWork(ControllerLevel expectedLevel, float currentFuelPercent, bool isTurboActivated);
    }
}