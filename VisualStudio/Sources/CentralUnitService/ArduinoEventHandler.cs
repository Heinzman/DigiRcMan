using System;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Races;
using System.Collections.Generic;

namespace Elreg.CentralUnitService
{
    public class ArduinoEventHandler
    {
        private readonly IArduinoReader _arduinoReader;
        private readonly IRaceModel _raceModel;
        private readonly ICentralUnitOptionsService _optionsService;
        private DateTime _dateTimeOfLastPauseOrRestartRequest = DateTime.Now;
        private readonly Dictionary<LaneId, Queue<DateTime>> _dictOfButtonClickQueue = new Dictionary<LaneId, Queue<DateTime>>();

        private const int MinMilliSecsForPauseOrRestartRequest = 1500;
        private const int MinMilliSecsForValidButtonClick = 50;
        private const int MinMilliSecsForRocket = 1000;

        public ArduinoEventHandler(IArduinoReader arduinoReader, IRaceModel raceModel, ICentralUnitOptionsService optionsService)
        {
            _arduinoReader = arduinoReader;
            _arduinoReader.PauseOrRestartRequested += ArduinoReaderPauseOrRestartRequested;
            _arduinoReader.UpperButtonClicked += ArduinoReaderUpperButtonClicked;
            _raceModel = raceModel;
            _optionsService = optionsService;
            InitDictOfButtonClickQueue();
        }

        private void InitDictOfButtonClickQueue()
        {
            _dictOfButtonClickQueue.Add(LaneId.Lane1, new Queue<DateTime>());
            _dictOfButtonClickQueue.Add(LaneId.Lane2, new Queue<DateTime>());
            _dictOfButtonClickQueue.Add(LaneId.Lane3, new Queue<DateTime>());
            _dictOfButtonClickQueue.Add(LaneId.Lane4, new Queue<DateTime>());
            _dictOfButtonClickQueue.Add(LaneId.Lane5, new Queue<DateTime>());
            _dictOfButtonClickQueue.Add(LaneId.Lane6, new Queue<DateTime>());
        }

        private void ArduinoReaderUpperButtonClicked(object sender, LaneId laneId)
        {
            if (_raceModel.IsRocketWithCentralUnitActivated)
                HandleUpperButtonClick(laneId);
        }

        private void HandleUpperButtonClick(LaneId laneId)
        {
            Queue<DateTime> queue;

            if (_dictOfButtonClickQueue.TryGetValue(laneId, out queue))
            {
                bool isValidClick = true;

                if (queue.Count > 0)
                {
                    DateTime dateTimeOfLastClick = queue.Peek();
                    TimeSpan timeSpan = DateTime.Now - dateTimeOfLastClick;

                    if (timeSpan.TotalMilliseconds < MinMilliSecsForValidButtonClick)
                        isValidClick = false;
                }
                queue.Enqueue(DateTime.Now);
                if (isValidClick && queue.Count > 1)
                {
                    int count = queue.Count;

                    DateTime[] dateTimes = queue.ToArray();
                    TimeSpan timeSpan = dateTimes[count - 1] - dateTimes[count - 2];
                    if (timeSpan.TotalMilliseconds < MinMilliSecsForRocket)
                        _raceModel.RequestStartRocket(laneId);
                }
            }
        }

        private void ArduinoReaderPauseOrRestartRequested(object sender, LaneId laneId)
        {
            if (_optionsService.Options.IsCentralUnitActivated && _optionsService.Options.IsPauseByArduinoActivated)
                HandlePauseOrRestartRequest(laneId);
        }

        private void HandlePauseOrRestartRequest(LaneId laneId)
        {
            if (_raceModel.Race != null && _raceModel.Race.Type != Race.TypeEnum.Qualification && IsLastPauseOrRestartRequestedExpired)
            {
                if (_raceModel.StatusHandler.IsRaceStartedOrInCountDown)
                {
                    _raceModel.PauseRaceByArduino(laneId);
                    _dateTimeOfLastPauseOrRestartRequest = DateTime.Now;
                }
                else if (_raceModel.StatusHandler.IsRacePausedByKeyboardOrArduino)
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
    }
}
