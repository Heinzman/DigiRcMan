namespace Elreg.RaceSound.StereoSound
{
    public static class StereoPan
    {
        private const int PanCenter = 0;
        private const int PanLeft = -10000;
        private const int PanRight = 10000;

        public static int CenterPosition
        {
            get { return PanCenter; }
        }

        public static int RightPosition
        {
            get { return PanRight; }
        }

        public static int LeftPosition
        {
            get { return PanLeft; }
        }

        public static int RightCenterPosition
        {
            get { return PanRight/3; }
        }

        public static int LeftCenterPosition
        {
            get { return PanLeft/3; }
        }

        public static int RightRightCenterPosition
        {
            get { return PanRight*3/5; }
        }

        public static int RightCenterCenterPosition
        {
            get { return PanRight/5; }
        }

        public static int LeftCenterCenterPosition
        {
            get { return PanLeft/5; }
        }

        public static int LeftLeftCenterPosition
        {
            get { return PanLeft*3/5; }
        }
    }
}
