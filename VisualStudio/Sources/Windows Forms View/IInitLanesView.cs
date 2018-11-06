using System.Collections.Generic;
using Elreg.BusinessObjects.Lanes;
using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface IInitLanesView : ISimpleView
    {
        DataGridView GrdLanes { get; }
        List<InitialLane> InitialLanes { get; }
        bool Ok { get; }
        Button BtnRefresh { get; }
        Button BtnRotateUp { get; }
        Button BtnRotateDown { get; }
        Button BtnRandomize { get; }
        Button BtnOk { get; }
        Button BtnCancel { get; }
        DataGridViewColumn GridColumnId { get; }
        DataGridViewColumn GridColumnGhostcar { get; }
        DataGridViewColumn GridColumnDriver { get; }
        DataGridViewColumn GridColumnCar { get; }
        ToolStripMenuItem ToolStripMenuItemLargerFont { get; }
        ToolStripMenuItem ToolStripMenuItemSmallerFont { get; }
        ToolStripMenuItem ToolStripMenuItemLargerHeaderFont { get; }
        ToolStripMenuItem ToolStripMenuItemSmallerHeaderFont { get; }
        ToolStripMenuItem ToolStripMenuItemSaveSettings { get; }
        ToolStripMenuItem ToolStripMenuItemLoadSettings { get; }
    }
}
