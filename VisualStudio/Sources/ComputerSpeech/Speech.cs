using System.Speech.Synthesis;

namespace Elreg.ComputerSpeech
{
    public class Speech
    {
        private readonly string _textToSpeak;
        private readonly int _speed;
        private readonly SpeechSynthesizer _speechSynthesizer = new SpeechSynthesizer();

        public Speech(string textToSpeak, int speed)
        {
            _textToSpeak = textToSpeak + ",  ,   !";
            _speed = speed;
            InitializeVoice();
        }

        public void Speak()
        {
            _speechSynthesizer.Speak(_textToSpeak);
        }

        public void SpeakAsync()
        {
            _speechSynthesizer.SpeakAsync(_textToSpeak);
        }

        private void InitializeVoice()
        {
            _speechSynthesizer.Rate = _speed;
        }

    }
}
