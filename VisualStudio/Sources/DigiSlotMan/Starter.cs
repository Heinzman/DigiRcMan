using System;
using System.Windows;
using Catel.IoC;
using Elreg.BusinessObjectContracts;
using Elreg.BusinessObjects;
using Elreg.DigiRcMan.Properties;
using Elreg.DigiRcMan.Start;
using Elreg.FrameworkContracts;

namespace Elreg.DigiRcMan
{
    public class Starter
    {
        private readonly IPropertySettings _propertySettings = new PropertySettings();
        private static Initializer _initializer;

        public void DoWork()
        {
            try
            { 
                CreatePropertySettings();
                RegisterIocServices();
                StartInitializer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Es ist leider ein Fehler aufgetreten", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StartInitializer()
        {
            CreateInitializer();
            _initializer.StartApp();
        }

        private static void CreateInitializer()
        {
            _initializer = new Initializer();
        }

        private void RegisterIocServices()
        {
            ServiceLocator.Default.RegisterInstance(_propertySettings);
        }

        private void CreatePropertySettings()
        {
            _propertySettings.AlwaysShowExceptionMessages = Settings.Default.AlwaysShowExceptionMessages;
            _propertySettings.MusicActivated = Settings.Default.MusicActivated;
            _propertySettings.SoundActivated = Settings.Default.SoundActivated;
            _propertySettings.TraceAutoFlush = Settings.Default.TraceAutoFlush;
            _propertySettings.Tracing = Settings.Default.Tracing;
            _propertySettings.UseMockVcuSerialPortReader = Settings.Default.UseMockVcuSerialPortReader;
            _propertySettings.AutoPauseAfterStart = Settings.Default.AutoPauseAfterStart;
        }
    }
}
