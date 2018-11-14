using System;
using Elreg.Log;
using NAudio.Wave;

namespace Elreg.SoundHandling
{
    public class SoundPlayer
    {
        private readonly string _filePath;

        public SoundPlayer(string filePath)
        {
            _filePath = filePath;
        }

        public void Play()
        {
            try
            {
                IWavePlayer player = new WaveOut(WaveCallbackInfo.FunctionCallback());
                var audioFileReader = new AudioFileReader(_filePath);
                player.Init(audioFileReader);
                player.Play();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}
