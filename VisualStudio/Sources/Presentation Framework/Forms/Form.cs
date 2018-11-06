using System;
using System.Windows.Forms;
using Elreg.Log;

namespace Elreg.WinFormsPresentationFramework.Forms
{
    public class Form : Controls.Forms.Form
    {
        protected bool IsHiddenWhenClosed { get; set; }

        protected Form()
        {
            IsHiddenWhenClosed = true;
            SetCursor(this);
            FormClosing += FormFormClosing;
        }

        public static void SetCursor(System.Windows.Forms.Form form)
        {
            form.Cursor = LargeCursor;
        }

        protected static Cursor LargeCursor
        {
            get
            {
                CursorConverter cv = new CursorConverter();
                return (Cursor)cv.ConvertFrom(Resources.Resources.Cursor1);
            }
        }

        protected override string RegkeyPath
        {
            get { return Constants.RegkeyPath; }
        }

        private void FormFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (IsHiddenWhenClosed && e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    Hide();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected void InitControls()
        {
            GuiHelper.SetColoredImageForCheckboxes(Controls);
        }

    }
}
