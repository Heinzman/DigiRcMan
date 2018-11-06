using System;
using Elreg.BusinessObjects.PortActions;
using Elreg.Log;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework;

namespace Elreg.WindowsFormsApplication.FormMocks
{
    public partial class ControllersMockForm : Controls.Forms.Form, IControllersMockView
    {
        private readonly CarControllersAction _carControllersAction = new CarControllersAction();
        private readonly LapDetectionAction _lapDetectionAction = new LapDetectionAction();

        public ControllersMockForm()
        {
            InitializeComponent();
        }

        private void CtlMockControllerLaneChangeButtonPressed(object sender, BusinessObjects.DerivedEventArgs.MockControllerLaneChangeArgs e)
        {
            try
            {
                CarController carController = GetCarController(sender);
                carController.LaneChange = e.IsPressed;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private CarController GetCarController(object sender)
        {
            CarController carController = new CarController();

            if (sender == ctlMockController1)
                carController = _carControllersAction.CarController1;
            else if (sender == ctlMockController2)
                carController = _carControllersAction.CarController2;
            else if (sender == ctlMockController3)
                carController = _carControllersAction.CarController3;
            else if (sender == ctlMockController4)
                carController = _carControllersAction.CarController4;
            else if (sender == ctlMockController5)
                carController = _carControllersAction.CarController5;
            else if (sender == ctlMockController6)
                carController = _carControllersAction.CarController6;

            return carController;
        }

        private void CtlMockControllerLapAdded(object sender, EventArgs e)
        {
            if (sender == ctlMockController1)
                _lapDetectionAction.Car1 = true;
            else if (sender == ctlMockController2)
                _lapDetectionAction.Car2 = true;
            else if (sender == ctlMockController3)
                _lapDetectionAction.Car3 = true;
            else if (sender == ctlMockController4)
                _lapDetectionAction.Car4 = true;
            else if (sender == ctlMockController5)
                _lapDetectionAction.Car5 = true;
            else if (sender == ctlMockController6)
                _lapDetectionAction.Car6 = true;
            _lapDetectionAction.TimeStamp = DateTime.Now;
        }

        private void CtlMockControllerSpeedChanged(object sender, BusinessObjects.DerivedEventArgs.MockControllerSpeedChangedArgs e)
        {
            try
            {
                CarController carController = GetCarController(sender);
                carController.Speed = e.Speed;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public CarControllersAction CarControllersAction
        {
            get { return _carControllersAction; }
        }

        public LapDetectionAction LapDetectionAction
        {
            get
            {
                LapDetectionAction lapDetectionAction = CopyOfLapDetectionAction;
                ClearLapDetectionAction();
                return lapDetectionAction;
            }
        }

        private LapDetectionAction CopyOfLapDetectionAction
        {
            get
            {
                LapDetectionAction lapDetectionAction = new LapDetectionAction
                                                      {
                                                          Car1 = _lapDetectionAction.Car1,
                                                          Car2 = _lapDetectionAction.Car2,
                                                          Car3 = _lapDetectionAction.Car3,
                                                          Car4 = _lapDetectionAction.Car4,
                                                          Car5 = _lapDetectionAction.Car5,
                                                          Car6 = _lapDetectionAction.Car6,
                                                          TimeStamp = _lapDetectionAction.TimeStamp
                                                      };
                return lapDetectionAction;
            }
        }

        private void ClearLapDetectionAction()
        {
            _lapDetectionAction.Car1 = false;
            _lapDetectionAction.Car2 = false;
            _lapDetectionAction.Car3 = false;
            _lapDetectionAction.Car4 = false;
            _lapDetectionAction.Car5 = false;
            _lapDetectionAction.Car6 = false;
        }

        protected override string RegkeyPath
        {
            get { return Constants.RegkeyPath; }
        }

    }
}
