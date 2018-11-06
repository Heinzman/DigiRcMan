using System;
using System.Collections.Generic;
using System.Text;

namespace Heinzman.ParallelPortReader
{
    public interface IParallelPortObserver
    {
        void ParallelPortDataReceived(object sender, int value);
    }
}
