using System;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.Log;
using Elreg.WindowsFormsView;
using Elreg.DomainModels;
using Elreg.BusinessObjects.PortActions;

namespace Elreg.WindowsFormsPresenter
{
    public class PortParserLogGuiPresenter 
    {
        private readonly IPortParserLogGuiView _portParserLogGuiView;
        private readonly PortParserLogModel _portParserLogModel;
        private CarControllersAction _carControllersAction;
        private LapDetectionAction _lapDetectionAction;

        public PortParserLogGuiPresenter(IPortParserLogGuiView portParserLogGuiView, PortParserLogModel portParserLogModel)
        {
            try
            {
                _portParserLogGuiView = portParserLogGuiView;
                _portParserLogModel = portParserLogModel;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Attach()
        {
            try
            {
                _portParserLogModel.LogReceived += PortParserLogModelLogReceived;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void Detach()
        {
            try
            {
                _portParserLogModel.LogReceived -= PortParserLogModelLogReceived;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void PortParserLogModelLogReceived(object sender, PortParserEventArgs e)
        {
            try
            {
                _carControllersAction = e.CarControllersAction;
                _lapDetectionAction = e.LapDetectionAction;
                Display();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void Display()
        {
            if (_carControllersAction != null)
            {
                _portParserLogGuiView.Speed1 = _carControllersAction.CarController1.Speed;
                _portParserLogGuiView.Speed2 = _carControllersAction.CarController2.Speed;
                _portParserLogGuiView.Speed3 = _carControllersAction.CarController3.Speed;
                _portParserLogGuiView.Speed4 = _carControllersAction.CarController4.Speed;
                _portParserLogGuiView.Speed5 = _carControllersAction.CarController5.Speed;
                _portParserLogGuiView.Speed6 = _carControllersAction.CarController6.Speed;

                _portParserLogGuiView.LaneChange1 = _carControllersAction.CarController1.LaneChange;
                _portParserLogGuiView.LaneChange2 = _carControllersAction.CarController2.LaneChange;
                _portParserLogGuiView.LaneChange3 = _carControllersAction.CarController3.LaneChange;
                _portParserLogGuiView.LaneChange4 = _carControllersAction.CarController4.LaneChange;
                _portParserLogGuiView.LaneChange5 = _carControllersAction.CarController5.LaneChange;
                _portParserLogGuiView.LaneChange6 = _carControllersAction.CarController6.LaneChange;
            }

            if (_lapDetectionAction != null)
            {
                if (_lapDetectionAction.Car1)
                    _portParserLogGuiView.AddLap1();
                if (_lapDetectionAction.Car2)
                    _portParserLogGuiView.AddLap2();
                if (_lapDetectionAction.Car3)
                    _portParserLogGuiView.AddLap3();
                if (_lapDetectionAction.Car4)
                    _portParserLogGuiView.AddLap4();
                if (_lapDetectionAction.Car5)
                    _portParserLogGuiView.AddLap5();
                if (_lapDetectionAction.Car6)
                    _portParserLogGuiView.AddLap6();
            }
        }

    }
}
