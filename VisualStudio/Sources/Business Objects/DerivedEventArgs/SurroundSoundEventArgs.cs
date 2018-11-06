namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class SurroundSoundEventArgs : System.EventArgs
    {
        public SurroundSoundEventArgs(bool isSurround)
        {
            IsSurround = isSurround;
        }

        public bool IsSurround { get; set; }
    }
}