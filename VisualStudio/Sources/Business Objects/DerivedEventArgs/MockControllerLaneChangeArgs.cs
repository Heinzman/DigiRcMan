namespace Elreg.BusinessObjects.DerivedEventArgs
{
    public class MockControllerLaneChangeArgs : System.EventArgs
    {
        public bool IsPressed { get; set; }

        public MockControllerLaneChangeArgs(bool isPressed)
        {
            IsPressed = isPressed;
        }
    }

}
