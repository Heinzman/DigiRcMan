namespace Elreg.BusinessObjects.Options
{
    public class RaceProviderOptions
    {
        public RaceProviderOptions()
        {
            NumberOfClicksForPenalty = 3;
            MillisecsPressedSinglePeriodForPenalty = 500;
            MillisecsPressedSinglePeriodForRocketLaunch = 300;
            SpeedToDetectPitstopOut = 3;
            SpeedToDetectFalseStart = 3;
            MillisecsPressedToDetectPitstopIn = 400;
            MillisecsPitstopNotZeroTolerance = 200;
        }

        public int MillisecsPressedToDetectPitstopIn { get; set; }

        public int MillisecsPressedSinglePeriodForPenalty { get; set; }

        public int MillisecsPressedSinglePeriodForRocketLaunch { get; set; }

        public int MillisecsPitstopNotZeroTolerance { get; set; }

        public uint SpeedToDetectPitstopOut { get; set; }

        public uint SpeedToDetectFalseStart { get; set; }

        public int NumberOfClicksForPenalty { get; set; }


    }
}
