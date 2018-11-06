using Heinzman.BusinessObjects;

namespace Heinzman.CentralUnitService.LevelModifier.GearShift
{
    public interface IGearHandler
    {
        ControllerLevel DoWork(ControllerLevel expectedLevel);
    }
}