namespace Elreg.BusinessObjects.Options
{
    public class SoundSettings
    {
        public string RelSoundsFolder;

        public SoundSettings()
        {
            RelSoundsFolder = ServiceHelper.RelSoundsPath;
        }

        public SoundSettings(string relSoundFolder)
        {
            RelSoundsFolder = relSoundFolder;
        }

    }
}
