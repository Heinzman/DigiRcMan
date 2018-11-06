using System;
using Elreg.BusinessObjects.Sound;

namespace Elreg.RaceOptionsService
{
    public class SoundOptionsService : ServiceBase<SoundOptions>
    {
        public event EventHandler SoundsChanged;

        public SoundOptionList SoundOptionsPenalty
        {
            get { return SoundOptions.SoundOptionsPenalty; }
            set { SoundOptions.SoundOptionsPenalty = value; }
        }

        public SoundOptionList SoundOptionsPitOut
        {
            get { return SoundOptions.SoundOptionsPitOut; }
            set { SoundOptions.SoundOptionsPitOut = value; }
        }

        public SoundOptionList SoundOptionsPitIn
        {
            get { return SoundOptions.SoundOptionsPitIn; }
            set { SoundOptions.SoundOptionsPitIn = value; }
        }

        public SoundOptionList SoundOptionsLap
        {
            get { return SoundOptions.SoundOptionsLap; }
            set { SoundOptions.SoundOptionsLap = value; }
        }

        public SoundOptionList SoundOptionsNoFuel
        {
            get { return SoundOptions.SoundOptionsNoFuel; }
            set { SoundOptions.SoundOptionsNoFuel = value; }
        }

        public SoundOptionList SoundOptionsDisqualified
        {
            get { return SoundOptions.SoundOptionsDisqualified; }
            set { SoundOptions.SoundOptionsDisqualified = value; }
        }

        public SoundOptionList SoundOptionsRefueled
        {
            get { return SoundOptions.SoundOptionsRefueled; }
            set { SoundOptions.SoundOptionsRefueled = value; }
        }

        public SoundOptionList SoundOptionsLapDetectedNotAdded
        {
            get { return SoundOptions.SoundOptionsLapDetectedNotAdded; }
            set { SoundOptions.SoundOptionsLapDetectedNotAdded = value; }
        }

        public SoundOptionList SoundOptionsFalseStart
        {
            get { return SoundOptions.SoundOptionsFalseStart; }
            set { SoundOptions.SoundOptionsFalseStart = value; }
        }

        public SoundOptionList SoundOptionsLowFuel
        {
            get { return SoundOptions.SoundOptionsLowFuel; }
            set { SoundOptions.SoundOptionsLowFuel = value; }
        }

        public SoundOptionList SoundOptionsFinished
        {
            get { return SoundOptions.SoundOptionsFinished; }
            set { SoundOptions.SoundOptionsFinished = value; }
        }

        public SoundOptionList SoundOptionsEngineDamaged
        {
            get { return SoundOptions.SoundOptionsEngineDamaged; }
            set { SoundOptions.SoundOptionsEngineDamaged = value; }
        }

        public SoundOptionList SoundOptionsPenaltiesDone
        {
            get { return SoundOptions.SoundOptionsPenaltiesDone; }
            set { SoundOptions.SoundOptionsPenaltiesDone = value; }
        }

        public override void Save()
        {
            base.Save();
            RaiseEventSoundsChanged();
        }

        protected override string Filename
        {
            get { return "Sounds.xml"; }
        }

        private SoundOptions SoundOptions
        {
            get { return Object; }
        }

        private void RaiseEventSoundsChanged()
        {
            if (SoundsChanged != null)
                SoundsChanged(this, null);
        }
    }
}
