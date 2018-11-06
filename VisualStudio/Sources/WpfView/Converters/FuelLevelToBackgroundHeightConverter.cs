using System;
using System.Globalization;
using System.Windows.Data;

namespace Heinzman.WpfView.Converters
{
    public class FuelLevelToBackgroundHeightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            FuelLevelToForegroundHeightConverter foregroundHeightConverter = new FuelLevelToForegroundHeightConverter();
            double absoluteForegroundHeight = (double)foregroundHeightConverter.Convert(values, targetType, parameter, culture);
            double maxHeight = (double)values[1];

            return maxHeight - absoluteForegroundHeight;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
