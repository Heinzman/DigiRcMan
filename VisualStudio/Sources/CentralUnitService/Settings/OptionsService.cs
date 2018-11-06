using Elreg.RaceOptionsService;

namespace Elreg.CentralUnitService.Settings
{
    public class OptionsService : ServiceBase<Options>, ICentralUnitOptionsService
    {
        public Options Options
        {
            get { return Object; }
            set { Object = value; }
        }

        protected override string Filename
        {
            get { return "CentralUnitOptions.xml"; }
        }
    }
}
