namespace Elreg.RaceSoundService
{
    public static class SoundHelper
    {
        public static int LimitVolume(int volume)
        {
            const int VolumeMax = 1000;
                const int VolumeMin = 0;
                
            int limitedVolume = volume;
            if (volume > (int)VolumeMax)
                limitedVolume = (int)VolumeMax;
            else if (volume < (int)VolumeMin)
                limitedVolume = (int)VolumeMin;
            return limitedVolume;
        }
    }
}
