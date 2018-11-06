namespace Elreg.BusinessObjects.Sound
{
    public class SoundOptions
    {
        public SoundOptions()
        {
            SoundOptionsPenalty = new SoundOptionList();
            SoundOptionsLap = new SoundOptionList();
            SoundOptionsPitIn = new SoundOptionList();
            SoundOptionsPitOut = new SoundOptionList();
            SoundOptionsLowFuel = new SoundOptionList();
            SoundOptionsNoFuel = new SoundOptionList();
            SoundOptionsLapDetectedNotAdded = new SoundOptionList();
            SoundOptionsFalseStart = new SoundOptionList();
            SoundOptionsDisqualified = new SoundOptionList();
            SoundOptionsRefueled = new SoundOptionList();
            SoundOptionsFinished = new SoundOptionList();
            SoundOptionsPenaltiesDone = new SoundOptionList();
            SoundOptionsEngineDamaged = new SoundOptionList();
        }

        public SoundOptionList SoundOptionsFinished { get; set; }

        public SoundOptionList SoundOptionsRefueled { get; set; }

        public SoundOptionList SoundOptionsDisqualified { get; set; }

        public SoundOptionList SoundOptionsFalseStart { get; set; }

        public SoundOptionList SoundOptionsLapDetectedNotAdded { get; set; }

        public SoundOptionList SoundOptionsNoFuel { get; set; }

        public SoundOptionList SoundOptionsLowFuel { get; set; }

        public SoundOptionList SoundOptionsPitOut { get; set; }

        public SoundOptionList SoundOptionsPitIn { get; set; }

        public SoundOptionList SoundOptionsLap { get; set; }

        public SoundOptionList SoundOptionsPenalty { get; set; }

        public SoundOptionList SoundOptionsEngineDamaged { get; set; }

        public SoundOptionList SoundOptionsPenaltiesDone { get; set; }
    }
}