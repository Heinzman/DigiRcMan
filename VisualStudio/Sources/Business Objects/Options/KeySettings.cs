using System.Collections.Generic;
using System.Windows.Forms;

namespace Elreg.BusinessObjects.Options
{
    public class KeySettings
    {
        public enum ActionByKey
        {
            None,
            InitRace,
            StartTraining,
            StartQualification,
            StartRace,
            PauseRace,
            RestartRace,
            StopRace,
            AddPenalty1,
            AddPenalty2,
            AddPenalty3,
            AddPenalty4,
            AddPenalty5,
            AddPenalty6,
            RemovePenalty1,
            RemovePenalty2,
            RemovePenalty3,
            RemovePenalty4,
            RemovePenalty5,
            RemovePenalty6,
            AddLap1,
            AddLap2,
            AddLap3,
            AddLap4,
            AddLap5,
            AddLap6,
            RemoveLap1,
            RemoveLap2,
            RemoveLap3,
            RemoveLap4,
            RemoveLap5,
            RemoveLap6,
            ShowChangeRaceForm,
            ShowRaceGridForm,
            ShowRaceSettingsForm,
            ShowDriverOptionsForm,
            ShowCarOptionsForm,
            ShowSoundOptionsForm,
            ShowRaceControlForm,
            ShowMixerForm,
            PlayNextSong,
            TurnDownMusic,
            TurnUpMusic,
            TurnDownActionSound,
            TurnUpActionSound
        }

        private readonly List<KeyValuePair<ActionByKey, KeyEventArgs>> _registeredKeys =
            new List<KeyValuePair<ActionByKey, KeyEventArgs>>();

        public KeySettings()
        {
            InitRegisteredKeysWithDefaultValues();
        }

        public bool IsActionKey(KeyEventArgs keyEventArgs, ActionByKey actionByKey)
        {
            bool ret = false;
            List<ActionByKey> foundActionsByKey = GetActionsByKey(keyEventArgs);

            foreach (ActionByKey foundActionByKey in foundActionsByKey)
            {
                if (actionByKey == foundActionByKey)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public List<ActionByKey> GetActionsByKey(KeyEventArgs keyEventArgs)
        {
            var actionsByKey = new List<ActionByKey>();
            foreach (var registeredKey in _registeredKeys)
            {
                if (registeredKey.Value.KeyData == keyEventArgs.KeyData &&
                    registeredKey.Value.Modifiers == keyEventArgs.Modifiers)
                    actionsByKey.Add(registeredKey.Key);
            }
            return actionsByKey;
        }

        public List<KeyEventArgs> GetKeysOf(ActionByKey actionByKey)
        {
            var keyEventArgsList = new List<KeyEventArgs>();
            foreach (var registeredKey in _registeredKeys)
            {
                if (registeredKey.Key == actionByKey)
                {
                    KeyEventArgs keyEventArgs = registeredKey.Value;
                    keyEventArgsList.Add(keyEventArgs);
                }
            }
            return keyEventArgsList;
        }

        private void InitRegisteredKeysWithDefaultValues()
        {
            RegisterRaceControlKeys();
            RegisterOptionsKeys();
            RegisterLapKeys();
            RegisterPenaltyKeys();
            RegisterSoundKeys();
        }

        private void RegisterSoundKeys()
        {
            AddRegisteredKey(ActionByKey.PlayNextSong, Keys.F10 | Keys.Alt);
            AddRegisteredKey(ActionByKey.TurnUpMusic, Keys.PageUp | Keys.Shift);
            AddRegisteredKey(ActionByKey.TurnDownMusic, Keys.PageDown | Keys.Shift);
            AddRegisteredKey(ActionByKey.TurnUpActionSound, Keys.PageUp | Keys.Control);
            AddRegisteredKey(ActionByKey.TurnDownActionSound, Keys.PageDown | Keys.Control);
        }

        private void RegisterRaceControlKeys()
        {
            AddRegisteredKey(ActionByKey.InitRace, Keys.F1);
            AddRegisteredKey(ActionByKey.StartTraining, Keys.F2);
            AddRegisteredKey(ActionByKey.StartQualification, Keys.F3);
            AddRegisteredKey(ActionByKey.StartRace, Keys.F4);
            AddRegisteredKey(ActionByKey.PauseRace, Keys.F5);
            AddRegisteredKey(ActionByKey.RestartRace, Keys.F5);
            AddRegisteredKey(ActionByKey.StopRace, Keys.F6);
            AddRegisteredKey(ActionByKey.PauseRace, Keys.Space);
            AddRegisteredKey(ActionByKey.RestartRace, Keys.Space);
        }

        private void RegisterOptionsKeys()
        {
            AddRegisteredKey(ActionByKey.ShowRaceGridForm, Keys.F7);
            AddRegisteredKey(ActionByKey.ShowRaceGridForm, Keys.End);
            AddRegisteredKey(ActionByKey.ShowChangeRaceForm, Keys.F8);
            AddRegisteredKey(ActionByKey.ShowRaceSettingsForm, Keys.F9);
            AddRegisteredKey(ActionByKey.ShowMixerForm, Keys.F10);
            AddRegisteredKey(ActionByKey.ShowRaceControlForm, Keys.Home);
        }

        private void RegisterLapKeys()
        {
            AddRegisteredKey(ActionByKey.AddLap1, Keys.D1 | Keys.Alt);
            AddRegisteredKey(ActionByKey.AddLap2, Keys.D2 | Keys.Alt);
            AddRegisteredKey(ActionByKey.AddLap3, Keys.D3 | Keys.Alt);
            AddRegisteredKey(ActionByKey.AddLap4, Keys.D4 | Keys.Alt);
            AddRegisteredKey(ActionByKey.AddLap5, Keys.D5 | Keys.Alt);
            AddRegisteredKey(ActionByKey.AddLap6, Keys.D6 | Keys.Alt);

            AddRegisteredKey(ActionByKey.RemoveLap1, Keys.D1 | Keys.Alt | Keys.Shift);
            AddRegisteredKey(ActionByKey.RemoveLap2, Keys.D2 | Keys.Alt | Keys.Shift);
            AddRegisteredKey(ActionByKey.RemoveLap3, Keys.D3 | Keys.Alt | Keys.Shift);
            AddRegisteredKey(ActionByKey.RemoveLap4, Keys.D4 | Keys.Alt | Keys.Shift);
            AddRegisteredKey(ActionByKey.RemoveLap5, Keys.D5 | Keys.Alt | Keys.Shift);
            AddRegisteredKey(ActionByKey.RemoveLap6, Keys.D6 | Keys.Alt | Keys.Shift);
        }

        private void RegisterPenaltyKeys()
        {
            AddRegisteredKey(ActionByKey.AddPenalty1, Keys.D1);
            AddRegisteredKey(ActionByKey.AddPenalty2, Keys.D2);
            AddRegisteredKey(ActionByKey.AddPenalty3, Keys.D3);
            AddRegisteredKey(ActionByKey.AddPenalty4, Keys.D4);
            AddRegisteredKey(ActionByKey.AddPenalty5, Keys.D5);
            AddRegisteredKey(ActionByKey.AddPenalty6, Keys.D6);

            AddRegisteredKey(ActionByKey.RemovePenalty1, Keys.D1 | Keys.Shift);
            AddRegisteredKey(ActionByKey.RemovePenalty2, Keys.D2 | Keys.Shift);
            AddRegisteredKey(ActionByKey.RemovePenalty3, Keys.D3 | Keys.Shift);
            AddRegisteredKey(ActionByKey.RemovePenalty4, Keys.D4 | Keys.Shift);
            AddRegisteredKey(ActionByKey.RemovePenalty5, Keys.D5 | Keys.Shift);
            AddRegisteredKey(ActionByKey.RemovePenalty6, Keys.D6 | Keys.Shift);
        }

        private void AddRegisteredKey(ActionByKey actionByKey, Keys keys)
        {
            var keyEventArgs = new KeyEventArgs(keys);
            var registeredKey = new KeyValuePair<ActionByKey, KeyEventArgs>(actionByKey, keyEventArgs);
            _registeredKeys.Add(registeredKey);
        }
    }
}