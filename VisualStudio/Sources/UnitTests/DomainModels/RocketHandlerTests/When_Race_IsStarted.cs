using System.Reflection;
using Elreg.BusinessObjects.Lanes;
using Elreg.DomainModels.RocketModel;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RocketHandlerTests
{
    [TestFixture]
    public class When_Race_IsStarted : RocketHandlerTest
    {
        [Test]
        public void RocketData_of_all_Lanes_Should_Have_DefaultValues()
        {
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
        [Test]
        public void Rockets_of_all_Lanes_Should_Be_Loaded()
        {
            foreach (Lane lane in RaceModel.Race.Lanes)
                Assert.AreEqual(MaxRocketsCount, lane.RocketLaneData.RocketsCount);
        }

    }
}
