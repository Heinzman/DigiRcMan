using System;
using System.Globalization;
using System.Windows.Data;

namespace Heinzman.WpfView.Converters
{
    class EstimatedPositionToDisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string displayName = null;

            if (value is int)
                displayName = "(" + value + ")";
            return displayName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
