using System.Windows.Forms;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.WindowsFormsView
{
    public interface IRaceResultsView : ISimpleView
    {
        DataGridView GrdLanes { get; }
        void CreateRaceResult();
        void LoadAndShow(string raceResultsXmlFile);
        IRaceResult RaceResult { get; set; }
        Button BtnSave { get; }
        Button BtnDelete { get; }
        Button BtnClose { get; }
        bool Ok { get; }
        bool BtnDeleteVisible { set; }
        bool BtnSaveVisible { set; }
        string Caption { set; }
        string ToolStripMenuItemLargerFontText { set; }
        string ToolStripMenuItemSmallerFontText { set; }
        string ToolStripMenuItemLargerHeaderFontText { set; }
        string ToolStripMenuItemSmallerHeaderFontText { set; }
        string ToolStripMenuItemSaveSettingsText { set; }
        string ToolStripMenuItemLoadSettingsText { set; }
        string GridColumnPositionHeaderText { set; }
        string GridColumnDriverHeaderText { set; }
        string GridColumnPointsHeaderText { set; }
        string GridColumnCarHeaderText { set; }
        string GridColumnLapCountHeaderText { set; }
        string GridColumnBestLapTimeHeaderText { set; }
        string GridColumnPenaltiesHeaderText { set; }
        string GridColumnRaceTimeNetHeaderText { set; }
        int GetIndexOfAddedRowInGrdLanes();
    }
}
