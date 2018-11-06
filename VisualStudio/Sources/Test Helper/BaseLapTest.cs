using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Options;
using Elreg.BusinessObjects.Races;
using Elreg.DomainModels.RaceModel;
using Elreg.GhostCarService;
using Elreg.RaceOptionsService;
using Elreg.UnitTests.MockObjects;
using NUnit.Framework;

namespace Elreg.UnitTests.TestHelper
{
    public abstract class BaseLapTest
    {
        protected RaceModel RaceModel;
        protected List<InitialLane> InitialLanes;
        private RaceSettingsService _raceSettingsService;
        protected IRaceDataProvider RaceDataProvider;
        private FileStream _log;

        [SetUp]
        public void BaseSetUp()
        {
            CreateRaceModel();
            // todo Initializer.InitErrorLogs();
            InitSpecificObjects();
        }

        [TearDown]
        public void BaseTearDown()
        {
            DisposeSpecificObjects();
        }

        protected virtual void DisposeSpecificObjects()
        {
        }

        protected virtual void InitSpecificObjects()
        {
        }

        protected static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private void AddRegularLapAndWaitValidSecondsFor(LaneId laneId)
        {
            AddLapFor(laneId);
            WaitSecondsForValidLap();
        }

        protected void AddLapFor(LaneId laneId)
        {
            MockRaceDataProvider.RaiseAddLapForLane(laneId);
        }

        protected void AddRegularLapAndWaitValidSeconds()
        {
            AddRegularLapAndWaitValidSecondsFor(Lane1.Id);
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
                return (int)timespan.TotalSeconds;
            }
        }

        protected void AutoDetectLap()
        {
            long previousSpeedSum = -1;
            int counter = 0;
            while (counter++ < 1000 && Lane1.SpeedSum > previousSpeedSum)
            {
                previousSpeedSum = (uint)Lane1.SpeedSum;
                MockRaceDataProvider.RaiseHandleFuelComsumptionForLane(Lane1.Id, 12, new List<uint> {12});
            }
        }

        protected void WaitSecondsForValidLap()
        {
            Thread.Sleep(RaceSettings.SecondsForValidLap * 1000);
        }

        protected void WaitSecondsForServingPenalty()
        {
            Thread.Sleep((int)(RaceSettings.IntervalInSecsForPenalty * 1100));
        }

        protected void WaitSecondsForCountDownFinished()
        {
            Thread.Sleep(RaceSettings.StartCountDownRaceInitNo * 4000);
        }

        protected static void WaitSomeMilliSeconds()
        {
            Thread.Sleep(300);
        }

        protected static void WaitSeconds(int count)
        {
            Thread.Sleep(1000 * count);
        }

        protected static void WaitMilliSeconds(int ms)
        {
            Thread.Sleep(ms);
        }

        protected void WaitSecondsForInvalidLap()
        {
            int milliSecs = RaceSettings.SecondsForValidLap/4;
            Thread.Sleep(milliSecs);
        }

        protected virtual void CreateRaceDataProvider()
        {
            RaceDataProvider = new MockRaceDataProvider();
        }

        protected virtual void InitRaceSettings()
        {
            RaceSettings.LapsToDrive = 100;
            RaceSettings.AutoDetectLapEnabled = true;
            RaceSettings.AutoDetectLapSpeedFactor = 1.5f;
            RaceSettings.AutoDetectZerothLapEnabled = true;
            RaceSettings.AutoDetectZerothLapSpeedFactor = 1.5f;
            RaceSettings.RestartCountDownRaceActivated = false;
            RaceSettings.StartCountDownRaceActivated = false;
            RaceSettings.SecondsForValidLap = 1;
            RaceSettings.PausePyParallelPortActivated = false;
            RaceSettings.AutoDisqualificationRaceActivated = false;
            RaceSettings.ResetPenaltiesAfterInvalidLap = false;
            RaceSettings.PenaltiesToRemoveAfterInvalidLap = 0;
            RaceSettings.IntervalInSecsForPenalty = 0.5;
        }

        protected virtual void CreateInitialLanes()
        {
            InitialLanes = new List<InitialLane>();
            Driver driver1 = NewDriver1;
            Driver driver2 = NewDriver2;
            Driver driver3 = NewDriver3;
            Car car1 = CreateNewCar(1);
            Car car2 = CreateNewCar(2);
            Car car3 = CreateNewCar(3);
            const float tankMaximumInLitres = 100f;
            const float fuelconsumptionFactor = 1f;
            InitialLanes.Add(new InitialLane(LaneId.Lane1, tankMaximumInLitres, fuelconsumptionFactor, driver1, car1));
            InitialLanes.Add(new InitialLane(LaneId.Lane2, tankMaximumInLitres, fuelconsumptionFactor, driver2, car2));
            InitialLanes.Add(new InitialLane(LaneId.Lane3, tankMaximumInLitres, fuelconsumptionFactor, driver3, car3));
        }

        protected virtual Driver NewDriver1
        {
            get { return CreateNewDriver(1); }
        }

        protected virtual Driver NewDriver2
        {
            get { return CreateNewDriver(2); }
        }

        protected virtual Driver NewDriver3
        {
            get { return CreateNewDriver(3); }
        }

        protected Driver CreateNewDriver(int id)
        {
            return new Driver { Name = "Driver" + id, Id = id };
        }

        protected Car CreateNewCar(int id)
        {
            return new Car { Name = "Car" + id, Id = id };
        }

        private void CreateRaceModel()
        {
            RaceModel = new RaceModel();
            CreateRaceSettingsService();
            InitRaceSettings();
            RaceModel.SpeedSumAvgCalculator = new MockSpeedSumAvgCalculator();
            RaceModel.LapTimeAvgCalculator = new MockLapTimeAvgCalculator();
            AutoDetectLapSpeedSum = 100;
            RaceModel.RaceSettings = RaceSettings;
            RaceModel.GhostcarsService = GhostcarsService;
        }

        protected virtual GhostcarsService GhostcarsService
        {
            get { return null; }
        }

        protected void StartCompetition(Race.TypeEnum competitionType)
        {
            InitRace();
            StartRaceCheckCountDown(competitionType);
        }

        private void StartRaceCheckCountDown(Race.TypeEnum competitionType)
        {
            RaceModel.Race.Type = competitionType;
            RaceModel.StartRaceCheckCountDown();
        }

        protected void InitRace()
        {
            CreateInitialLanes();
            CreateRaceDataProvider();
            RaceModel.InitialLanes = InitialLanes;
            RaceModel.RaceDataProvider = RaceDataProvider;
            RaceModel.InitRace();
        }

        protected void StartRace()
        {
            StartCompetition(Race.TypeEnum.Race);
        }

        private void CreateRaceSettingsService()
        {
            _raceSettingsService = new RaceSettingsService();
        }

        protected Lane Lane1
        {
            get { return RaceModel.RaceHandler.GetLaneById(LaneId.Lane1); }
        }

        protected Lane Lane2
        {
            get { return RaceModel.RaceHandler.GetLaneById(LaneId.Lane2); }
        }

        protected Lane Lane3
        {
            get { return RaceModel.RaceHandler.GetLaneById(LaneId.Lane3); }
        }

        protected Lane Lane4
        {
            get { return RaceModel.RaceHandler.GetLaneById(LaneId.Lane4); }
        }

        protected Lane Lane5
        {
            get { return RaceModel.RaceHandler.GetLaneById(LaneId.Lane5); }
        }

        protected Lane Lane6
        {
            get { return RaceModel.RaceHandler.GetLaneById(LaneId.Lane6); }
        }

        protected RaceSettings RaceSettings
        {
            get { return _raceSettingsService.RaceSettings; }
        }

        protected void StartTraceLogging()
        {
            _log = new FileStream(@"d:\Log.txt", FileMode.OpenOrCreate);
            Trace.Listeners.Add(new TextWriterTraceListener(_log));
            Trace.AutoFlush = true;
        }

        protected void StopTraceLogging()
        {
            _log.Close();
        }

        protected MockRaceDataProvider MockRaceDataProvider
        {
            get { return (MockRaceDataProvider) RaceDataProvider; }
        }

        protected int? AutoDetectLapSpeedSum
        {
            set { RaceModel.SpeedSumAvgCalculator.SpeedSumAvg = value; }
        }
    }
}
