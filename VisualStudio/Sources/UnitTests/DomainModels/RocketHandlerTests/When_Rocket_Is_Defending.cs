using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RocketHandlerTests
{
    [TestFixture]
    public class When_Rocket_Is_Defending : RocketHandlerTest
    {
        private bool _isEventRaised;
        private int _laneId;

        [Test]
        public void And_After_FlightTime_Then_Event_RocketExplodedDueDefending_Should_be_Raised()
        {
            RaceModel.RocketExplodedDueDefending += RaceModelRocketExplodedDueDefending;
            _isEventRaised = false;
            _laneId = -1;

            AddMinLapForeachLane();
            if (Lane1.RocketLaneData.TargetLaneId.HasValue)
            {
                Lane targetLane = RaceModel.RaceHandler.GetLaneById(Lane1.RocketLaneData.TargetLaneId.Value);
                RaceModel.RequestStartRocket(LaneId.Lane1);
                RaceModel.RequestStartRocket(targetLane.Id);
                WaitMilliSeconds((int) (CentralUnitOptionsService.Options.RocketSettings.MaxTargetDistanceInMs*1.2));
            }
            Assert.IsTrue(_isEventRaised);
            Assert.AreEqual((int)Lane1.Id, _laneId);
        }

        private void RaceModelRocketExplodedDueDefending(LaneId laneId)
        {
            _isEventRaised = true;
            _laneId = (int) laneId;
        }

    }
}
