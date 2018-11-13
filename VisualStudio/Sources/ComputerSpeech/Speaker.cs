using System.Threading;
using SpeechLib;

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
            SpVoice voice = new SpVoice {Volume = 100};
            voice.Speak(_text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }

        public void SaveTo(string fileName)
        {
            SpVoice voice = new SpVoice { Volume = 100 };

            const SpeechStreamFileMode spFileMode = SpeechStreamFileMode.SSFMCreateForWrite;
            SpFileStream spFileStream = new SpFileStream();
            spFileStream.Open(fileName, spFileMode);

            voice.AudioOutputStream = spFileStream;
            voice.Speak(_text);
            voice.WaitUntilDone(Timeout.Infinite);

            spFileStream.Close();
        }
    }
}
