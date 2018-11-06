using System.Windows.Forms;
using Elreg.Controls;

namespace Elreg.WinFormsPresentationFramework
{
    public static class GuiHelper
    {
        public static void SetColoredImageForCheckboxes(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is ColoredCheckbox)
                {
                    ColoredCheckbox coloredCheckbox = control as ColoredCheckbox;
                    coloredCheckbox.CheckedBackgroundImage = Resources.Resources.glossymetal_green;
                }
                SetColoredImageForCheckboxes(control.Controls);
            }
        }

    }
}
