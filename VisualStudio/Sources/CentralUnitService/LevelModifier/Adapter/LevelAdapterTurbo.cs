using Heinzman.BusinessObjects;
using Heinzman.CentralUnitService.Settings;

namespace Heinzman.CentralUnitService.LevelModifier.Adapter
{
    public class LevelAdapterTurbo : LevelAdapter
    {

        public LevelAdapterTurbo(Options options) : base(options)
        { }

        public override ControllerLevel DoWork(ControllerLevel controllerLevel, bool isTurboActivated)
        {
            ControllerLevel level = ControllerLevel.L0;

            if (controllerLevel < ControllerLevel.L14)
                level = controllerLevel;
            else if (controllerLevel == ControllerLevel.L14)
            {
                if (Options.TurboOptions.IsActivated)
                    level = ControllerLevel.L13;
            }
            else if (controllerLevel == ControllerLevel.L15)
            {
                if (Options.TurboOptions.IsActivated && isTurboActivated)
                    level = ControllerLevel.L15;
                else
                    level = ControllerLevel.L13;
            }
            return level;
        }
    }
}
