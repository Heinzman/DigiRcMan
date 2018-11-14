using System;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.SoundHandling;
using System.Windows.Forms;
using Elreg.Log;

namespace Elreg.RaceActionSound
{
    public class CountDownSoundHandler : IRaceStatusObserver
    {
        private readonly IRaceModel _raceModel;

        private const string Soundcountdownpath = @"\Sounds\CountDown\";
        private const string Soundfive = "five.wav";
        private const string Soundfour = "four.wav";
        private const string Soundthree = "three.wav";
        private const string Soundtwo = "two.wav";
        private const string Soundone = "one.wav";
        private const string Soundstart = "Start.wav";

        public CountDownSoundHandler(IRaceModel raceModel)
        {
            _raceModel = raceModel;
            _raceModel.CountDownModel.CountDownChanged += CountDownModelCountDownChanged;
            AttachToModelAsObserver();
        }

        public static string CountDownSoundPath
        {
            get { return Application.StartupPath + Soundcountdownpath +"\\de\\"; }
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


        private void AttachToModelAsObserver()
        {
            _raceModel.Attach(this);
        }

        private void CountDownModelCountDownChanged(object sender, CountDownEventArgs e)
        {
            try
            {
                string soundFilePath = GetSoundFilePath(e.Type);
                if (!string.IsNullOrEmpty(soundFilePath))
                {
                    SoundPlayer soundPlayer = new SoundPlayer(soundFilePath);
                    soundPlayer.Play();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private string GetSoundFilePath(CountDownEventArgs.TypeEnum type)
        {
            string soundFilePath;

            switch (type)
            {
                case CountDownEventArgs.TypeEnum.Count5:
                    soundFilePath = FilePathFive;
                    break;
                case CountDownEventArgs.TypeEnum.Count4:
                    soundFilePath = FilePathFour;
                    break;
                case CountDownEventArgs.TypeEnum.Count3:
                    soundFilePath = FilePathThree;
                    break;
                case CountDownEventArgs.TypeEnum.Count2:
                    soundFilePath = FilePathTwo;
                    break;
                case CountDownEventArgs.TypeEnum.Count1:
                    soundFilePath = FilePathOne;
                    break;
                case CountDownEventArgs.TypeEnum.Go:
                    soundFilePath = FilePathStart;
                    break;
                default:
                    soundFilePath = null;
                    break;
            }
            return soundFilePath;
        }

        public void RaceStarted(object sender, EventArgs e) { }

        public void RaceRestarted(object sender, EventArgs e) { }

        public void RacePaused(object sender, EventArgs e) { }

        public void RaceBreaked(object sender, EventArgs e) { }

        public void RaceInitialized(object sender, EventArgs e) { }

        public void RaceFinished(object sender, EventArgs e) { }

        public void RaceStopped(object sender, EventArgs e) { }

        public void RaceUnbreaked(object sender, EventArgs e) { }
    }
}
