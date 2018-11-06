namespace Elreg.BusinessObjects
{
    public class PenaltyNullObject : Penalty
    {
        public PenaltyNullObject(int lapsLeftToStop)
            : base(lapsLeftToStop)
        {
        }

        public new int LapsLeftToStop
        {
            get { return 100; }
        }
    }
}