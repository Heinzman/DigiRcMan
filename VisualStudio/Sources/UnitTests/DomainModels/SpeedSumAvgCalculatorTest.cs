using Elreg.BusinessObjects.Interfaces;
using Elreg.DomainModels;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels
{
    [TestFixture]
    public class SpeedSumAvgCalculatorTest : BaseLapTest
    {
        private ISpeedSumAvgCalculator _speedSumAvgCalculator;

        [Test]
        public void TestCalcAverageBy10TestValues()
        {
            InitSpeedSumAvgCalculator();

            _speedSumAvgCalculator.Reset();
            _speedSumAvgCalculator.AddSpeedSum(1250);
            _speedSumAvgCalculator.AddSpeedSum(1000);
            _speedSumAvgCalculator.AddSpeedSum(800);
            _speedSumAvgCalculator.AddSpeedSum(900);
            _speedSumAvgCalculator.AddSpeedSum(1200);
            _speedSumAvgCalculator.AddSpeedSum(950);
            _speedSumAvgCalculator.AddSpeedSum(1050);
            _speedSumAvgCalculator.AddSpeedSum(1100);
            _speedSumAvgCalculator.AddSpeedSum(850);
            _speedSumAvgCalculator.AddSpeedSum(1150);

            int? speedSumAvg = _speedSumAvgCalculator.SpeedSumAvg;
            const int expectedValue = 1025;
            Assert.AreEqual(expectedValue, speedSumAvg);
        }

        [Test]
        public void TestCalcAverageBy4TestValues()
        {
            InitSpeedSumAvgCalculator();

            _speedSumAvgCalculator.Reset();
            Add4SpeedSums();

            int? speedSumAvg = _speedSumAvgCalculator.SpeedSumAvg;
            const int expectedValue = 950;
            Assert.AreEqual(expectedValue, speedSumAvg);
        }

        private void Add4SpeedSums()
        {
            _speedSumAvgCalculator.AddSpeedSum(1250);
            _speedSumAvgCalculator.AddSpeedSum(1000);
            _speedSumAvgCalculator.AddSpeedSum(800);
            _speedSumAvgCalculator.AddSpeedSum(900);
        }

        [Test]
        public void TestCalcAverageBy3DefaultValueNotExistsShouldBeNull()
        {
            AutoDetectLapSpeedSum = 0;
            InitSpeedSumAvgCalculator();

            _speedSumAvgCalculator.Reset();
            _speedSumAvgCalculator.AddSpeedSum(1000);
            _speedSumAvgCalculator.AddSpeedSum(800);
            _speedSumAvgCalculator.AddSpeedSum(900);

            int? speedSumAvg = _speedSumAvgCalculator.SpeedSumAvg;
            Assert.IsNull(speedSumAvg);
        }

        [Test]
        public void TestAfterResetSpeedSumAvgShouldBeZero()
        {
            AutoDetectLapSpeedSum = 0;
            InitSpeedSumAvgCalculator();

            _speedSumAvgCalculator.Reset();
            Add4SpeedSums();
            Assert.IsTrue(_speedSumAvgCalculator.SpeedSumAvg > 0);
            _speedSumAvgCalculator.Reset();
            Assert.IsNull(_speedSumAvgCalculator.SpeedSumAvg);
        }

        private void InitSpeedSumAvgCalculator()
        {
            _speedSumAvgCalculator = new SpeedSumAvgCalculator();
        }

    }
}
