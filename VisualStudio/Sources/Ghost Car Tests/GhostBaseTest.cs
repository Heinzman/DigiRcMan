using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.Races;
using Elreg.GhostCarService;
using Elreg.GhostCarService.Replay;
using Elreg.UnitTests.MockObjects;
using Elreg.UnitTests.TestHelper;

namespace Elreg.UnitTests.GhostCar
{
    public class GhostBaseTest : BaseLapTest
    {
        private IArduinoWriter _arduinoWriter;
        private GhostcarsService _ghostcarsService;
        protected readonly MockGhostCarSerialPortParser MockGhostCarSerialPortParser = new MockGhostCarSerialPortParser();

        protected void InitGhostCarRace()
        {
            InitGhostcarsService();
            _arduinoWriter = new MockArduinoWriter();
            new ReplayService(RaceModel, MockGhostCarSerialPortParser, _arduinoWriter, GhostcarsService);
            CreateRaceDataProvider();
            InitInitialLanes();
            RaceModel.InitialLanes = InitialLanes;
            RaceModel.RaceDataProvider = RaceDataProvider;
            RaceModel.GhostcarsService = GhostcarsService;
            RaceModel.InitRace();
            RaceModel.Race.Type = Race.TypeEnum.Race;
        }

        protected virtual void InitInitialLanes()
        {
            InitialLanes = new List<InitialLane>();
            Driver driver1 = new Driver { Name = "Driver1", Id = 1 };
            Driver ghostCar1 = GhostcarsService.Ghostcars[0];
            Driver ghostCar2 = GhostcarsService.Ghostcars[1];
            Car car1 = new Car { Name = "Car1", Id = 1 };
            Car car2 = new Car { Name = "Car2", Id = 2 };
            Car car3 = new Car { Name = "Car3", Id = 3 };
            const float tankMaximumInLitres = 100f;
            const float fuelconsumptionFactor = 1f;
            InitialLanes.Add(new InitialLane(LaneId.Lane1, tankMaximumInLitres, fuelconsumptionFactor, driver1, car1));
            InitialLanes.Add(new InitialLane(LaneIdOfGhostcarA, tankMaximumInLitres, fuelconsumptionFactor, ghostCar1, car2));
            InitialLanes.Add(new InitialLane(LaneIdOfGhostcarB, tankMaximumInLitres, fuelconsumptionFactor, ghostCar2, car3));
        }

        protected virtual void InitGhostcarsService()
        {
            _ghostcarsService = new GhostcarsService();
            GhostcarsService.GhostcarsOptions.StartLatencyInMilliSecs = 0;
        }

        protected override GhostcarsService GhostcarsService
        {
            get { return _ghostcarsService; }
        }


        protected void ActivateDistanceHandler()
        {
            GhostcarsService.GhostcarsOptions.DistanceHandlerActivated = true;
            GhostcarsService.GhostcarsOptions.MinDistanceInSecs = 2;
        }

        protected void PauseAndRestartRace()
        {
            WaitMilliSeconds(50);
            RaceModel.PauseRaceByKeyboard();
            WaitMilliSeconds(50);
            RaceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
            WaitMilliSeconds(50);
        }

        protected LaneId LaneIdOfGhostcarA
        {
            get { return LaneId.Lane2; }
        }

        protected LaneId LaneIdOfGhostcarB
        {
            get { return LaneId.Lane3; }
        }

        protected bool IsButtonPressedOfGhostA
        {
            get { return ArduinoGhostControllerA.IsButtonPressed; }
        }

        protected bool IsButtonPressedOfGhostB
        {
            get { return ArduinoGhostControllerB.IsButtonPressed; }
        }

        protected GhostController ArduinoGhostControllerA
        {
            get { return _arduinoWriter.GetGhostControllerOf(LaneIdOfGhostcarA); }
        }

        protected GhostController ArduinoGhostControllerB
        {
            get { return _arduinoWriter.GetGhostControllerOf(LaneIdOfGhostcarB); }
        }

        protected uint GetArduinoValueMappedAsSpeedOf(Ghost ghost)
        {
            uint currentControllerValue;
            if (ghost == Ghost.GhostA)
                currentControllerValue = CurrentControllerValueA;
            else
                currentControllerValue = CurrentControllerValueB;
            return MapToSpeed(currentControllerValue);
        }

        private uint MapToSpeed(uint currentControllerValue)
        {
            uint speed;

            switch (currentControllerValue)
            {
                case 4:
                case 5:
                    speed = 4;
                    break;
                case 6:
                case 7:
                    speed = 5;
                    break;
                case 8:
                case 9:
                    speed = 6;
                    break;
                case 10:
                case 11:
                    speed = 7;
                    break;
                case 12:
                    speed = 8;
                    break;
                case 13:
                    speed = 9;
                    break;
                case 14:
                    speed = 10;
                    break;
                case 15:
                    speed = 12;
                    break;
                default:
                    speed = currentControllerValue;
                    break;
            }
            return speed;
        }

        protected void SetGhostCarOptionsToRecorded(Ghost ghost, uint defaultSpeed)
        {
            ReplayOptions replayOptions = GhostcarsService.GetReplayOptionsBy(ghost);
            replayOptions.DefaultSpeed = defaultSpeed;
            replayOptions.IsLaneChangeActivated = false;
            replayOptions.IsRecordedLapActivated = true;
            replayOptions.IsLaneChangeSupressed = false;
            replayOptions.LaneChangeFrequency = GhostCarLaneChangeFrequency.Often;
            replayOptions.RecordedLapData = LoadRecordedLapDataFromFile();
        }

        protected uint CurrentControllerValueA
        {
            get { return (uint)ArduinoGhostControllerA.Level; }
        }

        protected uint CurrentControllerValueB
        {
            get { return (uint)ArduinoGhostControllerB.Level; }
        }

        protected void StartRaceByConstantSpeedAOf(uint defaultSpeed)
        {
            InitGhostCarRace();
            ReplayOptions replayOptions = GhostcarsService.GetReplayOptionsBy(Ghost.GhostA);
            replayOptions.DefaultSpeed = defaultSpeed;
            replayOptions.IsLaneChangeActivated = false;
            replayOptions.IsRecordedLapActivated = false;
            RaceModel.StartRaceCheckCountDown();
        }

        protected RecordedLapData LoadRecordedLapDataFromFile()
        {
            string fileName = AssemblyDirectory + @"\GhostCarFiles\GhostCar01.gst";
            RecordedLapService recordedLapService = new RecordedLapService(fileName);
            return recordedLapService.RecordedLapData;
        }

        protected void WaitSomeGhostMilliSeconds()
        {
            WaitMilliSeconds(50);
        }

        protected void WaitLessThanMinDistanceInSecs()
        {
            int milliSecs = (int)(GhostcarsService.GhostcarsOptions.MinDistanceInSecs * 500);
            WaitMilliSeconds(milliSecs); 
        }

        protected void WaitMoreThanMinDistanceInSecs()
        {
            int milliSecs = (int)(GhostcarsService.GhostcarsOptions.MinDistanceInSecs * 1200);
            WaitMilliSeconds(milliSecs);
        }

    }
}
