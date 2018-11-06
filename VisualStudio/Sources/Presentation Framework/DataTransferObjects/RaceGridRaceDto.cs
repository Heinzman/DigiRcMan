using System.Collections.Generic;

namespace Elreg.WinFormsPresentationFramework.DataTransferObjects
{
    public class RaceGridRaceDto
    {
        public string RaceStatus;
        public readonly List<RaceGridLaneDto> Lanes;

        public RaceGridRaceDto()
        {
            Lanes = new List<RaceGridLaneDto>();
        }
    }
}
