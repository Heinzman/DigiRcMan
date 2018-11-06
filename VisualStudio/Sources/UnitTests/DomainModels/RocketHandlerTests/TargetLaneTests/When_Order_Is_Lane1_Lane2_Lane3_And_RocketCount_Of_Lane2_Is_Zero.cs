using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RocketHandlerTests.TargetLaneTests
{
    [TestFixture]
    public class When_Order_Is_Lane1_Lane2_Lane3_And_RocketCount_Of_Lane2_Is_Zero : RocketHandlerTest
    {
        [Test]
        public void Then_TargetLane_Of_Lane1_Should_Be_Lane3()
        {
            Lane2.RocketLaneData.RocketsCount = 0;
            AddMinLapForeachLane();

            Assert.AreEqual(Lane3, Lane1.RocketLaneData.TargetLaneId);
        }

        [Test]
        public void Then_TargetLane_Of_Lane2_Should_Be_Null()
        {
            Lane2.RocketLaneData.RocketsCount = 0;
            AddMinLapForeachLane();

            Assert.IsNull(Lane2.RocketLaneData.TargetLaneId);
        }

        [Test]
        public void Then_TargetLane_Of_Lane3_Should_Be_Lane1()
        {
            Lane2.RocketLaneData.RocketsCount = 0;
            AddMinLapForeachLane();

            Assert.AreEqual(Lane2, Lane3.RocketLaneData.TargetLaneId);
        }

    }
}
