using System;
using System.Runtime.InteropServices;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.Log;

namespace Elreg.ParallelPort
{
    public class PortWriter : IParallelPortWriter
    {
        private readonly ParallelPortSettings _parallelPortSettings;
        private readonly bool _invertOutputValues;
        public int CurrentValue { get; private set; }

        [DllImport("Dlls\\inpout32.dll", EntryPoint = "Out32")]
        private static extern void Output(int adress, int value);

        public PortWriter(ParallelPortSettings parallelPortSettings, bool invertOutputValues)
        {
            _parallelPortSettings = parallelPortSettings;
            _invertOutputValues = invertOutputValues;
            InitValues();
        }

        private void InitValues()
        {
            CurrentValue = 0;
            WriteValue(CurrentValue);
        }

        public void WriteValue(int value)
        {
            try
            {
                int adaptedValue = value;
                if (_invertOutputValues)
                    adaptedValue = Invert(value);
                Output(PortAddress, value);
                CurrentValue = adaptedValue;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private int Invert(int value)
        {
            byte binValue = (byte)value;
            byte invertedByte = (byte)(~binValue);
            return invertedByte;
        }

        private int PortAddress
        {
            get { return _parallelPortSettings.PortAddess; }
        }

    }
}
