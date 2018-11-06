using Heinzman.BusinessObjects.Interfaces;
using Heinzman.BusinessObjects.Lanes;
using Heinzman.CentralUnitService.LevelModifier.Adapter;
using Heinzman.CentralUnitService.LevelModifier.Delayer;
using Heinzman.CentralUnitService.LevelModifier.GearShift;
using Heinzman.CentralUnitService.LevelModifier.Mapper;
using Heinzman.CentralUnitService.LevelModifier.Stutter;
using Heinzman.CentralUnitService.LevelModifier.Turbo;

namespace Heinzman.CentralUnitService
{
    public class LaneController
    {
        public ITurboHandler TurboHandler { get; set; }
        public IVirtualController VirtualController { get; private set; }
        public Lane Lane { get; private set; }
        public IControllerMapper ControllerMapper { get; set; }
        public LevelAdapter LevelAdapter { get; set; }
        public IDelayHandler DelayHandler { get; set; }
        public IStutterHandler StutterHandler { get; set; }
        public IGearHandler GearHandler { get; set; }

        public LaneController(IVirtualController virtualController, Lane lane)
        {
            VirtualController = virtualController;
            Lane = lane;
        }
    }
}
