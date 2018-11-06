using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface ILoggerView : ISimpleView
    {
        bool RaceReplayLoggerChecked { get; set; }
        bool RaceLoggerChecked { get; set; }
        bool PortReaderLoggerChecked { get; set; }
        bool PortParserLoggerChecked { get; set; }
        Button BtnOk { get; }
        Button BtnCancel { get; }
        Button BtnOpenRaceLog { get; }
        Button BtnOpenComPortLog { get; }
        Button BtnOpenPortParserLog { get; }
    }
}
