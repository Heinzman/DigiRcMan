﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Elreg.ComputerSpeech
{
    public class SpeechHandler
    {
        private readonly Queue<string> _textQueue = new Queue<string>();
        private bool _inProgress;
        private readonly Speech _speech;

        public SpeechHandler(int speed)
        {
            _speech = new Speech(speed);
        }

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
                    await SpeakAsync(AllTextToSpeak);
                }
                _inProgress = false;
            }
        }

        public string AllTextToSpeak
        {
            get
            {
                var allTextToSpeak = string.Empty;

                while (_textQueue.Count > 0)
                    allTextToSpeak += _textQueue.Dequeue();

                return allTextToSpeak;
            }
        }

        private Task SpeakAsync(string textToSpeak)
        {
            return Task.Factory.StartNew(() =>
            {
                _speech.Speak(textToSpeak);
            });
        }

        private void AddTextToQueue(string textToSpeak)
        {
            _textQueue.Enqueue(textToSpeak);
        }
    }
}
