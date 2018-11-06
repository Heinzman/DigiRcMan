using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;

namespace Elreg.RaceOptionsService
{
    public class DriversService : ServiceBase<List<Driver>>
    {
        public event EventHandler SoundsChanged;

        public override void Save()
        {
            base.Save();
            RaiseEventSoundsChanged();
        }

        public List<Driver> Drivers
        {
            get { return Object; }
        }

        protected override string Filename
        {
            get { return "Drivers.xml"; }
        }

        private void RaiseEventSoundsChanged()
        {
            if (SoundsChanged != null)
                SoundsChanged(this, null);
        }

        public int GetNextId()
        {
            int maxId = 0;
            foreach (Driver driver in Drivers)
            {
                if (driver.Id.HasValue && driver.Id.Value > maxId)
                    maxId = driver.Id.Value;
            }
            return ++maxId;
        }
    }
}