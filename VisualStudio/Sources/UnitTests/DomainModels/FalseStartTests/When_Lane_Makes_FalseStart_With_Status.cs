using System.Collections.Generic;
using Elreg.BusinessObjects.Lanes;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.FalseStartTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Lane_Makes_FalseStart_With_Status : BaseLapTest
    {
        [Test]
        public void Is_Disqualified_Then_Penalty_Must_not_be_Added()
        {
            MakeFalseStartWith(Lane.LaneStatusEnum.Disqualified);
            Assert.AreEqual(0, Lane1.PenaltyCount);
        }

        [Test]
        public void Is_Finished_Then_Penalty_Must_not_be_Added()
        {
            MakeFalseStartWith(Lane.LaneStatusEnum.Finished);
            Assert.AreEqual(0, Lane1.PenaltyCount);
        }

        [Test]
        public void Is_Started_Then_Penalty_Should_be_Added()
        {
            MakeFalseStartWith(Lane.LaneStatusEnum.Started);
            Assert.AreEqual(1, Lane1.PenaltyCount);
        }

        private void MakeFalseStartWith(Lane.LaneStatusEnum status)
        {
            StartRace();
            Lane1.Status = status;
            Assert.AreEqual(0, Lane1.PenaltyCount);
            uint speed = RaceDataProvider.SpeedToDetectFalseStart;
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, speed, new List<uint> {speed});
        }

        protected override void InitRaceSettings()
        {
            base.InitRaceSettings();
            RaceSettings.StartCountDownRaceActivated = true;
        }
    }
}
