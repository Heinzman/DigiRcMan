using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elreg.Controls.ProgressColumns
{
    public class DataGridViewVertProgressCell : DataGridViewProgressCell
    {
        protected override void DrawProgressBar(Graphics g, Rectangle cellBounds, DataGridViewCellStyle cellStyle, float percentage, StringFormat sFormat,
                             int progressVal)
        {
            Color foreColor = GetForeColorByProgress(progressVal);
            Color backColor = GetBackColorByProgress(progressVal);
            g.FillRectangle(new SolidBrush(backColor), cellBounds.X + 2, cellBounds.Y + 2, cellBounds.Width - 4, cellBounds.Height - 4);
            int progessBarHeight = Convert.ToInt32((1 - percentage)*cellBounds.Height);
            g.FillRectangle(new SolidBrush(foreColor), cellBounds.X + 2, progessBarHeight + cellBounds.Y + 2, cellBounds.Width - 4, cellBounds.Height - progessBarHeight - 4);
            g.DrawString(progressVal.ToString(), cellStyle.Font, new SolidBrush(Color.FromArgb(70, 255, 255, 255)), new Rectangle(cellBounds.X + 1, cellBounds.Y + 1, cellBounds.Width, cellBounds.Height), sFormat);
            g.DrawString(progressVal.ToString(), cellStyle.Font, new SolidBrush(Color.FromArgb(70, 255, 255, 255)), new Rectangle(cellBounds.X - 1, cellBounds.Y + 1, cellBounds.Width, cellBounds.Height), sFormat);
            g.DrawString(progressVal.ToString(), cellStyle.Font, new SolidBrush(Color.FromArgb(70, 255, 255, 255)), new Rectangle(cellBounds.X + 1, cellBounds.Y - 1, cellBounds.Width, cellBounds.Height), sFormat);
            g.DrawString(progressVal.ToString(), cellStyle.Font, new SolidBrush(Color.FromArgb(70, 255, 255, 255)), new Rectangle(cellBounds.X - 1, cellBounds.Y - 1, cellBounds.Width, cellBounds.Height), sFormat);
            g.DrawString(progressVal.ToString(), cellStyle.Font, new SolidBrush(Color.Black), cellBounds, sFormat);
        }

    }
}