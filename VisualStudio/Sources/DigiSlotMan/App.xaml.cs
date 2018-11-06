using System;
using System.Threading.Tasks;
using System.Windows;
using Catel.Logging;

namespace Heinzman.DigiSlotMan
{
    public partial class App
    {
        const string DllPath = "Heinzman.DigiSlotMan.DllsAsResource.";

        static App()
        {
#if !DEBUG_
            ResolveAssemlies();
#endif
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
            TaskScheduler.UnobservedTaskException += (sender, excArgs) => excArgs.SetObserved();
        }

        static void ResolveAssemlies()
        {
            AssemblyResolver assemblyResolver = new AssemblyResolver(DllPath);
            assemblyResolver.DoWork();
        }

        static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
                LogManager.GetCurrentClassLogger().Error(ex);
        }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            Starter starter = new Starter();
            starter.DoWork();
        }
    }
}
