using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface IChampionshipListView : ISimpleView
    {
        ListBox ListBoxChampionships { get; }
        Button BtnRefresh { get; }
        Button BtnClose { get; }
    }
}
