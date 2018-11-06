using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.PitInDetectionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_SpeedIsReducedToZero_With_ButtonIsPressed_Then_Released_Then_PressedAgain : PitInDetectionTest
    {
        [Test]
        public void PitIn_Should_Be_Detected()
        {
            StartTraceLogging();
            InitAndStartRace();
            Assert.IsFalse(Lane1.IsInPitstop);
            MockControllerDataSupplier.SetCarControllersActionFor(Lane1.Id, 3, true);
            WaitSomeMilliSeconds();
            MockControllerDataSupplier.SetCarControllersActionFor(Lane1.Id, 0, false);
            WaitSomeMilliSeconds();
            MockControllerDataSupplier.SetCarControllersActionFor(Lane1.Id, 0, true);
            WaitSecondsForPitstopInDetection();
            StopTraceLogging();
            Assert.IsTrue(Lane1.IsInPitstop);
        }
    }
    // ReSharper restore InconsistentNaming

}
