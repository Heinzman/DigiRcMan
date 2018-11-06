using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Sound;
using Elreg.ResourcesService;
using Microsoft.DirectX.DirectSound;
using Elreg.Log;
using System.Windows.Forms;

namespace Elreg.RaceSound
{
    public class CountDownSoundHandler : IRaceStatusObserver
    {
        private readonly IRaceModel _raceModel;
        private readonly SoundMixer _soundMixer;
        private readonly Device _device;
        private BufferDescription _bufferDescription;
        private readonly Dictionary<CountDownEventArgs.TypeEnum, SecondaryBuffer> _buffers = new Dictionary<CountDownEventArgs.TypeEnum, SecondaryBuffer>();

        private const string Soundcountdownpath = @"\Sounds\CountDown\";
        private const string Soundfive = "five.wav";
        private const string Soundfour = "four.wav";
        private const string Soundthree = "three.wav";
        private const string Soundtwo = "two.wav";
        private const string Soundone = "one.wav";
        private const string Soundstart = "Start.wav";

        public CountDownSoundHandler(IRaceModel raceModel, Device device, SoundMixer soundMixer)
        {
            _raceModel = raceModel;
            _soundMixer = soundMixer;
            _device = device;
            _raceModel.CountDownModel.CountDownChanged += CountDownModelCountDownChanged;
            AttachToModelAsObserver();
        }

        public void Init()
        {
            try
            {
                InitBufferDescription();
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

        private void InitBufferDescription()
        {
            _bufferDescription = new BufferDescription
                                     {
                                         Flags = BufferDescriptionFlags.ControlVolume | BufferDescriptionFlags.ControlFrequency |
                                                 BufferDescriptionFlags.ControlPan,
                                         GlobalFocus = true
                                     };
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
                SecondaryBuffer buffer = CreateSoundBuffer(type);
                if (buffer != null)
                    _buffers.Add(type, buffer);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private SecondaryBuffer CreateSoundBuffer(CountDownEventArgs.TypeEnum type)
        {
            SecondaryBuffer buffer;
            switch (type)
            {
                case CountDownEventArgs.TypeEnum.Count5:
                    buffer = new SecondaryBuffer(FilePathFive, _bufferDescription, _device);
                    break;
                case CountDownEventArgs.TypeEnum.Count4:
                    buffer = new SecondaryBuffer(FilePathFour, _bufferDescription, _device);
                    break;
                case CountDownEventArgs.TypeEnum.Count3:
                    buffer = new SecondaryBuffer(FilePathThree, _bufferDescription, _device);
                    break;
                case CountDownEventArgs.TypeEnum.Count2:
                    buffer = new SecondaryBuffer(FilePathTwo, _bufferDescription, _device);
                    break;
                case CountDownEventArgs.TypeEnum.Count1:
                    buffer = new SecondaryBuffer(FilePathOne, _bufferDescription, _device);
                    break;
                case CountDownEventArgs.TypeEnum.Go:
                    buffer = new SecondaryBuffer(FilePathStart, _bufferDescription, _device);
                    break;
                default:
                    buffer = null;
                    break;
            }
            return buffer;
        }

        private SecondaryBuffer GetSoundBufferToPlay(CountDownEventArgs.TypeEnum type)
        {
            SecondaryBuffer buffer;

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
                SecondaryBuffer buffer = GetSoundBufferToPlay(e.Type);
                if (buffer != null)
                {
                    buffer.Volume = _soundMixer.CountDownVolumeAdapted;
                    buffer.Play(0, BufferPlayFlags.Default);
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
