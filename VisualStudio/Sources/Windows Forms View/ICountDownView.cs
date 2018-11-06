using System.Drawing;
using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface ICountDownView : ISimpleView
    {
        string CountDownText { set; }
        Font CountDownFont { get; set; }
        Form Form { get; }
    }
}
