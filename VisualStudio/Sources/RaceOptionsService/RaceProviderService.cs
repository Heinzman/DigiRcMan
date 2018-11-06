using Elreg.BusinessObjects.Options;

namespace Elreg.RaceOptionsService
{
    public class RaceProviderService : ServiceBase<RaceProviderOptions>
    {
        public RaceProviderOptions RaceProviderOptions
        {
            get { return Object; }
        }

        protected override string Filename
        {
            get { return "RaceProviderOptions.xml"; }
        }
    }
}