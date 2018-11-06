using System;

namespace Elreg.BusinessObjects.Lanes
{
    [Serializable]
    public class ChampionshipLane
    {
        public ChampionshipLane()
        {
            Position = 0;
            Points = 0;
        }

        public int Points { get; set; }

        public int Position { get; set; }

        public Driver Driver { get; set; }
    }
}
