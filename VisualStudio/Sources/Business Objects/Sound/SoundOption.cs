namespace Elreg.BusinessObjects.Sound
{
    public class SoundOption
    {
        public SoundOption()
        {
            SpecialSound = (int) Specialsound.None;
        }

        public string SoundPath { get; set; }

        public int SpecialSound { get; set; }
    }
}