using System.Reflection;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.DomainModels.RocketModel;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RocketHandlerTests
{
    [TestFixture]
    public class When_Laps_Less_Than_MinLapCount : RocketHandlerTest
    {
        [Test]
        public void And_Laps_Equal_Zero_Then_TargetLanes_Should_be_Null()
        {
            AddLapForeachLane();

            foreach (Lane lane in RaceModel.Race.Lanes)
            {
                Assert.IsNull(lane.RocketLaneData.TargetLaneId);
                Assert.IsNull(lane.RocketLaneData.TargetLaneIdAtAttackingStart);
            }
        }

        [Test]
        public void And_Laps_Equal_One_Then_TargetLanes_Should_be_Null()
        {
            AddLapForeachLane();
            AddLapForeachLane();

            foreach (Lane lane in RaceModel.Race.Lanes)
            {
                Assert.IsNull(lane.RocketLaneData.TargetLaneId);
                Assert.IsNull(lane.RocketLaneData.TargetLaneIdAtAttackingStart);
            }
        }

        [Test]
        public void Attacking_Should_Be_Possible()
        {
            for (int i = 0; i < MinLapCount + 1; i++)
                AddLapForeachLane();

            RaceModel.RequestStartRocket(LaneId.Lane1);
            Assert.IsTrue(Lane1.RocketLaneData.IsJustAttacking);
        }

    }
}
