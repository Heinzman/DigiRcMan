namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class RaceChangedEventArgs : System.EventArgs
    {
        public RaceChangedEventArgs()
        {
            WasJustStarted = false;
            WasJustPaused = false;
            WasJustRestartedOrRestartCountDown = false;
            HasJustCountDownBegan = false;
            WasJustFinished = false;
            WasJustStopped = false;
            WasJustSetWaitForStart = false;
        }

        public bool WasJustSetWaitForStart { get; set; }

        public bool WasJustStopped { get; set; }

        public bool WasJustFinished { get; set; }

        public bool HasJustCountDownBegan { get; set; }

        public bool WasJustRestartedOrRestartCountDown { get; set; }

        public bool WasJustPaused { get; set; }

        public bool WasJustStarted { get; set; }
    }

}
