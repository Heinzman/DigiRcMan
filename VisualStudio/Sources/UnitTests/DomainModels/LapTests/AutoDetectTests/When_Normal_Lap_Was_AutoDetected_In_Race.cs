using Elreg.BusinessObjects.Races;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.AutoDetectTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    public class When_Normal_Lap_Was_AutoDetected_In_Race : BaseAutoDetectLapTest
    {
        [Test]
        public void Lap_Should_Be_Counted()
        {
            ForceNormalAutoDetectedLapFor(Race.TypeEnum.Race);
            Assert.IsTrue(Lane1.Lap == 1);
        }

    }
}
