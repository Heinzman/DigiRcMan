using System.Drawing;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.UnitTests.MockObjects
{
    public class MockRaceGridPresenter : IRaceGridPresenter
    {
        private const int RowIndex1 = 1;

        public int GetRowIndexBy(LaneId laneId)
        {
            return RowIndex1;
        }

        public Color DefaultBackgroundColor
        {
            get { return Color.FromArgb(210, 210, 210); }
        }

        public Color AlternatingBackgroundColor
        {
            get { return Color.FromArgb(190, 190, 190); }
        }
    }
}
