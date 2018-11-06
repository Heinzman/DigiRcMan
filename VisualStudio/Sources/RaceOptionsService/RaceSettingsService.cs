using System;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Options;

namespace Elreg.RaceOptionsService
{
    public class RaceSettingsService : ServiceBase<RaceSettings>
    {
        public static event EventHandler<SurroundSoundEventArgs> SoundOptionsChanged;

        public RaceSettings RaceSettings
        {
            get { return Object; }
        }

        protected override string Filename
        {
            get { return "RaceSettings.xml"; }
        }

        public bool HasSoundOptionsChanged { private get; set; }

        public override void Save()
        {
            base.Save();
            CheckToRaiseEventSoundOptionsChanged();
        }

        private void CheckToRaiseEventSoundOptionsChanged()
        {
            if (HasSoundOptionsChanged && SoundOptionsChanged != null)
            {
                SurroundSoundEventArgs surroundSoundEventArgs = new SurroundSoundEventArgs(isSurround: false);
                SoundOptionsChanged(this, surroundSoundEventArgs);
            }
        }
    }
}
