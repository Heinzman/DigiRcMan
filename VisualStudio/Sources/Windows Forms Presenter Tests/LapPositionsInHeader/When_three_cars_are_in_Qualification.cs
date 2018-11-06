using Elreg.BusinessObjects.Races;
using Elreg.UnitTests.MockObjects;
using Elreg.UnitTests.TestHelper;
using Elreg.WindowsFormsPresenter.RaceGrid;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.WindowsFormsPresenter.LapPositionsInHeader
{
    [TestFixture]
    public class When_three_cars_are_in_Qualification : BaseLapTest
    {
        private MockRaceGridView _raceGridView;
        private PositionsCalculator _positionsCalculator;

        private const string Label2TextWith1Secs = "2.Driver2 (01.000)";

        [SetUp]
        public void Initialize()
        {
            _raceGridView = new MockRaceGridView();
            _positionsCalculator = new PositionsCalculator(RaceModel, _raceGridView);
            StartCompetition(Race.TypeEnum.Qualification);
        }

        [Test]
        public void All_labels_should_be_empty_before_zeroth_lap()
        {
            _positionsCalculator.UpdatePositions();
            AssertLabelIsEmpty(0);
            AssertLabelIsEmpty(1);
            AssertLabelIsEmpty(2);
            AssertLabelIsEmpty(3);
            AssertLabelIsEmpty(4);
            AssertLabelIsEmpty(5);
        }

        [Test]
        public void First_Three_labels_should_be_empty_After_zeroth_lap()
        {
            _positionsCalculator.UpdatePositions();
            AssertLabelIsEmpty(0);
            AssertLabelIsEmpty(1);
            AssertLabelIsEmpty(2);
            AssertLabelIsEmpty(3);
            AssertLabelIsEmpty(4);
            AssertLabelIsEmpty(5);
        }

        [Test]
        public void First_Three_labels_should_be_filled_After_first_lap()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane3.Id);
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
        public void Label2_should_be_correct_After_first_lap()
        {
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            WaitSeconds(1);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            _positionsCalculator.UpdatePositions();
            AssertLabel2TextWith1Secs();
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

        private void AssertLabel2TextWith1Secs()
        {
            int lengthWitoutDecimals = Label2TextWith1Secs.Length - 3;
            string expected = Label2TextWith1Secs.Substring(0, lengthWitoutDecimals);
            string actual = TextOfLabelWithIndex(1).Substring(0, lengthWitoutDecimals);
            Assert.AreEqual(expected, actual);
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
            RaceSettings.QualificationMinutes = 1000;
            RaceSettings.QualificationBreaks = 0;
            RaceSettings.StartCountDownQualiActivated = false;
            RaceSettings.RestartCountDownQualiActivated = false;
        }


    }
}
