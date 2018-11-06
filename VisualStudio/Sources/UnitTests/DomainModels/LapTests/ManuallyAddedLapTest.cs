using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests
{
    [TestFixture]
    public class ManuallyAddedLapTest : BaseLapTest
    {
        [Test]
        public void TestManuallyAddedLapInstantlyAfterValidLapAddedShouldBeCounted()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            int laps = Lane1.Lap;
            RaceModel.AddLapManuallyFor(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == laps+1);
        }

        [Test]
        public void TestManuallyAddedLapAfterValidLapAddedWaitMinSecsShouldBeCounted()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            int laps = Lane1.Lap;
            RaceModel.AddLapManuallyFor(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == laps + 1);
        }

        [Test]
        public void TestValidLapInstantlyAfterManuallyAddedLapShouldBeCounted()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            int laps = Lane1.Lap;
            RaceModel.AddLapManuallyFor(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == laps + 2);
        }

        [Test]
        public void TestManuallyAddedLapInstantlyAfterInvalidLapAddedShouldBeCounted()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            int laps = Lane1.Lap;
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id); // Invalid due min secs
            RaceModel.AddLapManuallyFor(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == laps + 1);
        }

        [Test]
        public void TestInvalidLapInstantlyAfterManuallyAddedLapShouldNotBeCounted()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            int laps = Lane1.Lap;
            RaceModel.AddLapManuallyFor(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);  // Invalid due min secs
            Assert.IsTrue(Lane1.Lap == laps + 1);
        }

        [Test]
        public void TestManuallyAddedLapInstantlyAfterAutoDetectedLapShouldBeCounted()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            int laps = Lane1.Lap;
            AutoDetectLap();
            RaceModel.AddLapManuallyFor(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == laps + 2);
        }

        [Test]
        public void TestAutoDetectedLapInstantlyAfterManuallyAddedLapShouldBeCounted()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            int laps = Lane1.Lap;
            RaceModel.AddLapManuallyFor(Lane1.Id);
            AutoDetectLap();
            Assert.IsTrue(Lane1.Lap == laps + 2);
        }


    }
}
