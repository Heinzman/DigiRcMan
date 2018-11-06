using Elreg.BusinessObjects.Races;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.PitInDetectionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_ButtonIsPressed_While_StartCountDown : PitInDetectionTest
    {
        [Test]
        public void PitIn_Must_Not_Be_Detected_After_CountDown()
        {
            RaceSettings.StartCountDownRaceActivated = true;
            InitAndStartRace();
            Assert.AreEqual(Race.StatusEnum.StartCountDown, RaceModel.Race.Status);
            Assert.IsFalse(Lane1.IsInPitstop);
            MockControllerDataSupplier.SetCarControllersActionFor(Lane1.Id, 0, true);
            WaitSecondsForCountDownFinished();
            Assert.AreEqual(Race.StatusEnum.Started, RaceModel.Race.Status);
            WaitSecondsForPitstopInDetection();
            Assert.IsFalse(Lane1.IsInPitstop);
        }
    }
    // ReSharper restore InconsistentNaming

}
