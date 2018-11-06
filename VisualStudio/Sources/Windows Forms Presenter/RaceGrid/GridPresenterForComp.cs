using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework.SerializationObjects;

namespace Elreg.WindowsFormsPresenter.RaceGrid
{
    public class GridPresenterForComp : GridPresenter
    {
        private readonly IRaceGridView _raceGridView;

        public GridPresenterForComp(IRaceGridView raceGridView)
            : base(raceGridView)
        {
            _raceGridView = raceGridView;
            var raceStatusDescription = new RaceStatusDescription(raceGridView.SplitContainerStatus, raceGridView.Labels);
            var racePositionDescription = new RacePositionDescription(raceGridView.SplitContainerPosition, raceGridView.PositionLabels);
            GridHandler = new GridHandler(raceGridView.GrdLanes, raceStatusDescription, racePositionDescription);
        }

        public void CheckOrUncheckColumnMenuItems()
        {
            foreach (GridColumnProperties gridColumnProperties in GridHandler.RaceGridSettings.GridColumnPropertiesList)
            {
                foreach (ToolStripItem toolStripItem in _raceGridView.MenuItemColumns.DropDownItems)
                {
                    var toolStripMenuItem = toolStripItem as ToolStripMenuItem;
                    if (toolStripMenuItem != null && toolStripMenuItem.Tag.ToString() == gridColumnProperties.Name)
                    {
                        toolStripMenuItem.Checked = gridColumnProperties.Visible;
                        break;
                    }
                }
            }
        }

        protected override string DefaultXmlFileName
        {
            get
            {
                const string fileName = "View_Lanes.xml";
                return ServiceHelper.ConfigViewPath + fileName;
            }
        }

        public void IncreasePositionsCellFont()
        {
            GridHandler.IncreasePositionsCellFont();
        }

        public void DecreasePositionsCellFont()
        {
            GridHandler.DecreasePositionsCellFont();
        }

    }
}
