using System.Collections.Generic;
using Elreg.BusinessObjects.Lanes;
using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface IUpdateLanesView : ISimpleView
    {
        DataGridView GrdLanes { get; }
        List<ChangedLane> ChangedLanes { get; }
        bool Ok { get; }
        Button BtnRefresh { get; }
        Button BtnOk { get; }
        Button BtnCancel { get; }
        DataGridViewColumn GridColumnId { get; }
        DataGridViewColumn GridColumnDriver { get; }
        DataGridViewColumn GridColumnCar { get; }
        DataGridViewColumn GridColumnLapCount { get; }
        DataGridViewColumn GridColumnStatus { get; }
        DataGridViewColumn GridColumnOverallPenalties { get; }
        ToolStripMenuItem ToolStripMenuItemLargerFont { get; }
        ToolStripMenuItem ToolStripMenuItemSmallerFont { get; }
        ToolStripMenuItem ToolStripMenuItemLargerHeaderFont { get; }
        ToolStripMenuItem ToolStripMenuItemSmallerHeaderFont { get; }
        ToolStripMenuItem ToolStripMenuItemSaveSettings { get; }
        ToolStripMenuItem ToolStripMenuItemLoadSettings { get; }
    }
}
