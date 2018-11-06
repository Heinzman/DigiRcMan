using System.Collections.Generic;
using Catel.MVVM;
using Elreg.BusinessObjects.Lanes;
using Elreg.DomainModels;

namespace Elreg.WpfViewModel
{
    public class RaceResultsViewModel : ViewModelBase
    {
        private readonly RaceResultsModel _raceResultsModel;

        public RaceResultsViewModel(RaceResultsModel raceResultsModel)
        {
            _raceResultsModel = raceResultsModel;
        }

        public List<RaceResultLane> RaceResultLane
        {
            get { return _raceResultsModel.RaceResult.RaceResultLanes; }
        }
    }
}
