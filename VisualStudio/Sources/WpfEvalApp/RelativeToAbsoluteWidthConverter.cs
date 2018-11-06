using System;
using System.Globalization;
using System.Windows.Data;

namespace Heinzman.WpfEvalApp
{
    public class RelativeToAbsoluteWidthOrHeightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double realtiveX = 0; 
            double maxX = 100;

            if (values[0] is double)
                realtiveX = (double)values[0];

            if (values[1] is double)
                maxX = (double)values[1];

            double absoluteX = realtiveX / 100 * maxX;
            return absoluteX;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
