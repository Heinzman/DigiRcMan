using System.Drawing;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface IRaceGridPresenter
    {
        int GetRowIndexBy(LaneId laneId);
        Color DefaultBackgroundColor { get; }
        Color AlternatingBackgroundColor { get; }
    }
}
