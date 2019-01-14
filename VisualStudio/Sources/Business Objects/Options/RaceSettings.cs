using System;
using Elreg.ResourcesService;

namespace Elreg.BusinessObjects.Options
{
    [Serializable]
    public class RaceSettings
    {
        public RaceSettings()
        {
            RestartCountDownRaceActivated = true;
            RestartCountDownRaceInitNo = 2;
            StartCountDownRaceActivated = true;
            StartCountDownRaceInitNo = 3;
            RestartCountDownQualiActivated = true;
            RestartCountDownQualiInitNo = 2;
            StartCountDownQualiActivated = true;
            StartCountDownQualiInitNo = 3;
            RestartCountDownTrainingActivated = true;
            RestartCountDownTrainingInitNo = 2;
            StartCountDownTrainingActivated = true;
            StartCountDownTrainingInitNo = 3;
            LapsToDrive = 4;
            QualificationMinutes = 1;
            QualificationBreaks = 0;
            QualificationTimeBasedActivated = true;
            QualificationLapBasedActivated = false;
            QualificationMaxLaps = 5;
            SecondsForValidLap = 6;
            MilliSecForIgnoringDetections = 500;
            VolumeToAddToMaxSpeed = 1500;
            DescendingLapCount = false;
            LanguageType = LanguageType.German;
            AutoDisqualificationRaceActivated = false;
            AutoDisqualificationRaceAfterPenalties = 10;
            DisqualificationLapSecsActivated = false;
            DisqualificationLapSecsFactor = 16;
            DisqualificationRaceSecsActivated = false;
            DisqualificationRaceSecsFactor = 50;
            BufferBytesToCutFromActionSounds = 30000;
            TrackName = "Track1";
            EventName = DateTime.Today.ToString("yyyy-MM-dd");
            IsAllowedPenaltyAdditionByThreeClicksOnlyInPauseOrCountDown = true;
            PointsForPosition1 = 12;
            PointsForPosition2 = 9;
            PointsForPosition3 = 6;
            PointsForPosition4 = 4;
            PointsForPosition5 = 2;
            PointsForPosition6 = 1;
            SpeedOfSpeech = 0;
            ModuloForLapCountSpeech = 5;
            IsUserSpeechForEveryLapActivated = false;
        }

        public int SpeedOfSpeech { get; set; }

        public int ModuloForLapCountSpeech { get; set; }

        public bool IsUserSpeechForEveryLapActivated { get; set; }

        public bool IsAllowedPenaltyAdditionByThreeClicksOnlyInPauseOrCountDown { get; set; }

        public bool DescendingLapCount { get; set; }

        public int SecondsForValidLap { get; set; }

        public int MilliSecForIgnoringDetections { get; set; }

        public decimal QualificationMinutes { get; set; }

        public decimal QualificationBreaks { get; set; }

        public bool CountDownCharsAnimated { get; set; }

        public bool PauseCharsAnimated { get; set; }

        public int LapsToDrive { get; set; }

        public int StartCountDownRaceInitNo { get; set; }

        public bool StartCountDownRaceActivated { get; set; }

        public int RestartCountDownRaceInitNo { get; set; }

        public bool RestartCountDownRaceActivated { get; set; }

        public int StartCountDownQualiInitNo { get; set; }

        public bool StartCountDownQualiActivated { get; set; }

        public int RestartCountDownQualiInitNo { get; set; }

        public bool RestartCountDownQualiActivated { get; set; }

        public int StartCountDownTrainingInitNo { get; set; }

        public bool StartCountDownTrainingActivated { get; set; }

        public int RestartCountDownTrainingInitNo { get; set; }

        public bool RestartCountDownTrainingActivated { get; set; }

        public int VolumeToAddToMaxSpeed { get; set; }

        public LanguageType LanguageType { get; set; }

        public bool SplittedActionSoundsActivated { get; set; }

        public bool AutoDisqualificationRaceActivated { get; set; }

        public int AutoDisqualificationRaceAfterPenalties { get; set; }

        public bool DisqualificationLapSecsActivated { get; set; }

        public decimal DisqualificationLapSecsFactor { get; set; }

        public bool DisqualificationRaceSecsActivated { get; set; }

        public decimal DisqualificationRaceSecsFactor { get; set; }

        public int BufferBytesToCutFromActionSounds { get; set; }

        public string TrackName { get; set; }

        public string EventName { get; set; }

        public bool QualificationTimeBasedActivated { get; set; }

        public bool QualificationLapBasedActivated { get; set; }

        public int QualificationMaxLaps { get; set; }

        public int PointsForPosition1 { get; set; }

        public int PointsForPosition2 { get; set; }

        public int PointsForPosition3 { get; set; }

        public int PointsForPosition4 { get; set; }

        public int PointsForPosition5 { get; set; }

        public int PointsForPosition6 { get; set; }

        public enum EngineDamageProbabilityOfSlowerCars
        {
            Equal,
            ABitLess,
            Less,
            MuchLess
        }

        public enum SecsToAutoFixOfSlowerCars
        {
            Equal,
            Less,
            MuchLess
        }

    }
}