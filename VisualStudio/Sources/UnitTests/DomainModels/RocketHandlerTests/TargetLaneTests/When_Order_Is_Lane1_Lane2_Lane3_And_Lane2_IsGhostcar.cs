using Elreg.BusinessObjects;
using Elreg.GhostCarService;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RocketHandlerTests.TargetLaneTests
{
    [TestFixture]
    public class When_Order_Is_Lane1_Lane2_Lane3_And_Lane2_IsGhostcar : RocketHandlerTest
    {
        [Test]
        public void Then_TargetLane_Of_Lane1_Should_Be_Lane3()
        {
            AddMinLapForeachLane();

            Assert.AreEqual(Lane3, Lane1.RocketLaneData.TargetLaneId);
        }

        [Test]
        public void Then_TargetLane_Of_Lane2_Should_Be_Null()
        {
            AddMinLapForeachLane();

            Assert.IsNull(Lane2.RocketLaneData.TargetLaneId);
        }

        [Test]
        public void Then_TargetLane_Of_Lane3_Should_Be_Lane1()
        {
            AddMinLapForeachLane();

            Assert.AreEqual(Lane1, Lane3.RocketLaneData.TargetLaneId);
        }

        protected override GhostcarsService GhostcarsService
        {
            get
            {
                GhostcarsService ghostcarsService = new GhostcarsService { IsActivated = true };
                ghostcarsService.GhostcarsOptions.RaceParticipation = true;
                return ghostcarsService;
            }
        }

        protected override Driver NewDriver2
        {
            get 
            {
                Driver driver = base.NewDriver2;
                driver.IsGhostcar = true;
                return driver;
            }
        }



    }
}
