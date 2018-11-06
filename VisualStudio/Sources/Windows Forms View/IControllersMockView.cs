using Elreg.BusinessObjects.PortActions;

namespace Elreg.WindowsFormsView
{
    public interface IControllersMockView
    {
        void Show();
        CarControllersAction CarControllersAction { get; }
        LapDetectionAction LapDetectionAction { get; }
    }
}
