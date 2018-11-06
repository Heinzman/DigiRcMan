using Catel.Data;
using Catel.MVVM;

namespace Elreg.WpfModelObjects
{
    public class LapLineCaption : ViewModelBase
    {
        public static readonly PropertyData YPercentageProperty = RegisterProperty("YPercentage", typeof(double));
        public static readonly PropertyData XPercentageProperty = RegisterProperty("XPercentage", typeof(double));
        public static readonly PropertyData CaptionProperty = RegisterProperty("Caption", typeof(string));
        public static readonly PropertyData FontSizeProperty = RegisterProperty("FontSize", typeof(int));
        public static readonly PropertyData YAbsoluteOffsetProperty = RegisterProperty("YAbsoluteOffset", typeof(int));

        public double YPercentage
        {
            get { return GetValue<double>(YPercentageProperty); }
            set { SetValue(YPercentageProperty, value); }
        }

        public string Caption
        {
            get { return GetValue<string>(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public double XPercentage
        {
            get { return GetValue<double>(XPercentageProperty); }
            set { SetValue(XPercentageProperty, value); }
        }

        public int FontSize
        {
            get { return GetValue<int>(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public int YAbsoluteOffset
        {
            get { return GetValue<int>(YAbsoluteOffsetProperty); }
            set { SetValue(YAbsoluteOffsetProperty, value); }
        }

    }
}