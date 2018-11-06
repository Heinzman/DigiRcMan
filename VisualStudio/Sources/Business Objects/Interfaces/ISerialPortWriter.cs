using System;
using System.Collections.Generic;
using Elreg.BusinessObjects.DerivedEventArgs;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface ISerialPortWriter
    {
        event EventHandler<SerialLineDataSentEventArgs> LineDataSent; 

        void Write(List<int> intValues);
    }
}
