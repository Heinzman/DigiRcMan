using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.GhostCarService.Replay;
using Elreg.RaceOptionsService;

namespace Elreg.GhostCarService
{
    public class GhostcarsService : ServiceBase<GhostcarsOptions>
    {
        private readonly List<Driver> _ghostcars;
        private readonly ReplayOptionsService _replayOptionsServiceA = new ReplayOptionsService(Ghost.GhostA);
        private readonly ReplayOptionsService _replayOptionsServiceB = new ReplayOptionsService(Ghost.GhostB);

        private const string GhostcarAName = "Ghostcar A";
        private const string GhostcarBName = "Ghostcar B";

        private enum GhostCarId
        {
            A = -1000,
            B = -1001
        }

        public GhostcarsService()
        {
            _ghostcars = new List<Driver>
                             {
                                 new Driver {Name = GhostcarAName, IsGhostcar = true, HasFuelConsumptionFactor = true,
                                      FuelConsumptionFactor = 0, Id = (int)GhostCarId.A},
                                 new Driver {Name = GhostcarBName, IsGhostcar = true,  HasFuelConsumptionFactor = true, 
                                     FuelConsumptionFactor = 0, Id = (int)GhostCarId.B}
                             };
        }

        public bool IsActivated { get; set; }

        public List<Driver> Ghostcars
        {
            get { return _ghostcars; }
        }

        public Ghost GetGhostBy(Driver driver)
        {
            Ghost ghost = Ghost.GhostA;

            if (driver.Id == (int)GhostCarId.B)
                ghost = Ghost.GhostB;
            return ghost;
        }

        public string GetNameBy(Ghost ghost)
        {
            string name = GhostcarAName;

            if (ghost == Ghost.GhostB)
                name = GhostcarBName;
            return name;
        }

        public ReplayOptions GetReplayOptionsBy(Ghost ghost)
        {
            ReplayOptionsService replayOptionsService = GetReplayOptionsServiceBy(ghost);
            return replayOptionsService.ReplayOptions;
        }

        public void Save(ReplayOptions replayOptions, Ghost ghost)
        {
            ReplayOptionsService replayOptionsService = GetReplayOptionsServiceBy(ghost);
            replayOptionsService.Save(replayOptions);
            replayOptionsService.ReplayOptions = replayOptions;
        }

        public GhostcarsOptions GhostcarsOptions
        {
            get { return Object; }
        }

        private ReplayOptionsService GetReplayOptionsServiceBy(Ghost ghost)
        {
            ReplayOptionsService replayOptionsService = _replayOptionsServiceA;
            if (ghost == Ghost.GhostB)
                replayOptionsService = _replayOptionsServiceB;
            return replayOptionsService;
        }

        protected override string Filename
        {
            get { return "GhostcarsOptions.xml"; }
        }
    }
}
