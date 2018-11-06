using System;
using System.Collections.Generic;

namespace Elreg.CentralUnitService.Settings
{
    [Serializable]
    public class PwmDataConfigSettings
    {
        public PwmDataConfigSettings()
        {
            MasterPwmValues = new List<int>();
            SlavePwmValues = new List<int>();
        }

        public List<int> MasterPwmValues { get; set; }
        public List<int> SlavePwmValues { get; set; }
    }
}
