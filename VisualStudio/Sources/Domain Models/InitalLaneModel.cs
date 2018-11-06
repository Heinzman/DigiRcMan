using System;
using System.Drawing;
using Elreg.BusinessObjects.Lanes;

namespace Elreg.DomainModels
{
    public class InitalLaneModel : IDisposable
    {
        private InitialLane _initialLane;

        public InitalLaneModel(InitialLane initialLane)
        {
            _initialLane = initialLane;
        }

        public void Dispose()
        {
            _initialLane = null;
        }

        public string DriverName
        {
            get 
            {
                string driverName = null;
                if (_initialLane.Driver != null)
                    driverName = _initialLane.Driver.Name;
                return driverName; 
            }
        }

        public string CarName
        {
            get
            {
                string carName = null;
                if (_initialLane.Car != null)
                    carName = _initialLane.Car.Name;
                return carName;
            }
        }

        public Image CarPicture
        {
            get
            {
                Image carPicture = null;
                if (_initialLane.Car != null)
                    carPicture = _initialLane.Car.Image;
                return carPicture;
            }
        }

    }
}
