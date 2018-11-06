using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Elreg.BusinessObjects
{
    public class RaceStatusDescription
    {
        private readonly List<Label> _labels;
        private readonly SplitContainer _splitContainer;

        public RaceStatusDescription(SplitContainer splitContainer, List<Label> labels)
        {
            _splitContainer = splitContainer;
            if (labels == null)
                _labels = new List<Label>();
            else
                _labels = labels;
        }

        public int RaceStatusHeight
        {
            get { return _splitContainer.SplitterDistance; }
            set { _splitContainer.SplitterDistance = value; }
        }

        public float RaceStatusFontSize
        {
            get
            {
                float fontSize = 8f;
                if (_labels.Count > 0)
                    fontSize = _labels[0].Font.Size;
                return fontSize;
            }
            set
            {
                foreach (Label label in _labels)
                {
                    var font = new Font(label.Font.FontFamily, value);
                    label.Font = font;
                }
            }
        }
    }
}