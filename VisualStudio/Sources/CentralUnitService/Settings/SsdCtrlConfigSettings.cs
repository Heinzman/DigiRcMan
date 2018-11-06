using System;
using System.Collections.Generic;

namespace Elreg.CentralUnitService.Settings
{
    [Serializable]
    public class SsdCtrlConfigSettings
    {
        public SsdCtrlConfigSettings()
        {
            ValuesBtnAList = new List<int>();
            ValuesBtnBList = new List<int>();
            ValuesBtnAAndBList = new List<int>();
            ValuesNoBtnsList = new List<int>();
        }

        public List<int> ValuesNoBtnsList { get; set; }
        public List<int> ValuesBtnAList { get; set; }
        public List<int> ValuesBtnBList { get; set; }
        public List<int> ValuesBtnAAndBList { get; set; }
    }
}
