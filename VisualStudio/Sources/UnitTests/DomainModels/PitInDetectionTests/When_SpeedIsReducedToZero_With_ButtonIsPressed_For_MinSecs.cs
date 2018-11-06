using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.PitInDetectionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_SpeedIsReducedToZero_With_ButtonIsPressed_For_MinSecs : PitInDetectionTest
    {
        [Test]
        public void PitIn_Must_Not_Be_Detected()
        {
            StartTraceLogging();
            InitAndStartRace();
            WaitSomeMilliSeconds();
            Assert.IsFalse(Lane1.IsInPitstop);
            MockControllerDataSupplier.SetCarControllersActionFor(Lane1.Id, 3, true);
            Assert.IsFalse(Lane1.IsInPitstop);
            WaitSeconds(2);
            Assert.IsFalse(Lane1.IsInPitstop);
            MockControllerDataSupplier.SetCarControllersActionFor(Lane1.Id, 0, true);
            WaitSecondsForPitstopInDetection();
            StopTraceLogging();
            Assert.IsFalse(Lane1.IsInPitstop);
        }
    }
    // ReSharper restore InconsistentNaming

}
