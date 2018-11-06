using Elreg.BusinessObjects.Lanes;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests
{
    [TestFixture]
    public class LapDetectionInCountdownTest : BaseLapTest
    {
        [Test]
        public void TestLapIsCountedInStartCountDown()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == 0);
            Assert.IsTrue(Lane1.Status == Lane.LaneStatusEnum.Undefined);
            WaitSecondsForCountDownFinished();
            Assert.IsTrue(Lane1.Status == Lane.LaneStatusEnum.Started);
        }

        [Test]
        public void TestLapIsCountedInRestartCountDown()
        {
            StartRace();
            WaitSecondsForCountDownFinished();
            RaceModel.PauseRaceByKeyboard();
            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
            WaitSomeMilliSeconds();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == 0);
        }

        [Test]
        public void TestLapIsCountedInStartAndRestartCountDown()
        {
            StartRace();
            WaitSecondsForCountDownFinished();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == 0);
            WaitSecondsForValidLap();
            RaceModel.PauseRaceByKeyboard();
            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.AreEqual(1, Lane1.Lap);
        }

        protected override void InitRaceSettings()
        {
            base.InitRaceSettings();
            RaceSettings.StartCountDownRaceActivated = true;
            RaceSettings.StartCountDownRaceInitNo = 1;
            RaceSettings.RestartCountDownRaceActivated = true;
            RaceSettings.RestartCountDownRaceInitNo = 1;
        }

    }
}
