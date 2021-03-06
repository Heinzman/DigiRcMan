﻿using System;
using System.Collections.Generic;
using Elreg.HelperClasses;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.SpeedSumTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_InvalidLapIsAddedDueNoFuel : BaseLapTest
    {
        [Test]
        public void SpeedSum_Should_Be_Resetted2Zero()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 5, new List<uint> { 5 });
            Lane1.AddFuelInLitres(-100);
            AddRegularLapAndWaitValidSeconds();
            Assert.IsTrue(Math.Abs(Lane1.SpeedSum - 0.0) < SystemHelper.Epsilon);
        }
    }
    // ReSharper restore InconsistentNaming
}
