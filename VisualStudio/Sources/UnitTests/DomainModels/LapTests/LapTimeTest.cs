using System;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests
{
    [TestFixture]
    public class LapTimeTest : BaseLapTest
    {
        [Test]
        public void TestLapTime()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.LapTimeNet >= ExpectedMinTimeSpanForALap() && Lane1.LapTimeNet <= ExpectedMaxTimeSpanForALap());
        }

        [Test]
        public void TestLapTimeNormalPauseShouldNotBecontained()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            RaceModel.PauseRaceByKeyboard();
            WaitSecondsForValidLap();
            WaitSecondsForValidLap();
            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.LapTimeNet >= ExpectedMinTimeSpanForALap() && Lane1.LapTimeNet <= ExpectedMaxTimeSpanForALap());
        }

        [Test]
        public void TestLapTimeAfterAutoDetectedLapShouldBeNull()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLap();
            Assert.IsNull(Lane1.LapTime);
            Assert.IsNull(Lane1.LapTimeNet);
        }

        [Test]
        public void TestLapTimeAfterRegularLapAfterAutoDetectedLapShouldBeNull()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsNull(Lane1.LapTime);
            Assert.IsNull(Lane1.LapTimeNet);
        }

        [Test]
        public void TestLapTimeAfterRegularLapAfterRegularLapAfterAutoDetectedLapShouldNotBeNull()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            AddRegularLapAndWaitValidSeconds();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsNotNull(Lane1.LapTime);
            Assert.IsNotNull(Lane1.LapTimeNet);
        }

        private TimeSpan ExpectedMinTimeSpanForALap()
        {
            int seconds = RaceSettings.SecondsForValidLap;
            return new TimeSpan(0, 0, seconds);
        }

        private TimeSpan ExpectedMaxTimeSpanForALap()
        {
            const int fairnessSeconds = 1;
            int seconds = RaceSettings.SecondsForValidLap + fairnessSeconds;
            return new TimeSpan(0, 0, seconds);
        }
    }
}
