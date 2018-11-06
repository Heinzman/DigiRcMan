using Heinzman.BusinessObjects;
using System.Collections.Generic;
using Heinzman.CentralUnitService.Settings;

namespace Heinzman.CentralUnitService.LevelModifier.Delayer
{
    public class DelayHandler : SimpleDelayHandler
    {
        private readonly Dictionary<ControllerLevel, int> _mapperTable;

        public DelayHandler(DelaySettings delaySettings, Dictionary<ControllerLevel, int> mapperTable)
            : base(delaySettings)
        {
            _mapperTable = mapperTable;
        }

        protected override int CalcDeltaExpPrev()
        {
            return Map(ExpectedLevel) - Map(PreviousCalculatedLevel);
        }

        private int Map(ControllerLevel controllerLevel)
        {
            int value;
            _mapperTable.TryGetValue(controllerLevel, out value);
            return value;
        }

    }
}
