using System;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests
{
    [TestFixture]
    public class ExactLapTimeTest : BaseLapTest
    {
        [Test]
        public void TestLapTimeNet()
        {
            StartRace();
            DateTime timeStampLap0 = new DateTime(2011, 1, 1, 0, 0, 0);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id, timeStampLap0);
            DateTime timeStampLap1 = new DateTime(2011, 1, 1, 0, 0, 7);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id, timeStampLap1);
            TimeSpan? expected = timeStampLap1 - timeStampLap0;
            TimeSpan? actual = Lane1.LapTime;
            Assert.AreEqual(expected, actual);
        }

    }
}
