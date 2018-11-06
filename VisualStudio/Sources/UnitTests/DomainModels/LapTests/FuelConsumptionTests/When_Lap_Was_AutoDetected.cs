using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.FuelConsumptionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Lap_Was_AutoDetected : BaseLapTest
    {
        [Test]
        public void FuelConsumption_Per_Lap_Should_Be_Null()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLap();
            Assert.IsNull(Lane1.FuelConsumptionPerLap);
        }

    }
}
