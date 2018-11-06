using System;
using Elreg.BusinessObjects.Sound;
using Newtonsoft.Json;

// ReSharper disable MemberCanBePrivate.Global
namespace Elreg.BusinessObjects
{
    [Serializable]
    public class Driver
    {
        public Driver()
        {
            SoundOptionsLap = new SoundOptionList();
            Activated = true;
        }

        [JsonIgnore]
        public SoundOptionList SoundOptionsLap { get; set; }

        [JsonIgnore]
        public string Name { get; set; }

        public int? Id { get; set; }

        [JsonIgnore]
        public string SoundFilename { get; set; }

        [JsonIgnore]
        public string HymnFilename { get; set; }

        [JsonIgnore]
        public bool Activated { get; set; }

    }
}