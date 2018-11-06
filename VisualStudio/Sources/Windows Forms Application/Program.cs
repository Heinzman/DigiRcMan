using System;
using Heinzman.WindowsFormsApplication.Start;

namespace Heinzman.WindowsFormsApplication
{
    static class Program
    {
        private static Initializer _initializer;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main__()        
        {
            CreateInitializer();
            _initializer.StartApp();
        }

        private static void CreateInitializer()
        {
            if (Properties.Settings.Default.StartTestCase)
                _initializer = new TestCaseInitializer();
            else if (Properties.Settings.Default.StartCarSound3DTest)
                _initializer = new CarSound3DInitializer();
            else
                _initializer = new Initializer();
        }
    }
}
