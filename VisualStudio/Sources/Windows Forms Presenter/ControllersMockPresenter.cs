using System;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.PortActions;
using Elreg.Log;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter
{
    public class ControllersMockPresenter
    {
        private readonly IControllersMockView _controllersMockView;
        private readonly ISerialPortParser _serialPortParser;
        private CarControllersAction _carControllersAction;
        private LapDetectionAction _lapDetectionAction;
        private bool _existsLapDetectionAction;

        public ControllersMockPresenter(IControllersMockView controllersMockView, ISerialPortParser serialPortParser)
        {
            _controllersMockView = controllersMockView;
            _serialPortParser = serialPortParser;
            AttachEvents();
            ShowControllersMockView();
        }

        private void AttachEvents()
        {
            _serialPortParser.GetControllersData += SerialPortParserGetControllersData;
        }

        private void SerialPortParserGetControllersData(object sender, BusinessObjects.DerivedEventArgs.PortParserMockEventArgs e)
        {
            try
            {
                DetermineLapDetectionAction();
                DetermineCarControllersAction();

                e.CarControllersAction = _carControllersAction;
                e.LapDetectionAction = _lapDetectionAction;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void DetermineCarControllersAction()
        {
            if (_existsLapDetectionAction)
                _carControllersAction = null;
            else
                CreateCarControllersAction();
        }

        private void DetermineLapDetectionAction()
        {
            _lapDetectionAction = _controllersMockView.LapDetectionAction;
            _existsLapDetectionAction = _lapDetectionAction.Car1 && _lapDetectionAction.Car2 && _lapDetectionAction.Car3 && 
                                     _lapDetectionAction.Car4 && _lapDetectionAction.Car5 && _lapDetectionAction.Car6;
        }

        private void CreateCarControllersAction()
        {
            _carControllersAction = _controllersMockView.CarControllersAction;
        }

        private void ShowControllersMockView()
        {
            _controllersMockView.Show();
        }
    }
}
