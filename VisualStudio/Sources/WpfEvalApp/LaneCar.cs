using Catel.Data;
using Catel.MVVM;

namespace Elreg.WpfEvalApp
{
    public class LaneCar : ViewModelBase
    {
        public static readonly PropertyData CarImageTopPercentageProperty = RegisterProperty("CarImageTopPercentage", typeof(double));
        public static readonly PropertyData CarImageHeightPercentageProperty = RegisterProperty("CarImageHeightPercentage", typeof(double));
        public static readonly PropertyData CarImageXPercentageProperty = RegisterProperty("CarImageXPercentage", typeof(double));

        public double CarImageHeightPercentage
        {
            get { return GetValue<double>(CarImageHeightPercentageProperty); }
            set { SetValue(CarImageHeightPercentageProperty, value); }
        }

        public double CarImageTopPercentage
        {
            get { return GetValue<double>(CarImageTopPercentageProperty); }
            set { SetValue(CarImageTopPercentageProperty, value); }
        }

        public double Laps { get; set; }

        public double CarImageXPercentage
        {
            get { return GetValue<double>(CarImageXPercentageProperty); }
            set { SetValue(CarImageXPercentageProperty, value); }
        }
    }
}