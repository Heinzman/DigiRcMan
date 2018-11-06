using Elreg.BusinessObjects.Options;

namespace Elreg.RaceOptionsService
{
    public class RfIdSettingsService : ServiceBase<RfIdSettings>
    {
        public RfIdSettings RfIdSettings
        {
            get { return Object; }
        }

        protected override string Filename
        {
            get { return "RfIdSettings.xml"; }
        }
    }
}
