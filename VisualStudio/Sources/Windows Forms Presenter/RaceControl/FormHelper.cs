using System.Windows;
using System.Windows.Forms;
using Elreg.WindowsFormsView;
using Form = Elreg.Controls.Forms.Form;

namespace Elreg.WindowsFormsPresenter.RaceControl
{
    public static class FormHelper
    {
        public static void HideForm(ISimpleView form)
        {
            if (form.Visible)
                form.InvokeHide();
        }

        public static void ShowAndFocus(ISimpleView form)
        {
            form.InvokeShowAndFocus();
        }

        public static void ShowDialog(ISimpleView form)
        {
            if (form.Visible == false)
                form.InvokeShowDialog();
        }

        public static void ShowModalDialog(ISimpleView view)
        {
            HideForm(view);
            ShowDialog(view);
        }

        public static void ShowNotModalDialog(ISimpleView view)
        {
            ShowAndFocus(view);
        }

        public static void Show(ISimpleView form)
        {
            if (form.Visible == false)
                form.InvokeShow();
        }

        public static void ShowWpfDialog(Window window)
        {
            StartForm.Invoke((MethodInvoker)(() => window.ShowDialog()));
        }

        public static Form StartForm { get; set; }
    }
}
