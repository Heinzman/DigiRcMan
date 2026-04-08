using System.Threading;
using System.Speech.Synthesis;

namespace Elreg.ComputerSpeech
{
    public class Speaker
    {
        private readonly string _text;

        public Speaker(string text)
        {
            _text = text;
        }

        public void Speak()
        {
            using (var synth = new SpeechSynthesizer())
            {
                synth.Volume = 100;
                synth.SpeakAsync(_text);
            }
        }

        public void SaveTo(string fileName)
        {
            using (var synth = new SpeechSynthesizer())
            {
                synth.Volume = 100;
                synth.SetOutputToWaveFile(fileName);
                synth.Speak(_text);
            }
        }
    }
}
