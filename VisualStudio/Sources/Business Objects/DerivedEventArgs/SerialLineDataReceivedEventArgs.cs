namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class SerialLineDataReceivedEventArgs : System.EventArgs
    {
        public SerialLineDataReceivedEventArgs(string line)
        {
            Line = line;
        }

        public string Line { get; set; }
    }
}