using System;

namespace Elreg.BusinessObjects
{
    [Serializable]
    public class Penalty
    {
        public Penalty()
        {
        }

        public Penalty(int lapsLeftToStop)
        {
            LapsLeftToStop = lapsLeftToStop;
        }

        public int LapsLeftToStop { get; set; }
    }
}