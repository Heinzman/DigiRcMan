using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.CentralUnitService;
using Elreg.DomainModels;
using Elreg.RaceOptionsService;
using Elreg.UnitTests.MockObjects;
using Elreg.UnitTests.TestHelper;
using Moq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Elreg.UnitTests.CentralUnitTests
{
    public abstract class CentralUnitBaseTest : BaseLapTest
    {
        protected CentralUnit _centralUnit;
        protected IArduinoWriter _arduinoWriter;
        protected readonly ICentralUnitOptionsService _centralUnitOptionsService = new MockCentralUnitOptionsService();

        [SetUp]
        public void StartUp()
        {
            InitRace();
            InitCentralUnit();
        }

        private void InitCentralUnit()
        {
            InitCentralUnitOptionsService();
            _arduinoWriter = new MockArduinoWriter();
            Mock<ISerialPortReader> serialPortReaderMock = new Mock<ISerialPortReader>();
            _centralUnit = new CentralUnit(RaceModel, _centralUnitOptionsService, _arduinoWriter, serialPortReaderMock.Object);
        }

        protected FuelConsumption InitFuelConsumption(FuelConsumptionPerSpeed fuelConsumptionPerSpeed)
        {
            FuelConsumptionService fuelConsumptionService = new FuelConsumptionService {FuelConsumptionPerSpeed = fuelConsumptionPerSpeed};
            FuelConsumption fuelConsumption = new FuelConsumption(fuelConsumptionService) { Options = _centralUnitOptionsService.Options };
            return fuelConsumption;
        }

        protected abstract void InitCentralUnitOptionsService();
    }
}
