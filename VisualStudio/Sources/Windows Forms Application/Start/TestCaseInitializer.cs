using System;
using System.Windows.Forms;
using Heinzman.CentralUnitService;
using Heinzman.CentralUnitService.Settings;
using Heinzman.Log;
using Heinzman.MockObjects;
using Heinzman.WindowsFormsApplication.Forms;

namespace Heinzman.WindowsFormsApplication.Start
{
    public class TestCaseInitializer : Initializer
    {
        public override void StartApp()
        {
            try
            {
                InitErrorLogs();
                Init();
                InstantiateStartForm();
                StartForm.Show();
                Application.Run(StartForm);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected override void InstantiateStartForm()
        {
            StartForm = new TestForm(VcuSerialPortReader, VcuSerialPortWriter, VcuSerialPortService, ArduinoWriter);
        }

        protected override void InitCentralUnit()
        {
            CentralUnit = new CentralUnit(RaceModel, CentralUnitOptionsService, ArduinoWriter, VcuSerialPortReader);
        }

        protected override void InitCentralUnitOptionsService()
        {
            CentralUnitOptionsService = new MockCentralUnitOptionsService {Options = CreateCentralUnitOptions()};
        }

        private Options CreateCentralUnitOptions()
        {
            Options options = new Options
                                  {
                                      DelayOptions = { IsActivated = false },
                                      StutterOptions = { IsActivated = false },
                                      TurboOptions = { IsActivated = false }
                                  };
            return options;
        }
    }
}
