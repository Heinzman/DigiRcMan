using System;
using Elreg.BusinessObjects.Lanes;
using Elreg.DomainModels.RaceModel;
using Elreg.HelperClasses;
using Elreg.Log;

namespace Elreg.MusicPlayer
{
    public class HymnPlayer : Player
    {
        private readonly RaceModel _raceModel;
        private Lane _winnerLane;

        public event EventHandler SongStopped;

        public HymnPlayer(RaceModel raceModel, int volume) : base(null, volume)
        {
            _raceModel = raceModel;
        }

        public override void Play()
        {
            if (!base.PlayNext())
                StopAudioAndRaiseEvent();
        }

        public override bool PlayNext()
        {
            StopAudioAndRaiseEvent();
            return false;
        }

        public override void Pause()
        {
            Stop();
        }

        protected override void AudioEnding(object sender, EventArgs e)
        {
            try
            {
                RaiseEventSongStopped();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected override void GetNextSong()
        {
            _winnerLane = _raceModel.Race.WinnerLane;
            if (_winnerLane == null)
                StopAudioAndRaiseEvent();
            else
                GetSongOfWinnerDriver();
        }

        private void GetSongOfWinnerDriver()
        {
            SongFileName = SystemHelper.GetAbsolutePath(_winnerLane.Driver.HymnFilename);
        }

        private void StopAudioAndRaiseEvent()
        {
            if (!IsAudioStopped)
                Stop();
            RaiseEventSongStopped();
        }

        private void RaiseEventSongStopped()
        {
            if (SongStopped != null)
                SongStopped(this, null);
        }
    }
}


