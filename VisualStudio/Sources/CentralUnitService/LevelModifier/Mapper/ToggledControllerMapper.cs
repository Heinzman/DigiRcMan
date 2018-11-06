using System;
using System.Collections.Generic;
using Heinzman.BusinessObjects;
using Heinzman.CentralUnitService.Settings;

namespace Heinzman.CentralUnitService.LevelModifier.Mapper
{
    public class ToggledControllerMapper : IControllerMapper
    {
        private readonly ToggleSettings _toggleSettings;

        private DateTime _lastToggledDateTime = DateTime.Now;
        private bool _isUpperToggleValue;

        public ToggledControllerMapper(ToggleSettings toggleSettings)
        {
            _toggleSettings = toggleSettings;
            CreateMapperTable();
        }

        public Dictionary<ControllerLevel, int> MapperTable { get; private set; }

        public ControllerLevel DoWork(ControllerLevel controllerLevel) // todo evtl löschen
        {
            ControllerLevel level;

            switch (controllerLevel)
            {
                case ControllerLevel.L1:
                    level = ControllerLevel.L1;
                    break;
                case ControllerLevel.L2:
                    level = ControllerLevel.L2;
                    break;
                case ControllerLevel.L3:
                    level = CalcToggledValue(ControllerLevel.L2);
                    break;
                case ControllerLevel.L4:
                    level = ControllerLevel.L3;
                    break;
                case ControllerLevel.L5:
                    level = ControllerLevel.L4;
                    break;
                case ControllerLevel.L6:
                    level = ControllerLevel.L5;
                    break;
                case ControllerLevel.L7:
                    level = ControllerLevel.L7;
                    break;
                case ControllerLevel.L8:
                    level = CalcToggledValue(ControllerLevel.L7);
                    break;
                case ControllerLevel.L9:
                    level = ControllerLevel.L9;
                    break;
                case ControllerLevel.L10:
                    level = CalcToggledValue(ControllerLevel.L9);
                    break;
                case ControllerLevel.L11:
                    level = ControllerLevel.L11;
                    break;
                case ControllerLevel.L12:
                    level = CalcToggledValue(ControllerLevel.L11);
                    break;
                case ControllerLevel.L13:
                    level = ControllerLevel.L13;
                    break;
                case ControllerLevel.L14:
                    level = CalcToggledValue(ControllerLevel.L13);
                    break;
                case ControllerLevel.L15:
                    level = ControllerLevel.L15;
                    break;
                default:
                    level = ControllerLevel.L0;
                    break;
            }
            return level;
        }

        private ControllerLevel CalcToggledValue(ControllerLevel lowerLevel)
        {
            ControllerLevel level = lowerLevel;
            if (_toggleSettings.IsActivated)
            {
                TimeSpan timeSpan = DateTime.Now - _lastToggledDateTime;
                if (timeSpan.TotalMilliseconds >= _toggleSettings.MilliSecsToToggleSpeed)
                {
                    _isUpperToggleValue = !_isUpperToggleValue;
                    _lastToggledDateTime = DateTime.Now;
                }
                if (_isUpperToggleValue)
                    level = ((ControllerLevel)(int)lowerLevel + 1);
            }
            return level;
        }

        private void CreateMapperTable()
        {
            MapperTable = new Dictionary<ControllerLevel, int> 
                              { 
                                  {ControllerLevel.L0, 0},
                                  {ControllerLevel.L1, 0},
                                  {ControllerLevel.L2, 1},
                                  {ControllerLevel.L3, 2},
                                  {ControllerLevel.L4, 3},
                                  {ControllerLevel.L5, 4},
                                  {ControllerLevel.L6, 5},
                                  {ControllerLevel.L7, 6},
                                  {ControllerLevel.L8, 7},
                                  {ControllerLevel.L9, 8},
                                  {ControllerLevel.L10, 9},
                                  {ControllerLevel.L11, 10},
                                  {ControllerLevel.L12, 11},
                                  {ControllerLevel.L13, 12},
                                  {ControllerLevel.L14, 13},
                                  {ControllerLevel.L15, 14},
                              };
        }
    }
}
