using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.WinFormsPresentationFramework.Forms;

namespace Elreg.DigiRcMan.Start
{
    public class CarIdChecker
    {
        private readonly List<Car> _cars;
        private string _errorText;

        public CarIdChecker(List<Car> cars)
        {
            _cars = cars;
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
            foreach (Car car1 in _cars)
            {
                foreach (Car car2 in _cars)
                {
                    if (car1 != car2 && car1.Id.HasValue && car2.Id.HasValue && car1.Id == car2.Id)
                    {
                        _errorText = @"There are Cars with idential IDs. Please check file 'Config\Cars.xml'";
                        break;
                    }
                }
            }
        }

        private void CheckExistenceOfIds()
        {
            foreach (Car car in _cars)
            {
                if (!car.Id.HasValue)
                {
                    _errorText = @"There are Cars without ID. Please check file 'Config\Cars.xml'";
                    break;
                }
            }
        }
    }
}
