using System;
using System.Collections.Generic;
using Elreg.HelperClasses;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.SpeedSumTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_RaceIsPaused : BaseLapTest
    {
        [Test]
        public void All_SpeedSums_Should_Be_Resetted2Zero()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseAddLapForLane(Lane2.Id);
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane2.Id, 10, new List<uint> { 10 });
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 5, new List<uint> { 5 });
            WaitSecondsForValidLap();
            RaceModel.PauseRaceByKeyboard();
            Assert.IsTrue(Math.Abs(Lane1.SpeedSum - 0.0) < SystemHelper.Epsilon);
            Assert.IsTrue(Math.Abs(Lane2.SpeedSum - 0.0) < SystemHelper.Epsilon);
        }
    }
}
