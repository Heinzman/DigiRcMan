using System.Windows;

namespace Heinzman.WpfControls
{
    public class CascadingWindowSettings : WindowSettings
    {
        private const int Offset = 10;

        public new static readonly DependencyProperty SaveProperty
            = DependencyProperty.RegisterAttached("Save", typeof(bool), typeof(CascadingWindowSettings),
                                                  new FrameworkPropertyMetadata(OnSaveInvalidated));

        public new static readonly DependencyProperty SaveOnSizeLocationChangedProperty
            = DependencyProperty.RegisterAttached("SaveOnSizeLocationChanged", typeof(bool), typeof(CascadingWindowSettings),
                                                  new FrameworkPropertyMetadata(OnSaveOnSizeLocationChangedInvalidated));

        public new static void SetSave(DependencyObject dependencyObject, bool enabled)
        {
            dependencyObject.SetValue(SaveProperty, enabled);
        }

        public new static void SetSaveOnSizeLocationChanged(DependencyObject dependencyObject, bool enabled)
        {
            dependencyObject.SetValue(SaveOnSizeLocationChangedProperty, enabled);
        }


        private CascadingWindowSettings(Window window) : base(window)
        {
            
        }

        protected override void LoadWindowState()
        {
            LoadFromFile();
            UserWindowSettings.Location = new Rect(new Point(UserWindowSettings.Location.X + Offset, 
                                                   UserWindowSettings.Location.Y + Offset), UserWindowSettings.Location.Size);
            SaveToFile();

            base.LoadWindowState();
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
                        var settings = new CascadingWindowSettings(window);
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
                        var settings = new CascadingWindowSettings(window);
                        settings.AttachToSizeLocationChanged();
                    }
                }
            }
            catch { }
        }

    }
}
