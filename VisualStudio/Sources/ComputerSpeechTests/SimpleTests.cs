using System.Threading.Tasks;
using Elreg.ComputerSpeech;
using NUnit.Framework;

namespace ComputerSpeechTests
{
    [TestFixture]
    public class SimpleTests
    {
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
            Speech speech = new Speech("Mannie erster, 20", 0);
            speech.Speak();
            await Task.Delay(5000);
        }

        [Test]
        public async Task TestSpeakThreeSentences()
        {
            SpeechHandler speakerHandler = new SpeechHandler();

            speakerHandler.AddTextToQueueAndSpeak("Heinz zweiter, 1.");
            speakerHandler.AddTextToQueueAndSpeak("Mannie erster, 20.");
            speakerHandler.AddTextToQueueAndSpeak("Steg dritter, 15.");

            await Task.Delay(20000);
        }

        [Test]
        public async Task TestSpeakSixSentences()
        {
            SpeechHandler speakerHandler = new SpeechHandler();

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
