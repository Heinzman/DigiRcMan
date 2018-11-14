using System;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.ComputerSpeech;
using Elreg.Log;

namespace Elreg.RaceActionSpeech
{
    public class CountDownSpeechHandler : IRaceStatusObserver
    {
        private readonly IRaceModel _raceModel;
        private readonly SpeechHandler _speachHandler = new SpeechHandler();

        public CountDownSpeechHandler(IRaceModel raceModel)
        {
            _raceModel = raceModel;
            _raceModel.CountDownModel.CountDownChanged += CountDownModelCountDownChanged;
            AttachToModelAsObserver();
        }

        private void AttachToModelAsObserver()
        {
            _raceModel.Attach(this);
        }

        private void CountDownModelCountDownChanged(object sender, CountDownEventArgs e)
        {
            try
            {
                string textToSpeak = GetTextToSpeak(e.Type);
                _speachHandler.AddTextToQueueAndSpeak(textToSpeak);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private string GetTextToSpeak(CountDownEventArgs.TypeEnum type)
        {
            string textToSpeak;

            switch (type)
            {
                case CountDownEventArgs.TypeEnum.Count5:
                    textToSpeak = "Fünf";
                    break;
                case CountDownEventArgs.TypeEnum.Count4:
                    textToSpeak = "Vier";
                    break;
                case CountDownEventArgs.TypeEnum.Count3:
                    textToSpeak = "Drei";
                    break;
                case CountDownEventArgs.TypeEnum.Count2:
                    textToSpeak = "Zwei";
                    break;
                case CountDownEventArgs.TypeEnum.Count1:
                    textToSpeak = "Eins";
                    break;
                case CountDownEventArgs.TypeEnum.Go:
                    textToSpeak = "Los";
                    break;
                default:
                    textToSpeak = string.Empty;
                    break;
            }
            return textToSpeak;
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
