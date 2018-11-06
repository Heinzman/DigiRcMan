using System.Configuration;
using System.Windows;

namespace Heinzman.WpfControls
{
    public class WindowApplicationSettings : ApplicationSettingsBase
    {
        public WindowApplicationSettings(WindowSettings windowSettings)
            : base(windowSettings.Window.DependencyObjectType.Name)
        {
        }

        [UserScopedSetting]
        public Rect Location
        {
            get
            {
                if (this["Location"] != null)
                    return ((Rect)this["Location"]);
                return Rect.Empty;
            }
            set { this["Location"] = value; }
        }

        [UserScopedSetting]
        public WindowState WindowState
        {
            get
            {
                if (this["WindowState"] != null)
                    return (WindowState)this["WindowState"];
                return WindowState.Normal;
            }
            set { this["WindowState"] = value; }
        }

        [UserScopedSetting]
        public bool UpgradeRequired
        {
            get
            {
                if (this["UpgradeRequired"] != null)
                    return (bool)this["UpgradeRequired"];
                return true;
            }
            set { this["UpgradeRequired"] = value; }
        }
    }
}