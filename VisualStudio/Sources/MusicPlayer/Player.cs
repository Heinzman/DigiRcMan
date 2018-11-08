using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using Elreg.Log;
using Elreg.RaceSoundService;
using NAudio.Wave;

namespace Elreg.MusicPlayer
{
    public class Player : IPlayer
    {
        private readonly string _directory;
        private int _volume;
        private WaveOutEvent _waveOutEvent = new WaveOutEvent();
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
                _waveOutEvent?.Pause();
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
                if (_waveOutEvent != null)
                    _waveOutEvent.Volume = SoundHelper.LimitVolume(volume);
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
            get { return _volume == 0; }
        }

        protected void Stop()
        {
            try
            {
                _status = Status.Stopped;
                _waveOutEvent?.Stop();
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
            get { return _status == Status.Paused; }
        }

        private bool IsAudioPlaying
        {
            get { return _status == Status.Playing; }
        }

        protected bool IsAudioStopped
        {
            get { return !IsAudioPlaying || IsAudioAtEndPosition; }
        }

        private bool IsAudioAtEndPosition
        {
            get { return _waveOutEvent != null && _waveOutEvent.GetPosition() >= _waveOutEvent.NumberOfBuffers; } // todo
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
                _waveOutEvent.Play();
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
                if (_waveOutEvent == null)
                {
                    _waveOutEvent = new WaveOutEvent();
                    // todo _waveOutEvent.Ending += AudioEnding;
                }
                var audioFileReader = new AudioFileReader(SongFileName);
                _waveOutEvent.Init(audioFileReader);
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
