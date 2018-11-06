namespace Elreg.GhostCarService
{
    public class GhostcarsOptions
    {
        public double MinDistanceInSecs { get; set; }
        public int StartLatencyInMilliSecs { get; set; }
        public bool DistanceHandlerActivated { get; set; }
        public bool RaceParticipation { get; set; }
        public bool RaceSounds { get; set; }

        public GhostcarsOptions()
        {
            MinDistanceInSecs = 2;
            DistanceHandlerActivated = false;
            StartLatencyInMilliSecs = 500;
        }
    }
}
