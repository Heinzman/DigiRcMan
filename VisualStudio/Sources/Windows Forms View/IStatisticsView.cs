using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface IStatisticsView : ISimpleView
    {
        DataGridView GrdStatistics { get; }
        ComboBox CbxEventNames { get; }
        ComboBox CbxTrackNames { get; }
        ComboBox CbxRaceTypes { get; }
        ComboBox CbxGroupBy { get; }
        ComboBox CbxSortBy { get; }
        DataGridViewColumn ColumnOfDriver { get; }
        DataGridViewColumn ColumnOfCar { get; }
        DataGridViewColumn ColumnOfCarName { get; }
    }
}
