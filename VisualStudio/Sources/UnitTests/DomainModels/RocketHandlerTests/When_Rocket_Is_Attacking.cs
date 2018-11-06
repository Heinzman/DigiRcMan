using System.Collections.Generic;
using System.Reflection;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.DomainModels.RocketModel;
using Elreg.HelperClasses;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RocketHandlerTests
{
    [TestFixture]
    public class When_Rocket_Is_Attacking : RocketHandlerTest
    {
        private Dictionary<LaneId, PausableTimer> _rocketFlightTimers;
        private bool _isEventRaised;
        private int _laneId;

        [Test]
        public void Then_RocketFlightTimer_Should_Be_Started()
        {
            AddMinLapForeachLane();
            DetermineRocketFlightTimers();
            PausableTimer pausableTimer = GetRocketFlightTimerFor(LaneId.Lane1);
            Assert.IsFalse(pausableTimer.IsStarted);

            RaceModel.RequestStartRocket(LaneId.Lane1);

            Assert.IsTrue(pausableTimer.IsStarted);
        }

        [Test]
        public void And_TargetLane_Is_Null_Then_RocketFlightTimer_Should_Be_Started()
        {
            AddMinLapForeachLane();
            DetermineRocketFlightTimers();
            PausableTimer pausableTimer = GetRocketFlightTimerFor(LaneId.Lane1);
            Assert.IsFalse(pausableTimer.IsStarted);

            Lane1.RocketLaneData.TargetLaneId = null;
            RaceModel.RequestStartRocket(LaneId.Lane1);

            Assert.IsTrue(pausableTimer.IsStarted);
        }

        [Test]
        public void And_After_FlightTime_Then_Event_CarDamagedByRocket_Should_be_Raised()
        {
            RaceModel.CarDamagedByRocket += RaceModelCarDamagedByRocket;
            _isEventRaised = false;
            _laneId = -1;
            var targetLane = AttackAndWaitUntilDamaged();

            Assert.IsTrue(_isEventRaised);
            Assert.AreEqual((int)targetLane.Id, _laneId);
        }

        [Test]
        public void And_After_FlightTime_Then_TargetLane_Should_be_Set_To_Null()
        {
            AddMinLapForeachLane();
            Assert.IsFalse(Lane1.RocketLaneData.IsJustAttacking);
            Assert.IsNotNull(Lane1.RocketLaneData.TargetLaneId);
            AttackAndWaitUntilDamaged();

            Assert.IsNull(Lane1.RocketLaneData.TargetLaneId);
        }

        private void DetermineRocketFlightTimers()
        {
            FieldInfo fieldInfo = (typeof (RocketHandler)).GetField("_rocketFlightTimers", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
                _rocketFlightTimers = fieldInfo.GetValue(RocketHandler) as Dictionary<LaneId, PausableTimer>;
        }

        private void RaceModelCarDamagedByRocket(LaneId laneId)
        {
            _isEventRaised = true;
            _laneId = (int) laneId;
        }

        private Lane AttackAndWaitUntilDamaged()
        {
            AddMinLapForeachLane();

            Lane targetLane = null;
            if (Lane1.RocketLaneData.TargetLaneId.HasValue)
            {
                targetLane = RaceModel.RaceHandler.GetLaneById(Lane1.RocketLaneData.TargetLaneId.Value);
                RaceModel.RequestStartRocket(LaneId.Lane1);
                Assert.IsFalse(targetLane.RocketLaneData.IsDamaged);
                WaitMilliSeconds((int) (CentralUnitOptionsService.Options.RocketSettings.MaxTargetDistanceInMs*1.5));
            }
            return targetLane;
        }

        private PausableTimer GetRocketFlightTimerFor(LaneId laneId)
        {
            PausableTimer rocketFlightTimer;
            _rocketFlightTimers.TryGetValue(laneId, out rocketFlightTimer);
            return rocketFlightTimer;
        }

    }
}
