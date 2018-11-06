using Elreg.BusinessObjects.Lanes;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.DisqualificationTests
{
    [TestFixture]
    public class DisqualificationAfterMultiplePenaltiesTest : BaseLapTest
    {
        [Test]
        public void TestAutoDisqualificationRaceNotActivatedSoMultiplePenaltiesDoNotMatter()
        {
            RaceSettings.AutoDisqualificationRaceActivated = false;
            StartRace();
            for (int i = 0; i < RaceSettings.AutoDisqualificationRaceAfterPenalties * 2; i++)
            {
                RaceModel.AddPenaltyFor(Lane1.Id);
                Assert.IsTrue(Lane1.Status == Lane.LaneStatusEnum.Started);
            }
        }

        [Test]
        public void TestAfterSpecificPenaltiesShouldLaneBeDisqualified()
        {
            StartRace();
            for (int i = 1; i < RaceSettings.AutoDisqualificationRaceAfterPenalties; i++)
            {
                RaceModel.AddPenaltyFor(Lane1.Id);
                Assert.IsTrue(Lane1.Status == Lane.LaneStatusEnum.Started);
            }
            RaceModel.AddPenaltyFor(Lane1.Id);
            Assert.IsTrue(Lane1.Status == Lane.LaneStatusEnum.Disqualified);
        }

        protected override void InitRaceSettings()
        {
            base.InitRaceSettings();
            RaceSettings.AutoDisqualificationRaceActivated = true;
            RaceSettings.AutoDisqualificationRaceAfterPenalties = 4;
        }

    }
}
