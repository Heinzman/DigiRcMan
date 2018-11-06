using System.Collections.Generic;

namespace Elreg.WinFormsPresentationFramework.SerializationObjects
{
    public class RaceGridSettings
    {
        public readonly List<GridColumnProperties> GridColumnPropertiesList = new List<GridColumnProperties>();
        public int HeaderHeight = 20;
        public float HeaderFontSize = 8f;
        public int RaceStatusHeight = 20;
        public float RaceStatusFontSize = 8f;
        public float PositionFontSize = 22f;
        public int PositionsHeight = 20;
    }
}
