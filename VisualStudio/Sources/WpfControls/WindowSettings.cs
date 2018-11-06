using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using Elreg.HelperLib;

namespace Heinzman.WpfControls
{
    public class WindowSettings
    {
        public readonly Window Window;
        private bool _isSavingAllowed = true;
        private readonly SerializerService<UserWindowSettings> _serializerService;
        private UserWindowSettings _userWindowSettings;

        protected WindowSettings(Window window)
        {
            Window = window;
            string path = SystemHelper.UserSettingsPath;
            string fileName = window.DependencyObjectType.Name + "Settings.xml";
            _serializerService = new SerializerService<UserWindowSettings>(path, fileName);
        }

        public static readonly DependencyProperty SaveProperty
            = DependencyProperty.RegisterAttached("Save", typeof(bool), typeof(WindowSettings),
                                                  new FrameworkPropertyMetadata(OnSaveInvalidated));

        public static readonly DependencyProperty SaveOnSizeLocationChangedProperty
            = DependencyProperty.RegisterAttached("SaveOnSizeLocationChanged", typeof(bool), typeof(WindowSettings),
                                                  new FrameworkPropertyMetadata(OnSaveOnSizeLocationChangedInvalidated));

        public static void SetSave(DependencyObject dependencyObject, bool enabled)
        {
            dependencyObject.SetValue(SaveProperty, enabled);
        }

        public static void SetSaveOnSizeLocationChanged(DependencyObject dependencyObject, bool enabled)
        {
            dependencyObject.SetValue(SaveOnSizeLocationChangedProperty, enabled);
        }

        [Browsable(false)]
        protected UserWindowSettings UserWindowSettings
        {
            get
            {
                if (_userWindowSettings == null)
                    _userWindowSettings = new UserWindowSettings();
                return _userWindowSettings;
            }
            set { _userWindowSettings = value; }
        }

        protected virtual void LoadWindowState()
        {
            try
            {
                _isSavingAllowed = false;
                LoadFromFile(); 

                if (UserWindowSettings.Location != Rect.Empty && IsInVisibleArea)
                {
                    Window.Left = UserWindowSettings.Location.Left;
                    Window.Top = UserWindowSettings.Location.Top;
                    Window.Width = UserWindowSettings.Location.Width;
                    Window.Height = UserWindowSettings.Location.Height;
                }

                if (UserWindowSettings.WindowState != WindowState.Maximized)
                    Window.WindowState = UserWindowSettings.WindowState;

            }
            finally
            {
                _isSavingAllowed = true;
            }
        }

        protected void LoadFromFile()
        {
            UserWindowSettings = _serializerService.Object;
        }

        private bool IsInVisibleArea
        {
            get
            {
                bool isInVisibleArea = false;
                const int minimumBorder = 100;
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (UserWindowSettings.Location.X >= screen.Bounds.X - UserWindowSettings.Location.Width + minimumBorder &&
                        UserWindowSettings.Location.X < (screen.Bounds.X + screen.Bounds.Width - minimumBorder))
                    {
                        isInVisibleArea = true;
                        break;
                    }
                }
                return isInVisibleArea;
            }
        }

        private void SaveWindowState()
        {
            if (_isSavingAllowed)
            {
                UserWindowSettings.WindowState = Window.WindowState;
                if (Window.WindowState != WindowState.Normal)
                    UserWindowSettings.Location = Window.RestoreBounds;
                else
                    UserWindowSettings.Location = new Rect(Window.Left, Window.Top, Window.Width, Window.Height);

                SaveToFile(); 
            }
        }

        protected void SaveToFile()
        {
            _serializerService.Save(UserWindowSettings);
        }

        private static void OnSaveInvalidated(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var window = dependencyObject as Window;
                if (window != null)
                {
                    if ((bool)e.NewValue)
                    {
                        var settings = new WindowSettings(window);
                        settings.Attach();
                    }
                }
            }
            catch { }
        }

        private static void OnSaveOnSizeLocationChangedInvalidated(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var window = dependencyObject as Window;
                if (window != null)
                {
                    if ((bool)e.NewValue)
                    {
                        var settings = new WindowSettings(window);
                        settings.AttachToSizeLocationChanged();
                    }
                }
            }
            catch { }
        }

        protected void Attach()
        {
            if (Window != null)
            {
                Window.Closing += WindowClosing;
                Window.Initialized += WindowInitialized;
                Window.Loaded += WindowLoaded;
            }
        }

        protected void AttachToSizeLocationChanged()
        {
            if (Window != null)
            {
                Window.SizeChanged += WindowSizeChanged;
                Window.LocationChanged += WindowLocationChanged;
            }
        }

        private void WindowLocationChanged(object sender, EventArgs e)
        {
            try
            {
                CheckToSaveWindowState(sender);
            }
            catch { }
        }

        private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                CheckToSaveWindowState(sender);
            }
            catch { }
        }

        private void CheckToSaveWindowState(object sender)
        {
            var window = sender as Window;
            if (window != null && window.IsLoaded)
                SaveWindowState();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserWindowSettings.WindowState == WindowState.Maximized)
                {
                    WindowStyle windowStyle = Window.WindowStyle;
                    Window.WindowStyle = WindowStyle.SingleBorderWindow;

                    Window.WindowState = UserWindowSettings.WindowState;

                    Window.WindowStyle = windowStyle;
                }
            }
            catch { }
        }

        private void WindowInitialized(object sender, EventArgs e)
        {
            try
            {
                LoadWindowState();
            }
            catch {}
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            try
            {
                SaveWindowState();
            }
            catch {}
        }
         
    }
}