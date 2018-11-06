using System.Collections.Generic;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.PenaltyTests
{
    [TestFixture]
    public class PenaltyCountTest : BaseLapTest
    {
        [Test]
        public void TestAfterAddingOne()
        {
            StartRace();
            Assert.AreEqual(0, Lane1.PenaltyCount);
            RaceModel.AddPenaltyFor(Lane1.Id);
            Assert.AreEqual(1, Lane1.PenaltyCount);
        }

        [Test]
        public void TestAfterAddingOneAndPitstopShouldBeOne()
        {
            StartRace();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitSecondsForValidLap();
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.AreEqual(0, Lane1.PenaltyCount);
            RaceModel.AddPenaltyFor(Lane1.Id);
            Assert.AreEqual(1, Lane1.PenaltyCount);
            MockRaceDataProvider.RaisePitstopInForLane(Lane1.Id);

            WaitSeconds(3);
            Assert.AreEqual(0, Lane1.PenaltyQueue.Count);
            Assert.AreEqual(1, Lane1.PenaltyCount);
        }

        [Test]
        public void TestAfterAddingOneUndoPenaltyShouldBeZero()
        {
            StartRace();
            Assert.AreEqual(0, Lane1.PenaltyCount);
            RaceModel.AddPenaltyFor(Lane1.Id);
            Assert.AreEqual(1, Lane1.PenaltyCount);
            RaceModel.UndoPenaltyFor(Lane1.Id);
            Assert.AreEqual(0, Lane1.PenaltyQueue.Count);
            Assert.AreEqual(0, Lane1.PenaltyCount);
        }

        [Test]
        public void TestAfterAddingThree()
        {
            StartRace();
            Assert.AreEqual(0, Lane1.PenaltyCount);
            RaceModel.AddPenaltyFor(Lane1.Id);
            Assert.AreEqual(1, Lane1.PenaltyCount);
            RaceModel.AddPenaltyFor(Lane1.Id);
            Assert.AreEqual(2, Lane1.PenaltyCount);
            RaceModel.AddPenaltyFor(Lane1.Id);
            Assert.AreEqual(3, Lane1.PenaltyCount);
        }

        [Test]
        public void TestAfterFalseStart()
        {
            RaceSettings.StartCountDownRaceActivated = true;
            StartRace();
            Assert.AreEqual(0, Lane1.PenaltyCount);
            uint speed = RaceDataProvider.SpeedToDetectFalseStart;
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, speed, new List<uint> { speed });
            Assert.AreEqual(1, Lane1.PenaltyCount);
        }

        [Test]
        public void TestAfterFalseStartAndAddingOne()
        {
            RaceSettings.StartCountDownRaceActivated = true;
            StartRace();
            Assert.AreEqual(0, Lane1.PenaltyCount);
            uint speed = RaceDataProvider.SpeedToDetectFalseStart;
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, speed, new List<uint> { speed });
            Assert.AreEqual(1, Lane1.PenaltyCount);
            RaceModel.AddPenaltyFor(Lane1.Id);
            Assert.AreEqual(2, Lane1.PenaltyCount);
        }

        protected override void InitRaceSettings()
        {
            base.InitRaceSettings();
            RaceSettings.RefuelingAfterServingPenaltyAllowed = false;
        }

    }
}
