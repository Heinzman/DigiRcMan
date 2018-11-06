using System.Drawing;
using System.Windows.Forms;

namespace Elreg.Controls.ProgressColumns
{
    public abstract class DataGridViewProgressColumn : DataGridViewColumn
    {
        public int LevelLimitMiddleToLow
        {
            set
            {
                DataGridViewProgressCell dataGridViewProgressCell = CellTemplate as DataGridViewProgressCell;
                if (dataGridViewProgressCell != null)
                    dataGridViewProgressCell.LevelLimitMiddleToLow = value;
            }
        }

        public int LevelLimitHighToMiddle
        {
            set
            {
                DataGridViewProgressCell dataGridViewProgressCell = CellTemplate as DataGridViewProgressCell;
                if (dataGridViewProgressCell != null)
                    dataGridViewProgressCell.LevelLimitHighToMiddle = value;
            }
        }

        public Color ColorHighLevel
        {
            set
            {
                DataGridViewProgressCell dataGridViewProgressCell = CellTemplate as DataGridViewProgressCell;
                if (dataGridViewProgressCell != null)
                    dataGridViewProgressCell.ColorHighLevel = value;
            }
        }

        public Color ColorMiddleLevel
        {
            set
            {
                DataGridViewProgressCell dataGridViewProgressCell = CellTemplate as DataGridViewProgressCell;
                if (dataGridViewProgressCell != null)
                    dataGridViewProgressCell.ColorMiddleLevel = value;
            }
        }

        public Color ColorLowLevel
        {
            set
            {
                DataGridViewProgressCell dataGridViewProgressCell = CellTemplate as DataGridViewProgressCell;
                if (dataGridViewProgressCell != null)
                    dataGridViewProgressCell.ColorLowLevel = value;
            }
        }

        public Color ColorLightHighLevel
        {
            set
            {
                DataGridViewProgressCell dataGridViewProgressCell = CellTemplate as DataGridViewProgressCell;
                if (dataGridViewProgressCell != null)
                    dataGridViewProgressCell.ColorLightHighLevel = value;
            }
        }

        public Color ColorLightMiddleLevel
        {
            set
            {
                DataGridViewProgressCell dataGridViewProgressCell = CellTemplate as DataGridViewProgressCell;
                if (dataGridViewProgressCell != null)
                    dataGridViewProgressCell.ColorLightMiddleLevel = value;
            }
        }

        public Color ColorLightLowLevel
        {
            set
            {
                DataGridViewProgressCell dataGridViewProgressCell = CellTemplate as DataGridViewProgressCell;
                if (dataGridViewProgressCell != null)
                    dataGridViewProgressCell.ColorLightLowLevel = value;
            }
        }

    }
}
