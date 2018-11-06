using System.Windows.Forms;
using Elreg.WinFormsPresentationFramework.Forms;

namespace Elreg.WinFormsPresentationFramework
{
    public class LargeMessageBoxHandler
    {
        private readonly IWin32Window _ownerWindow;
        private LargeMessageBox _largeMessageBox;

        public LargeMessageBoxHandler(IWin32Window ownerWindow)
        {
            _ownerWindow = ownerWindow;
        }

        public LargeMessageBoxHandler()
        {
            _ownerWindow = null;
        }

        public DialogResult ShowDialog(string text)
        {
            CreateLargeMessageBox(text);
            _largeMessageBox.ShowDialog();
            return _largeMessageBox.DialogResult;
        }

        private void CreateLargeMessageBox(string text)
        {
            if (_ownerWindow != null)
                _largeMessageBox = new LargeMessageBox(text, _ownerWindow);
            else
                _largeMessageBox = new LargeMessageBox(text);
        }
    }
}
