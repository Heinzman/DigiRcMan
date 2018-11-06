using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using Elreg.Log;
using Elreg.RaceSoundService;
using Microsoft.DirectX.AudioVideoPlayback;
using Microsoft.DirectX.DirectSound;

namespace Elreg.MusicPlayer
{
    public class Player : IPlayer
    {
        private readonly string _directory;
        private int _volume;
        private Audio _audio;
        private List<string> _songFileNames;
        protected string SongFileName;
        private Status _status = Status.Stopped;
        private readonly Timer _timer = new Timer();
        private bool _wasInactiveByMinVolume;

        private enum Status
        {
            Stopped,
            Playing,
            Paused
        }

        public Player(string directory, int volume)
        {
            _directory = directory;
            SetAudioVolume(volume);
            InitTimer();
        }

        public virtual void Play()
        {
            if (IsAudioPaused)
                PlayAudio();
            else if (IsAudioStopped)
                PlayNext();
        }

        public virtual bool PlayNext()
        {
            bool ret = false;
            try
            {
                GetNextSong();
                Stop();
                if (ExistsSongFile)
                {
                    LoadSong();
                    PlayAudio();
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            return ret;
        }

        public virtual void Pause()
        {
            try
            {
                _status = Status.Paused;
                if (_audio != null)
                    _audio.Pause();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void SetAudioVolume(int volume)
        {
            try
            {
                _volume = volume;
                CheckToPauseOrRestartByVolume();
                _wasInactiveByMinVolume = HasMinVolume;
                if (_audio != null)
                    _audio.Volume = SoundHelper.LimitVolume(volume);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CheckToPauseOrRestartByVolume()
        {
            if (_status == Status.Playing)
            {
                if (HasMinVolume)
                    Pause();
                else if (_wasInactiveByMinVolume)
                    Play();
            }
        }

        private bool HasMinVolume
        {
            get { return _volume == (int) Volume.Min; }
        }

        protected void Stop()
        {
            try
            {
                _status = Status.Stopped;
                if (_audio != null)
                    _audio.Stop();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private bool ExistsSongFile
        {
            get { return File.Exists(SongFileName); }
        }

        private bool IsAudioPaused
        {
            get { return _audio != null && _audio.Paused; }
        }

        private bool IsAudioPlaying
        {
            get { return _audio != null && _audio.Playing; }
        }

        protected bool IsAudioStopped
        {
            get { return !IsAudioPlaying || IsAudioAtEndPosition; }
        }

        private bool IsAudioAtEndPosition
        {
            get { return _audio != null && _audio.CurrentPosition >= _audio.Duration; }
        }

        private List<string> SongFileNames
        {
            get
            {
                if (_songFileNames == null || _songFileNames.Count == 0)
                    GetMp3Files();
                return _songFileNames;
            }
        }

        private void PlayAudio()
        {
            try
            {
                _status = Status.Playing;
                _audio.Play();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void LoadSong()
        {
            try
            {
                if (_audio == null)
                {
                    _audio = new Audio(SongFileName);
                    _audio.Ending += AudioEnding;
                }
                _audio.Open(SongFileName);
                SetAudioVolume(_volume);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected virtual void AudioEnding(object sender, EventArgs e)
        {
            try
            {
                PlayNext();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected virtual void GetNextSong()
        {
            if (SongFileNames.Count > 0)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                int index = random.Next(0, SongFileNames.Count);
                SongFileName = string.Copy(SongFileNames[index]);
                SongFileNames.RemoveAt(index);
            }
        }

        private void GetMp3Files()
        {
            string[] songFileNames = Directory.GetFiles(_directory, "*.mp3", SearchOption.AllDirectories);
            _songFileNames = new List<string>(songFileNames);
        }

        private void InitTimer()
        {
            _timer.Enabled = true;
            _timer.Interval = 3000;
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (_status == Status.Playing && IsAudioStopped)
                {
                    _status = Status.Stopped;
                    PlayNext();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}
