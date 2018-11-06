namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class ActionSoundPlayedStereoEventArgs : System.EventArgs
    {
        public bool ForEveryBody { get; set; }
        public int StereoPan { get; private set; }
        public bool IsPlaying { get; private set; }

        public ActionSoundPlayedStereoEventArgs(int stereoPan, bool isPlaying, bool forEveryBody)
        {
            ForEveryBody = forEveryBody;
            StereoPan = stereoPan;
            IsPlaying = isPlaying;
        }
    }
}