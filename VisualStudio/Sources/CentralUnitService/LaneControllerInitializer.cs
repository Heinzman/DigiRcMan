using System.Collections.Generic;
using Heinzman.CentralUnitService.LevelModifier.Adapter;
using Heinzman.CentralUnitService.LevelModifier.Delayer;
using Heinzman.CentralUnitService.LevelModifier.GearShift;
using Heinzman.CentralUnitService.LevelModifier.Mapper;
using Heinzman.CentralUnitService.LevelModifier.Stutter;
using Heinzman.CentralUnitService.LevelModifier.Turbo;
using Heinzman.CentralUnitService.Settings;

namespace Heinzman.CentralUnitService
{
    public class LaneControllerInitializer
    {
        private readonly List<LaneController> _laneControllers;
        private readonly Options _options;

        public LaneControllerInitializer(List<LaneController> laneControllers, Options options)
        {
            _laneControllers = laneControllers;
            _options = options;
        }

        public void DoWork()
        {
            foreach (LaneController laneController in _laneControllers)
            {
                CreateTurboHandler(laneController);
                CreateControllerMapper(laneController);
                CreateDelayHandler(laneController);
                CreateStutterHandler(laneController);
                CreateLevelAdapter(laneController);
                CreateGearHandler(laneController);
            }
        }

        private void CreateGearHandler(LaneController laneController)
        {
            if (_options.IsGearShiftMode)
                laneController.GearHandler = new GearHandler(_options);
            else
                laneController.GearHandler = new GearHandlerNullObject();
        }

        private void CreateLevelAdapter(LaneController laneController)
        {
            if (_options.TurboOptions.IsActivated)
            {
                if (_options.TurboOptions.MaxLevelWithoutTurbo != null &&
                    (_options.TurboOptions.LevelOfTurbo == null || !_options.TurboOptions.IsActivated))
                    laneController.LevelAdapter = new LevelAdapterMaxLevel(_options);
                else if (_options.TurboOptions.MaxLevelWithoutTurbo != null && _options.TurboOptions.LevelOfTurbo != null &&
                         _options.TurboOptions.IsActivated)
                    laneController.LevelAdapter = new LevelAdapterMaxLevelTurbo(_options);
                else if (_options.TurboOptions.MaxLevelWithoutTurbo == null &&
                         _options.TurboOptions.LevelOfTurbo != null && _options.TurboOptions.IsActivated)
                    laneController.LevelAdapter = new LevelAdapterTurbo(_options);
                else
                    laneController.LevelAdapter = new LevelAdapter(_options);
            }
            else
                laneController.LevelAdapter = new LevelAdapter(_options);
        }

        private void CreateStutterHandler(LaneController laneController)
        {
            if (_options.StutterOptions.IsActivated)
                laneController.StutterHandler = new StutterHandler(_options.StutterOptions);
            else
                laneController.StutterHandler = new StutterHandlerNullObject();
        }

        private void CreateDelayHandler(LaneController laneController)
        {
            if (_options.DelayOptions.IsActivated)
                laneController.DelayHandler = new DelayHandler(_options.DelayOptions, laneController.ControllerMapper.MapperTable);
            else
                laneController.DelayHandler = new DelayHandlerNullObject();
        }

        private void CreateControllerMapper(LaneController laneController)
        {
            if (_options.ToggleOptions.IsActivated)
                laneController.ControllerMapper = new ToggledControllerMapper(_options.ToggleOptions);
            else
                laneController.ControllerMapper = new ControllerMapperNullObject();
        }

        private void CreateTurboHandler(LaneController laneController)
        {
            if (_options.TurboOptions.IsActivated)
                laneController.TurboHandler = new TurboHandler(_options.TurboOptions);
            else
                laneController.TurboHandler = new TurboHandlerNullObject();
        }
    }
}
