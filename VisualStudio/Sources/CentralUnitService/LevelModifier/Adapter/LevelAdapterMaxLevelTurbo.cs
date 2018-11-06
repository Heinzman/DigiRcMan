// ReSharper disable PossibleInvalidOperationException

using Heinzman.BusinessObjects;
using Heinzman.CentralUnitService.Settings;

namespace Heinzman.CentralUnitService.LevelModifier.Adapter
{
    public class LevelAdapterMaxLevelTurbo : LevelAdapterMaxLevel
    {
        public LevelAdapterMaxLevelTurbo(Options options)
            : base(options)
        {}

        protected override void CalcMaxLevelWith(ControllerLevel level)
        {
            if (level < Options.TurboOptions.MaxLevelWithoutTurbo.Value)
                Level = level;
            else if (IsTurboActivated)
                Level = Options.TurboOptions.LevelOfTurbo.Value;
            else
                Level = Options.TurboOptions.MaxLevelWithoutTurbo.Value;
        }

    }
}
