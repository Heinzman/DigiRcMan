using Elreg.BusinessObjects.Races;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.AutoDetectTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Zeroth_Lap_Was_AutoDetected_In_Race : BaseAutoDetectLapTest
    {
        [Test]
        public void Lap_Should_Be_Counted()
        {
            ForceZerothAutoDetectedLapForLane3For(Race.TypeEnum.Race);
            Assert.AreEqual(0, Lane3.Lap);
        }
    }
}
