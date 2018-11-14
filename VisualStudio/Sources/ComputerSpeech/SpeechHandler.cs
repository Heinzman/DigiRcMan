using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Elreg.ComputerSpeech
{
    public class SpeechHandler
    {
        private readonly Queue<string> _textQueue = new Queue<string>();
        private bool _inProgress;

        public void AddTextToQueueAndSpeak(string textToSpeak)
        {
            AddTextToQueue(textToSpeak);
            CheckToSpeakAllTexts();
        }

        private async void CheckToSpeakAllTexts()
        {
            if (!_inProgress)
            {
                _inProgress = true;

                while (_textQueue.Count > 0)
                {
                    await SpeakAsync(_textQueue.Dequeue());
                    await Task.Delay(TimeSpan.FromMilliseconds(100));
                }
                _inProgress = false;
            }
        }

        private Task SpeakAsync(string textToSpeak)
        {
            return Task.Factory.StartNew(() =>
            {
                Speech speech = new Speech(textToSpeak, 0);
                speech.Speak();
            });
        }

        private void AddTextToQueue(string textToSpeak)
        {
            _textQueue.Enqueue(textToSpeak);
        }
    }
}
