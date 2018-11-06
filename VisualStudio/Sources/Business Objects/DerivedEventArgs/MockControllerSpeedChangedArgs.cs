namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class  MockControllerSpeedChangedArgs : System.EventArgs
    {
        public uint Speed { get; set; }

        public MockControllerSpeedChangedArgs(uint speed)
        {
            Speed = speed;
        }
    }

}
