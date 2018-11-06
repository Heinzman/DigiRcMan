namespace Elreg.BusinessObjects.Options
{
    public class ApplicationSettings
    {
        public ApplicationSettings()
        {
            IsAppClosedNormally = true;
            IsRaceInProgress = false;
        }

        public bool IsRaceInProgress { get; set; }

        public bool IsAppClosedNormally { get; set; }
    }
}
