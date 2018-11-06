using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Elreg.BusinessObjects
{
    public class RacePositionDescription
    {
        private readonly SplitContainer _splitContainer;
        private readonly List<Label> _posLabels;

        public RacePositionDescription(SplitContainer splitContainer, List<Label> posLabels)
        {
            _splitContainer = splitContainer;
            _posLabels = posLabels ?? new List<Label>();
        }

        public float FontSize
        {
            get
            {
                float fontSize = 8f;
                if (_posLabels.Count > 0)
                    fontSize = _posLabels[0].Font.Size;
                return fontSize;
            }
            set { SetFontSize(value, _posLabels); }
        }

        public int PositionsHeight
        {
            get { return _splitContainer.SplitterDistance; }
            set { _splitContainer.SplitterDistance = value; }
        }

        private static void SetFontSize(float value, IEnumerable<Label> labelList)
        {
            foreach (Label label in labelList)
            {
                var font = new Font(label.Font.FontFamily, value);
                label.Font = font;
            }
        }
    }
}