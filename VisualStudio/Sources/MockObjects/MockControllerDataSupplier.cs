using System;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.PortActions;
using Elreg.Log;

namespace Elreg.UnitTests.MockObjects
{
    public class MockControllerDataSupplier
    {
        private readonly CarControllersAction _carControllersAction = new CarControllersAction();
        private LapDetectionAction _lapDetectionAction;
        private bool _existsLapDetectionAction;

        public MockControllerDataSupplier(ISerialPortParser serialPortParser)
        {
            serialPortParser.GetControllersData += PortParserGetControllersData;
        }

        private void PortParserGetControllersData(object sender, PortParserMockEventArgs e)
        {
            try
            {
                e.CarControllersAction = _carControllersAction;
                if (_existsLapDetectionAction)
                {
                    e.LapDetectionAction = ClonedLapDetectionAction;
                    _existsLapDetectionAction = false;
                }
                else
                    e.LapDetectionAction = null;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private LapDetectionAction ClonedLapDetectionAction
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
                                                          Car6 = _lapDetectionAction.Car6
                                                      };
                return lapDetectionAction;
            }
        }

        public void SetFinishActionFor(LaneId laneId)
        {
            _lapDetectionAction = new LapDetectionAction();

            switch (laneId)
            {
                case LaneId.Lane1:
                    _lapDetectionAction.Car1 = true;
                    break;
                case LaneId.Lane2:
                    _lapDetectionAction.Car2 = true;
                    break;
                case LaneId.Lane3:
                    _lapDetectionAction.Car3 = true;
                    break;
                case LaneId.Lane4:
                    _lapDetectionAction.Car4 = true;
                    break;
                case LaneId.Lane5:
                    _lapDetectionAction.Car5 = true;
                    break;
                case LaneId.Lane6:
                    _lapDetectionAction.Car6 = true;
                    break;
            }
            _existsLapDetectionAction = true;
        }

        public void SetCarControllersActionFor(LaneId laneId, uint speed, bool laneChange)
        {
            CarController carController = null;
            switch (laneId)
            {
                case LaneId.Lane1:
                    carController = _carControllersAction.CarController1;
                    break;
                case LaneId.Lane2:
                    carController = _carControllersAction.CarController2;
                    break;
                case LaneId.Lane3:
                    carController = _carControllersAction.CarController3;
                    break;
                case LaneId.Lane4:
                    carController = _carControllersAction.CarController4;
                    break;
                case LaneId.Lane5:
                    carController = _carControllersAction.CarController5;
                    break;
                case LaneId.Lane6:
                    carController = _carControllersAction.CarController6;
                    break;
            }
            if (carController != null)
            {
                carController.Speed = speed;
                carController.LaneChange = laneChange;
            }
        }

    }
}
