using Microsoft.DirectX.DirectSound;

namespace Elreg.BusinessObjects.Sound
{
    public class BufferSound
    {
        public BufferSound(SecondaryBuffer secondaryBuffer, bool varyFrequency)
        {
            SecondaryBuffer = secondaryBuffer;
            VaryFrequency = varyFrequency;
        }

        public SecondaryBuffer SecondaryBuffer { get; private set; }

        public bool VaryFrequency { get; set; }
    }
}