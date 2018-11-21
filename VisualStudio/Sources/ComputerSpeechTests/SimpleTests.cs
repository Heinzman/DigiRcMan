using System.Threading.Tasks;
using Elreg.ComputerSpeech;
using NUnit.Framework;

namespace ComputerSpeechTests
{
    [TestFixture]
    public class SimpleTests
    {
        private const int Speed = 0;

        [Test]
        public async void TestSpeakOneSentenceWithSpeaker()
        {
            Speaker speaker = new Speaker("Heinz zweiter, 1.");
            speaker.Speak();
            await Task.Delay(5000);
        }

        [Test]
        public async void TestSpeakOneSentenceWithSpeech()
        {
            Speech speech = new Speech(Speed);
            speech.Speak("Mannie erster 20.");
            await Task.Delay(5000);
        }

        [Test]
        public async Task TestSpeakThreeSentences()
        {
            SpeechHandler speakerHandler = new SpeechHandler(Speed);

            speakerHandler.AddTextToQueueAndSpeak("Heinz zweiter Runde 1, ");
            speakerHandler.AddTextToQueueAndSpeak("Mannie erster Runde 20, ");
            speakerHandler.AddTextToQueueAndSpeak("Steg dritte Runde 15, ");
            speakerHandler.AddTextToQueueAndSpeak("Danny vierter Runde 15, ");
            speakerHandler.AddTextToQueueAndSpeak("Christoph fünfter Runde 15, ");
            speakerHandler.AddTextToQueueAndSpeak("Kumpe sechster Runde 15, ");

            await Task.Delay(20000);
        }

        [Test]
        public async Task TestSpeakSixSentences()
        {
            SpeechHandler speakerHandler = new SpeechHandler(Speed);

            speakerHandler.AddTextToQueueAndSpeak("Heinz zweiter, 1");
            speakerHandler.AddTextToQueueAndSpeak("Mannie erster, 20");
            await Task.Delay(5000);
            speakerHandler.AddTextToQueueAndSpeak("Steg dritter, 15");
            await Task.Delay(5000);
            speakerHandler.AddTextToQueueAndSpeak("Heinz zweiter, 2");
            speakerHandler.AddTextToQueueAndSpeak("Mannie erster, 21");
            await Task.Delay(5000);
            speakerHandler.AddTextToQueueAndSpeak("Steg dritter, 16");
            speakerHandler.AddTextToQueueAndSpeak("Heinz zweiter, 1");
            speakerHandler.AddTextToQueueAndSpeak("Mannie erster, 20");
            await Task.Delay(5000);
            speakerHandler.AddTextToQueueAndSpeak("Steg dritter, 15");
            await Task.Delay(5000);
            speakerHandler.AddTextToQueueAndSpeak("Heinz zweiter, 2");
            speakerHandler.AddTextToQueueAndSpeak("Mannie erster, 21");
            await Task.Delay(5000);
            speakerHandler.AddTextToQueueAndSpeak("Steg dritter, 16");

            await Task.Delay(30000);
        }

    }
}
