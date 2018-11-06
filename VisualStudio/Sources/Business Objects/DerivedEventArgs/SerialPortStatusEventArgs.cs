namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class SerialPortStatusEventArgs : System.EventArgs
    {
        public SerialPortStatusEventArgs(SerialPortStatus status)
        {
            Status = status;
        }

        public SerialPortStatus Status { get; set; }
    }

}
