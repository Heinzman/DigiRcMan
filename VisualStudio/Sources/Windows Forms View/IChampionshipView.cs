using System.Windows.Forms;
using Elreg.BusinessObjects.Championships;
using Elreg.Controls;

namespace Elreg.WindowsFormsView
{
    public interface IChampionshipView : ISimpleView
    {
        PrettyGrid GrdLanes { get; }
        void LoadAndShow(string championshipXmlFile);
        void AddToLatest(RaceResult raceResult);
        void AddToNew(RaceResult raceResult);
        string Caption { set; }
        Button BtnSave { get; }
        Button BtnClose { get; }
        DataGridViewColumn GridColumnPosition { get; }
        DataGridViewColumn GridColumnDriver { get; }
        DataGridViewColumn GridColumnPoints { get; }
        ToolStripMenuItem ToolStripMenuItemLargerFont { get; }
        ToolStripMenuItem ToolStripMenuItemSmallerFont { get; }
        ToolStripMenuItem ToolStripMenuItemLargerHeaderFont { get; }
        ToolStripMenuItem ToolStripMenuItemSmallerHeaderFont { get; }
        ToolStripMenuItem ToolStripMenuItemSaveSettings { get; }
        ToolStripMenuItem ToolStripMenuItemLoadSettings { get; }
    }
}
