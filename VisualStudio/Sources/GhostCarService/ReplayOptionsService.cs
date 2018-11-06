using Elreg.BusinessObjects;
using Elreg.GhostCarService.Replay;
using Elreg.RaceOptionsService;

namespace Elreg.GhostCarService
{
    public class ReplayOptionsService : ServiceBase<ReplayOptions>
    {
        private readonly string _fileName = "ReplayOptionsOf";

        public ReplayOptionsService(Ghost ghost)
        {
            string ghostName = "GhostcarA";
            if (ghost == Ghost.GhostB)
                ghostName = "GhostcarB";
            _fileName += ghostName + ".xml";
        }

        public ReplayOptions ReplayOptions
        {
            get { return Object; }
            set { Object = value; }
        }

        protected override string Filename
        {
            get { return _fileName; }
        }
    }
}
