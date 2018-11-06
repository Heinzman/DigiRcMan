using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Elreg.WpfEvalApp.Converters
{
    public class RelativeToAbsoluteWidthOrHeightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double realtiveXorY = 0; 
            double maxX = 100;
            int xOrYAbsoluteOffset = 0;

            if (values[0] is double)
                realtiveXorY = (double)values[0];

            if (values[1] is double)
                maxX = (double)values[1];

            if (values.Length > 2 && values[2] is int)
                xOrYAbsoluteOffset = (int)values[2];

            double absoluteXorY = realtiveXorY / 100 * maxX + xOrYAbsoluteOffset;
            return absoluteXorY;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
