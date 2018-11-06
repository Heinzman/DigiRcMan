using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.PortActions;
using Elreg.RaceDataService.RaceData;
using Elreg.RaceOptionsService;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.RaceDataServiceTests.PenaltyControllerTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_ControllerButton_Is_Clicked : BaseLapTest
    {
        private int _penaltyCount;
        private List<uint> _speedList = new List<uint> { 10 };
        private LapDetectionSingleAction _lapDetectionSingleAction = new LapDetectionSingleAction();
        private RaceProviderService _raceProviderService = new RaceProviderService();
        private ActionsCalculator _actionsCalculator;

        
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            ActionsCalculator.PenaltyAdditionForLane += ActionsCalculatorPenaltyAdditionForLane;
        }

        [SetUp]
        public void StartUp()
        {
            _penaltyCount = 0;
            _speedList = new List<uint> { 10 };
            _lapDetectionSingleAction = new LapDetectionSingleAction();
            _raceProviderService = new RaceProviderService();
            _actionsCalculator = new ActionsCalculator(_raceProviderService, LaneId.Lane1);
            StartRace();
        }

        [Test]
        public void Three_Times_within_MinSecs_Then_Should_be_raised_Penalty_Event()
        {
            CheckPenaltiesAfterButtonPressedCountOf(3);
            Assert.AreEqual(1, _penaltyCount);
        }

        [Test]
        public void Four_Times_within_MinSecs_Then_Must_not_raise_Two_Penalty_Events()
        {
            CheckPenaltiesAfterButtonPressedCountOf(4);
            Assert.AreEqual(1, _penaltyCount);
        }

        [Test]
        public void Five_Times_within_MinSecs_Then_Must_not_raise_Two_Penalty_Events()
        {
            CheckPenaltiesAfterButtonPressedCountOf(5);
            Assert.AreEqual(1, _penaltyCount);
        }

        [Test]
        public void Six_Times_within_MinSecs_Then_Should_be_raised_Two_Penalty_Events()
        {
            CheckPenaltiesAfterButtonPressedCountOf(6);
            Assert.AreEqual(2, _penaltyCount);
        }

        private void CheckPenaltiesAfterButtonPressedCountOf(int buttonPressedCount)
        {
            Assert.AreEqual(0, _penaltyCount);
            for (int i = 0; i < buttonPressedCount; i++)
            {
                WaitAndCalcPenaltyFor(true);
                WaitAndCalcPenaltyFor(false);
            }
        }

        private void WaitAndCalcPenaltyFor(bool isButtonPressed)
        {
            WaitMilliSeconds(100);
            CarController carController = new CarController {LaneChange = isButtonPressed, Speed = 0};
            _actionsCalculator.DoWork(carController, _lapDetectionSingleAction, _speedList);
        }

        private void ActionsCalculatorPenaltyAdditionForLane(LaneId laneId)
        {
            _penaltyCount++;
        }
    }
}
