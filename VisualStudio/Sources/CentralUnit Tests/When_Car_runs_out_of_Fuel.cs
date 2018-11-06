using System.Collections.Generic;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Interfaces;
using Heinzman.BusinessObjects.Races;
using Heinzman.CentralUnitService;
using Heinzman.CentralUnitService.Settings;
using Heinzman.MockObjects;
using Heinzman.ParallelPortDataHandler;
using Heinzman.UnitTests.TestHelper;
using Heinzman.VirtualControllerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming
namespace Heinzman.CentralUnitTests
{
    [TestClass]
    public class When_Car_runs_out_of_Fuel : BaseLapTest
    {
        private readonly VirtualController _virtualController = new VirtualController();
        private IPortDataWriter _portDataWriter;

        [TestInitialize]
        public new void StartUp()
        {
            base.StartUp();
            InitRace();
            InitCentralUnit();
        }

        private void InitCentralUnit()
        {
            List<LaneController> laneControllers = new List<LaneController>
                                                       {
                                                           new LaneController(_virtualController, Lane3)
                                                       };
            ICentralUnitOptionsService optionsService = new MockCentralUnitOptionsService();
            optionsService.Options = new Options
                                        {
                                            TurboOptions = 
                                            { 
                                                IsActivated = false, 
                                                MaxLevelWithoutTurbo = ControllerLevel.L14, 
                                                LevelOfTurbo = ControllerLevel.L15 
                                            },
                                            ToggleOptions = { IsActivated = false }
                                        };
            _portDataWriter = new DataWriter(new MockParallelPortWriter());
            // todo new CentralUnit(laneControllers, _portDataWriter, RaceModel, optionsService);
        }

        [TestMethod]
        public void Car_stops_if_Not_NegativeFuelLevelEnabled()
        {
            RaceSettings.NegativeFuelLevelEnabled = false;
            Lane3.CurrentFuelLevelInLitres = 10;
            StartRaceCheckCountDown(Race.TypeEnum.Race);

            _virtualController.CurrentLevel = ControllerLevel.L15;
            WaitMilliSeconds(10);
            Assert.AreNotEqual(0, _portDataWriter.PortValue);

            int counter = 0;
            while (counter++ < 1000 && Lane3.CurrentFuelLevelInLitres > 0)
                MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane3.Id, 12, new List<uint> { 12 });

            WaitMilliSeconds(10);
            Assert.AreEqual(0, _portDataWriter.PortValue);
        }

        [TestMethod]
        public void Car_still_runs_if_NegativeFuelLevelEnabled()
        {
            RaceSettings.NegativeFuelLevelEnabled = true;
            Lane3.CurrentFuelLevelInLitres = 10;
            StartRaceCheckCountDown(Race.TypeEnum.Race);

            _virtualController.CurrentLevel = ControllerLevel.L15;
            WaitMilliSeconds(10);
            Assert.AreNotEqual(0, _portDataWriter.PortValue);

            int counter = 0;
            while (counter++ < 1000 && Lane3.CurrentFuelLevelInLitres > -10)
                MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane3.Id, 12, new List<uint> { 12 });

            WaitMilliSeconds(10);
            Assert.AreNotEqual(0, _portDataWriter.PortValue);
        }

    }
}
