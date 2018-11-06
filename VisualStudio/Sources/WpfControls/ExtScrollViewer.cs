using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Heinzman.WpfControls
{
    public class ExtScrollViewer : ScrollViewer
    {
        private ScrollBar _verticalScrollbar;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _verticalScrollbar = GetTemplateChild("PART_VerticalScrollBar") as ScrollBar;
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            if ((_verticalScrollbar != null) && (_verticalScrollbar.Visibility == Visibility.Visible) && _verticalScrollbar.IsEnabled)
                base.OnMouseWheel(e);
        }
    }
}
