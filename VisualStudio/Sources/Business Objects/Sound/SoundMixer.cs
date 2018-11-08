namespace Elreg.BusinessObjects.Sound
{
    public class SoundMixer
    {
        private int _speakerRearLeftVolume;
        private int _speakerFrontLeftVolume;
        private int _speakerCenterVolume;
        private int _speakerFrontRightVolume;
        private int _speakerRearRightVolume;
        private int _speakerVirtualLeftVolume;
        private int _actionSoundVolume;
        private int _actionFadeVolume;
        private int _carSoundVolume;
        private int _carEngineVolume;
        private int _carIdleVolume;
        private int _carFadeOwnVolume;
        private int _carFadeAllVolume;
        private int _carPitstopVolume;
        private int _rocketStartVolume;
        private int _rocketExplosionVolume;
        private int _engineDamageVolume;
        private int _rocketWarningVolume;
        private int _carBrakesVolume;
        private int _carSpinWheelsVolume;
        private int _countDownVolume;
        private int _musicMainVolume;
        private int _musicRaceVolume;
        private int _musicPauseVolume;
        private int _musicHymnVolume;

        public const int MaximumVolume = 0;
        public const int MinimumVolume = -5000;
        public const int NearlyMinimumVolume = MinimumVolume + 100;

        public SoundMixer()
        {
            SpeakerRearLeftVolume = MaximumVolume;
            SpeakerFrontLeftVolume = MaximumVolume;
            SpeakerCenterVolume = MaximumVolume;
            SpeakerFrontRightVolume = MaximumVolume;
            SpeakerRearRightVolume = MaximumVolume;
            SpeakerVirtualLeftVolume = MaximumVolume;
            ActionSoundVolume = MaximumVolume;
            CarSoundVolume = MaximumVolume;
            CarEngineVolume = MaximumVolume;
            CarIdleVolume = MaximumVolume;
            MusicMainVolume = MaximumVolume;
            CarFadeOwnVolume = MinimumVolume;
            CarPitstopVolume = MaximumVolume;
            RocketStartVolume = MaximumVolume;
            RocketExplosionVolume = MaximumVolume;
            RocketWarningVolume = MaximumVolume;
            CarBrakesVolume = MaximumVolume;
            CarSpinWheelsVolume = MaximumVolume;
            CountDownVolume = MaximumVolume;
        }

        public int SpeakerVirtualLeftVolume
        {
            get { return _speakerVirtualLeftVolume; }
            set { _speakerVirtualLeftVolume = Limit(value); }
        }

        public int SpeakerRearLeftVolume
        {
            get { return _speakerRearLeftVolume; }
            set { _speakerRearLeftVolume = Limit(value); }
        }

        public int SpeakerFrontLeftVolume
        {
            get { return _speakerFrontLeftVolume; }
            set { _speakerFrontLeftVolume = Limit(value); }
        }

        public int SpeakerCenterVolume
        {
            get { return _speakerCenterVolume; }
            set { _speakerCenterVolume = Limit(value); }
        }

        public int SpeakerFrontRightVolume
        {
            get { return _speakerFrontRightVolume; }
            set { _speakerFrontRightVolume = Limit(value); }
        }

        public int SpeakerRearRightVolume
        {
            get { return _speakerRearRightVolume; }
            set { _speakerRearRightVolume = Limit(value); }
        }

        public int ActionSoundVolume
        {
            get { return _actionSoundVolume; }
            set { _actionSoundVolume = Limit(value); }
        }

        public int ActionFadeVolume
        {
            get { return _actionFadeVolume; }
            set { _actionFadeVolume = Limit(value); }
        }

        public int CarSoundVolume
        {
            get { return _carSoundVolume; }
            set { _carSoundVolume = Limit(value); }
        }

        public int MusicMainVolume
        {
            get { return _musicMainVolume; }
            set { _musicMainVolume = Limit(value); }
        }

        public int MusicHymnVolume
        {
            get { return _musicHymnVolume; }
            set { _musicHymnVolume = Limit(value); }
        }

        public int CarFadeOwnVolume
        {
            get { return _carFadeOwnVolume; }
            set { _carFadeOwnVolume = Limit(value); }
        }

        public int CarFadeAllVolume
        {
            get { return _carFadeAllVolume; }
            set { _carFadeAllVolume = Limit(value); }
        }
        
        public int CarPitstopVolume
        {
            get { return _carPitstopVolume; }
            set { _carPitstopVolume = Limit(value); }
        }

        public int RocketStartVolume
        {
            get { return _rocketStartVolume; }
            set { _rocketStartVolume = Limit(value); }
        }

        public int RocketExplosionVolume
        {
            get { return _rocketExplosionVolume; }
            set { _rocketExplosionVolume = Limit(value); }
        }

        public int EngineDamageVolume
        {
            get { return _engineDamageVolume; }
            set { _engineDamageVolume = Limit(value); }
        }

        public int RocketWarningVolume
        {
            get { return _rocketWarningVolume; }
            set { _rocketWarningVolume = Limit(value); }
        }

        public int CarBrakesVolume
        {
            get { return _carBrakesVolume; }
            set { _carBrakesVolume = Limit(value); }
        }

        public int CarEngineVolume
        {
            get { return _carEngineVolume; }
            set { _carEngineVolume = Limit(value); }
        }

        public int CarIdleVolume
        {
            get { return _carIdleVolume; }
            set { _carIdleVolume = Limit(value); }
        }

        public int CarSpinWheelsVolume
        {
            get { return _carSpinWheelsVolume; }
            set { _carSpinWheelsVolume = Limit(value); }
        }

        public int CountDownVolume
        {
            get { return _countDownVolume; }
            set { _countDownVolume = Limit(value); }
        }

        public int MusicRaceVolume
        {
            get { return _musicRaceVolume; }
            set { _musicRaceVolume = Limit(value); }
        }

        public int MusicPauseVolume
        {
            get { return _musicPauseVolume; }
            set { _musicPauseVolume = Limit(value); }
        }

        public static int Limit(int value)
        {
            int limitedValue = value;
            if (value > MaximumVolume)
                limitedValue = MaximumVolume;
            else if (value <= MinimumVolume)
                limitedValue = MinimumVolume;
            return limitedValue;
        }

        public int SpeakerVirtualLeftVolumeAdapted
        {
            get { return Adapt(SpeakerVirtualLeftVolume); }
        }

        public int SpeakerRearLeftVolumeAdapted
        {
            get { return Adapt(SpeakerRearLeftVolume); }
        }

        public int SpeakerFrontLeftVolumeAdapted
        {
            get { return Adapt(SpeakerFrontLeftVolume); }
        }

        public int SpeakerCenterVolumeAdapted
        {
            get { return Adapt(SpeakerCenterVolume); }
        }

        public int SpeakerFrontRightVolumeAdapted
        {
            get { return Adapt(SpeakerFrontRightVolume); }
        }

        public int SpeakerRearRightVolumeAdapted
        {
            get { return Adapt(SpeakerRearRightVolume); }
        }

        public int ActionSoundVolumeAdapted
        {
            get { return Adapt(ActionSoundVolume); }
        }

        public int ActionFadeVolumeAdapted
        {
            get { return Adapt(ActionFadeVolume); }
        }

        public int CarSoundVolumeAdapted
        {
            get { return Adapt(CarSoundVolume); }
        }

        public int MusicMainVolumeAdapted
        {
            get { return Adapt(MusicMainVolume); }
        }

        public int MusicHymnVolumeAdapted
        {
            get { return Adapt(MusicHymnVolume); }
        }

        public int CarFadeOwnVolumeAdapted
        {
            get { return Adapt(CarFadeOwnVolume); }
        }

        public int CarFadeAllVolumeAdapted
        {
            get { return Adapt(CarFadeAllVolume); }
        }

        public int CarPitstopVolumeAdapted
        {
            get { return Adapt(CarPitstopVolume); }
        }

        public int RocketStartVolumeAdapted
        {
            get { return Adapt(RocketStartVolume); }
        }

        public int RocketExplosionVolumeAdapted
        {
            get { return Adapt(RocketExplosionVolume); }
        }

        public int EngineDamageVolumeAdapted
        {
            get { return Adapt(EngineDamageVolume); }
        }

        public int RocketWarningVolumeAdapted
        {
            get { return Adapt(RocketWarningVolume); }
        }

        public int CarBrakesVolumeAdapted
        {
            get { return Adapt(CarBrakesVolume); }
        }

        public int CarEngineVolumeAdapted
        {
            get { return Adapt(CarEngineVolume); }
        }

        public int CarIdleVolumeAdapted
        {
            get { return Adapt(CarIdleVolume); }
        }

        public int CarSpinWheelsVolumeAdapted
        {
            get { return Adapt(CarSpinWheelsVolume); }
        }

        public int CountDownVolumeAdapted
        {
            get { return Adapt(CountDownVolume); }
        }

        public int MusicRaceVolumeAdapted
        {
            get { return Adapt(MusicRaceVolume); }
        }

        public int MusicPauseVolumeAdapted
        {
            get { return Adapt(MusicPauseVolume); }
        }

        private int Adapt(int volume)
        {
            if (volume <= NearlyMinimumVolume)
                return (int) 0;
            else
                return volume;
        }
    }
}
