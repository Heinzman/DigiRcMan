using System;
using System.Globalization;
using System.Windows.Data;

namespace Heinzman.WpfView.Converters
{
    public class RelativeToAbsoluteRowHeightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double realtiveHeight = 0;
            double maxHeight = 100;
            double headerHeight = 0;

            if (values[0] is double)
                realtiveHeight = (double)values[0];

            if (values[1] is double)
                maxHeight = (double)values[1];

            if (values.Length > 2 && values[2] is double)
                headerHeight = (double)values[2];

            double absoluteHeight = realtiveHeight / 100 * (maxHeight - headerHeight);
            if (absoluteHeight < 0)
                absoluteHeight = 0;
            return absoluteHeight;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
