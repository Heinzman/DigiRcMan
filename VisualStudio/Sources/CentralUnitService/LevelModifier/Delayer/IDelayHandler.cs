using Heinzman.BusinessObjects;

namespace Heinzman.CentralUnitService.LevelModifier.Delayer
{
    public interface IDelayHandler
    {
        ControllerLevel DoWork(ControllerLevel expectedLevel, float currentFuelPercent, bool isTurboActivated);
    }
}