using Heinzman.BusinessObjects;

namespace Heinzman.CentralUnitService.LevelModifier.Stutter
{
    public class StutterHandlerNullObject : IStutterHandler
    {
        public ControllerLevel DoWork(ControllerLevel expectedLevel, float currentFuelPercent, bool isTurboActivated)
        {
            return expectedLevel;
        }
    }
}
