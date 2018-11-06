using Elreg.BusinessObjects.Lanes;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RocketHandlerTests
{
    [TestFixture]
    public class When_Race_IsInitialized : RocketHandlerTest
    {
        [Test]
        public void RocketData_of_all_Lanes_Should_Have_DefaultValues()
        {
            RaceModel.StopRace();
            RaceModel.InitRace();

            foreach (Lane lane in RaceModel.Race.Lanes)
            {
                Assert.IsFalse(lane.RocketLaneData.IsDamaged);
                Assert.IsFalse(lane.RocketLaneData.IsJustAttacked);
                Assert.IsFalse(lane.RocketLaneData.IsJustDefending);
                Assert.IsFalse(lane.RocketLaneData.IsJustAttacking);
                Assert.IsNull(lane.RocketLaneData.TargetLaneId);
                Assert.IsNull(lane.RocketLaneData.TargetLaneIdAtAttackingStart);
            }
        }
    }
}
