using System.Threading;
using Elreg.BusinessObjects.Interfaces;
using Elreg.PortDataParser;
using Elreg.RaceDataService.RaceData;
using Elreg.RaceOptionsService;
using Elreg.UnitTests.MockObjects;
using Elreg.UnitTests.TestHelper;

namespace Elreg.UnitTests.DomainModels.PitInDetectionTests
{
    public class PitInDetectionTest : BaseLapTest
    {
        private ISerialPortParser _serialPortParser;
        private RaceProviderService _raceProviderService;
        protected MockControllerDataSupplier MockControllerDataSupplier;

        protected override void InitRaceSettings()
        {
            base.InitRaceSettings();
            RaceSettings.RefuelingAfterServingPenaltyAllowed = false;
            _raceProviderService = new RaceProviderService();
        }

        protected override void CreateRaceDataProvider()
        {
            RaceDataProvider = new RaceDataProvider(_serialPortParser, _raceProviderService, RaceModel);
        }

        protected void WaitSecondsForPitstopInDetection()
        {
            Thread.Sleep(_raceProviderService.RaceProviderOptions.MillisecsPressedToDetectPitstopIn * 2);
        }

        protected void InitAndStartRace()
        {
            _serialPortParser = new MockSerialPortParser();
            MockControllerDataSupplier = new MockControllerDataSupplier(_serialPortParser);
            StartRace();
        }

    }
}
