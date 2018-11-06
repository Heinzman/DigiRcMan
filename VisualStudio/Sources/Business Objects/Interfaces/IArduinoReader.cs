namespace Elreg.BusinessObjects.Interfaces
{
    public interface IArduinoReader
    {
        event Delegates.SsdControllerHandler UpperButtonClicked;
        event Delegates.SsdControllerHandler PauseOrRestartRequested;
    }
}
