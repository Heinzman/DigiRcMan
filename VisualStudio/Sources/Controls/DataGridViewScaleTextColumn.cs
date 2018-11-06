using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using Elreg.HelperClasses;

namespace Elreg.Controls
{
    public sealed class DataGridViewScaleTextColumn : DataGridViewTextBoxColumn
    {
        public DataGridViewScaleTextColumn()
        {
            CellTemplate = new DataGridViewScaleTextCell();
        }
    }

    class DataGridViewScaleTextCell : DataGridViewTextBoxCell
    {

        public DataGridViewScaleTextCell()
        {
            ValueType = typeof(string);
        }

        public override sealed Type ValueType
        {
            get { return base.ValueType; }
            set { base.ValueType = value; }
        }

        protected override object GetFormattedValue(object value,
                            int rowIndex, ref DataGridViewCellStyle cellStyle,
                            TypeConverter valueTypeConverter,
                            TypeConverter formattedValueTypeConverter,
                            DataGridViewDataErrorContexts context)
        {
            return string.Empty;
        }

        protected override void Paint(Graphics g, Rectangle clipBounds, Rectangle cellBounds, 
                                      int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, 
                                      string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, 
                                      DataGridViewPaintParts paintParts)
        {
            string text = value as string;
            // Draws the cell grid
            base.Paint(g, clipBounds, cellBounds,
                     rowIndex, cellState, value, formattedValue, errorText,
                     cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));

            using (Font f = new Font("Tahoma", 15))
            {
                SizeF size;
                using (Font f2 = AppropriateFont(g, 5, 50, cellBounds.Size, text, f, out size))
                {
                    PointF p = new PointF( (cellBounds.Width - size.Width) / 2, (cellBounds.Height - size.Height) / 2);
                    g.DrawString(text, f2, Brushes.Black, p);
                    TextRenderer.DrawText(g, text, f2, new Point(cellBounds.Location.X + 20, cellBounds.Location.Y), cellStyle.SelectionForeColor, TextFormatFlags.EndEllipsis);

                }
            }


            //if (value == null)
            //    value = 0;
            //int progressVal = (int)value;
            //float percentage = ((float)progressVal / 100.0f); // Need to convert to float before division; otherwise C# returns int which is 0 for anything but 100%.

            //// Draws the cell grid
            //base.Paint(g, clipBounds, cellBounds,
            //         rowIndex, cellState, value, formattedValue, errorText,
            //         cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));

            //StringFormat sFormat = new StringFormat();
            //sFormat.LineAlignment = StringAlignment.Center;
            //sFormat.Alignment = StringAlignment.Center;
            //sFormat.FormatFlags = StringFormatFlags.NoWrap;

            //// Draw the progress bar and the text
            //Color color = GetColorByProgress(progressVal);
            //g.FillRectangle(new SolidBrush(color), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 4);
            //g.DrawString(progressVal + "%", cellStyle.Font, new SolidBrush(Color.FromArgb(70, 255, 255, 255)), new Rectangle(cellBounds.X + 1, cellBounds.Y + 1, cellBounds.Width, cellBounds.Height), sFormat);
            //g.DrawString(progressVal + "%", cellStyle.Font, new SolidBrush(Color.FromArgb(70, 255, 255, 255)), new Rectangle(cellBounds.X - 1, cellBounds.Y + 1, cellBounds.Width, cellBounds.Height), sFormat);
            //g.DrawString(progressVal + "%", cellStyle.Font, new SolidBrush(Color.FromArgb(70, 255, 255, 255)), new Rectangle(cellBounds.X + 1, cellBounds.Y - 1, cellBounds.Width, cellBounds.Height), sFormat);
            //g.DrawString(progressVal + "%", cellStyle.Font, new SolidBrush(Color.FromArgb(70, 255, 255, 255)), new Rectangle(cellBounds.X - 1, cellBounds.Y - 1, cellBounds.Width, cellBounds.Height), sFormat);
            //.DrawString(progressVal + "%", cellStyle.Font, new SolidBrush(Color.Black), cellBounds, sFormat);
        }

        public Font AppropriateFont(Graphics g, float minFontSize, float maxFontSize, Size layoutSize, string s, Font f, out SizeF extent)
        {
            if (Math.Abs(maxFontSize - minFontSize) < SystemHelper.Epsilon)
                f = new Font(f.FontFamily, minFontSize, f.Style);

            extent = g.MeasureString(s, f);

            if (maxFontSize <= minFontSize)
                return f;

            float hRatio = layoutSize.Height / extent.Height;
            float wRatio = layoutSize.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = f.Size * ratio;

            if (newSize < minFontSize)
                newSize = minFontSize;
            else if (newSize > maxFontSize)
                newSize = maxFontSize;

            f = new Font(f.FontFamily, newSize, f.Style);
            extent = g.MeasureString(s, f);

            return f;
        }

    }
}
