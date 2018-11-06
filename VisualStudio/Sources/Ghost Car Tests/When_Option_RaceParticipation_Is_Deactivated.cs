using Elreg.BusinessObjects.Lanes;
using NUnit.Framework;

namespace Elreg.UnitTests.GhostCar
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Option_RaceParticipation_Is_Deactivated : GhostBaseTest
    {
        [SetUp]
        public void Initialize()
        {
            InitGhostCarRace();
            RaceModel.StartRaceCheckCountDown();
        }

        [Test]
        public void Lane_in_Race_Should_not_be_found()
        {
            MockGhostCarSerialPortParser.AddLapFor(LaneIdOfGhostcarA);
            Lane lane = RaceModel.RaceHandler.GetLaneById(LaneIdOfGhostcarA);
            Assert.IsNull(lane);
        }

        protected override void InitGhostcarsService()
        {
            base.InitGhostcarsService();
            GhostcarsService.GhostcarsOptions.RaceParticipation = false;
        }

    }
}
