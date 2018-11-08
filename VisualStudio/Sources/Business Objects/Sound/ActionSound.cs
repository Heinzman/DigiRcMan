using NAudio.Wave;

namespace Elreg.BusinessObjects.Sound
{
    public class ActionSound
    {
        public bool VaryFrequency { get; set; }

        public Specialsound Specialsound { get; set; }

        public WaveOutEvent WaveOutEvent { get; set; }
    }
}