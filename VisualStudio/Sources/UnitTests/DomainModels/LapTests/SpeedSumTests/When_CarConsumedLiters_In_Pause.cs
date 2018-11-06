using System;
using System.Collections.Generic;
using Elreg.HelperClasses;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.SpeedSumTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_CarConsumedLiters_In_Pause : BaseLapTest
    {
        [Test]
        public void SpeedSum_Should_Be_Zero()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 1, new List<uint> { 1 });
            WaitSecondsForValidLap();
            Assert.IsTrue(Math.Abs(Lane1.SpeedSum - 1) < SystemHelper.Epsilon);
            RaceModel.PauseRaceByKeyboard();
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 5, new List<uint> { 5 });
            WaitSomeMilliSeconds();
            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
            Assert.AreEqual(Lane1.SpeedSum, 0);
        }
    }
}
