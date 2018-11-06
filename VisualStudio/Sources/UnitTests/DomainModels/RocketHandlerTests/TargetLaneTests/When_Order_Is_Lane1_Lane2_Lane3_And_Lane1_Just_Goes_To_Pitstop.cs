using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RocketHandlerTests.TargetLaneTests
{
    [TestFixture]
    public class When_Order_Is_Lane1_Lane2_Lane3_And_Lane1_Just_Goes_To_Pitstop : RocketHandlerTest
    {
        [Test]
        public void Then_TargetLane_Of_Lane1_Should_Be_Null()
        {
            AddMinLapForeachLaneWithJustInTheMomentPitstopForLane1();

            Assert.IsNull(Lane1.RocketLaneData.TargetLaneId);
        }

        [Test]
        public void Then_TargetLane_Of_Lane2_Should_Be_Null()
        {
            AddMinLapForeachLaneWithJustInTheMomentPitstopForLane1();

            WaitSeconds(2);
            Assert.IsNull(Lane2.RocketLaneData.TargetLaneId);
        }

        [Test]
        public void Then_TargetLane_Of_Lane3_Should_Be_Lane2()
        {
            AddMinLapForeachLaneWithJustInTheMomentPitstopForLane1();

            Assert.AreEqual(Lane2.Id, Lane3.RocketLaneData.TargetLaneId);
        }

        private void AddMinLapForeachLaneWithJustInTheMomentPitstopForLane1()
        {
            AddMinLapForeachLane();
            MockRaceDataProvider.RaiseAddLapForLane(LaneId.Lane1);
            RaceModel.HandlePitInFor(LaneId.Lane1);
        }
    }
}
