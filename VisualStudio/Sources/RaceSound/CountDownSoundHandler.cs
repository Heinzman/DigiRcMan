using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Sound;
using Elreg.ResourcesService;
using Elreg.Log;
using System.Windows.Forms;
using NAudio.Wave;

namespace Elreg.RaceSound
{
    public class CountDownSoundHandler : IRaceStatusObserver
    {
        private readonly IRaceModel _raceModel;
        private readonly SoundMixer _soundMixer;
        private WaveOutEvent _waveOutEvent;
        private readonly Dictionary<CountDownEventArgs.TypeEnum, AudioFileReader> _buffers = new Dictionary<CountDownEventArgs.TypeEnum, AudioFileReader>();

        private const string Soundcountdownpath = @"\Sounds\CountDown\";
        private const string Soundfive = "five.wav";
        private const string Soundfour = "four.wav";
        private const string Soundthree = "three.wav";
        private const string Soundtwo = "two.wav";
        private const string Soundone = "one.wav";
        private const string Soundstart = "Start.wav";

        public CountDownSoundHandler(IRaceModel raceModel, SoundMixer soundMixer)
        {
            _raceModel = raceModel;
            _soundMixer = soundMixer;
            _raceModel.CountDownModel.CountDownChanged += CountDownModelCountDownChanged;
            AttachToModelAsObserver();
        }

        public void Init()
        {
            try
            {
                InitWaveOutEvent();
                CreateSoundBuffers();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AttachToModelAsObserver()
        {
            _raceModel.Attach(this);
        }

        private void InitWaveOutEvent()
        {
            _waveOutEvent = new WaveOutEvent();
        }

        private void CreateSoundBuffers()
        {
            _buffers.Clear();
            CreateAndAddSoundBuffer(CountDownEventArgs.TypeEnum.Count5);
            CreateAndAddSoundBuffer(CountDownEventArgs.TypeEnum.Count4);
            CreateAndAddSoundBuffer(CountDownEventArgs.TypeEnum.Count3);
            CreateAndAddSoundBuffer(CountDownEventArgs.TypeEnum.Count2);
            CreateAndAddSoundBuffer(CountDownEventArgs.TypeEnum.Count1);
            CreateAndAddSoundBuffer(CountDownEventArgs.TypeEnum.Go);
        }

        private void CreateAndAddSoundBuffer(CountDownEventArgs.TypeEnum type)
        {
            try
            {
                AudioFileReader audioFileReader = CreateAudioFileReader(type);
                if (audioFileReader != null)
                    _buffers.Add(type, audioFileReader);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private AudioFileReader CreateAudioFileReader(CountDownEventArgs.TypeEnum type)
        {
            AudioFileReader audioFileReader;
            switch (type)
            {
                case CountDownEventArgs.TypeEnum.Count5:
                    audioFileReader = new AudioFileReader(FilePathFive);
                    break;
                case CountDownEventArgs.TypeEnum.Count4:
                    audioFileReader = new AudioFileReader(FilePathFour);
                    break;
                case CountDownEventArgs.TypeEnum.Count3:
                    audioFileReader = new AudioFileReader(FilePathThree);
                    break;
                case CountDownEventArgs.TypeEnum.Count2:
                    audioFileReader = new AudioFileReader(FilePathTwo);
                    break;
                case CountDownEventArgs.TypeEnum.Count1:
                    audioFileReader = new AudioFileReader(FilePathOne);
                    break;
                case CountDownEventArgs.TypeEnum.Go:
                    audioFileReader = new AudioFileReader(FilePathStart);
                    break;
                default:
                    audioFileReader = null;
                    break;
            }
            return audioFileReader;
        }

        private AudioFileReader GetSoundBufferToPlay(CountDownEventArgs.TypeEnum type)
        {
            AudioFileReader buffer;

            _buffers.TryGetValue(type, out buffer);
            return buffer;
        }

        public static string CountDownSoundPath
        {
            get { return Application.StartupPath + Soundcountdownpath + LanguageManager.LanguagePath; }
        }

        private void CountDownModelCountDownChanged(object sender, CountDownEventArgs e)
        {
            try
            {
                AudioFileReader buffer = GetSoundBufferToPlay(e.Type);
                if (buffer != null)
                {
                    buffer.Volume = _soundMixer.CountDownVolumeAdapted;
                    _waveOutEvent.Init(buffer);
                    _waveOutEvent.Play();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public static string FilePathFive
        {
            get { return CountDownSoundPath + Soundfive; }
        }

        public static string FilePathFour
        {
            get { return CountDownSoundPath + Soundfour; }
        }

        public static string FilePathThree
        {
            get { return CountDownSoundPath + Soundthree; }
        }

        public static string FilePathTwo
        {
            get { return CountDownSoundPath + Soundtwo; }
        }

        public static string FilePathOne
        {
            get { return CountDownSoundPath + Soundone; }
        }

        private static string FilePathStart
        {
            get { return CountDownSoundPath + Soundstart; }
        }

        public void RaceStarted(object sender, EventArgs e) { }

        public void RaceRestarted(object sender, EventArgs e) { }

        public void RacePaused(object sender, EventArgs e) { }

        public void RaceBreaked(object sender, EventArgs e) { }

        public void RaceInitialized(object sender, EventArgs e)
        {
            try
            {
                CreateSoundBuffers();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void RaceFinished(object sender, EventArgs e) { }

        public void RaceStopped(object sender, EventArgs e) { }

        public void RaceUnbreaked(object sender, EventArgs e) { }
    }
}
