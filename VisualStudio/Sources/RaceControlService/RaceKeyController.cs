using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects;
using Elreg.DomainModels.RaceModel;

namespace Elreg.RaceControlService
{
    public class RaceKeyController : IRaceKeyController
    {
        private readonly RaceModel _raceModel;
        private readonly KeySettings _keySettings;

        public event EventHandler ShowInitRaceForm;
        public event EventHandler ShowRaceGridForm;
        public event EventHandler ShowChangeRaceForm;
        public event EventHandler ShowRaceSettingsForm;
        public event EventHandler ShowDriverOptionsForm;
        public event EventHandler ShowCarOptionsForm;
        public event EventHandler ShowSoundOptionsForm;
        public event EventHandler ShowRaceControlForm;
        public event EventHandler ShowMixerForm;
        public event EventHandler StopRace;
        public event EventHandler StartRace;
        public event EventHandler StartTraining;
        public event EventHandler StartQualification;
        public event EventHandler PlayNextSong;
        public event EventHandler TurnDownMusic;
        public event EventHandler TurnUpMusic;
        public event EventHandler TurnDownActionSound;
        public event EventHandler TurnUpActionSound;

        public RaceKeyController(RaceModel raceModel, KeySettings keySettings)
        {
            _raceModel = raceModel;
            _keySettings = keySettings;
        }

        public void HandleKey(KeyEventArgs e)
        {
            e.Handled = true;
            if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.InitRace))
                RaiseEvent(ShowInitRaceForm);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.PauseRace) && (_raceModel.IsPauseByKeyboardOrArduinoPossible))
                _raceModel.PauseRaceByKeyboard();
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RestartRace) && _raceModel.StatusHandler.IsRacePaused)
                _raceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.StartTraining))
                RaiseEvent(StartTraining);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.StartQualification))
                RaiseEvent(StartQualification);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.StartRace))
                RaiseEvent(StartRace);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.StopRace))
                RaiseEvent(StopRace);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.ShowChangeRaceForm))
                RaiseEvent(ShowChangeRaceForm);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.ShowRaceGridForm))
                RaiseEvent(ShowRaceGridForm);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.ShowRaceSettingsForm))
                RaiseEvent(ShowRaceSettingsForm);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.ShowDriverOptionsForm))
                RaiseEvent(ShowDriverOptionsForm);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.ShowCarOptionsForm))
                RaiseEvent(ShowCarOptionsForm);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.ShowSoundOptionsForm))
                RaiseEvent(ShowSoundOptionsForm);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.ShowRaceControlForm))
                RaiseEvent(ShowRaceControlForm);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.ShowMixerForm))
                RaiseEvent(ShowMixerForm);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.PlayNextSong))
                RaiseEvent(PlayNextSong);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.TurnDownActionSound))
                RaiseEvent(TurnDownActionSound);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.TurnUpActionSound))
                RaiseEvent(TurnUpActionSound);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.TurnDownMusic))
                RaiseEvent(TurnDownMusic);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.TurnUpMusic))
                RaiseEvent(TurnUpMusic);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddPenalty1))
                _raceModel.AddPenaltyFor(LaneId.Lane1);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddPenalty2))
                _raceModel.AddPenaltyFor(LaneId.Lane2);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddPenalty3))
                _raceModel.AddPenaltyFor(LaneId.Lane3);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddPenalty4))
                _raceModel.AddPenaltyFor(LaneId.Lane4);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddPenalty5))
                _raceModel.AddPenaltyFor(LaneId.Lane5);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddPenalty6))
                _raceModel.AddPenaltyFor(LaneId.Lane6);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemovePenalty1))
                _raceModel.UndoPenaltyFor(LaneId.Lane1);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemovePenalty2))
                _raceModel.UndoPenaltyFor(LaneId.Lane2);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemovePenalty3))
                _raceModel.UndoPenaltyFor(LaneId.Lane3);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemovePenalty4))
                _raceModel.UndoPenaltyFor(LaneId.Lane4);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemovePenalty5))
                _raceModel.UndoPenaltyFor(LaneId.Lane5);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemovePenalty6))
                _raceModel.UndoPenaltyFor(LaneId.Lane6);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddLap1))
                _raceModel.AddLapManuallyFor(LaneId.Lane1);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddLap2))
                _raceModel.AddLapManuallyFor(LaneId.Lane2);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddLap3))
                _raceModel.AddLapManuallyFor(LaneId.Lane3);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddLap4))
                _raceModel.AddLapManuallyFor(LaneId.Lane4);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddLap5))
                _raceModel.AddLapManuallyFor(LaneId.Lane5);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.AddLap6))
                _raceModel.AddLapManuallyFor(LaneId.Lane6);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemoveLap1))
                _raceModel.RemoveLapFor(LaneId.Lane1);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemoveLap2))
                _raceModel.RemoveLapFor(LaneId.Lane2);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemoveLap3))
                _raceModel.RemoveLapFor(LaneId.Lane3);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemoveLap4))
                _raceModel.RemoveLapFor(LaneId.Lane4);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemoveLap5))
                _raceModel.RemoveLapFor(LaneId.Lane5);
            else if (_keySettings.IsActionKey(e, KeySettings.ActionByKey.RemoveLap6))
                _raceModel.RemoveLapFor(LaneId.Lane6);
        }

        public IEnumerable<KeyEventArgs> GetKeysOf(KeySettings.ActionByKey actionByKey)
        {
            return _keySettings.GetKeysOf(actionByKey);
        }

        private void RaiseEvent(EventHandler eventHandler)
        {
            if (eventHandler != null)
                eventHandler(this, null);
        }

    }
}
