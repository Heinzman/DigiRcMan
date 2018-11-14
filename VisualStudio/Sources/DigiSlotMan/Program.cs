using System;
using System.Threading.Tasks;
using Elreg.Log;

namespace Elreg.DigiRcMan
{
    static class Program
    {
        const string DllPath = "Elreg.DigiRcMan.DllsAsResource.";

        [STAThread]
        static void Main()
        {
#if !DEBUG_
            ResolveAssemlies();
#endif
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
            TaskScheduler.UnobservedTaskException += (sender, excArgs) => excArgs.SetObserved();
            Starter starter = new Starter();
            starter.DoWork();
        }

        static void ResolveAssemlies()
        {
            AssemblyResolver assemblyResolver = new AssemblyResolver(DllPath);
            assemblyResolver.DoWork();
        }

        static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
                ErrorLog.LogError(false, ex);
        }

    }
}
