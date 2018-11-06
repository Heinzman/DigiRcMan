using System.Windows.Forms;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Options;
using Elreg.RaceOptionsService;

namespace Elreg.WindowsFormsPresenter.InitUpdateLanes
{
    public class GridLaneUpdateHelper : GridLaneHelper
    {

        public GridLaneUpdateHelper(DataGridView grdLanes, DriversService driversService, CarsService carsService)
            : base(grdLanes, driversService, carsService)
        {
        }

        public override bool IsLaneValid(int rowIndex)
        {
            RowIndex = rowIndex;
            return CurrentDriver != null;
        }

        public ChangedLane GetChangedLane(int rowIndex)
        {
            RowIndex = rowIndex;
            return new ChangedLane(CurrentLaneId, CurrentDriver, CurrentCar, CurrentLap, CurrentStatus, CurrentOveralPenaltyCount);
        }

    }
}
