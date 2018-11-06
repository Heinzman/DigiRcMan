using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;
using Elreg.DomainModels;
using Elreg.DomainModels.RaceModel.LaneModel;
using Elreg.RaceOptionsService;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.FuelConsumptionTests
{
    [TestFixture]
    // ReSharper disable InconsistentNaming
    // ReSharper disable PossibleInvalidOperationException
    public class When_Regular_Lap_Was_Added : BaseLapTest
    {
        private FuelConsumption _fuelConsumption;

        [SetUp]
        public void StartUp()
        {
            _fuelConsumption = new FuelConsumption(new FuelConsumptionService());
        }

        [Test]
        public void FuelConsumption_Per_Lap_Should_Be_Correct()
        {
            float fuelConsumptionPerLap = 0f;
            StartRace();
            AddRegularLapAndWaitValidSeconds();
            for (int i = 0; i < 2; i++)
            {
                MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 12, new List<uint> { 12 });
                CalcFuelConsumptionPerLap(ref fuelConsumptionPerLap, 12);
            }
            MockRaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            Assert.AreEqual(Math.Round(Lane1.FuelConsumptionPerLap.Value, 2), Math.Round(fuelConsumptionPerLap, 2));
        }

        private void CalcFuelConsumptionPerLap(ref float fuelConsumptionPerLap, uint speed)
        {
            float litres = CalcLitresBySpeed(speed);
            FuelConsumptionCalculator fuelConsumptionCalculator = new FuelConsumptionCalculator(Lane1, RaceSettings);
            const float speedListConsumptionFactor = 1f;
            float litersToConsume = fuelConsumptionCalculator.CalcCurrentLitresToConsume(litres, speedListConsumptionFactor);
            fuelConsumptionPerLap += litersToConsume;
        }

        private float CalcLitresBySpeed(uint speed)
        {
            Lane lane = new Lane { Position = 1, Lap = 1 };
            return _fuelConsumption.GetFuelConsumptionPer(speed, lane, Race.TypeEnum.Race);
        }

    }
}
