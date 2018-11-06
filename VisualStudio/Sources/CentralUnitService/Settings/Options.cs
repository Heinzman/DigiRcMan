using System;
using System.ComponentModel;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Options;

// ReSharper disable MemberCanBePrivate.Global
namespace Elreg.CentralUnitService.Settings
{
    [Serializable]
    public class Options : INotifyPropertyChanged
    {
        public const string PropNameIsCentralUnitActivated = "IsCentralUnitActivated";

        public event PropertyChangedEventHandler PropertyChanged;

        public bool ShouldCarStopDueEmptyTank { get; set; }

        public bool IsDebugMode { get; set; }

        public bool IsPauseByArduinoActivated { get; set; }

        public uint GlobalMaxLevel { get; set; }

        public StutterSettings StutterOptions { get; set; }

        public DelaySettings DelayOptions { get; set; }

        public TurboSettings TurboOptions { get; set; }

        public EngineDamageSettings EngineDamageSettings { get; set; }

        public SsdCtrlConfigSettings SsdCtrlConfigSettings { get; set; }

        public PwmDataConfigSettings PwmDataConfigSettings { get; set; }

        public RocketSettings RocketSettings { get; set; }

        public VirtualControllers VirtualControllerNames { get; set; }

        public Options()
        {
            IsCentralUnitActivated = false;
            GlobalMaxLevel = (uint)ControllerLevel.L15;
            StutterOptions = new StutterSettings();
            DelayOptions = new DelaySettings();
            TurboOptions = new TurboSettings();
            VirtualControllerNames = new VirtualControllers();
            EngineDamageSettings = new EngineDamageSettings();
            RocketSettings = new RocketSettings();
            SsdCtrlConfigSettings = new SsdCtrlConfigSettings();
            PwmDataConfigSettings = new PwmDataConfigSettings();
        }

        public bool IsCentralUnitActivated { get; set; }

        public bool IsToggleModeActivated { get; set; }

        public void RaiseEventPropertyChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, null);
        }

        public class VirtualControllers
        {
            public string Name1 { get; set; }
            public string Name2 { get; set; }
            public string Name3 { get; set; }
            public string Name4 { get; set; }
            public string Name5 { get; set; }
            public string Name6 { get; set; }
        }

        public enum FuelConsumptionOfSlowerCars
        {
            Equal,
            ABitLess,
            Less,
            MuchLess
        }


    }
}
