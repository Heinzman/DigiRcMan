using System.Drawing;

namespace Elreg.Controls.ProgressColumns
{
    public class DataGridViewVertProgressCellSpeed : DataGridViewVertProgressCell
    {
        private static int _levelLimitHighToMiddle = 20;
        private static int _levelLimitMiddleToLow = 10;

        private static Color _colorHighLevel;
        private static Color _colorMiddleLevel;
        private static Color _colorLowLevel;

        private static Color _colorLightHighLevel;
        private static Color _colorLightMiddleLevel;
        private static Color _colorLightLowLevel;

        public override Color ColorHighLevel
        {
            get { return _colorHighLevel; }
            set { _colorHighLevel = value; }
        }

        public override Color ColorMiddleLevel
        {
            get { return _colorMiddleLevel; }
            set { _colorMiddleLevel = value; }
        }

        public override Color ColorLowLevel
        {
            get { return _colorLowLevel; }
            set { _colorLowLevel = value; }
        }

        public override Color ColorLightHighLevel
        {
            get { return _colorLightHighLevel; }
            set { _colorLightHighLevel = value; }
        }

        public override Color ColorLightMiddleLevel
        {
            get { return _colorLightMiddleLevel; }
            set { _colorLightMiddleLevel = value; }
        }

        public override Color ColorLightLowLevel
        {
            get { return _colorLightLowLevel; }
            set { _colorLightLowLevel = value; }
        }

        public override int LevelLimitMiddleToLow
        {
            get { return _levelLimitMiddleToLow; }
            set { _levelLimitMiddleToLow = value; }
        }

        public override int LevelLimitHighToMiddle
        {
            get { return _levelLimitHighToMiddle; }
            set { _levelLimitHighToMiddle = value; }
        }
    }
}