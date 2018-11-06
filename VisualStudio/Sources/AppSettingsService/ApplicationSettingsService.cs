using Elreg.BusinessObjects.Options;
using Elreg.RaceOptionsService;

namespace Elreg.RaceRecovery
{
    public class ApplicationSettingsService : ServiceBase<ApplicationSettings>
    {
        public ApplicationSettings ApplicationSettings
        {
            get { return Object; }
        }

        protected override string Filename
        {
            get { return "ApplicationSettings.xml"; }
        }
    }
}
