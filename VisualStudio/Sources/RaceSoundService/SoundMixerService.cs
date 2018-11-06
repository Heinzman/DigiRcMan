using System;
using Elreg.BusinessObjects.Sound;
using Elreg.RaceOptionsService;

namespace Elreg.RaceSoundService
{
    public class SoundMixerService : ServiceBase<SoundMixer>
    {
        private const int VolumeTurnDownOrUpStep = 100;

        public event EventHandler VolumeChanged;

        public SoundMixer SoundMixer
        {
            get { return Object; }
        }

        public int MusicRaceVolume
        {
            get { return SoundMixer.MusicRaceVolumeAdapted; }
        }

        public int MusicPauseVolume
        {
            get { return SoundMixer.MusicPauseVolumeAdapted; }
        }

        public int MusicMainVolume
        {
            get { return SoundMixer.MusicMainVolumeAdapted; }
        }

        public int MusicHymnVolume
        {
            get { return SoundMixer.MusicHymnVolumeAdapted; }
        }

        public void RaiseEventVolumeChanged()
        {
            if (VolumeChanged != null)
                VolumeChanged(this, null);
        }

        public void TurnDownMusicMain()
        {
            SoundMixer.MusicMainVolume -= VolumeTurnDownOrUpStep;
            Save();
        }

        public void TurnUpMusicMain()
        {
            SoundMixer.MusicMainVolume += VolumeTurnDownOrUpStep;
            Save();
        }

        public void TurnDownMusicPause()
        {
            SoundMixer.MusicPauseVolume -= VolumeTurnDownOrUpStep;
            Save();
        }

        public void TurnUpMusicPause()
        {
            SoundMixer.MusicPauseVolume += VolumeTurnDownOrUpStep;
            Save();
        }

        public void TurnDownMusicHymn()
        {
            SoundMixer.MusicHymnVolume -= VolumeTurnDownOrUpStep;
            Save();
        }

        public void TurnUpMusicHymn()
        {
            SoundMixer.MusicHymnVolume += VolumeTurnDownOrUpStep;
            Save();
        }

        public void TurnDownMusicRace()
        {
            SoundMixer.MusicRaceVolume -= VolumeTurnDownOrUpStep;
            Save();
        }

        public void TurnUpMusicRace()
        {
            SoundMixer.MusicRaceVolume += VolumeTurnDownOrUpStep;
            Save();
        }

        public void TurnDownActionSound()
        {
            SoundMixer.ActionSoundVolume -= VolumeTurnDownOrUpStep;
            Save();
        }

        public void TurnUpActionSound()
        {
            SoundMixer.ActionSoundVolume += VolumeTurnDownOrUpStep;
            Save();
        }

        public void TurnDownCarSound()
        {
            SoundMixer.CarSoundVolume -= VolumeTurnDownOrUpStep;
            Save();
        }

        public void TurnUpCarSound()
        {
            SoundMixer.CarSoundVolume += VolumeTurnDownOrUpStep;
            Save();
        }

        protected override string Filename
        {
            get { return "Mixer.xml"; }
        }
    }
}
