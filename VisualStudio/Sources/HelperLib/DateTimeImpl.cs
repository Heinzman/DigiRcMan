using System;
using Elreg.FrameworkContracts;

namespace Elreg.HelperLib
{
    public class DateTimeImpl : IDateTime
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
