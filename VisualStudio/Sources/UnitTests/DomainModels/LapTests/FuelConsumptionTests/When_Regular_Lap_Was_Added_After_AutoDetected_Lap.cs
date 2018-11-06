using System.Collections.Generic;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.FuelConsumptionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Regular_Lap_Was_Added_After_AutoDetected_Lap : BaseLapTest
    {
        [Test]
        public void FuelConsumption_Per_Lap_Should_Be_Null()
        {
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            AutoDetectLap();
            for (int i = 0; i < 2; i++)
                MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 12, new List<uint> { 12 });
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.IsNull(Lane1.FuelConsumptionPerLap);
        }
    }
}
