namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class CountDownEventArgs : System.EventArgs
    {
        #region TypeEnum enum

        public enum TypeEnum
        {
            BeginCountDown,
            Count5,
            Count4,
            Count3,
            Count2,
            Count1,
            Go,
            Done
        }

        #endregion

        public CountDownEventArgs(TypeEnum type)
        {
            Type = type;
        }

        public TypeEnum Type { get; set; }
    }
}