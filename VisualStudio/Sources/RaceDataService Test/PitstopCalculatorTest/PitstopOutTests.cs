using System.Reflection;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.PortActions;
using Elreg.RaceDataService;
using Elreg.RaceDataService.RaceData;
using Elreg.RaceOptionsService;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.RaceDataServiceTests.PitstopCalculatorTest
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class PitstopOutTests : BaseLapTest
    {
        private RaceProviderService _raceProviderService;
        private PitstopCalculator _pitstopCalculator;
        private CarController _carController;
        private bool _isEventRaisedPitOut;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _isEventRaisedPitOut = false;
            _raceProviderService = new RaceProviderService();
            _pitstopCalculator = new PitstopCalculator(_raceProviderService, LaneId.Lane1);
            _pitstopCalculator.PitstopInForLane += PitstopCalculatorPitstopInForLane;
            _pitstopCalculator.PitstopOutForLane += PitstopCalculatorPitstopOutForLane;
            _pitstopCalculator.GetLaneById += PitstopCalculatorGetLaneById;
            _carController = new CarController();
        }

        [SetUp]
        public void StartUp()
        {
            StartRace();
        }

        [Test]
        public void WhenLaneIsInPitstopAndSpeedIs3ForLongTimespanThenShouldRaiseEventPitstopOutForLane()
        {
            SetPitstopIn();

            CalcPitstopWithSpeed(0);
            CalcPitstopWithSpeed(3);
            WaitMilliSeconds((int)(_raceProviderService.RaceProviderOptions.MillisecsPitstopNotZeroTolerance*1.1));
            CalcPitstopWithSpeed(3);
            CalcPitstopWithSpeed(0);

            Assert.IsTrue(_isEventRaisedPitOut);
        }

        [Test]
        public void WhenLaneIsInPitstopAndSpeedIs3forVeryShortTimespanThenMustNotRaiseEventPitstopOutForLane()
        {
            SetPitstopIn();

            CalcPitstopWithSpeed(0);
            CalcPitstopWithSpeed(3);
            WaitMilliSeconds((int)(_raceProviderService.RaceProviderOptions.MillisecsPitstopNotZeroTolerance*0.2));
            CalcPitstopWithSpeed(3);
            CalcPitstopWithSpeed(0);

            Assert.IsFalse(_isEventRaisedPitOut);
        }

        private void SetPitstopIn()
        {
            FieldInfo fieldInfo = (typeof (PitstopCalculator)).GetField("_pitstopData", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                PitstopData pitstopData = fieldInfo.GetValue(_pitstopCalculator) as PitstopData;
                if (pitstopData != null)
                    pitstopData.PitstopIn = true;
            }
        }

        private void CalcPitstopWithSpeed(uint speed)
        {
            _carController.Speed = speed;
            _pitstopCalculator.DoWork(_carController);
        }

        private void PitstopCalculatorPitstopOutForLane(LaneId laneId)
        {
            _isEventRaisedPitOut = true;
        }

        private void PitstopCalculatorPitstopInForLane(LaneId laneId)
        {
        }

        void PitstopCalculatorGetLaneById(LaneId laneId, out BusinessObjects.Lanes.Lane lane)
        {
            lane = null;
        }
    }
}
