using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Heinzman.WpfView.Converters
{
    class FuelLevelToForegroundColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Brush brush = new SolidColorBrush(Colors.Green);
            int fuelLevelToWarnYellow = 20;
            int fuelLevelToWarnRed = fuelLevelToWarnYellow / 2;

            if (values[0] is int)
            {
                int fuelLevel = (int)values[0];

                if (values.Length > 1 && values[1] is int)
                    fuelLevelToWarnYellow = (int)values[1];

                if (values.Length > 2 && values[2] is int)
                    fuelLevelToWarnRed = (int)values[2];

                if (fuelLevel <= fuelLevelToWarnRed)
                    brush = new SolidColorBrush(Colors.Red);
                else if (fuelLevel <= fuelLevelToWarnYellow)
                    brush = new SolidColorBrush(Colors.Yellow);
            }
            return brush;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
