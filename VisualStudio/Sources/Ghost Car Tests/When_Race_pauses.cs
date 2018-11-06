using NUnit.Framework;

namespace Elreg.UnitTests.GhostCar
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Race_pauses : GhostBaseTest
    {
        [SetUp]
        public void Initialize()
        {
            StartRaceByConstantSpeedAOf(4);         
        }

        [Test]
        public void Ghostcar_should_stop()
        {
            WaitSomeGhostMilliSeconds();
            Assert.AreNotEqual(0, CurrentControllerValueA);

            RaceModel.PauseRaceByKeyboard();
            WaitSomeGhostMilliSeconds();
            Assert.AreEqual((uint)0, CurrentControllerValueA);
        }

        [Test]
        public void Ghostcar_should_start_after_Race_restarted()
        {
            Ghostcar_should_stop();

            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
            Assert.AreNotEqual((uint)0, CurrentControllerValueA);
        }

    }
}
