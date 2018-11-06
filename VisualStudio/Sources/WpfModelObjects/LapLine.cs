using System.Collections.ObjectModel;
using Catel.Data;
using Catel.MVVM;

namespace Elreg.WpfModelObjects
{
    public class LapLine : ViewModelBase
    {

        public static readonly PropertyData XPercentageProperty = RegisterProperty("XPercentage", typeof(double));
        public static readonly PropertyData CaptionProperty = RegisterProperty("Caption", typeof(string));
        public static readonly PropertyData FontSizeProperty = RegisterProperty("FontSize", typeof(int));
        public static readonly PropertyData IsVisibleProperty = RegisterProperty("IsVisible", typeof(bool));

        public double XPercentage
        {
            get { return GetValue<double>(XPercentageProperty); }
            set { SetValue(XPercentageProperty, value); }
        }

        public string Caption
        {
            get { return GetValue<string>(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public int FontSize
        {
            get { return GetValue<int>(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public bool IsVisible
        {
            get { return GetValue<bool>(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        public ObservableCollection<LapLineCaption> LapLineCaptions { get; set; }

    }
}
