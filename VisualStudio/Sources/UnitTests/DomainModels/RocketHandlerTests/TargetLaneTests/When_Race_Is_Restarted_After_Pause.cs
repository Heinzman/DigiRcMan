using Elreg.BusinessObjects;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.RocketHandlerTests.TargetLaneTests
{
    [TestFixture]
    public class When_Race_Is_Restarted_After_Pause : RocketHandlerTest
    {
        private LaneId? _targetLaneIdOfLane1;
        private LaneId? _targetLaneIdOfLane2;
        private LaneId? _targetLaneIdOfLane3;

        [Test]
        public void Then_TargetLane_Of_All_Lanes_Should_Be_Null_First()
        {
            AddMinLapForeachLane();
            AssertAllTagetLanesAreNotNull();

            RaceModel.PauseRaceByKeyboard();
            AssertAllTagetLanesAreNotNull();

            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();

            AssertAllTagetLanesAreNull();
        }

        [Test]
        public void Then_TargetLane_Of_All_Lanes_Should_Be_Set_With_Previous_Values()
        {
            AddMinLapForeachLane();
            _targetLaneIdOfLane1 = Lane1.RocketLaneData.TargetLaneId;
            _targetLaneIdOfLane2 = Lane2.RocketLaneData.TargetLaneId;
            _targetLaneIdOfLane3 = Lane3.RocketLaneData.TargetLaneId;

            RaceModel.PauseRaceByKeyboard();
            AssertAllTagetLanesAreNotNull();

            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();

            AssertAllTagetLanesAreNull();
            WaitSeconds(4);

            AssertAllTagetLanesAreNotNull();
            Assert.AreSame(_targetLaneIdOfLane1, Lane1.RocketLaneData.TargetLaneId);
            Assert.AreSame(_targetLaneIdOfLane2, Lane2.RocketLaneData.TargetLaneId);
            Assert.AreSame(_targetLaneIdOfLane3, Lane3.RocketLaneData.TargetLaneId);
        }

        private void AssertAllTagetLanesAreNull()
        {
            Assert.IsNull(Lane1.RocketLaneData.TargetLaneId);
            Assert.IsNull(Lane2.RocketLaneData.TargetLaneId);
            Assert.IsNull(Lane3.RocketLaneData.TargetLaneId);
        }

        private void AssertAllTagetLanesAreNotNull()
        {
            Assert.IsNotNull(Lane1.RocketLaneData.TargetLaneId);
            Assert.IsNotNull(Lane2.RocketLaneData.TargetLaneId);
            Assert.IsNotNull(Lane3.RocketLaneData.TargetLaneId);
        }
    }
}
