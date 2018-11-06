using Microsoft.DirectX;

namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class ActionSoundPlayed3DEventArgs : System.EventArgs
    {
        public Vector3 Position { get; private set; }
        public bool IsPlaying { get; private set; }
        public bool ForEveryBody { get; set; }

        public ActionSoundPlayed3DEventArgs(Vector3 position, bool isPlaying, bool forEveryBody)
        {
            Position = position;
            IsPlaying = isPlaying;
            ForEveryBody = forEveryBody;
        }
    }
}