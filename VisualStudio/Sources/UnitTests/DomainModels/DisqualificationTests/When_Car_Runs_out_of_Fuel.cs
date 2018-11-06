using System.Collections.Generic;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.DomainModels.DisqualificationTests
{
    [TestFixture]
    public class When_Car_Runs_out_of_Fuel : BaseLapTest
    {
        [Test]
        public void Car_Should_be_Disqualified_if_Not_NegativeTankAllowed()
        {
            RaceSettings.NegativeFuelLevelEnabled = false;
            StartRaceAndConsumeFuel();
            Assert.IsTrue(Lane1.IsDisqualified);
        }

        [Test]
        public void Car_Must_not_be_Disqualified_if_NegativeTankAllowed()
        {
            RaceSettings.NegativeFuelLevelEnabled = true;
            StartRaceAndConsumeFuel();
            Assert.IsFalse(Lane1.IsDisqualified);
        }

        private void StartRaceAndConsumeFuel()
        {
            StartRace();
            int i = 0;
            while (i < 1000 && Lane1.CurrentFuelLevelInLitres > 0)
            {
                MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 12, new List<uint> {12});
                i++;
            }
            Assert.IsTrue(Lane1.CurrentFuelLevelInLitres <= 0);
        }
    }
}
