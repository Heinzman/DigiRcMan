using System.Collections.Generic;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.FalseStartTests
{
    [TestFixture]
    public class FalseStartTest : BaseLapTest
    {
        [Test]
        public void TestCountDownCurrentSpeedIsSpeedToDetectFalseStart()
        {
            StartRace();
            Assert.IsNull(Lane1.LastFalseStartDateTime);
            uint speed = RaceDataProvider.SpeedToDetectFalseStart;
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, speed, new List<uint> { speed });
            Assert.IsNotNull(Lane1.LastFalseStartDateTime);
        }

        [Test]
        public void TestCountDownCurrentSpeedIsLessThanSpeedToDetectFalseStartShouldNotBeDetected()
        {
            StartRace();
            Assert.IsNull(Lane1.LastFalseStartDateTime);
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 1, new List<uint> { 1 });
            Assert.IsNull(Lane1.LastFalseStartDateTime);
        }

        protected override void InitRaceSettings()
        {
            base.InitRaceSettings();
            RaceSettings.StartCountDownRaceActivated = true;
        }
    }
}
