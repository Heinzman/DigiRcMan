using Heinzman.BusinessObjects;
using Heinzman.CentralUnitService.Settings;

namespace Heinzman.CentralUnitService.LevelModifier.Adapter
{
    public class LevelAdapter
    {
        protected readonly Options Options;
        protected ControllerLevel Level;
        protected bool IsTurboActivated;

        public LevelAdapter(Options options)
        {
            Options = options;
        }

        public virtual ControllerLevel DoWork(ControllerLevel controllerLevel, bool isTurboActivated)
        {
            return controllerLevel;
        }
    }
}
