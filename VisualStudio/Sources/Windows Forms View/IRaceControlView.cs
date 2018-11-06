using System;
using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface IRaceControlView : ISimpleView, IWin32Window
    {
        Control BtnInit { get; }
        Control BtnStartTraining { get; }
        Control BtnStartQualification { get; }
        Control BtnStartRace { get; }
        Control BtnPauseOrRestart { get; }
        Control BtnStop { get; }
        Control BtnChangeRace { get; }
        Control BtnShowRaceView { get; }
        Control BtnRaceSettings { get; }
        Control BtnDriversOptions { get; }
        Control BtnCarsOptions { get; }
        Control BtnSoundOptions { get; }
        Control BtnShowRaceResults { get; }
        Control BtnShowChampionships { get; }
        Control BtnConfigureArduino { get; }
        Control BtnLogging { get; }
        Label LblComPortStatus { get; }
        void SetEnabled(Control button, bool enabled);
        Cursor Cursor { get; set; }
        Control BtnSoundMixer { get; }
        GroupBox GrpRaceControl { get; }
        GroupBox GrpRace { get; }
        GroupBox GrpResults { get; }
        GroupBox GrpOptions { get; }
        GroupBox GrpSerialPort { get; }
        Control Form { get; }
        IRaceResultsView CreateRaceResultsForm();
    }
}
