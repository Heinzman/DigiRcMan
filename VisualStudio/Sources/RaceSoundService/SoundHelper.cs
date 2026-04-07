namespace Elreg.RaceSoundService
{
    public static class SoundHelper
    {
        public static int LimitVolume(int volume)
        {
            int limitedVolume = volume;
            // Use the project's SoundMixer volume limits (replace DirectSound constants with our own)
            var max = Elreg.BusinessObjects.Sound.SoundMixer.MaximumVolume;
            var min = Elreg.BusinessObjects.Sound.SoundMixer.MinimumVolume;
            if (volume > max)
                limitedVolume = max;
            else if (volume < min)
                limitedVolume = min;
            return limitedVolume;
        }
    }
}
