using System;
using System.Collections.Generic;
using Elreg.HelperClasses;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.AutoDetectTests
{
    [TestFixture]
    public class AutoDetectLapTestWithMockSpeedSumCalc : BaseLapTest
    {
        [Test]
        public void TestAutoDetectedLapWithoutFirstRegularLapShouldNotBeCounted()
        {
            StartRace();
            AutoDetectLap();
            Assert.IsTrue(Lane1.Lap == -1);
        }

        [Test]
        public void TestAutoDetectedLapAfterFirstManuallyAddedLapShouldNotBeCounted()
        {
            StartRace();
            RaceModel.AddLapManuallyFor(Lane1.Id);
            AutoDetectLap();
            Assert.IsTrue(Lane1.Lap == 0);
        }

        [Test]
        public void TestAutoDetectedLapAfterFirstRegularLap()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLap();
            Assert.IsTrue(Lane1.Lap == 1);
        }

        [Test]
        public void TestRegularLapIsRecognizedAfterOneAutoDetectedLap()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == 2);
        }

        [Test]
        public void TestRegularLapIsRecognizedAfterTwoAutoDetectedLap()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == 3);
        }

        [Test]
        public void TestSeveralAutoDetectedLapsShouldCountedMaxTwo()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            Assert.IsTrue(Lane1.Lap == 2);
        }

        [Test]
        public void TestThreeAutoDetectedLapsShouldCountedMaxTwo()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            AutoDetectLapAndWaitValidSeconds();
            Assert.IsTrue(Lane1.Lap == 2);
        }

        [Test]
        public void TestRegularLapIsNotValidImmediatlyAfterAutoDetectedLap()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Lane1.Lap == 1);
        }

        [Test]
        public void TestAfterInvalidLapAfterAutoDetectedLapSpeedSumShouldBeZero()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLap();
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 2, new List<uint> { 2 });
            Assert.IsTrue(Lane1.SpeedSum > 0);
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsTrue(Math.Abs(Lane1.SpeedSum - 0) < SystemHelper.Epsilon);
        }

    }
}
