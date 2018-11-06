using Elreg.BusinessObjects.Races;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.AutoDetectTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_ZerothAutoDetected_Then_LapDetected : BaseAutoDetectLapTest
    {
        [Test]
        public void Lap_Should_Be_Counted_After_SecondsForValidLap_Div_2()
        {
            ForceZerothAutoDetectedLapForLane3For(Race.TypeEnum.Race);
            Assert.AreEqual(0, Lane3.Lap);
            int milliSecsForValidLapDiv2 = 1000 * RaceSettings.SecondsForValidLap / 2;
            WaitMilliSeconds(milliSecsForValidLapDiv2);
            MockRaceDataProvider.RaiseAddLapForLane(Lane3.Id);
            Assert.AreEqual(1, Lane3.Lap);
        }

        [Test]
        public void Lap_Must_Not_Be_Counted_Before_SecondsForValidLap_Div_2()
        {
            ForceZerothAutoDetectedLapForLane3For(Race.TypeEnum.Race);
            Assert.AreEqual(0, Lane3.Lap);
            int milliSecsForValidLapDiv2 = 1000 * RaceSettings.SecondsForValidLap / 4;
            WaitMilliSeconds(milliSecsForValidLapDiv2);
            MockRaceDataProvider.RaiseAddLapForLane(Lane3.Id);
            Assert.AreEqual(0, Lane3.Lap);
        }

        [Test]
        public void Lap_Must_Not_Be_Counted_Before_SecondsForValidLap_Div_2_But_Next_Lap()
        {
            Lap_Must_Not_Be_Counted_Before_SecondsForValidLap_Div_2();
            WaitSecondsForValidLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane3.Id);
            Assert.AreEqual(1, Lane3.Lap);
        }
    }
}
