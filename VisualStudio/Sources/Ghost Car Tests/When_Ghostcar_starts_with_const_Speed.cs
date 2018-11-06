using NUnit.Framework;

namespace Elreg.UnitTests.GhostCar
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Ghostcar_starts_with_const_Speed_ : GhostBaseTest
    {
        [Test]
        public void Of_0_Then_ArduinoWriter_Should_Have_Value_0()
        {
            StartCarCheckArduinoValue(0, 0);
        }

        [Test]
        public void Of_1_Then_ArduinoWriter_Should_Have_Value_1()
        {
            StartCarCheckArduinoValue(1, 1);
        }

        [Test]
        public void Of_2_Then_ArduinoWriter_Should_Have_Value_2()
        {
            StartCarCheckArduinoValue(2, 2);
        }
        [Test]
        public void Of_3_Then_ArduinoWriter_Should_Have_Value_3()
        {
            StartCarCheckArduinoValue(3, 3);
        }

        [Test]
        public void Of_4_Then_ArduinoWriter_Should_Have_Value_4()
        {
            StartCarCheckArduinoValue(4, 5);
        }

        [Test]
        public void Of_5_Then_ArduinoWriter_Should_Have_Value_5()
        {
            StartCarCheckArduinoValue(5, 7);
        }

        [Test]
        public void Of_6_Then_ArduinoWriter_Should_Have_Value_6()
        {
            StartCarCheckArduinoValue(6, 9);
        }

        [Test]
        public void Of_7_Then_ArduinoWriter_Should_Have_Value_7()
        {
            StartCarCheckArduinoValue(7, 11);
        }

        [Test]
        public void Of_8_Then_ArduinoWriter_Should_Have_Value_8()
        {
            StartCarCheckArduinoValue(8, 12);
        }

        [Test]
        public void Of_9_Then_ArduinoWriter_Should_Have_Value_9()
        {
            StartCarCheckArduinoValue(9, 13);
        }

        [Test]
        public void Of_10_Then_ArduinoWriter_Should_Have_Value_10()
        {
            StartCarCheckArduinoValue(10, 14);
        }

        [Test]
        public void Of_12_Then_ArduinoWriter_Should_Have_Value_15()
        {
            StartCarCheckArduinoValue(12, 15);
        }

        private void StartCarCheckArduinoValue(uint speed, uint controllerValue)
        {
            StartRaceByConstantSpeedAOf(speed);
            Assert.AreEqual(controllerValue, CurrentControllerValueA);
        }
    }
}
