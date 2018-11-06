using System.Collections.Generic;

namespace Elreg.BusinessObjects.Options
{
    public class TagIdsOfCarId
    {
        public int CarId { get; set; }

        public List<string> TagIds { get; set; }

        public TagIdsOfCarId()
        {
            TagIds = new List<string>();
        }
    }
}