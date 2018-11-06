using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.ModifyRaceDataByAdminTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Penalty_is_removed : BaseLapTest
    {
        [Test]
        public void And_Was_Disqualified_By_Penalties_Then_Status_should_be_Started()
        {
            StartRace();
            for (int i = 0; i < RaceSettings.AutoDisqualificationRaceAfterPenalties; i++)
                RaceModel.AddPenaltyFor(Lane1.Id);
            Assert.AreEqual(RaceSettings.AutoDisqualificationRaceAfterPenalties, Lane1.ActivePenalties);
            Assert.IsTrue(Lane1.IsDisqualified);

            RaceModel.UndoPenaltyFor(LaneId.Lane1);
            Assert.AreEqual(RaceSettings.AutoDisqualificationRaceAfterPenalties - 1, Lane1.ActivePenalties);
            Assert.IsTrue(Lane1.IsStarted);
        }

        [Test]
        public void And_Was_Disqualified_Not_by_Penalties_Then_Status_should_stay()
        {
            StartRace();
            RaceModel.AddPenaltyFor(Lane1.Id);
            Lane1.Status = Lane.LaneStatusEnum.Disqualified;
            Assert.AreEqual(1, Lane1.ActivePenalties);
            Assert.IsTrue(Lane1.IsDisqualified);

            RaceModel.UndoPenaltyFor(LaneId.Lane1);
            Assert.AreEqual(1, Lane1.ActivePenalties);
            Assert.IsTrue(Lane1.IsDisqualified);
        }

        protected override void InitRaceSettings()
        {
            base.InitRaceSettings();
            RaceSettings.AutoDisqualificationRaceActivated = true;
            RaceSettings.AutoDisqualificationRaceAfterPenalties = 3;
        }
    }
    // ReSharper restore InconsistentNaming
}
