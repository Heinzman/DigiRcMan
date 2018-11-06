using System;

namespace Elreg.FrameworkContracts
{
    public interface ILogger
    {
        void Log(Exception ex);
        void Debug(string msg);
    }
}