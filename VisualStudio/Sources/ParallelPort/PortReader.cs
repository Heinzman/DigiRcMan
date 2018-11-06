using System;
using System.Runtime.InteropServices;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.Log;

namespace Elreg.ParallelPort
{
    public class PortReader : IParallelPortReader
    {
        public delegate void PortDataReceivedHandler(object sender, int value);

        private readonly ParallelPortSettings _parallelPortSettings;
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private int _portValue;

        [DllImport("Dlls\\inpout32.dll", EntryPoint = "Inp32")]
        private static extern int Input(int portAddress);

        public PortReader(ParallelPortSettings parallelPortSettings)
        {
            _parallelPortSettings = parallelPortSettings;
            InitValues();
            InitTimer();
        }

        #region IParallelPortReader Members

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public int PortValue
        {
            get
            {
                ReadPortValue();
                return _portValue;
            }
        }

        public void Attach(IParallelPortObserver parallelPortObserver)
        {
            PortDataReceived += parallelPortObserver.ParallelPortDataReceived;
        }

        public void Detach(IParallelPortObserver parallelPortObserver)
        {
            PortDataReceived -= parallelPortObserver.ParallelPortDataReceived;
        }

        public int PortAddress
        {
            get { return _parallelPortSettings.PortAddess; }
            set { _parallelPortSettings.PortAddess = value; }
        }

        #endregion

        public event PortDataReceivedHandler PortDataReceived;

        private void InitValues()
        {
            _portValue = 0;
        }

        private void InitTimer()
        {
            _timer.Elapsed += TimerElapsed;
            _timer.Interval = _parallelPortSettings.TimerInterval;
            _timer.Start();
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                ReadPortValue();
                RaiseEventPortDataReceived();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ReadPortValue()
        {
           _portValue = Input(PortAddress);
        }

        private void RaiseEventPortDataReceived()
        {
            if (PortDataReceived != null)
                PortDataReceived(this, _portValue);
        }

    }
}