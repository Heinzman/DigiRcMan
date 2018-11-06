using System.Collections.Generic;
using System.Windows.Forms;
using Elreg.BusinessObjects.Options;
using Elreg.RaceControlService;

namespace Elreg.WindowsFormsPresenter.RaceControl
{
    public class ShortCutStringCreator
    {
        private readonly RaceKeyController _raceKeyController;

        public ShortCutStringCreator(RaceKeyController raceKeyController)
        {
            _raceKeyController = raceKeyController;
        }

        public string CreateShortcutStringBy(KeySettings.ActionByKey actionByKey)
        {
            const string separator = " | ";
            const string start = " {";
            const string end = "}";
            const string alt = "Alt+";
            const string ctrl = "Strg+";
            const string shift = "Shift+";

            IEnumerable<KeyEventArgs> keyEventArgsList = _raceKeyController.GetKeysOf(actionByKey);
            string shortcut = start;

            foreach (KeyEventArgs keyEventArgs in keyEventArgsList)
            {
                if (keyEventArgs.Alt)
                    shortcut += alt;
                if (keyEventArgs.Control)
                    shortcut += ctrl;
                if (keyEventArgs.Shift)
                    shortcut += shift;
                shortcut += keyEventArgs.KeyCode + separator;
            }
            if (shortcut.Length > start.Length)
                shortcut = shortcut.Substring(0, shortcut.Length - separator.Length);
            shortcut += end;

            if (shortcut.Length <= start.Length + end.Length)
                shortcut = string.Empty;
            return shortcut;
        }

    }
}
