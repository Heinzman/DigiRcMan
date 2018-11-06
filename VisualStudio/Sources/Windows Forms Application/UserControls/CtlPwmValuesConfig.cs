using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsApplication.UserControls
{
    public partial class CtlPwmValuesConfig : UserControl
    {
        public CtlPwmValuesConfig()
        {
            InitializeComponent();
        }

        [Description("Sets the Caption"),
         Category("Values"),
         DefaultValue("--"),
         Browsable(true)]
        public string Caption
        {
            get { return lblCaption.Text; }
            set { lblCaption.Text = value; }
        }

        public List<int> PwmValues
        {
            get
            {
                List<int> pwmValues = new List<int>();
                pwmValues.Add((int)updLevel0.Value);
                pwmValues.Add((int)updLevel1.Value);
                pwmValues.Add((int)updLevel2.Value);
                pwmValues.Add((int)updLevel3.Value);
                pwmValues.Add((int)updLevel4.Value);
                pwmValues.Add((int)updLevel5.Value);
                pwmValues.Add((int)updLevel6.Value);
                pwmValues.Add((int)updLevel7.Value);
                pwmValues.Add((int)updLevel8.Value);
                pwmValues.Add((int)updLevel9.Value);
                pwmValues.Add((int)updButtonOff.Value);
                pwmValues.Add((int)updButtonOn.Value);
                return pwmValues;
            }

            set
            {
                updLevel0.Value = value[0];
                updLevel1.Value = value[1];
                updLevel2.Value = value[2];
                updLevel3.Value = value[3];
                updLevel4.Value = value[4];
                updLevel5.Value = value[5];
                updLevel6.Value = value[6];
                updLevel7.Value = value[7];
                updLevel8.Value = value[8];
                updLevel9.Value = value[9];
                updButtonOff.Value = value[10];
                updButtonOn.Value = value[11];
            }
        }
    }
}
