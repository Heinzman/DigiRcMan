using System.Windows.Forms;
using System.Drawing;

namespace Elreg.Controls
{
    public class PrettyGrid : DataGridView
    {
        private Image _backgroundImage;

        public override Image BackgroundImage
        {
            get { return _backgroundImage; }
            set { _backgroundImage = value; }
        }

        protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, 
            Rectangle gridBounds)
        {
            base.PaintBackground(graphics, clipBounds, gridBounds);
            if (_backgroundImage != null)
                graphics.DrawImage(_backgroundImage, gridBounds);

        }

    }
}
