﻿using Elreg.BusinessObjects.Races;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.AutoDetectTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Zeroth_Lap_Was_AutoDetected_In_Training : BaseAutoDetectLapTest
    {
        [Test]
        public void Lap_Must_Not_Be_Counted()
        {
            ForceZerothAutoDetectedLapForLane3For(Race.TypeEnum.Training);
            Assert.AreEqual(-1, Lane3.Lap);
        }
    }
}
