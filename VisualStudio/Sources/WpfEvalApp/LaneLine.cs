using System.Windows.Media;
using Catel.Data;
using Catel.MVVM;

namespace Elreg.WpfEvalApp
{
    public class LaneLine : ViewModelBase
    {
        public static readonly PropertyData Line1YPercentageProperty = RegisterProperty("Line1YPercentage", typeof(double));
        public static readonly PropertyData Line2YPercentageProperty = RegisterProperty("Line2YPercentage", typeof(double));
        public static readonly PropertyData HeightPercentageProperty = RegisterProperty("HeightPercentage", typeof(double));
        public static readonly PropertyData BackgroundBrushProperty = RegisterProperty("BackgroundBrush", typeof(Brush));
        public static readonly PropertyData CaptionProperty = RegisterProperty("Caption", typeof(string));
        public static readonly PropertyData FontSizeProperty = RegisterProperty("FontSize", typeof(int));

        public double Line1YPercentage
        {
            get { return GetValue<double>(Line1YPercentageProperty); }
            set { SetValue(Line1YPercentageProperty, value); }
        }

        public string Caption
        {
            get { return GetValue<string>(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public double Line2YPercentage
        {
            get { return GetValue<double>(Line2YPercentageProperty); }
            set { SetValue(Line2YPercentageProperty, value); }
        }

        public double HeightPercentage
        {
            get { return GetValue<double>(HeightPercentageProperty); }
            set { SetValue(HeightPercentageProperty, value); }
        }

        public Brush BackgroundBrush
        {
            get { return GetValue<Brush>(BackgroundBrushProperty); }
            set { SetValue(BackgroundBrushProperty, value); }
        }

        public int FontSize
        {
            get { return GetValue<int>(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

    }
}