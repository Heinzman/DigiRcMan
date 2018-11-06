using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface IRaceResultsListView : ISimpleView
    {
        ListBox ListBoxRaceResults { get; }
        Button BtnRefresh { get; }
        Button BtnClose { get; }
    }
}
