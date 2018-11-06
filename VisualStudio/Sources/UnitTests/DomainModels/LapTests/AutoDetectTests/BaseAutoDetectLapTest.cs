using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Races;
using Elreg.DomainModels;
using Elreg.UnitTests.TestHelper;
using NUnit.Framework;

namespace Elreg.UnitTests.DomainModels.LapTests.AutoDetectTests
{
    public class BaseAutoDetectLapTest : BaseLapTest
    {
        protected void ForceNormalAutoDetectedLapFor(Race.TypeEnum competitionType)
        {
            const int defaultSpeedSum = 25;
            InitAndStartRaceAndAddZerothLap(defaultSpeedSum, competitionType);
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 8, new List<uint> { 8 });
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 8, new List<uint> { 8 });
            Assert.IsTrue(Lane1.Lap == 0);
            MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 9, new List<uint> { 9 });
        }

        protected void ForceZerothAutoDetectedLapForLane3For(Race.TypeEnum competitionType)
        {
            InitAndStartCompetition(competitionType);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane1, 1);
            AddLapAndAddSpeedSumTenTimesOf(LaneId.Lane2, 1);
            AddSpeedSumTenTimesOf(LaneId.Lane3, 2);
        }

        protected void InitAndStartCompetition(Race.TypeEnum competitionType)
        {
            RaceModel.SpeedSumAvgCalculator = new SpeedSumAvgCalculator();
            StartCompetition(competitionType);
        }

        private void InitAndStartRaceAndAddZerothLap(int defaultSpeedSum, Race.TypeEnum competitionType)
        {
            RaceSettings.AutoDetectLapSpeedFactor = 1;
            RaceSettings.StartCountDownRaceActivated = false;
            RaceSettings.RestartCountDownRaceActivated = false;
            RaceModel.SpeedSumAvgCalculator = new SpeedSumAvgCalculator();
            StartCompetition(competitionType);
            AutoDetectLapSpeedSum = defaultSpeedSum;
            AddRegularLapAndWaitValidSeconds();
        }

        protected void AddLapAndAddSpeedSumTenTimesOf(LaneId laneId, uint speedSum)
        {
            AddSpeedSumTenTimesOf(laneId, speedSum);
            MockRaceDataProvider.RaiseAddLapForLane(laneId);
        }

        protected void AddSpeedSumTenTimesOf(LaneId laneId, uint speedSum)
        {
            for (int i = 0; i < 10; i++)
                MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(laneId, speedSum, new List<uint> { speedSum });
        }

    }
}
