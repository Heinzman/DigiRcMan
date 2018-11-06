using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface IRaceReplayView : IRaceGridView
    {
        Label LblEventDescription { get; }
        Label LblRaceTimeNet { get; }
        ProgressBar ProgressBar { get; }
        CheckBox ChkPlayInSteps { get; }
        Button BtnPlayOrPause { get; }
        NumericUpDown UdSpeed { get; }
    }
}
