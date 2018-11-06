namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class SerialLineDataSentEventArgs : System.EventArgs
    {
        public SerialLineDataSentEventArgs(string line)
        {
            Line = line;
        }

        public string Line { get; set; }
    }
}