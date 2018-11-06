using System;
using System.Drawing;
using System.Windows.Forms;
using Elreg.HelperClasses;
using Elreg.Log;
using System.Reflection;

namespace Elreg.Controls.Forms
{
    public class Form : System.Windows.Forms.Form
    {
        private Size _size;
        private Point _location;
        private readonly MainFormSettings _settings = new MainFormSettings();

        private const int Undefined = -999;
        private const int MinLoc = -1500;
        private const int MaxLoc = 3500;

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        protected delegate void VoidHandler();
        private delegate DialogResult DialogHandler();
        private delegate void DialogShowHandler();
        private delegate DialogResult DialogOwnerHandler(IWin32Window owner);
        public delegate void ShowOwnerHandler(IWin32Window owner);

        public event EventHandler FormLoaded;

        protected virtual void OnFormLoaded()
        {
            EventHandler handler = FormLoaded;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private delegate bool BoolHandler();

        public string RegKey
        {
            get { return RegkeyPath + Name; }
        }

        protected Form()
        {
            FormClosing += FormFormClosing;
            Load += FormLoad;
            ResizeEnd += FormResizeEnd;
        }

        public virtual void InvokeShowAndFocus()
        {
            if (InvokeRequired)
            {
                Invoke(new VoidHandler(Show));
                Invoke(new BoolHandler(Focus));
            }
            else
            {
                Show();
                Focus();
            }
        }

        public virtual DialogResult InvokeShowDialog()
        {
            DialogResult dialogResult;
            if (InvokeRequired)
                dialogResult = (DialogResult)Invoke(new DialogHandler(ShowDialog));
            else
                dialogResult = ShowDialog();
            return dialogResult;
        }

        public void InvokeShow()
        {
            if (InvokeRequired)
                Invoke(new DialogShowHandler(Show));
            else
                Show();
        }

        public DialogResult InvokeShowDialog(IWin32Window owner)
        {
            DialogResult dialogResult;
            if (InvokeRequired)
                dialogResult = (DialogResult)Invoke(new DialogOwnerHandler(ShowDialog), owner);
            else
                dialogResult = ShowDialog(owner);
            return dialogResult;
        }

        public void ShowAndHide()
        {
            Show();
            Hide();
        }

        public void InvokeHide()
        {
            if (InvokeRequired)
                BeginInvoke(new VoidHandler(Hide));
            else
                Hide();
        }

        public void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            try
            {
                if (control.InvokeRequired)
                    control.BeginInvoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new[] { control, propertyName, propertyValue });
                else
                    control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new[] { propertyValue });
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected virtual void LoadSettings()
        {
            try
            {
                Savior.Read(_settings, RegKey);

                if (_settings.Location.X != Undefined && _settings.Location.Y != Undefined &&
                    _settings.Location.X > MinLoc && _settings.Location.X < MaxLoc &&
                    _settings.Location.Y > MinLoc && _settings.Location.Y < MaxLoc)
                {
                    Location = _settings.Location;
                    _location = _settings.Location;
                }
                if (FormBorderStyle == FormBorderStyle.Sizable || FormBorderStyle == FormBorderStyle.SizableToolWindow)
                {
                    if (_settings.TheSize.Height != Undefined && _settings.TheSize.Width != Undefined)
                    {
                        Size = _settings.TheSize;
                        _size = _settings.TheSize;
                    }
                    // was form maximized ?
                    if (_settings.Maximized)
                        WindowState = FormWindowState.Maximized;
                    else
                        WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected virtual void SaveSettings()
        {
            try
            {
                FormWindowState formWindowState = WindowState;
                if (formWindowState == FormWindowState.Normal)
                {
                    _size = Size;
                    _location = Location;
                }
                else
                {
                    _size = RestoreBounds.Size;
                    _location = RestoreBounds.Location;
                }
                _settings.Location = _location;
                _settings.TheSize = _size;
                _settings.Maximized = formWindowState == FormWindowState.Maximized;
                Savior.Save(_settings, RegKey);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected virtual string RegkeyPath { get { return string.Empty; } }

        protected void UpdateUi(MethodInvoker uiDelegate)
        {
            if (InvokeRequired)
                Invoke(uiDelegate);
            else
                uiDelegate();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            try
            {
                LoadSettings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void FormFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveSettings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void FormResizeEnd(object sender, EventArgs e)
        {
            try
            {
                _location = Location;
                _size = Size;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private class MainFormSettings
        {
            public Point Location = new Point(0, 0);
            public Size TheSize = new Size(800, 600);
            public bool Maximized = true;
        }

    }
}
