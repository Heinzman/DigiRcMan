using Catel.Data;
using Catel.MVVM;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.WpfViewModel
{
    public class RaceGridViewModel : ViewModelBase
    {
        public static readonly PropertyData HeaderHeightProperty = RegisterProperty("HeaderHeight", typeof(double));

        public PositionsViewModel PositionsViewModel { get; private set; }

        public RaceDataGridViewModel RaceDataGridViewModel { get; private set; }

        public RaceGridViewModel(IRaceModel raceModel)
        {
            PositionsViewModel = new PositionsViewModel(raceModel);
            RaceDataGridViewModel = new RaceDataGridViewModel(raceModel);

            HeaderHeight = 30; // todo
        }

        public double HeaderHeight
        {
            get { return GetValue<double>(HeaderHeightProperty); }
            set
            {
                SetValue(HeaderHeightProperty, value);
                RaceDataGridViewModel.HeaderHeight = value;
            }
        }

    }
}
