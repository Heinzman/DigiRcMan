using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RocketHandlerTests
{
    [TestFixture]
    public class When_StartRocket_Is_Requested : RocketHandlerTest
    {
        [Test]
        public void RocketCount_Should_be_Decremented()
        {
            AddMinLapForeachLane();

            int rocketCount = Lane1.RocketLaneData.RocketsCount;
            RaceModel.RequestStartRocket(LaneId.Lane1);

            Assert.AreEqual(rocketCount - 1, Lane1.RocketLaneData.RocketsCount);
        }

        [Test]
        public void And_IsAttacked_Then_RocketCount_Should_be_Decremented()
        {
            AddMinLapForeachLane();

            int rocketCount = Lane1.RocketLaneData.RocketsCount;
            Lane1.RocketLaneData.IsJustAttacked = true;
            RaceModel.RequestStartRocket(LaneId.Lane1);

            Assert.AreEqual(rocketCount - 1, Lane1.RocketLaneData.RocketsCount);
        }

        [Test]
        public void And_IsAttacked_Then_IsJustDefending_should_be_set()
        {
            AddMinLapForeachLane();

            Lane1.RocketLaneData.IsJustAttacked = true;
            RaceModel.RequestStartRocket(LaneId.Lane1);

            Assert.IsTrue(Lane1.RocketLaneData.IsJustDefending);
        }

        [Test]
        public void And_RocketCount_Equal_Zero_Then_Nothing_Should_Happen()
        {
            AddMinLapForeachLane();

            Lane1.RocketLaneData.RocketsCount = 0;
            RaceModel.RequestStartRocket(LaneId.Lane1);

            Assert.AreEqual(0, Lane1.RocketLaneData.RocketsCount);
            Assert.IsFalse(Lane1.RocketLaneData.IsJustAttacking);
            Assert.IsFalse(Lane1.RocketLaneData.IsJustDefending);
        }

        [Test]
        public void And_IsJustAttacking_Then_Nothing_Should_Happen()
        {
            AddMinLapForeachLane();

            int rocketCount = Lane1.RocketLaneData.RocketsCount;
            Lane1.RocketLaneData.IsJustAttacking = true;
            RaceModel.RequestStartRocket(LaneId.Lane1);

            Assert.AreEqual(rocketCount, Lane1.RocketLaneData.RocketsCount);
        }

        [Test]
        public void And_IsJustDefending_Then_Nothing_Should_Happen()
        {
            AddMinLapForeachLane();

            int rocketCount = Lane1.RocketLaneData.RocketsCount;
            Lane1.RocketLaneData.IsJustDefending = true;
            RaceModel.RequestStartRocket(LaneId.Lane1);

            Assert.AreEqual(rocketCount, Lane1.RocketLaneData.RocketsCount);
        }

        [Test]
        public void And_IsDamaged_Then_Nothing_Should_Happen()
        {
            AddMinLapForeachLane();

            int rocketCount = Lane1.RocketLaneData.RocketsCount;
            Lane1.RocketLaneData.IsDamaged = true;
            RaceModel.RequestStartRocket(LaneId.Lane1);

            Assert.AreEqual(rocketCount, Lane1.RocketLaneData.RocketsCount);
        }

        [Test]
        public void IsJustAttacking_Should_Be_Set()
        {
            AddMinLapForeachLane();

            RaceModel.RequestStartRocket(LaneId.Lane1);
            Assert.IsTrue(Lane1.RocketLaneData.IsJustAttacking);
        }

        [Test]
        public void IsJustAttacked_of_TargetLane_Should_Be_Set()
        {
            AddMinLapForeachLane();

            RaceModel.RequestStartRocket(LaneId.Lane1);

            Lane targetLaneIdAtAttackingStart = null;
            if (Lane1.RocketLaneData.TargetLaneIdAtAttackingStart.HasValue)
                targetLaneIdAtAttackingStart = RaceModel.RaceHandler.GetLaneById(Lane1.RocketLaneData.TargetLaneIdAtAttackingStart.Value);

            Assert.IsNotNull(targetLaneIdAtAttackingStart);
            Assert.IsTrue(targetLaneIdAtAttackingStart.RocketLaneData.IsJustAttacked);
        }

        [Test]
        public void And_TargetLane_IsNull_Then_IsJustAttacking_Should_Be_Set()
        {
            AddMinLapForeachLane();

            Lane1.RocketLaneData.TargetLaneId = null;
            RaceModel.RequestStartRocket(LaneId.Lane1);

            Assert.IsTrue(Lane1.RocketLaneData.IsJustAttacking);
        }

        [Test]
        public void And_TargetLane_IsNull_Then_IsJustAttacked_ofeach_Lane_must_be_false()
        {
            AddMinLapForeachLane();

            Lane1.RocketLaneData.TargetLaneId = null;
            RaceModel.RequestStartRocket(LaneId.Lane1);

            foreach (Lane lane in RaceModel.Race.Lanes)
                Assert.IsFalse(lane.RocketLaneData.IsJustAttacked);
        }


    }
}
