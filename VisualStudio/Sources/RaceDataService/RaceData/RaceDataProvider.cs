using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.BusinessObjects.PortActions;
using Elreg.BusinessObjects.Races;
using Elreg.Log;
using Elreg.RaceOptionsService;

namespace Elreg.RaceDataService.RaceData
{
    public class RaceDataProvider : IRaceDataProvider, ILaneBaseObserver
    {
        private readonly RaceProviderService _raceProviderService;
        private readonly IRaceModel _raceModel;
        private DateTime _dateTimeOfLastPauseOrRestartRequest = DateTime.Now;

        private const int MinMilliSecsForPauseOrRestartRequest = 1500;

        public event Delegates.LaneAdditionHandler AddLapForLane;
        public event Delegates.LaneHandler PenaltyAdditionForLane;
        public event Delegates.GetLaneByIdHandler GetLaneById;
        private readonly ActionsCalculator _actionsCalculator1;
        private readonly ActionsCalculator _actionsCalculator2;
        private readonly ActionsCalculator _actionsCalculator3;
        private readonly ActionsCalculator _actionsCalculator4;
        private readonly ActionsCalculator _actionsCalculator5;
        private readonly ActionsCalculator _actionsCalculator6;

        public RaceDataProvider(ISerialPortParser vcuSerialPortParser, RaceProviderService raceProviderService, IRaceModel raceModel)
        {
            raceModel.Attach(this);
            AttachActionsCalculatorEvents();
            _raceProviderService = raceProviderService;
            _raceModel = raceModel;
            _actionsCalculator1 = new ActionsCalculator(_raceProviderService, LaneId.Lane1);
            _actionsCalculator2 = new ActionsCalculator(_raceProviderService, LaneId.Lane2);
            _actionsCalculator3 = new ActionsCalculator(_raceProviderService, LaneId.Lane3);
            _actionsCalculator4 = new ActionsCalculator(_raceProviderService, LaneId.Lane4);
            _actionsCalculator5 = new ActionsCalculator(_raceProviderService, LaneId.Lane5);
            _actionsCalculator6 = new ActionsCalculator(_raceProviderService, LaneId.Lane6);
            vcuSerialPortParser.DataReceived += PortParserDataReceived;
            vcuSerialPortParser.StartStopRequested += VcuSerialPortParserStartStopRequested;
        }

        private void VcuSerialPortParserStartStopRequested(object sender, EventArgs e)
        {
            if (_raceModel.Race != null && _raceModel.Race.Type != Race.TypeEnum.Qualification && IsLastPauseOrRestartRequestedExpired)
            {
                if (_raceModel.StatusHandler.IsRaceStartedOrInCountDown)
                {
                    _raceModel.PauseRaceByArduino();
                    _dateTimeOfLastPauseOrRestartRequest = DateTime.Now;
                }
                else if (_raceModel.StatusHandler.IsRacePausedByKeyboardOrArduino ||
                         _raceModel.StatusHandler.IsRacePausedBeforeStart)
                {
                    _raceModel.RestartRaceByKeyboardOrArduinoCheckCountDown();
                    _dateTimeOfLastPauseOrRestartRequest = DateTime.Now;
                }
            }
        }

        private bool IsLastPauseOrRestartRequestedExpired
        {
            get
            {
                TimeSpan timeSpan = DateTime.Now - _dateTimeOfLastPauseOrRestartRequest;
                return timeSpan.TotalMilliseconds > MinMilliSecsForPauseOrRestartRequest;
            }
        }

        public uint SpeedToDetectFalseStart
        {
            get { return _raceProviderService.RaceProviderOptions.SpeedToDetectFalseStart; }
        }

        public void LaneChanged(LaneId laneId) { }

        public void RaceStatusChanged(object sender, EventArgs e)
        {
        }

        private void AttachActionsCalculatorEvents()
        {
            ActionsCalculator.AddLapForLane += ActionsCalculatorAddLapForLane;
            ActionsCalculator.GetLaneById += ActionsCalculatorGetLaneById;
            ActionsCalculator.PenaltyAdditionForLane += ActionsCalculatorPenaltyAdditionForLane;
        }

        private void PortParserDataReceived(object sender, PortParserEventArgs e)
        {
            try
            {
                CalculateActions(_actionsCalculator1, e);
                CalculateActions(_actionsCalculator2, e); 
                CalculateActions(_actionsCalculator3, e);
                CalculateActions(_actionsCalculator4, e);
                CalculateActions(_actionsCalculator5, e);
                CalculateActions(_actionsCalculator6, e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void CalculateActions(ActionsCalculator actionsCalculator, PortParserEventArgs portParserEventArgs)
        {
            CarController carController = GetCarController(portParserEventArgs, actionsCalculator.LaneId);
            List<uint> speedList = GetSpeedList(portParserEventArgs);
            LapDetectionSingleAction lapDetectionSingleAction = GetLapDetectionAction(portParserEventArgs, actionsCalculator.LaneId);
            actionsCalculator.DoWork(carController, lapDetectionSingleAction, speedList);
        }

        private List<uint> GetSpeedList(PortParserEventArgs portParserEventArgs)
        {
            List<uint> speedList = new List<uint>();
            if (portParserEventArgs.CarControllersAction != null)
            {
                speedList.Add(portParserEventArgs.CarControllersAction.CarController1.Speed);
                speedList.Add(portParserEventArgs.CarControllersAction.CarController2.Speed);
                speedList.Add(portParserEventArgs.CarControllersAction.CarController3.Speed);
                speedList.Add(portParserEventArgs.CarControllersAction.CarController4.Speed);
                speedList.Add(portParserEventArgs.CarControllersAction.CarController5.Speed);
                speedList.Add(portParserEventArgs.CarControllersAction.CarController6.Speed);
            }
            return speedList;
        }

        public static LapDetectionSingleAction GetLapDetectionAction(PortParserEventArgs portParserEventArgs, LaneId laneId)
        {
            LapDetectionSingleAction lapDetectionSingleAction = new LapDetectionSingleAction();
            if (portParserEventArgs.LapDetectionAction != null)
            {
                lapDetectionSingleAction.TimeStamp = portParserEventArgs.LapDetectionAction.TimeStamp;
                switch (laneId)
                {
                    case LaneId.Lane1:
                        lapDetectionSingleAction.Detected = portParserEventArgs.LapDetectionAction.Car1;
                        break;
                    case LaneId.Lane2:
                        lapDetectionSingleAction.Detected = portParserEventArgs.LapDetectionAction.Car2;
                        break;
                    case LaneId.Lane3:
                        lapDetectionSingleAction.Detected = portParserEventArgs.LapDetectionAction.Car3;
                        break;
                    case LaneId.Lane4:
                        lapDetectionSingleAction.Detected = portParserEventArgs.LapDetectionAction.Car4;
                        break;
                    case LaneId.Lane5:
                        lapDetectionSingleAction.Detected = portParserEventArgs.LapDetectionAction.Car5;
                        break;
                    case LaneId.Lane6:
                        lapDetectionSingleAction.Detected = portParserEventArgs.LapDetectionAction.Car6;
                        break;
                }
            }
            return lapDetectionSingleAction;
        }

        public static CarController GetCarController(PortParserEventArgs portParserEventArgs, LaneId laneId)
        {
            CarController carController = null;
            if (portParserEventArgs.CarControllersAction != null)
            {
                switch (laneId)
                {
                    case LaneId.Lane1:
                        carController = portParserEventArgs.CarControllersAction.CarController1;
                        break;
                    case LaneId.Lane2:
                        carController = portParserEventArgs.CarControllersAction.CarController2;
                        break;
                    case LaneId.Lane3:
                        carController = portParserEventArgs.CarControllersAction.CarController3;
                        break;
                    case LaneId.Lane4:
                        carController = portParserEventArgs.CarControllersAction.CarController4;
                        break;
                    case LaneId.Lane5:
                        carController = portParserEventArgs.CarControllersAction.CarController5;
                        break;
                    case LaneId.Lane6:
                        carController = portParserEventArgs.CarControllersAction.CarController6;
                        break;
                }
            }
            return carController;
        }

        private void ActionsCalculatorPenaltyAdditionForLane(LaneId laneId)
        {
            try
            {
                if (PenaltyAdditionForLane != null)
                    PenaltyAdditionForLane(laneId);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ActionsCalculatorGetLaneById(LaneId laneId, out Lane lane)
        {
            lane = null;
            try
            {
                if (GetLaneById != null)
                    GetLaneById(laneId, out lane);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ActionsCalculatorAddLapForLane(LaneId laneId, DateTime? timeStampOfLapAddition)
        {
            try
            {
                if (AddLapForLane != null)
                    AddLapForLane(laneId, timeStampOfLapAddition);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}