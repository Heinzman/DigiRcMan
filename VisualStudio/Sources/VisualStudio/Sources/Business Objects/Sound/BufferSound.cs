using Microsoft.DirectX.DirectSound;

using Microsoft.DirectX.DirectSound;

namespace Elreg.BusinessObjects.Sound
{
    public class BufferSound
    {
        public SecondaryBuffer SecondaryBuffer { get; private set; }

        public bool VaryFrequency { get; set; }

        public BufferSound(SecondaryBuffer secondaryBuffer, bool varyFrequency)
        {
            SecondaryBuffer = secondaryBuffer;
            VaryFrequency = varyFrequency;
        }
    }
}
