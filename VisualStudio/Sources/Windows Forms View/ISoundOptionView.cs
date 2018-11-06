using System.Windows.Forms;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Sound;
using Elreg.RaceOptionsService;
using Elreg.RaceSoundService;

namespace Elreg.WindowsFormsView
{
    public interface ISoundOptionView
    {
        BindingSource BindingSource { get; }
        CheckBox ChkChangeFrequency { get; }
        void Init(SoundOptionList soundOptionList, SoundSettings userSoundSettings, ActionSoundsService actionSoundsService, DriversService driversService, RaceSettings raceSettings);
        string Caption { set; }
    }
}
