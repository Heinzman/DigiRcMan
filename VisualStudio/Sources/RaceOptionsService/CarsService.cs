using System.Collections.Generic;
using Elreg.BusinessObjects;

namespace Elreg.RaceOptionsService
{
    public class CarsService : ServiceBase<List<Car>>
    {
        public List<Car> Cars
        {
            get { return Object; }
        }

        protected override string Filename
        {
            get { return "Cars.xml"; }
        }

        public int GetNextId()
        {
            int maxId = 0;
            foreach (Car car in Cars)
            {
                if (car.Id.HasValue && car.Id.Value > maxId)
                    maxId = car.Id.Value;
            }
            return ++maxId;
        }
    }
}
