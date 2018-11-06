using Elreg.BusinessObjects.Lanes;
using NUnit.Framework;

namespace Elreg.UnitTests.GhostCar
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Option_RaceParticipation_Is_Activated : GhostBaseTest
    {
        [SetUp]
        public void Initialize()
        {
            InitGhostCarRace();
            RaceModel.StartRaceCheckCountDown();
        }

        [Test]
        public void Lap_of_Ghostcar_Should_Be_Counted()
        {
            MockRaceDataProvider.RaiseAddLapForLane(LaneIdOfGhostcarA);
            Lane lane = RaceModel.RaceHandler.GetLaneById(LaneIdOfGhostcarA);

            Assert.AreEqual(0, lane.Lap);
        }

        protected override void InitGhostcarsService()
        {
            base.InitGhostcarsService();
            GhostcarsService.GhostcarsOptions.RaceParticipation = true;
        }
    }
}
