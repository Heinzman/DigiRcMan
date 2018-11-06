using System.Collections.Generic; 
using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface IRaceGridView: ISimpleView
    {
        Label GetLblPositionOf(int position);
        List<Label> PositionLabels { get; }
        List<PictureBox> PositionPictures { get; }
        DataGridView GrdLanes { get; }
        ToolStripMenuItem MenuItemColumns { get; }
        string RaceStatus { set; }
        SplitContainer SplitContainerStatus { get; }
        SplitContainer SplitContainerPosition { get; }
        List<Label> Labels { get; }
        DataGridViewImageColumn GridColumnStatus { get; }
        DataGridViewTextBoxColumn GridColumnDriver { get; }
        DataGridViewColumn GridColumnId { get; }
        DataGridViewColumn GridColumnLapCount { get; }
        DataGridViewColumn GridColumnPenalties { get; }
        DataGridViewColumn GridColumnCar { get; }
        DataGridViewColumn GridColumnPosition { get; }
        DataGridViewColumn GridColumnBestLapTime { get; }
        DataGridViewColumn GridColumnLapTime { get; }
        DataGridViewColumn GridColumnLapTimeBestLapTime { get; }
        Button BtnShowRaceControlForm { get; }
        void FillView();
        ToolStripMenuItem ToolStripMenuItemLargerFont { get; }
        ToolStripMenuItem ToolStripMenuItemSmallerFont { get; }
        ToolStripMenuItem ToolStripMenuItemLargerHeaderFont { get; }
        ToolStripMenuItem ToolStripMenuItemSmallerHeaderFont { get; }
        ToolStripMenuItem ToolStripMenuItemSaveSettings { get; }
        ToolStripMenuItem ToolStripMenuItemLoadSettings { get; }
        ToolStripMenuItem ToolStripMenuItemColumns { get; }
        ToolStripMenuItem ToolStripMenuItemColumnId { get; }
        ToolStripMenuItem ToolStripMenuItemColumnDriver { get; }
        ToolStripMenuItem ToolStripMenuItemColumnCarPicture { get; }
        ToolStripMenuItem ToolStripMenuItemColumnLaps { get; }
        ToolStripMenuItem ToolStripMenuItemColumnPos { get; }
        ToolStripMenuItem ToolStripMenuItemColumnBestLapTime { get; }
        ToolStripMenuItem ToolStripMenuItemColumnLapTime { get; }
        ToolStripMenuItem ToolStripMenuItemColumnLapTimeBest { get; }
        ToolStripMenuItem ToolStripMenuItemColumnStatus { get; }
        ToolStripMenuItem ToolStripMenuItemColumnPenalties { get; }
        ToolStripMenuItem ToolStripMenuItemLargerStatusFont { get; }
        ToolStripMenuItem ToolStripMenuItemSmallerStatusFont { get; }
        PictureBox GetPicPositionOf(int position);
    }
}
