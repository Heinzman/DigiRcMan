using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elreg.Log;
using Elreg.RaceOptionsService;

namespace Elreg.WindowsFormsPresenter.InitUpdateLanes
{
    public class GridLaneInitHelper : GridLaneHelper
    {
        private List<string> _drivers;

        private delegate void ChangeLaneFunc();

        public GridLaneInitHelper(DataGridView grdLanes, DriversService driversService, CarsService carsService)
            : base(grdLanes, driversService, carsService)
        {
        }

        public override bool IsLaneValid(int rowIndex)
        {
            RowIndex = rowIndex;
            return CurrentDriver != null && CurrentCar != null;
        }

        public void RandomizeLanes()
        {
            ChangeLanes(RandomizeDrivers);
        }

        public void RotateDownLanes()
        {
            ChangeLanes(RotateDownDrivers);
        }

        public void RotateUpLanes()
        {
            ChangeLanes(RotateUpDrivers);
        }

        private bool IsLaneValidOrParticipatingGhost(int rowIndex)
        {
            return IsLaneValid(rowIndex);
        }

        private void ChangeLanes(ChangeLaneFunc changeLaneFunc)
        {
            GetDriversOfValidLanes();
            changeLaneFunc();
            AssignDriversToValidLanes();
            UpdateAllDependentValues();
        }

        private void GetDriversOfValidLanes()
        {
            _drivers = new List<string>();
            foreach (DataGridViewRow row in GrdLanes.Rows)
            {
                if (IsLaneValidOrParticipatingGhost(row.Index))
                {
                    string driver = GrdLanes[ColumnDriver.Name, row.Index].Value.ToString();
                    _drivers.Add(driver);
                }
            }
        }

        private void RandomizeDrivers()
        {
            try
            {
                Random rng = new Random(Guid.NewGuid().GetHashCode());
                int n = _drivers.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    string value = _drivers[k];
                    _drivers[k] = _drivers[n];
                    _drivers[n] = value;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RotateDownDrivers()
        {
            try
            {
                int n = 0;
                string oldValue = _drivers[_drivers.Count - 1];
                while (n < _drivers.Count)
                {
                    string currentValue = _drivers[n];
                    _drivers[n] = oldValue;
                    oldValue = currentValue;
                    n++;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RotateUpDrivers()
        {
            try
            {
                int n = _drivers.Count;
                string oldValue = _drivers[0];
                while (n > 0)
                {
                    n--;
                    string currentValue = _drivers[n];
                    _drivers[n] = oldValue;
                    oldValue = currentValue;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AssignDriversToValidLanes()
        {
            int driverIndex = 0;
            foreach (DataGridViewRow row in GrdLanes.Rows)
            {
                if (IsLaneValidOrParticipatingGhost(row.Index) && driverIndex < _drivers.Count)
                    GrdLanes[ColumnDriver.Name, row.Index].Value = _drivers[driverIndex++];
            }
        }
    }
}
