using Elreg.CarSound.Interfaces;

namespace Elreg.CarSound.AdditionalSoundCalculator
{
    public class WheelSpinHandler
    {
        private readonly IWheelSpinSoundProvider _wheelSpinSoundProvider;

        public WheelSpinHandler(IWheelSpinSoundProvider wheelSpinSoundProvider)
        {
            _wheelSpinSoundProvider = wheelSpinSoundProvider;
        }

        public void StopSound()
        {
            _wheelSpinSoundProvider.WheelSpinSound.Stop();
        }

        public void PlayOrStopSound()
        {
            if (IsSpinning())
                _wheelSpinSoundProvider.WheelSpinSound.Start();
            else if (IsBrakingOrStandingStill())
                StopSound();
        }

        private bool IsSpinning()
        {
            return Delta > 6;
        }

        private bool IsBrakingOrStandingStill()
        {
            return Delta < 0 || _wheelSpinSoundProvider.IsEngineIdle || _wheelSpinSoundProvider.HasDestinatedFrequencyFactor;
        }

        private double Delta
        {
            get { return CurrentSpeedOfCar - LastAverageSpeedOfCar; }
        }

        private uint CurrentSpeedOfCar
        {
            get { return _wheelSpinSoundProvider.SpeedOfCarCalculator.CurrentSpeedOfCar; }
        }

        private double LastAverageSpeedOfCar
        {
            get { return _wheelSpinSoundProvider.SpeedOfCarCalculator.LastAverageSpeedOfCar; }
        }

    }
}
