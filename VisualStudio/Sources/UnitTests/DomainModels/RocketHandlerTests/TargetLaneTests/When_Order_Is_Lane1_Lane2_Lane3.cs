using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RocketHandlerTests.TargetLaneTests
{
    [TestFixture]
    public class When_Order_Is_Lane1_Lane2_Lane3 : RocketHandlerTest
    {
        [Test]
        public void Then_TargetLane_Of_Lane1_Should_Be_Lane3()
        {
            AddMinLapForeachLane();

            Assert.AreEqual(Lane3.Id, Lane1.RocketLaneData.TargetLaneId);
        }

        [Test]
        public void Then_TargetLane_Of_Lane2_Should_Be_Lane1()
        {
            AddMinLapForeachLane();

            Assert.AreEqual(Lane1.Id, Lane2.RocketLaneData.TargetLaneId);
        }

        [Test]
        public void Then_TargetLane_Of_Lane3_Should_Be_Lane2()
        {
            AddMinLapForeachLane();

            Assert.AreEqual(Lane2.Id, Lane3.RocketLaneData.TargetLaneId);
        }


    }
}
