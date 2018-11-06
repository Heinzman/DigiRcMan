using Microsoft.DirectX.DirectSound;

namespace Elreg.RaceSoundService
{
    public static class SoundHelper
    {
        public static int LimitVolume(int volume)
        {
            int limitedVolume = volume;
            if (volume > (int)Volume.Max)
                limitedVolume = (int)Volume.Max;
            else if (volume < (int)Volume.Min)
                limitedVolume = (int)Volume.Min;
            return limitedVolume;
        }
    }
}
