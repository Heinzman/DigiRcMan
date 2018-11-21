using System.Speech.Synthesis;

namespace Elreg.ComputerSpeech
{
    public class Speech
    {
        private readonly int _speed;
        private readonly SpeechSynthesizer _speechSynthesizer = new SpeechSynthesizer();

        public Speech(int speed)
        {
            _speed = speed;
            InitializeVoice();
        }

        public void Speak(string textToSpeak)
        {
            _speechSynthesizer.Speak(textToSpeak);
        }

        public void SpeakAsync(string textToSpeak)
        {
            _speechSynthesizer.SpeakAsync(textToSpeak);
        }

        private void InitializeVoice()
        {
            _speechSynthesizer.Rate = _speed;
        }

    }
}
