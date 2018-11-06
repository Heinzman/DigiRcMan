using System.Collections.Generic;
using Heinzman.BusinessObjects;

namespace Heinzman.CentralUnitService.LevelModifier.Mapper
{
    public interface IControllerMapper
    {
        Dictionary<ControllerLevel, int> MapperTable { get; }
        ControllerLevel DoWork(ControllerLevel controllerLevel);
    }
}