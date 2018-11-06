using System;
using System.Collections.Generic;
using Elreg.HelperClasses;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.SpeedSumTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_CarConsumed1Liter : BaseLapTest
    {
        [Test]
        public void SpeedSum_Should_Be_1()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 1, new List<uint> { 1 });
            Assert.IsTrue(Math.Abs(Lane1.SpeedSum - 1) < SystemHelper.Epsilon);
        }
    }
    // ReSharper restore InconsistentNaming
}
