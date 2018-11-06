using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.PitInDetectionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_ButtonIsPressed_For_MinSecs_With_Speed : PitInDetectionTest
    {
        [Test]
        public void PitIn_Must_Not_Be_Detected()
        {
            InitAndStartRace();
            WaitSomeMilliSeconds();
            Assert.IsFalse(Lane1.IsInPitstop);
            MockControllerDataSupplier.SetCarControllersActionFor(Lane1.Id, 4, true);
            WaitSecondsForPitstopInDetection();
            Assert.IsFalse(Lane1.IsInPitstop);
        }
    }

}
