using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.FirstLapDetectionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_First_Lap_Was_Detected_After_Normal_Zeroth_Lap : BaseLapTest
    {
        [Test]
        public void Lap_Should_Be_Counted_After_Min_Secs()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.AreEqual(0, Lane1.Lap);
            WaitSecondsForValidLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.AreEqual(1, Lane1.Lap);
        }
    }
}
