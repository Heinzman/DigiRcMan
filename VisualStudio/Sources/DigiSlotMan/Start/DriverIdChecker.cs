using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.WinFormsPresentationFramework.Forms;

namespace Elreg.DigiRcMan.Start
{
    public class DriverIdChecker
    {
        private readonly List<Driver> _drivers;
        private string _errorText;

        public DriverIdChecker(List<Driver> drivers)
        {
            _drivers = drivers;
        }

        public void DoWork()
        {
            CheckExistenceOfIds();
            if (_errorText == null)
                CheckIdsAreUnique();

            if (_errorText != null)
            {
                LargeOkMessageBox largeMessageBox = new LargeOkMessageBox();
                largeMessageBox.ShowDialog(_errorText);
            }
        }

        private void CheckIdsAreUnique()
        {
            foreach (Driver driver1 in _drivers)
            {
                foreach (Driver driver2 in _drivers)
                {
                    if (driver1 != driver2 && driver1.Id.HasValue && driver2.Id.HasValue && driver1.Id == driver2.Id)
                    {
                        _errorText = @"There are Drivers with idential IDs. Please check file 'Config\Drivers.xml'";
                        break;
                    }
                }
            }
        }

        private void CheckExistenceOfIds()
        {
            foreach (Driver driver in _drivers)
            {
                if (!driver.Id.HasValue)
                {
                    _errorText = @"There are Drivers without ID. Please check file 'Config\Drivers.xml'";
                    break;
                }
            }
        }
    }
}
