using System.Collections.Generic;

namespace Elreg.BusinessObjects.Sound
{
    public class SoundOptionList
    {
        public SoundOptionList()
        {
            SoundOptions = new List<SoundOption>();
        }

        public bool VaryFrequency { get; set; }

        public bool Activated { get; set; }

        public List<SoundOption> SoundOptions { get; set; }
    }
}