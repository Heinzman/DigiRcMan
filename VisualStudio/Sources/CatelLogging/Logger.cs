using System;
using Catel.Logging;
using Elreg.FrameworkContracts;

namespace Elreg.CatelLogging
{
    public class Logger : ILogger
    {
        public void Log(Exception ex)
        {
            LogManager.GetCurrentClassLogger().ErrorWithData(ex.Message, ex.StackTrace);
        }

        public void Debug(string msg)
        {
            LogManager.GetCurrentClassLogger().Debug(msg);
        }
    }
}
