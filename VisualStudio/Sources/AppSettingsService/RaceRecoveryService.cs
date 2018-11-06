using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;
using Elreg.RaceOptionsService;

namespace Elreg.RaceRecovery
{
    public class RaceRecoveryService : ServiceBase<Race>
    {
        private List<InitialLane> _initialLanes;

        public Race Race
        {
            get { return Object; }
        }

        public List<InitialLane> InitialLanes
        {
            get
            {
                ExtractInitialLanes();
                return _initialLanes;
            }
        }

        protected override string Filename
        {
            get { return "RaceRecovery.xml"; }
        }

        protected override string Path
        {
            get { return ServiceHelper.LogsPath; }
        }

        private void ExtractInitialLanes()
        {
            _initialLanes = new List<InitialLane>();
            foreach (Lane lane in Race.Lanes)
                ExtractInitialLane(lane);
        }

        private void ExtractInitialLane(Lane lane)
        {
            InitialLane initialLane = new InitialLane
                                          {
                                              Id = lane.Id,
                                              Car = lane.Car,
                                              Driver = lane.Driver,
                                              FuelConsumptionFactor = lane.FuelConsumptionFactor,
                                              InitialFuelLevelInLitres = lane.TankMaximumInLitres,
                                              TankMaximumInLitres = lane.TankMaximumInLitres
                                          };
            _initialLanes.Add(initialLane);
        }

    }
}
