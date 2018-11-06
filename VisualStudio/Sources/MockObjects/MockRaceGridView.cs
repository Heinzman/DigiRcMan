using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Elreg.Controls.ProgressColumns;
using Elreg.WindowsFormsPresenter.RaceGrid;
using Elreg.WindowsFormsView;

namespace Elreg.UnitTests.MockObjects
{
    // ReSharper disable UnusedAutoPropertyAccessor.Local
    // ReSharper disable MethodOverloadWithOptionalParameter
    public class MockRaceGridView : IRaceGridView
    {
        private readonly Label _label1 = new Label { Name = "Label1" };
        private readonly Label _label2 = new Label { Name = "Label2" };
        private readonly Label _label3 = new Label { Name = "Label3" };
        private readonly Label _label4 = new Label { Name = "Label4" };
        private readonly Label _label5 = new Label { Name = "Label5" };
        private readonly Label _label6 = new Label { Name = "Label6" };
        private readonly List<Label> _positionLabels = new List<Label>();
        private readonly List<PictureBox> _positionPictures = new List<PictureBox>();

        public MockRaceGridView()
        {
            _positionLabels = new List<Label> { _label1, _label2, _label3, _label4, _label5, _label6 };
            Visible = true;
            WindowState = FormWindowState.Normal;
            RegKey = string.Empty;
            Opacity = 1;
            TopMost = true;
            Name = "MockRaceGridView";
            CreateGrdLanes();
            MenuItemColumns = new ToolStripMenuItem();
            RaceStatus = "RaceStatus";
            SplitContainerStatus = new SplitContainer();
            CreateLabels();
            GridColumnCarFuelLevel = new DataGridViewHorizProgressColumn();
            GridColumnCurrentSpeed = new DataGridViewVertProgressColumn();
            GridColumnStatus = new DataGridViewImageColumn();
            GridColumnDriver = new DataGridViewTextBoxColumn();
        }

        private void CreateLabels()
        {
            Labels = new List<Label> {new Label(), new Label(), new Label()};
        }

        private void CreateGrdLanes()
        {
            GrdLanes = new DataGridView();

            foreach (string columnName in Enum.GetNames(typeof(RaceGridPresenter.Columns)))
                GrdLanes.Columns.Add(columnName, columnName);

            GrdLanes.Rows.Add(3);
        }

        public DialogResult ShowDialog()
        {
            return DialogResult.None;
        }

        public DialogResult ShowDialog(IWin32Window owner)
        {
            return DialogResult.None;
        }

        public DialogResult InvokeShowDialog()
        {
            return DialogResult.None;
        }

        public void InvokeShowAndFocus()
        {
        }

        public void Close()
        {
        }

        public void Hide()
        {
        }

        public void InvokeHide()
        {
        }

        public object Invoke(Delegate method, params object[] args)
        {
            return null;
        }

        public object Invoke(Delegate method)
        {
            return null;
        }

        public void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new[] { propertyValue });
        }

        public bool Visible { get; set; }
        public FormWindowState WindowState { get; set; }
        public string RegKey { get; private set; }
        public double Opacity { get; set; }
        public bool TopMost { get; set; }
        public string Name { get; private set; }
        public string Text { get; set; }
        public void InvokeShow() { }

        public Label GetLblPositionOf(int position)
        {
            return PositionLabels[position-1];
        }

        public List<Label> PositionLabels
        {
            get { return _positionLabels; }
        }

        public List<PictureBox> PositionPictures
        {
            get { return _positionPictures; }
        }

        public List<Label> PosDiffLabels { get { return new List<Label>(); } }
        public DataGridView GrdLanes { get; private set; }
        public ToolStripMenuItem MenuItemColumns { get; private set; }
        public string RaceStatus { set; private get; }
        public SplitContainer SplitContainerStatus { get; private set; }
        public SplitContainer SplitContainerPosition { get; private set; }
        public List<Label> Labels { get; private set; }
        public DataGridViewHorizProgressColumn GridColumnCarFuelLevel { get; private set; }
        public DataGridViewVertProgressColumn GridColumnCurrentSpeed { get; private set; }
        public DataGridViewVertProgressColumn GridColumnEngineDamage { get; private set; }
        public DataGridViewImageColumn GridColumnStatus { get; private set; }
        public DataGridViewTextBoxColumn GridColumnDriver { get; private set; }
        public DataGridViewColumn GridColumnId { get; private set; }
        public DataGridViewColumn GridColumnLapCount { get; private set; }
        public DataGridViewColumn GridColumnPenalties { get; private set; }
        public DataGridViewColumn GridColumnCar { get; private set; }
        public DataGridViewColumn GridColumnRockets { get; private set; }
        public DataGridViewColumn GridColumnPosition { get; private set; }
        public DataGridViewColumn GridColumnBestLapTime { get; private set; }
        public DataGridViewColumn GridColumnLapTime { get; private set; }
        public DataGridViewColumn GridColumnLapTimeBestLapTime { get; private set; }
        public DataGridViewColumn GridColumnFuelConsumption { get; private set; }
        public DataGridViewColumn GridColumnFuelConsumptionwithAverage { get; private set; }
        public Button BtnShowRaceControlForm { get; private set; }
        public void FillView() { }
        public ToolStripMenuItem ToolStripMenuItemLargerFont { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemSmallerFont { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemLargerHeaderFont { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemSmallerHeaderFont { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemSaveSettings { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemLoadSettings { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumns { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnId { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnDriver { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnCarPicture { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnFuelLevel { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnLaps { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnPos { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnBestLapTime { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnLapTime { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnLapTimeBest { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnFuelConsumptionWithAverage { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnFuelConsumption { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnStatus { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemColumnPenalties { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemLargerStatusFont { get; private set; }
        public ToolStripMenuItem ToolStripMenuItemSmallerStatusFont { get; private set; }
        public PictureBox GetPicPositionOf(int position)
        {
            return null;
        }
    }
}
