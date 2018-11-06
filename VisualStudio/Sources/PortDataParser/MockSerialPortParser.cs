using System;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.PortActions;
using Elreg.Log;

namespace Elreg.PortDataParser
{
    public class MockSerialPortParser : ISerialPortParser
    {
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private readonly PortParserEventArgs _portParserEventArgs = new PortParserEventArgs();

        public event EventHandler<PortParserEventArgs> DataReceived;
        public event EventHandler<PortParserMockEventArgs> GetControllersData;
        public event EventHandler StartStopRequested;
        public event EventHandler ImAliveDetected;

        public MockSerialPortParser()
        {
            InitTimer();
        }

        private void InitTimer()
        {
            _timer.Enabled = true;
            _timer.Interval = 100;
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                DeterminePortParserEventArgs();

                if (DataReceived != null)
                    DataReceived(this, _portParserEventArgs);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void DeterminePortParserEventArgs()
        {
            if (GetControllersData != null)
            {
                PortParserMockEventArgs portPortParserMockEventArgs = new PortParserMockEventArgs();
                GetControllersData(this, portPortParserMockEventArgs);
                _portParserEventArgs.CarControllersAction = portPortParserMockEventArgs.CarControllersAction;
                _portParserEventArgs.LapDetectionAction = portPortParserMockEventArgs.LapDetectionAction;
            }
            else
            {
                _portParserEventArgs.CarControllersAction = new CarControllersAction();
                _portParserEventArgs.LapDetectionAction = new LapDetectionAction();
            }
        }
    }
}
