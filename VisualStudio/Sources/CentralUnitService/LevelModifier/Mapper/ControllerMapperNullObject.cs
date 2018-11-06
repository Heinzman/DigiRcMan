using System.Collections.Generic;
using Heinzman.BusinessObjects;

namespace Heinzman.CentralUnitService.LevelModifier.Mapper
{
    public class ControllerMapperNullObject : IControllerMapper
    {
        public ControllerMapperNullObject()
        {
            CreateMapperTable();
        }

        public Dictionary<ControllerLevel, int> MapperTable { get; private set; }

        public ControllerLevel DoWork(ControllerLevel controllerLevel)
        {
            return controllerLevel;
        }

        private void CreateMapperTable()
        {
            MapperTable = new Dictionary<ControllerLevel, int> 
                              { 
                                  {ControllerLevel.L0, 0},
                                  {ControllerLevel.L1, 1},
                                  {ControllerLevel.L2, 2},
                                  {ControllerLevel.L3, 3},
                                  {ControllerLevel.L4, 4},
                                  {ControllerLevel.L5, 5},
                                  {ControllerLevel.L6, 6},
                                  {ControllerLevel.L7, 7},
                                  {ControllerLevel.L8, 8},
                                  {ControllerLevel.L9, 9},
                                  {ControllerLevel.L10, 10},
                                  {ControllerLevel.L11, 11},
                                  {ControllerLevel.L12, 12},
                                  {ControllerLevel.L13, 13},
                                  {ControllerLevel.L14, 14},
                                  {ControllerLevel.L15, 15},
                              };
        }
    }
}
