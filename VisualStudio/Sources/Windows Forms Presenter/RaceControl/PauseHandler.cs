using System.Windows.Forms;
using Elreg.WindowsFormsView;
using Elreg.RaceControlService;
using Elreg.BusinessObjects.Options;

namespace Elreg.WindowsFormsPresenter.RaceControl
{
    public class PauseHandler
    {
        private readonly IRaceControlView _raceControlView;
        private readonly ShortCutStringCreator _shortCutStringCreator;
        private bool _isBtnPauseActivated = true;

        private const string BtntextPause = "Pause";
        private const string BtntextRestart = "Restart";

        public PauseHandler(IRaceControlView raceControlView, RaceKeyController raceKeyController)
        {
            _raceControlView = raceControlView;
            _shortCutStringCreator = new ShortCutStringCreator(raceKeyController);
        }

        public void UpdateControlsWithShortCuts()
        {
            SetControlText(KeySettings.ActionByKey.ShowRaceControlForm, _raceControlView.Form);
            SetControlText(KeySettings.ActionByKey.InitRace, _raceControlView.BtnInit);
            SetControlText(KeySettings.ActionByKey.StartTraining, _raceControlView.BtnStartTraining);
            SetControlText(KeySettings.ActionByKey.StartQualification, _raceControlView.BtnStartQualification);
            SetControlText(KeySettings.ActionByKey.StartRace, _raceControlView.BtnStartRace);
            SetControlText(KeySettings.ActionByKey.StopRace, _raceControlView.BtnStop);
            SetControlText(KeySettings.ActionByKey.ShowChangeRaceForm, _raceControlView.BtnChangeRace);
            SetControlText(KeySettings.ActionByKey.ShowRaceGridForm, _raceControlView.BtnShowRaceView);
            SetControlText(KeySettings.ActionByKey.ShowDriverOptionsForm, _raceControlView.BtnDriversOptions);
            SetControlText(KeySettings.ActionByKey.ShowCarOptionsForm, _raceControlView.BtnCarsOptions);
            SetControlText(KeySettings.ActionByKey.ShowSoundOptionsForm, _raceControlView.BtnSoundOptions);
            SetControlText(KeySettings.ActionByKey.ShowRaceSettingsForm, _raceControlView.BtnRaceSettings);
            SetControlText(KeySettings.ActionByKey.ShowMixerForm, _raceControlView.BtnSoundMixer);
            CreateShortcutForBtnPauseOrRestart();
        }

        public bool IsBtnPauseActivated
        {
            get { return _isBtnPauseActivated; }
            set
            {
                _isBtnPauseActivated = value;
                CreateShortcutForBtnPauseOrRestart();
            }
        }

        private void SetControlText(KeySettings.ActionByKey actionByKey, Control button)
        {
            string text = button.Text + _shortCutStringCreator.CreateShortcutStringBy(actionByKey);
            _raceControlView.SetControlPropertyThreadSafe(button, "Text", text);
        }

        private void CreateShortcutForBtnPauseOrRestart()
        {
            string text = BtntextRestart + _shortCutStringCreator.CreateShortcutStringBy(KeySettings.ActionByKey.PauseRace);
            if (_isBtnPauseActivated)
                text = BtntextPause + _shortCutStringCreator.CreateShortcutStringBy(KeySettings.ActionByKey.PauseRace);
            _raceControlView.SetControlPropertyThreadSafe(_raceControlView.BtnPauseOrRestart, "Text", text);
        }

    }
}
