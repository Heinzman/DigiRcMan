using System;
using System.Windows.Forms;
using System.Drawing;
using Elreg.Log;

namespace Elreg.Controls
{
    public class ColoredCheckbox : CheckBox
    {
        private Image _checkedBackgroundImage;
        private Image _uncheckedBackgroundImage;

        public ColoredCheckbox()
        {
            CheckedChanged += ColoredCheckboxCheckedChanged;
        }

        public Image UncheckedBackgroundImage
        {
            get { return _uncheckedBackgroundImage; }
            set { _uncheckedBackgroundImage = value; }
        }

        public Image CheckedBackgroundImage
        {
            get { return _checkedBackgroundImage; }
            set { _checkedBackgroundImage = value; }
        }

        public new bool Checked
        {
            get { return base.Checked; }
    
            set
            {
                base.Checked = value;
                SetBackColor();
            }
        }

        private void ColoredCheckboxCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SetBackColor();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SetBackColor()
        {
            if (base.Checked)
                SwitchToGreen();
            else
                RestoreCheckbox();
        }

        private void RestoreCheckbox()
        {
            base.BackColor = Parent.BackColor;
            BackgroundImage = _uncheckedBackgroundImage;
        }

        private void SwitchToGreen()
        {
            base.BackColor = Color.LightGreen;
            BackgroundImage = _checkedBackgroundImage;
        }
    }
}
