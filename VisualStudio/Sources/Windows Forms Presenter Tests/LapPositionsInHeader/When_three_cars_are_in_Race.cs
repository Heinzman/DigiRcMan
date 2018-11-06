using Elreg.UnitTests.MockObjects;
using Elreg.UnitTests.TestHelper;
using Elreg.WindowsFormsPresenter.RaceGrid;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.WindowsFormsPresenter.LapPositionsInHeader
{
    [TestFixture]
    public class When_three_cars_are_in_Race : BaseLapTest
    {
        private MockRaceGridView _raceGridView;
        private PositionsCalculator _positionsCalculator;

        private const string LabelTextWith6Secs = "2.Driver2 (01.00)";

        [SetUp]
        public void Initialize()
        {
            _raceGridView = new MockRaceGridView();
            _positionsCalculator = new PositionsCalculator(RaceModel, _raceGridView);
            StartRace();
        }

        [Test]
        public void All_labels_should_should_be_filled_before_zeroth_lap()
        {
            _positionsCalculator.UpdatePositions();
            AssertLabelIsFilled(0);
            AssertLabelIsFilled(1);
            AssertLabelIsFilled(2);
            AssertLabelIsEmpty(3);
            AssertLabelIsEmpty(4);
            AssertLabelIsEmpty(5);
        }

        [Test]
        public void First_Three_labels_should_be_filled_After_zeroth_lap()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane3.Id);

            _positionsCalculator.UpdatePositions();
            AssertLabelIsFilled(0);
            AssertLabelIsFilled(1);
            AssertLabelIsFilled(2);
            AssertLabelIsEmpty(3);
            AssertLabelIsEmpty(4);
            AssertLabelIsEmpty(5);
        }

        [Test]
        public void Label2_should_be_correct_After_zeroth_lap()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitSeconds(1);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        [Test]
        public void Label2_should_be_correct_after_one_pause_After_zeroth_lap()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitSeconds(1);
            PauseRaceForSecs(1);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        [Test]
        public void Label2_should_be_correct_after_two_pauses_After_zeroth_lap()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(500);
            PauseRaceForSecs(1);
            WaitMilliSeconds(500);
            PauseRaceForSecs(1);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        [Test]
        public void Label2_should_be_correct_After_first_lap()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitSeconds(1);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        [Test]
        public void Label2_should_be_correct_after_one_pause_After_first_lap()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitSeconds(1);
            PauseRaceForSecs(1);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        [Test]
        public void Label2_should_be_correct_after_two_pauses_After_first_lap()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(500);
            PauseRaceForSecs(1);
            WaitMilliSeconds(500);
            PauseRaceForSecs(1);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        [Test]
        public void Label2_should_be_correct_With_one_lap_distance()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(500);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(500);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        [Test]
        public void Label2_should_be_correct_first_with_one_lap_distance_then_same_lap()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(500);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            WaitMilliSeconds(500);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        [Test]
        public void Label2_should_be_correct_With_one_lap_distance_after_one_pause()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(500);
            PauseRaceForSecs(1);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(500);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        [Test]
        public void Label2_should_be_correct_With_one_lap_distance_after_two_pauses()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(500);
            PauseRaceForSecs(1);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(500);
            WaitSomeMilliSeconds();
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        [Test]
        public void Label2_should_be_correct_With_two_laps_distance()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(300);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(300);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(400);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        [Test]
        public void Label2_should_be_correct_With_three_laps_distance()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(250);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(250);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(250);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitMilliSeconds(250);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2IsLabelTextWith1Sec();
        }

        private void PauseRaceForSecs(int secs)
        {
            RaceModel.PauseRaceByKeyboard();
            WaitSeconds(secs);
            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
        }

        private void AssertLabel2IsLabelTextWith1Sec()
        {
            int lengthWitoutDecimals = LabelTextWith6Secs.Length - 3;
            string expected = LabelTextWith6Secs.Substring(0, lengthWitoutDecimals);
            string actual = TextOfLabelWithIndex(1).Substring(0, lengthWitoutDecimals);
            Assert.AreEqual(expected, actual);
        }

        private void AssertLabelIsEmpty(int index)
        {
            Assert.IsTrue(IsPositionLabelsNullOrEmpty(index));
        }

        private void AssertLabelIsFilled(int index)
        {
            Assert.IsFalse(IsPositionLabelsNullOrEmpty(index));
        }

        private bool IsPositionLabelsNullOrEmpty(int index)
        {
            return string.IsNullOrEmpty(TextOfLabelWithIndex(index));
        }

        private string TextOfLabelWithIndex(int index)
        {
            return _raceGridView.PositionLabels[index].Text;
        }

        protected override void InitRaceSettings()
        {
            RaceSettings.LapsToDrive = 100;
            RaceSettings.AutoDetectLapEnabled = false;
            RaceSettings.AutoDetectZerothLapEnabled = false;
            RaceSettings.RestartCountDownRaceActivated = false;
            RaceSettings.StartCountDownRaceActivated = false;
            RaceSettings.SecondsForValidLap = 0;
            RaceSettings.PausePyParallelPortActivated = false;
            RaceSettings.AutoDisqualificationRaceActivated = false;
        }


    }
}
