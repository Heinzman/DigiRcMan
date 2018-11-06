using Heinzman.BusinessObjects;
using Heinzman.CentralUnitService.Settings;
using Heinzman.VirtualControllerService;

namespace Heinzman.CentralUnitService.LevelModifier.GearShift
{
    public class GearHandler : IGearHandler
    {
        private readonly Options _options;
        private ControllerLevel _calculatedLevel;

        public GearHandler(Options options)
        {
            _options = options;
        }

        public ControllerLevel DoWork(ControllerLevel expectedLevel)
        {
            _calculatedLevel = expectedLevel;

            return _calculatedLevel;
        }
    }
}
