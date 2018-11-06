using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface IMaintainSoundsView : ISimpleView
    {
        ISoundOptionView CtlFinished { get; }
        ISoundOptionView CtlLapDetectedNotAdded { get; }
        ISoundOptionView CtlDisqualified { get; }
        ISoundOptionView CtlLap { get; }
        ISoundOptionView CtlPenalty { get; }
        Control BtnCancel { get; }
        Control BtnOk { get; }
        ITextToSpeechGrid GrdCoundDown { get; }
        ITextToSpeechGrid GrdSpecialSounds { get; }
        ITextToSpeechGrid GrdDrivers { get; }
        CheckBox ChkCreateNumbers { get; }
        Control BtnCreateWavs { get; }
    }
}