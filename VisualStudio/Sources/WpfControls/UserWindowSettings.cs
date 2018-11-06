using System;
using System.Windows;

namespace Heinzman.WpfControls
{
    [Serializable]
    public class UserWindowSettings
    {
        public Rect Location { get; set; }

        public WindowState WindowState { get; set; }
    }
}
