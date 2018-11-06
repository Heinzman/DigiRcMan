using System;
using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Options;

namespace Heinzman.DomainModels
{
    public class InitalLaneModel : IDisposable
    {
        private InitialLane _initialLane;
        private readonly RaceSettings _raceSettings;

        public InitalLaneModel(InitialLane initialLane, RaceSettings raceSettings)
        {
            _initialLane = initialLane;
            _raceSettings = raceSettings;
        }

        public void Dispose()
        {
            _initialLane = null;
        }

        public string DriverName
        {
            get 
            {
                string driverName = null;
                if (_initialLane.Driver != null)
                    driverName = _initialLane.Driver.Name;
                return driverName; 
            }
        }

        public string CarName
        {
            get 
            {
                string carName = null;
                if (_initialLane.Car != null)
                    carName = _initialLane.Car.Name;
                return carName; 
            }
        }

        public float? TankMaximumInLitres
        {
            get
            {
                float? tankMaximumInLitres = null;
                if (_initialLane.Driver != null || _initialLane.Car != null)
                {
                    tankMaximumInLitres = _raceSettings.TankMaximumInLitres;
                    if (_initialLane.Driver != null && _initialLane.Driver.HasTankMaximum)
                        tankMaximumInLitres = _initialLane.Driver.TankMaximumInLitres;
                    else if (_initialLane.Car != null && _initialLane.Car.HasTankMaximum)
                        tankMaximumInLitres = _initialLane.Car.TankMaximumInLitres;
                }
                return tankMaximumInLitres;
            }
        }

        public float? FuelConsumptionFactor
        {
            get
            {
                float? fuelConsumptionFactor = null;
                if (_initialLane.Driver != null || _initialLane.Car != null)
                {
                    fuelConsumptionFactor = 1.0f;
                    if (_initialLane.Driver != null && _initialLane.Driver.HasFuelConsumptionFactor)
                        fuelConsumptionFactor *= _initialLane.Driver.FuelConsumptionFactor;
                    if (_initialLane.Car != null && _initialLane.Car.HasFuelConsumptionFactor)
                        fuelConsumptionFactor *= _initialLane.Car.FuelConsumptionFactor;
                }
                return fuelConsumptionFactor;
            }
        }

        public float? InitialTankMaximumInLitres
        {
            get
            {
                if (_initialLane.TankMaximumInLitres != null)
                    return _initialLane.TankMaximumInLitres;
                else
                    return TankMaximumInLitres;
            }
        }

        public float? InitialFuelConsumptionFactor
        {
            get
            {
                if (_initialLane.FuelConsumptionFactor != null)
                    return _initialLane.FuelConsumptionFactor;
                else
                    return FuelConsumptionFactor;
            }
        }

    }
}
