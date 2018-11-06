using Elreg.BusinessObjects;

namespace Elreg.WindowsFormsView
{
    public interface ICtlSsdCtrlConfig
    {
        bool IsSelected(ControllerLevel controllerLevel);
        int GetValueOf(ControllerLevel controllerLevel);
        void SetValueOf(ControllerLevel controllerLevel, int value);
        SsdButtons SsdButtons { get; set; }
    }
}