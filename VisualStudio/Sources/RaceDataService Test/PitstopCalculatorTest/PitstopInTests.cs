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
    public class PitstopInTests : BaseLapTest
    {
        private RaceProviderService _raceProviderService;
        private PitstopCalculator _pitstopCalculator;
        private CarController _carController;
        private bool _isEventRaisedPitIn;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _isEventRaisedPitIn = false;
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
        public void WhenLaneIsInPitstopAndSpeedIs0AndButtonIsPressedForRequiredTimestampThenShouldRaiseEventPitstopInForLane()
        {
            _isEventRaisedPitIn = false;
            SetPitstopOut();

            CalcPitstopWithPressedButtonAndSpeed(false, 3);
            CalcPitstopWithPressedButtonAndSpeed(false, 0);
            CalcPitstopWithPressedButtonAndSpeed(true, 0);
            WaitMilliSeconds((int)(_raceProviderService.RaceProviderOptions.MillisecsPressedToDetectPitstopIn * 1.5));
            CalcPitstopWithPressedButtonAndSpeed(true, 0);
            CalcPitstopWithPressedButtonAndSpeed(false, 3);

            Assert.IsTrue(_isEventRaisedPitIn);
        }

        [Test]
        public void WhenLaneIsInPitstopAndSpeedIs0AndButtonIsPressedForShortTimestampThenMustNotRaiseEventPitstopInForLane()
        {
            _isEventRaisedPitIn = false;
            SetPitstopOut();

            CalcPitstopWithPressedButtonAndSpeed(false, 3);
            CalcPitstopWithPressedButtonAndSpeed(false, 0);
            CalcPitstopWithPressedButtonAndSpeed(true, 0);
            WaitMilliSeconds((int)(_raceProviderService.RaceProviderOptions.MillisecsPressedToDetectPitstopIn * 0.5));
            CalcPitstopWithPressedButtonAndSpeed(true, 0);
            CalcPitstopWithPressedButtonAndSpeed(false, 3);

            Assert.IsFalse(_isEventRaisedPitIn);
        }

        [Test]
        public void WhenLaneIsInPitstopAndSpeedIs0AndButtonIsPressedForRequiredTimestampButOneSpeed3PeakThenShouldRaiseEventPitstopInForLane()
        {
            _isEventRaisedPitIn = false;
            SetPitstopOut();

            CalcPitstopWithPressedButtonAndSpeed(false, 3);
            CalcPitstopWithPressedButtonAndSpeed(false, 0);
            CalcPitstopWithPressedButtonAndSpeed(true, 0);
            WaitMilliSeconds((int)(_raceProviderService.RaceProviderOptions.MillisecsPressedToDetectPitstopIn * 0.5));
            CalcPitstopWithPressedButtonAndSpeed(true, 0);
            CalcPitstopWithPressedButtonAndSpeed(true, 3);
            WaitMilliSeconds(10); 
            CalcPitstopWithPressedButtonAndSpeed(true, 3);
            CalcPitstopWithPressedButtonAndSpeed(true, 0);
            WaitMilliSeconds((int)(_raceProviderService.RaceProviderOptions.MillisecsPressedToDetectPitstopIn * 0.5));
            CalcPitstopWithPressedButtonAndSpeed(true, 0);
            CalcPitstopWithPressedButtonAndSpeed(false, 3);

            Assert.IsTrue(_isEventRaisedPitIn);
        }


        private void SetPitstopOut()
        {
            FieldInfo fieldInfo = (typeof(PitstopCalculator)).GetField("_pitstopData", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                PitstopData pitstopData = fieldInfo.GetValue(_pitstopCalculator) as PitstopData;
                if (pitstopData != null)
                    pitstopData.PitstopIn = false;
            }
        }

        private void CalcPitstopWithPressedButtonAndSpeed(bool pressed, uint speed)
        {
            _carController.LaneChange = pressed;
            _carController.Speed = speed;
            _pitstopCalculator.DoWork(_carController);
        }

        private void PitstopCalculatorPitstopOutForLane(LaneId laneId)
        {
            _isEventRaisedPitIn = false;
        }

        private void PitstopCalculatorPitstopInForLane(LaneId laneId)
        {
            _isEventRaisedPitIn = true;
        }

        void PitstopCalculatorGetLaneById(LaneId laneId, out BusinessObjects.Lanes.Lane lane)
        {
            lane = null;
        }
    }
}
