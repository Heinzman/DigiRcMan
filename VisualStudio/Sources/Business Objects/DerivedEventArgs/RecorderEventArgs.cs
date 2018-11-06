namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class RecorderEventArgs : System.EventArgs
    {
        public RecorderEventArgs(RecorderStatus status)
        {
            Status = status;
        }

        public RecorderStatus Status { get; set; }
    }

}
