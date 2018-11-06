using Heinzman.BusinessObjects;
using Heinzman.VirtualControllerService;

namespace Heinzman.CentralUnitService.LevelModifier.GearShift
{
    class GearHandlerNullObject : IGearHandler
    {
        public ControllerLevel DoWork(ControllerLevel expectedLevel)
        {
            return expectedLevel;
        }
    }
}
