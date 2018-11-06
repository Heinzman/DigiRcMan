using System;
using System.Collections.Generic;
using System.Threading;
using Heinzman.BusinessObjects;
using Heinzman.BusinessObjects.Lanes;
using Heinzman.BusinessObjects.Options;
using Heinzman.DomainModels.RaceModel;
using Heinzman.MockObjects;
using Heinzman.WindowsFormsApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heinzman.UnitTests.DomainModels.LapTests
{
    public class BaseLapTest
    {
        protected RaceModel RaceModel;
        private List<InitialLane> _initialLanes;
        protected RaceSettings RaceSettings;
        protected MockRaceDataProvider RaceDataProvider;

        [TestInitialize]
        public void StartUp()
        {
            CreateRaceModel();
            Initializer.InitErrorLogs();
        }

        protected void AddRegularLapAndWaitValidSeconds()
        {
            RaceDataProvider.RaiseAddLapForLane(Lane1.Id);
            WaitSecondsForValidLap();
        }

        protected void AutoDetectLapAndWaitValidSeconds()
        {
            AutoDetectLap();
            WaitSecondsForValidLap();
        }

        protected int SecondsSinceLastDetectedLap
        {
            get
            {
                TimeSpan timespan = new TimeSpan(0, 0, 0, RaceSettings.SecondsForValidLap);
                if (Lane1.LastTimeALapAlsoIrregularWasAdded.HasValue)
                    timespan = DateTime.Now - Lane1.LastTimeALapAlsoIrregularWasAdded.Value;
                return timespan.Seconds;
            }
        }

        protected void AutoDetectLap()
        {
            long previousSpeedSum = -1;
            int counter = 0;
            while (counter++ < 1000 && Lane1.SpeedSum > previousSpeedSum)
            {
                previousSpeedSum = Lane1.SpeedSum;
                RaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 12);
            }
        }

        protected void WaitSecondsForValidLap()
        {
            Thread.Sleep(RaceSettings.SecondsForValidLap * 1000);
        }

        protected void WaitSecondsForCountDownFinished()
        {
            Thread.Sleep(RaceSettings.StartCountDownInitNo * 4000);
        }

        protected void WaitSomeMilliSeconds()
        {
            Thread.Sleep(300);
        }

        protected void WaitSecondsForInvalidLap()
        {
            int milliSecs = RaceSettings.SecondsForValidLap/4;
            Thread.Sleep(milliSecs);
        }

        private void CreateRaceDataProvider()
        {
            RaceDataProvider = new MockRaceDataProvider();
        }

        protected virtual void CreateRaceSettings()
        {
            RaceSettings = new RaceSettings
                                {
                                    LapsToDrive = 100,
                                    AutoDetectLapEnabled = true,
                                    AutoDetectLapSpeedFactor = 1,
                                    AutoDetectLapSpeedSum = 10,
                                    RestartCountDownActivated = false,
                                    StartCountDownActivated = false,
                                    SecondsForValidLap = 3, 
                                    PausePyParallelPortActivated = false
                                };
        }

        private void CreateInitialLanes()
        {
            _initialLanes = new List<InitialLane>();
            Driver driver1 = new Driver { Name = "Driver1" };
            Driver driver2 = new Driver { Name = "Driver2" };
            Car car1 = new Car { Name = "Car1" };
            Car car2 = new Car { Name = "Car2" };
            const float tankMaximumInLitres = 100f;
            const float fuelconsumptionFactor = 1f;
            _initialLanes.Add(new InitialLane(LaneId.Lane1, tankMaximumInLitres, fuelconsumptionFactor, driver1, car1));
            _initialLanes.Add(new InitialLane(LaneId.Lane2, tankMaximumInLitres, fuelconsumptionFactor, driver2, car2));
        }

        private void CreateRaceModel()
        {
            RaceModel = new RaceModel();
        }

        protected void StartRace()
        {
            CreateInitialLanes();
            CreateRaceSettings();
            CreateRaceDataProvider();
            RaceModel.InitialLanes = _initialLanes;
            RaceModel.RaceSettings = RaceSettings;
            RaceModel.RaceDataProvider = RaceDataProvider;
            RaceModel.InitRace();
            RaceModel.StartRaceCheckCountDown(Race.TypeEnum.Race);
        }

        protected Lane Lane1
        {
            get { return RaceModel.RaceHandler.GetLaneById(LaneId.Lane1); }
        }

    }
}
