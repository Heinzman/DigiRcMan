using System;
using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface ISimpleView
    {
        DialogResult ShowDialog();
        DialogResult ShowDialog(IWin32Window owner);
        DialogResult InvokeShowDialog();
        void InvokeShowAndFocus();
        void Close();
        void Hide();
        void InvokeHide();
        object Invoke(Delegate method, object[] args);
        object Invoke(Delegate method);
        bool Visible { get; set; }
        FormWindowState WindowState { get; set; }
        string RegKey { get; }
        double Opacity { get; set; }
        void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue);
        bool TopMost { get; set; }
        string Name { get; }
        string Text { get; set; }
        void InvokeShow();
    }
}
