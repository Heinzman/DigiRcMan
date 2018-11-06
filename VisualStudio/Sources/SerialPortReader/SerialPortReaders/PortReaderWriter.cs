using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.SerialPortReader.SerialPortReaders
{
    public class PortReaderWriter : PortReader, ISerialPortWriter
    {
        public PortReaderWriter(ISerialPort serialPort) : base(serialPort) {}

        public event EventHandler<SerialLineDataSentEventArgs> LineDataSent;

        public void Write(List<int> intValues)
        {
            int count = intValues.Count;
            if (SerialPort.IsOpen && count > 0)
            {
                WriteBytesToSerialPort(intValues, count);
                RaiseEventSerialLineDataSent(intValues);
            }
        } 

        private void RaiseEventSerialLineDataSent(IEnumerable<int> intValues)
        {
            if (LineDataSent != null)
            {
                string line = CreateLineString(intValues);
                LineDataSent(this, new SerialLineDataSentEventArgs(line));
            }
        }

        private string CreateLineString(IEnumerable<int> intValues)
        {
            StringBuilder lineBuilder = new StringBuilder();

            foreach (int intValue in intValues)
            {
                lineBuilder.Append(intValue.ToString("X2", CultureInfo.InvariantCulture));
                lineBuilder.Append(" ");
            }
            lineBuilder.Append("\n");
            return lineBuilder.ToString();
        }

        private void WriteBytesToSerialPort(IEnumerable<int> intValues, int count)
        {
            const int offset = 0;
            byte[] bytesToSend = new byte[count];
            int index = 0;
            foreach (int intValue in intValues)
                bytesToSend[index++] = (byte) intValue;

            SerialPort.Write(bytesToSend, offset, count);
        }
    }
}
