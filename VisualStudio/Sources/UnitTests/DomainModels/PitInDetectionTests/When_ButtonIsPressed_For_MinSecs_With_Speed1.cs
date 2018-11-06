using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.PitInDetectionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_ButtonIsPressed_For_MinSecs_With_Speed1 : PitInDetectionTest
    {
        [Test]
        public void PitIn_Should_Be_Detected()
        {
            InitAndStartRace();
            WaitSomeMilliSeconds();
            Assert.IsFalse(Lane1.IsInPitstop);
            MockControllerDataSupplier.SetCarControllersActionFor(Lane1.Id, 1, true);
            WaitSecondsForPitstopInDetection();
            Assert.IsTrue(Lane1.IsInPitstop);
        }
    }
    // ReSharper restore InconsistentNaming

}
