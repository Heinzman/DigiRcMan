using System;
using System.Collections.Generic;
using Elreg.HelperClasses;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.SpeedSumTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_RaceIsStartedAgain_After_Race : BaseLapTest
    {
        [Test]
        public void SpeedSum_Should_Be_Zero()
        {
            StartRace();
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 5, new List<uint> { 5 });
            WaitSomeMilliSeconds();
            Assert.IsTrue(Math.Abs(Lane1.SpeedSum - 0) > SystemHelper.Epsilon);
            RaceModel.StopRace();
            RaceModel.RaceHandler.ResetLanes();
            RaceModel.StartRaceCheckCountDown();
            Assert.IsTrue(Math.Abs(Lane1.SpeedSum - 0) < SystemHelper.Epsilon);
        }
    }
    // ReSharper restore InconsistentNaming
}
