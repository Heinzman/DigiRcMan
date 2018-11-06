using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Elreg.Log;

namespace Elreg.Controls
{
    // ReSharper disable DoNotCallOverridableMethodsInConstructor
    [DefaultEvent("Click")]
    public class VistaButton : UserControl
    {
        #region -  Designer  -

        /// <summary>
        /// Initialize the component with it's
        /// default settings.
        /// </summary>
        public VistaButton()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            _mFadeIn.Interval = 30;
            _mFadeOut.Interval = 30;
        }

        #region -  Component Designer generated code  -

        private void InitializeComponent()
        {
            // 
            // VistaButton
            // 
            Name = "VistaButton";
            Size = new Size(100, 32);
            Paint += VistaButtonPaint;
            KeyUp += VistaButtonKeyUp;
            KeyDown += VistaButtonKeyDown;
            MouseEnter += VistaButtonMouseEnter;
            MouseLeave += VistaButtonMouseLeave;
            MouseUp += VistaButtonMouseUp;
            MouseDown += VistaButtonMouseDown;
            GotFocus += VistaButtonMouseEnter;
            LostFocus += VistaButtonMouseLeave;
            _mFadeIn.Tick += MFadeInTick;
            _mFadeOut.Tick += MFadeOutTick;
            Resize += VistaButtonResize;
        }

        #endregion

        #endregion

        #region -  Enums  -

        /// <summary>
        /// A public enumeration that determines whether
        /// the button background is painted when the 
        /// mouse is not inside the ClientArea.
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// Draw the button as normal
            /// </summary>
            Default,

            /// <summary>
            /// Only draw the background on mouse over.
            /// </summary>
            Flat
        };

        /// <summary>
        /// A private enumeration that determines 
        /// the mouse state in relation to the 
        /// current instance of the control.
        /// </summary>
        private enum State
        {
            None,
            Hover,
            Pressed
        };

        #endregion

        #region -  Properties  -

        private readonly Timer _mFadeIn = new Timer();
        private readonly Timer _mFadeOut = new Timer();
        private bool _calledbykey;
        private State _mButtonState = State.None;
        private int _mGlowAlpha;
        private Color _mUserButtonColor = Color.Black;
        private Color _mUserForeColor = Color.Black;

        #region -  Text  -

        private Color _mForeColor = Color.White;
        private string _mText;
        private ContentAlignment _mTextAlign = ContentAlignment.MiddleCenter;

        /// <summary>
        /// The text that is displayed on the button.
        /// </summary>
        [Category("Text"),
         Browsable(true),
         DefaultValue(""),
         Description("The text that is displayed on the button.")]
        public override string Text
        {
            get { return _mText; }
            set
            {
                _mText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The text that is displayed on the button.
        /// </summary>
        [Category("Text"),
         Description("The text that is displayed on the button.")]
        public string ButtonText
        {
            get { return _mText; }
            set
            {
                _mText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The color with which the text is drawn.
        /// </summary>
        [Category("Text"),
         Browsable(true),
         DefaultValue(typeof (Color), "White"),
         Description("The color with which the text is drawn.")]
        public override Color ForeColor
        {
            get { return _mForeColor; }
            set
            {
                _mForeColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The alignment of the button text
        /// that is displayed on the control.
        /// </summary>
        [Category("Text"),
         DefaultValue(typeof (ContentAlignment), "MiddleCenter"),
         Description("The alignment of the button text " +
                     "that is displayed on the control.")]
        public ContentAlignment TextAlign
        {
            get { return _mTextAlign; }
            set
            {
                _mTextAlign = value;
                Invalidate();
            }
        }

        #endregion

        #region -  Image  -

        private Image _mImage;

        private ContentAlignment _mImageAlign = ContentAlignment.MiddleLeft;

        private Size _mImageSize = new Size(24, 24);

        /// <summary>
        /// The image displayed on the button that 
        /// is used to help the user identify
        /// it's function if the text is ambiguous.
        /// </summary>
        [Category("Image"),
         DefaultValue(null),
         Description("The image displayed on the button that " +
                     "is used to help the user identify" +
                     "it's function if the text is ambiguous.")]
        public Image Image
        {
            get { return _mImage; }
            set
            {
                _mImage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The alignment of the image 
        /// in relation to the button.
        /// </summary>
        [Category("Image"),
         DefaultValue(typeof (ContentAlignment), "MiddleLeft"),
         Description("The alignment of the image " +
                     "in relation to the button.")]
        public ContentAlignment ImageAlign
        {
            get { return _mImageAlign; }
            set
            {
                _mImageAlign = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The size of the image to be displayed on the
        /// button. This property defaults to 24x24.
        /// </summary>
        [Category("Image"),
         DefaultValue(typeof (Size), "24, 24"),
         Description("The size of the image to be displayed on the" +
                     "button. This property defaults to 24x24.")]
        public Size ImageSize
        {
            get { return _mImageSize; }
            set
            {
                _mImageSize = value;
                Invalidate();
            }
        }

        #endregion

        #region -  Appearance  -

        private Image _mBackImage;
        private Color _mBaseColor = Color.Black;
        private Color _mButtonColor = Color.Black;
        private Style _mButtonStyle = Style.Default;

        private int _mCornerRadius = 8;
        private Color _mGlowColor = Color.FromArgb(141, 189, 255);

        private Color _mHighlightColor = Color.White;

        /// <summary>
        /// Sets whether the button background is drawn 
        /// while the mouse is outside of the client area.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(typeof (Style), "Default"),
         Description("Sets whether the button background is drawn " +
                     "while the mouse is outside of the client area.")]
        public Style ButtonStyle
        {
            get { return _mButtonStyle; }
            set
            {
                _mButtonStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The radius for the button corners. The 
        /// greater this value is, the more 'smooth' 
        /// the corners are. This property should
        ///  not be greater than half of the 
        ///  controls height.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(8),
         Description("The radius for the button corners. The " +
                     "greater this value is, the more 'smooth' " +
                     "the corners are. This property should " +
                     "not be greater than half of the " +
                     "controls height.")]
        public int CornerRadius
        {
            get { return _mCornerRadius; }
            set
            {
                _mCornerRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The colour of the highlight on the top of the button.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(typeof (Color), "White"),
         Description("The colour of the highlight on the top of the button.")]
        public Color HighlightColor
        {
            get { return _mHighlightColor; }
            set
            {
                _mHighlightColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The bottom color of the button that 
        /// will be drawn over the base color.
        /// </summary>
        [Category("Appearance"), DefaultValue(typeof (Color), "Black"),
         Description("The bottom color of the button that will be drawn over the base color.")]
        public Color ButtonColor
        {
            get { return _mButtonColor; }
            set
            {
                _mButtonColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The colour that the button glows when
        /// the mouse is inside the client area.
        /// </summary>
        [Category("Appearance"), DefaultValue(typeof (Color), "141,189,255"),
         Description("The colour that the button glows when the mouse is inside the client area.")]
        public Color GlowColor
        {
            get { return _mGlowColor; }
            set
            {
                _mGlowColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The background image for the button, 
        /// this image is drawn over the base 
        /// color of the button.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(null),
         Description("The background image for the button, " +
                     "this image is drawn over the base " +
                     "color of the button.")]
        public Image BackImage
        {
            get { return _mBackImage; }
            set
            {
                _mBackImage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The backing color that the rest of 
        /// the button is drawn. For a glassier 
        /// effect set this property to Transparent.
        /// </summary>
        [Category("Appearance"),
         DefaultValue(typeof (Color), "Black"),
         Description("The backing color that the rest of" +
                     "the button is drawn. For a glassier " +
                     "effect set this property to Transparent.")]
        public Color BaseColor
        {
            get { return _mBaseColor; }
            set
            {
                _mBaseColor = value;
                Invalidate();
            }
        }

        #endregion

        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                bool enabledHasChanged = value != base.Enabled;
                base.Enabled = value;
                if (enabledHasChanged)
                    SwitchAppearenceDependsOnEnabled();
            }
        }

        #endregion

        #region -  Functions  -

        private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X, y = r.Y, w = r.Width, h = r.Height;
            var rr = new GraphicsPath();
            rr.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr.AddLine(x + r1, y, x + w - r2, y);
            rr.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr.AddLine(x, y + h - r4, x, y + r1);
            return rr;
        }

        private StringFormat StringFormatAlignment(ContentAlignment textalign)
        {
            var sf = new StringFormat();
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    sf.LineAlignment = StringAlignment.Far;
                    break;
            }
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    break;
            }
            return sf;
        }

        #endregion

        #region -  Drawing  -

        /// <summary>
        /// Draws the outer border for the control
        /// using the ButtonColor property.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawOuterStroke(Graphics g)
        {
            if (ButtonStyle == Style.Flat && _mButtonState == State.None)
            {
                return;
            }
            Rectangle r = ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (var p = new Pen(ButtonColor))
                {
                    g.DrawPath(p, rr);
                }
            }
        }

        /// <summary>
        /// Draws the inner border for the control
        /// using the HighlightColor property.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawInnerStroke(Graphics g)
        {
            if (ButtonStyle == Style.Flat && _mButtonState == State.None)
            {
                return;
            }
            Rectangle r = ClientRectangle;
            r.X++;
            r.Y++;
            r.Width -= 3;
            r.Height -= 3;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (var p = new Pen(HighlightColor))
                {
                    g.DrawPath(p, rr);
                }
            }
        }

        /// <summary>
        /// Draws the background for the control
        /// using the background image and the 
        /// BaseColor.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawBackground(Graphics g)
        {
            if (ButtonStyle == Style.Flat && _mButtonState == State.None)
            {
                return;
            }
            int alpha = (_mButtonState == State.Pressed) ? 204 : 127;
            Rectangle r = ClientRectangle;
            r.Width--;
            r.Height--;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (var sb = new SolidBrush(BaseColor))
                {
                    g.FillPath(sb, rr);
                }
                SetClip(g);
                if (BackImage != null)
                {
                    g.DrawImage(BackImage, ClientRectangle);
                }
                g.ResetClip();
                using (var sb = new SolidBrush(Color.FromArgb(alpha, ButtonColor)))
                {
                    g.FillPath(sb, rr);
                }
            }
        }

        /// <summary>
        /// Draws the Highlight over the top of the
        /// control using the HightlightColor.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawHighlight(Graphics g)
        {
            if (ButtonStyle == Style.Flat && _mButtonState == State.None)
            {
                return;
            }
            int alpha = (_mButtonState == State.Pressed) ? 60 : 150;
            var rect = new Rectangle(0, 0, Width, Height/2);
            using (GraphicsPath r = RoundRect(rect, CornerRadius, CornerRadius, 0, 0))
            {
                using (var lg = new LinearGradientBrush(r.GetBounds(),
                                                        Color.FromArgb(alpha, HighlightColor),
                                                        Color.FromArgb(alpha/3, HighlightColor),
                                                        LinearGradientMode.Vertical))
                {
                    g.FillPath(lg, r);
                }
            }
        }

        /// <summary>
        /// Draws the glow for the button when the
        /// mouse is inside the client area using
        /// the GlowColor property.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawGlow(Graphics g)
        {
            if (_mButtonState == State.Pressed)
            {
                return;
            }
            SetClip(g);
            using (var glow = new GraphicsPath())
            {
                glow.AddEllipse(-5, Height/2 - 10, Width + 11, Height + 11);
                using (var gl = new PathGradientBrush(glow))
                {
                    gl.CenterColor = Color.FromArgb(_mGlowAlpha, GlowColor);
                    gl.SurroundColors = new[] {Color.FromArgb(0, GlowColor)};
                    g.FillPath(gl, glow);
                }
            }
            g.ResetClip();
        }

        /// <summary>
        /// Draws the text for the button.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawText(Graphics g)
        {
            StringFormat sf = StringFormatAlignment(TextAlign);
            var r = new Rectangle(8, 8, Width - 17, Height - 17);
            g.DrawString(ButtonText, Font, new SolidBrush(ForeColor), r, sf);
        }

        /// <summary>
        /// Draws the image for the button
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawImage(Graphics g)
        {
            if (Image == null)
            {
                return;
            }
            var r = new Rectangle(8, 8, ImageSize.Width, ImageSize.Height);
            switch (ImageAlign)
            {
                case ContentAlignment.TopCenter:
                    r = new Rectangle(Width/2 - ImageSize.Width/2, 8, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.TopRight:
                    r = new Rectangle(Width - 8 - ImageSize.Width, 8, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.MiddleLeft:
                    r = new Rectangle(8, Height/2 - ImageSize.Height/2, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.MiddleCenter:
                    r = new Rectangle(Width/2 - ImageSize.Width/2, Height/2 - ImageSize.Height/2, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.MiddleRight:
                    r = new Rectangle(Width - 8 - ImageSize.Width, Height/2 - ImageSize.Height/2, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.BottomLeft:
                    r = new Rectangle(8, Height - 8 - ImageSize.Height, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.BottomCenter:
                    r = new Rectangle(Width/2 - ImageSize.Width/2, Height - 8 - ImageSize.Height, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.BottomRight:
                    r = new Rectangle(Width - 8 - ImageSize.Width, Height - 8 - ImageSize.Height, ImageSize.Width, ImageSize.Height);
                    break;
            }
            g.DrawImage(Image, r);
        }

        private void SetClip(Graphics g)
        {
            Rectangle r = ClientRectangle;
            r.X++;
            r.Y++;
            r.Width -= 3;
            r.Height -= 3;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                g.SetClip(rr);
            }
        }

        #endregion

        #region -  Private Subs  -

        private void VistaButtonPaint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                DrawBackground(e.Graphics);
                DrawHighlight(e.Graphics);
                DrawImage(e.Graphics);
                DrawText(e.Graphics);
                DrawGlow(e.Graphics);
                DrawOuterStroke(e.Graphics);
                DrawInnerStroke(e.Graphics);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void VistaButtonResize(object sender, EventArgs e)
        {
            try
            {
                Rectangle r = ClientRectangle;
                r.X -= 1;
                r.Y -= 1;
                r.Width += 2;
                r.Height += 2;
                using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
                {
                    Region = new Region(rr);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SwitchAppearenceDependsOnEnabled()
        {
            if (Enabled)
                SetAppearenceToEnabled();
            else
                SetAppearenceToDisabled();
        }

        private void SetAppearenceToEnabled()
        {
            ForeColor = _mUserForeColor;
            ButtonColor = _mUserButtonColor;
        }

        private void SetAppearenceToDisabled()
        {
            _mUserForeColor = ForeColor;
            _mUserButtonColor = ButtonColor;
            ForeColor = Color.Gray;
            ButtonColor = Color.Transparent;
        }

        #region -  Mouse and Keyboard Events  -

        private void VistaButtonMouseEnter(object sender, EventArgs e)
        {
            try
            {
                _mButtonState = State.Hover;
                _mFadeOut.Stop();
                _mFadeIn.Start();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void VistaButtonMouseLeave(object sender, EventArgs e)
        {
            try
            {
                _mButtonState = State.None;
                if (_mButtonStyle == Style.Flat)
                {
                    _mGlowAlpha = 0;
                }
                _mFadeIn.Stop();
                _mFadeOut.Start();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void VistaButtonMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    _mButtonState = State.Pressed;
                    if (_mButtonStyle != Style.Flat)
                    {
                        _mGlowAlpha = 255;
                    }
                    _mFadeIn.Stop();
                    _mFadeOut.Stop();
                    Invalidate();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void MFadeInTick(object sender, EventArgs e)
        {
            try
            {
                if (ButtonStyle == Style.Flat)
                {
                    _mGlowAlpha = 0;
                }
                if (_mGlowAlpha + 30 >= 255)
                {
                    _mGlowAlpha = 255;
                    _mFadeIn.Stop();
                }
                else
                {
                    _mGlowAlpha += 30;
                }
                Invalidate();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void MFadeOutTick(object sender, EventArgs e)
        {
            try
            {
                if (ButtonStyle == Style.Flat)
                {
                    _mGlowAlpha = 0;
                }
                if (_mGlowAlpha - 30 <= 0)
                {
                    _mGlowAlpha = 0;
                    _mFadeOut.Stop();
                }
                else
                {
                    _mGlowAlpha -= 30;
                }
                Invalidate();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void VistaButtonKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                {
                    var m = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                    VistaButtonMouseDown(sender, m);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void VistaButtonKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    var m = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                    _calledbykey = true;
                    VistaButtonMouseUp(sender, m);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void VistaButtonMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    _mButtonState = State.Hover;
                    _mFadeIn.Stop();
                    _mFadeOut.Stop();
                    Invalidate();
                    if (_calledbykey)
                    {
                        OnClick(EventArgs.Empty);
                        _calledbykey = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        #endregion

        #endregion
    }
}