using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Options;

namespace Heinzman.DomainModels.RaceModel.LaneModel
{
    public class AutoDetection
    {
        private readonly RaceLaneModel _raceLaneModel;
        private readonly RaceSettings _raceSettings;

        public AutoDetection(RaceLaneModel raceLaneModel, RaceSettings raceSettings)
        {
            _raceLaneModel = raceLaneModel;
            _raceSettings = raceSettings;
        }

        public void CheckAutoDetectedLap(uint speed)
        {
            if (_raceLaneModel.LaneIsInRaceAndRaceIsInStartedOrCountDown)
            {
                CurrentLane.SpeedSum += DecodeSpeed(speed);
                if (ShouldLapBeAutoDetected())
                    _raceLaneModel.LapAppender.AddAutoDetectedLap();
            }
        }

        private bool ShouldLapBeAutoDetected()
        {
            return ShouldLapBeAutoDetectedForZerothLap() || ShouldLapBeAutoDetectedForLapGreaterZero();
        }

        private bool ShouldLapBeAutoDetectedForZerothLap()
        {
            return _raceSettings.AutoDetectZerothLapEnabled &&
                   CurrentLane.Lap == -1 &&
                   CurrentLane.SpeedSum >= RaceModel.SpeedSumAvgCalculator.SpeedSumAvgOfZerothLap * _raceSettings.AutoDetectZerothLapSpeedFactor;
        }

        private bool ShouldLapBeAutoDetectedForLapGreaterZero()
        {
            return _raceSettings.AutoDetectLapEnabled &&
                   CurrentLane.Lap >= 0 &&
                   _raceLaneModel.SecondsSinceLastDetectedLap >= _raceSettings.SecondsForValidLap &&
                   (ShouldBeFirstAutoDetectedLap() || ShouldBeSecondAutoDetectedLap());
        }

        private bool ShouldBeFirstAutoDetectedLap()
        {
            return CurrentLane.LastLapsAutoDetectedCount == 0 &&
                   CurrentLane.SpeedSum >= RaceModel.SpeedSumAvgCalculator.SpeedSumAvg * _raceSettings.AutoDetectLapSpeedFactor;
        }

        private bool ShouldBeSecondAutoDetectedLap()
        {
            return CurrentLane.LastLapsAutoDetectedCount == 1 &&
                   CurrentLane.SpeedSum >= RaceModel.SpeedSumAvgCalculator.SpeedSumAvg;
        }

        private uint DecodeSpeed(uint speed)
        {
            uint decodedSpeed = speed;

            if (speed == 12)
                decodedSpeed = 10;
            else if (speed == 10)
                decodedSpeed = 9;
            return decodedSpeed;
        }

        private Lane CurrentLane
        {
            get { return _raceLaneModel.CurrentLane; }
        }

        private RaceModel RaceModel
        {
            get { return _raceLaneModel.RaceModel; }
        }

    }
}
