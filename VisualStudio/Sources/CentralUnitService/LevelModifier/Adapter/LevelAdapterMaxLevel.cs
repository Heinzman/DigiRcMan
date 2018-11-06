using Heinzman.BusinessObjects;
using Heinzman.CentralUnitService.Settings;

// ReSharper disable PossibleInvalidOperationException
namespace Heinzman.CentralUnitService.LevelModifier.Adapter
{
    public class LevelAdapterMaxLevel : LevelAdapter
    {
        public LevelAdapterMaxLevel(Options options)
            : base(options)
        {}

        public override ControllerLevel DoWork(ControllerLevel controllerLevel, bool isTurboActivated)
        {
            IsTurboActivated = isTurboActivated;
            CalcMaxLevelWith(controllerLevel);
            return Level;
        }

        protected virtual void CalcMaxLevelWith(ControllerLevel controllerLevel)
        {
            if (Options.TurboOptions.MaxLevelWithoutTurbo <= controllerLevel)
                Level = Options.TurboOptions.MaxLevelWithoutTurbo.Value;
            else
                Level = controllerLevel;
        }

    }
}
