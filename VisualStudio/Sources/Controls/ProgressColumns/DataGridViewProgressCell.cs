using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Elreg.Controls.ProgressColumns
{
    public abstract class DataGridViewProgressCell : DataGridViewImageCell
    {
        private static readonly Image EmptyImage;
        private static int _levelLimitHighToMiddle = 20;
        private static int _levelLimitMiddleToLow = 10;

        private static Color _colorHighLevel = Color.LimeGreen;
        private static Color _colorMiddleLevel = Color.Yellow;
        private static Color _colorLowLevel = Color.Red;

        private static Color _colorLightHighLevel = Color.FromArgb(5, Color.LimeGreen);
        private static Color _colorLightMiddleLevel = Color.FromArgb(70, Color.Yellow);
        private static Color _colorLightLowLevel = Color.FromArgb(70, Color.Red);

        static DataGridViewProgressCell()
        {
            EmptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        protected DataGridViewProgressCell()
        {
            ValueType = typeof(int);
        }

        public override sealed Type ValueType
        {
            get { return base.ValueType; }
            set { base.ValueType = value; }
        }

        public virtual Color ColorHighLevel
        {
            get { return _colorHighLevel; }
            set { _colorHighLevel = value; }
        }

        public virtual Color ColorMiddleLevel
        {
            get { return _colorMiddleLevel; }
            set { _colorMiddleLevel = value; }
        }

        public virtual Color ColorLowLevel
        {
            get { return _colorLowLevel; }
            set { _colorLowLevel = value; }
        }

        public virtual Color ColorLightHighLevel
        {
            get { return _colorLightHighLevel; }
            set { _colorLightHighLevel = value; }
        }

        public virtual Color ColorLightMiddleLevel
        {
            get { return _colorLightMiddleLevel; }
            set { _colorLightMiddleLevel = value; }
        }

        public virtual Color ColorLightLowLevel
        {
            get { return _colorLightLowLevel; }
            set { _colorLightLowLevel = value; }
        }

        public virtual int LevelLimitMiddleToLow
        {
            get { return _levelLimitMiddleToLow; }
            set { _levelLimitMiddleToLow = value; }
        }

        public virtual int LevelLimitHighToMiddle
        {
            get { return _levelLimitHighToMiddle; }
            set { _levelLimitHighToMiddle = value; }
        }

        protected override object GetFormattedValue(object value,
                                                    int rowIndex, ref DataGridViewCellStyle cellStyle,
                                                    TypeConverter valueTypeConverter,
                                                    TypeConverter formattedValueTypeConverter,
                                                    DataGridViewDataErrorContexts context)
        {
            return EmptyImage;
        }

        protected override void Paint(Graphics g, Rectangle clipBounds, Rectangle cellBounds,
                                      int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue,
                                      string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                      DataGridViewPaintParts paintParts)
        {
            KeyValuePair<int, int> progressValue;

            if (value == null || (value is KeyValuePair<int, int>) == false)
                progressValue = new KeyValuePair<int, int>(100, 0);
            else
                progressValue = (KeyValuePair<int, int>)value;

            int progressVal = progressValue.Value;
            float percentage = (progressValue.Value / (float)progressValue.Key); // Need to convert to float before division; otherwise C# returns int which is 0 for anything but 100%.

            // Draws the cell grid
            base.Paint(g, clipBounds, cellBounds,
                       rowIndex, cellState, value, formattedValue, errorText,
                       cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));

            StringFormat sFormat = new StringFormat
                                       {
                                           LineAlignment = StringAlignment.Center,
                                           Alignment = StringAlignment.Center,
                                           FormatFlags = StringFormatFlags.NoWrap
                                       };
            DrawProgressBar(g, cellBounds, cellStyle, percentage, sFormat, progressVal);
        }

        protected abstract void DrawProgressBar(Graphics g, Rectangle cellBounds, DataGridViewCellStyle cellStyle, float percentage,
                                                StringFormat sFormat,
                                                int progressVal);

        protected Color GetForeColorByProgress(int progressVal)
        {
            if (progressVal > LevelLimitHighToMiddle)
                return ColorHighLevel;
            else if (progressVal > LevelLimitMiddleToLow)
                return ColorMiddleLevel;
            else
                return ColorLowLevel;
        }

        protected Color GetBackColorByProgress(int progressVal)
        {
            if (progressVal > LevelLimitHighToMiddle)
                return ColorLightHighLevel;
            else if (progressVal > LevelLimitMiddleToLow)
                return ColorLightMiddleLevel;
            else
                return ColorLightLowLevel;
        }
    }
}