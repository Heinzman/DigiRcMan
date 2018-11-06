using Heinzman.BusinessObjects;

namespace Heinzman.CentralUnitService.LevelModifier.Delayer
{
    public class DelayHandlerNullObject : IDelayHandler
    {
        public ControllerLevel DoWork(ControllerLevel expectedLevel, float currentFuelPercent, bool isTurboActivated)
        {
            return expectedLevel;
        }
    }
}
