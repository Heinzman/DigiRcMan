using System.Threading;
using Elreg.Log;

namespace Elreg.WindowsFormsApplication
{
    public class ThreadExceptionHandler
    {
        public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ErrorLog.LogError(false, e.Exception);
        }
    }
}
