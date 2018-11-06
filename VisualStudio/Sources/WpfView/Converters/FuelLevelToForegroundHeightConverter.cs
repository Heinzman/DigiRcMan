using System;
using System.Globalization;
using System.Windows.Data;

namespace Heinzman.WpfView.Converters
{
    public class FuelLevelToForegroundHeightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double relativeForegroundHeight = 0;
            double maxHeight = 100;

            if (values[0] is int)
                relativeForegroundHeight = (int)values[0];

            if (values[1] is double)
                maxHeight = (double)values[1];

            double absoluteForegroundHeight = relativeForegroundHeight / 100 * (maxHeight);
            if (absoluteForegroundHeight < 0)
                absoluteForegroundHeight = 0;

            return absoluteForegroundHeight;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
