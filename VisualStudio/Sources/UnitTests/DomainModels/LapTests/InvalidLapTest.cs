using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests
{
    [TestFixture]
    public class InvalidLapTest : BaseLapTest
    {
        [Test]
        public void TestInvalidLapShouldNotBeCounted()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            int laps = Lane1.Lap;
            WaitSecondsForInvalidLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == laps);
        }

        [Test]
        public void TestValidLapAfterInvalidLapShouldBeCounted()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitSecondsForInvalidLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            int laps = Lane1.Lap;
            WaitSecondsForValidLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == laps + 1);
        }

        [Test]
        public void TestValidLapAfterInvalidLapAfterAutoDetectedLapShouldBeCounted()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == 0);
            WaitSecondsForValidLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == 1);
            WaitSecondsForValidLap();
            AutoDetectLap();
            Assert.IsTrue(Lane1.Lap == 2);
            WaitSecondsForInvalidLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == 2);
            WaitSecondsForValidLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == 3);
        }

    }
}
