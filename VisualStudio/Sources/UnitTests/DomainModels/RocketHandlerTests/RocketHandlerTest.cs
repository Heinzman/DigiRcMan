using Elreg.BusinessObjects;
using Elreg.CentralUnitService;
using Elreg.CentralUnitService.Settings;
using Elreg.DomainModels.RocketModel;
using Elreg.UnitTests.TestHelper;

namespace Elreg.UnitTests.DomainModels.RocketHandlerTests
{
    public class RocketHandlerTest : BaseLapTest
    {
        protected RocketHandler RocketHandler { get; set; }

        protected override void InitSpecificObjects()
        {
            CentralUnitOptionsService = new OptionsService();
            CentralUnitOptionsService.Options.RocketSettings.IsDefensiveRocketsAllowed = true;
            CentralUnitOptionsService.Options.RocketSettings.MaxSecsToInitializeRockets = 0;
            RocketHandler = new RocketHandler(RaceModel, CentralUnitOptionsService.Options.RocketSettings);
            RaceModel.CentralUnitOptions = CentralUnitOptionsService.Options;
            StartRace();
        }

        protected ICentralUnitOptionsService CentralUnitOptionsService { get; private set; }

        protected override void DisposeSpecificObjects()
        {
            RocketHandler.Dispose();
        }

        protected void AddMinLapForeachLane()
        {
            for (int i = 0; i < MinLapCount + 2; i++)
                AddLapForeachLane();
        }

        protected int MinLapCount
        {
            get { return CentralUnitOptionsService.Options.RocketSettings.MinLapsToInitializeRockets; }
        }

        protected int MaxRocketsCount
        {
            get { return CentralUnitOptionsService.Options.RocketSettings.MaxRocketsCount; }
        }

        protected void AddLapForeachLane()
        {
            MockRaceDataProvider.RaiseAddLapForLane(LaneId.Lane1);
            MockRaceDataProvider.RaiseAddLapForLane(LaneId.Lane2);
            MockRaceDataProvider.RaiseAddLapForLane(LaneId.Lane3);
            WaitSecondsForValidLap();
        }

    }
}
