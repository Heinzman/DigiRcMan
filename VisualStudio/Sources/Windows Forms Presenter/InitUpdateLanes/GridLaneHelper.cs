using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Lanes;
using Elreg.RaceOptionsService;

namespace Elreg.WindowsFormsPresenter.InitUpdateLanes
{
    public abstract class GridLaneHelper
    {
        protected readonly DataGridView GrdLanes;
        protected int RowIndex;
        private readonly DriversService _driversService;
        private readonly CarsService _carsService;

        protected delegate bool TryParseFunc<T2>(string s, out T2 result);

        protected GridLaneHelper(DataGridView grdLanes, DriversService driversService, CarsService carsService)
        {
            GrdLanes = grdLanes;
            _driversService = driversService;
            _carsService = carsService;
        }

        public DataGridViewButtonColumn ColumnGhostcar
        {
            get { return GrdLanes.Columns["ColumnGhostcar"] as DataGridViewButtonColumn; }
        }

        public DataGridViewComboBoxColumn ColumnDriver
        {
            get { return GrdLanes.Columns["ColumnDriver"] as DataGridViewComboBoxColumn; }
        }

        public DataGridViewComboBoxColumn ColumnCar
        {
            get { return GrdLanes.Columns["ColumnCar"] as DataGridViewComboBoxColumn; }
        }

        public DataGridViewImageColumn ColumnCarPicture
        {
            get { return GrdLanes.Columns["ColumnCarPicture"] as DataGridViewImageColumn; }
        }

        public DataGridViewColumn ColumnId
        {
            get { return GrdLanes.Columns["ColumnID"]; }
        }

        public DataGridViewColumn ColumnLapCount
        {
            get { return GrdLanes.Columns["ColumnLapCount"]; }
        }

        public DataGridViewColumn ColumnOverallPenalties
        {
            get { return GrdLanes.Columns["ColumnOverallPenalties"]; }
        }

        public DataGridViewComboBoxColumn ColumnStatus
        {
            get { return GrdLanes.Columns["ColumnStatus"] as DataGridViewComboBoxColumn; }
        }

        public void UpdateAllDependentValues()
        {
            foreach (DataGridViewRow row in GrdLanes.Rows)
                UpdateDependentValues(row.Index);
        }

        public abstract bool IsLaneValid(int rowIndex);

        public InitialLane GetInitialLane(int rowIndex)
        {
            RowIndex = rowIndex;
            return new InitialLane(CurrentLaneId, CurrentDriver, CurrentCar);
        }

        public void UpdateDependentValues(int rowIndex)
        {
            RowIndex = rowIndex;
        }

        protected LaneId CurrentLaneId
        {
            get
            {
                DataGridViewRow row = GrdLanes.Rows[RowIndex];
                LaneId laneId = (LaneId)row.Tag;
                return laneId;
            }
        }

        protected Driver CurrentDriver
        {
            get
            {
                string driverName = GrdLanes[ColumnDriver.Name, RowIndex].Value as string;
                Driver driver = _driversService.Drivers.Find(driverIt => driverName == driverIt.Name);
                return driver;
            }
        }

        protected Car CurrentCar
        {
            get
            {
                string carName = GrdLanes[ColumnCar.Name, RowIndex].Value as string;
                Car car = _carsService.Cars.Find(carIt => carName == carIt.Name);
                return car;
            }
        }

        protected Lane.LaneStatusEnum CurrentStatus
        {
            get
            {
                Lane.LaneStatusEnum status = Lane.LaneStatusEnum.Undefined;
                object obj = GrdLanes[ColumnStatus.Name, RowIndex].Value;
                if (obj != null)
                    status = (Lane.LaneStatusEnum)obj;
                return status;
            }
        }

        protected int? CurrentLap
        {
            get { return GetCurrentValue<int>(ColumnLapCount.Name, int.TryParse); }
        }

        protected int? CurrentOveralPenaltyCount
        {
            get { return GetCurrentValue<int>(ColumnOverallPenalties.Name, int.TryParse); }
        }

        protected T? GetCurrentValue<T>(string columnName, TryParseFunc<T> tryParseFunc) where T : struct
        {
            T? currentValue = null;
            object objValue = GrdLanes[columnName, RowIndex].Value;
            if (objValue != null)
            {
                T parsedValue;
                if (tryParseFunc(objValue.ToString(), out parsedValue))
                    currentValue = parsedValue;
            }
            return currentValue;
        }

    }
}
