using Elreg.CarSound.Interfaces;

namespace Elreg.CarSound.AdditionalSoundCalculator
{
    public class BrakesHandler
    {
        private readonly IBrakesSoundProvider _brakesSoundProvider;

        public BrakesHandler(IBrakesSoundProvider brakesSoundProvider)
        {
            _brakesSoundProvider = brakesSoundProvider;
        }

        public void StopSound()
        {
            _brakesSoundProvider.BrakesSound.Stop();
        }

        public void PlayOrStopSound()
        {
            if (IsBraking())
                _brakesSoundProvider.BrakesSound.Start();
            else if (IsAcceleratingOrStandingStill())
                StopSound();
        }

        private bool IsBraking()
        {
            return Delta < -5 || (CurrentSpeedOfCar == 0 && Delta < -2);
        }

        private bool IsAcceleratingOrStandingStill()
        {
            return Delta > 0 || _brakesSoundProvider.IsEngineIdle || _brakesSoundProvider.HasDestinatedFrequencyFactor;
        }

        private double Delta
        {
            get { return CurrentSpeedOfCar - LastAverageSpeedOfCar; }
        }

        private uint CurrentSpeedOfCar
        {
            get { return _brakesSoundProvider.SpeedOfCarCalculator.CurrentSpeedOfCar; }
        }

        private double LastAverageSpeedOfCar
        {
            get { return _brakesSoundProvider.SpeedOfCarCalculator.LastAverageSpeedOfCar; }
        }

    }
}
