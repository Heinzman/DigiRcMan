using System;
using System.Collections.Generic;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.PortActions;
using Elreg.Log;
using Elreg.RaceDataService.RaceData;

namespace Elreg.GhostCarService
{
    public class Recorder
    {
        private readonly ISerialPortParser _serialPortParser;
        private LaneId _laneId;
        private CarController _carController;
        private LapDetectionSingleAction _lapDetectionSingleAction;
        private readonly List<RecordedLapData> _lapDataList = new List<RecordedLapData>();
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private readonly object _locker = new object();
        private RecorderStatus _recorderStatus = RecorderStatus.Idle;

        public event EventHandler<RecorderEventArgs> StatusChanged;
        public event EventHandler LapDataChanged;

        public Recorder(ISerialPortParser serialPortParser)
        {
            _serialPortParser = serialPortParser;
            _timer.Interval = 10;
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                HandleControllerData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SerialPortParserDataReceived(object sender, PortParserEventArgs portParserEventArgs)
        {
            try
            {
                lock (_locker)
                {
                    _carController = RaceDataProvider.GetCarController(portParserEventArgs, _laneId);
                    _lapDetectionSingleAction = RaceDataProvider.GetLapDetectionAction(portParserEventArgs, _laneId);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void HandleControllerData()
        {
            lock (_locker)
            {
                if (_lapDetectionSingleAction != null && _lapDetectionSingleAction.Detected)
                {
                    if (_recorderStatus == RecorderStatus.WaitingForStartLine)
                    {
                        _recorderStatus = RecorderStatus.Recording;
                        RaiseEventStatusChanged();
                    }
                    else
                    {
                        if (_lapDetectionSingleAction.TimeStamp.HasValue)
                            CurrentRecordedLapData.EndTime = _lapDetectionSingleAction.TimeStamp.Value;
                        CurrentRecordedLapData.Valid = true;
                        RaiseEventLapDataChanged();
                    }
                    RecordedLapData lapData = new RecordedLapData();
                    if (_lapDetectionSingleAction.TimeStamp.HasValue)
                        lapData.StartTime = _lapDetectionSingleAction.TimeStamp.Value;
                    _lapDataList.Add(lapData);
                    _lapDetectionSingleAction = null;
                }
                if (_carController != null && _recorderStatus == RecorderStatus.Recording)
                {
                    CarController carController = new CarController(_carController);
                    CurrentRecordedLapData.CarControllers.Add(carController);
                }
            }
        }

        public void Record(LaneId laneId)
        {
            _laneId = laneId;
            _recorderStatus = RecorderStatus.WaitingForStartLine;
            _serialPortParser.DataReceived += SerialPortParserDataReceived;
            _timer.Start();
            RaiseEventStatusChanged();
        }

        public void Stop()
        {
            _recorderStatus = RecorderStatus.Idle;
            _timer.Stop();
            _serialPortParser.DataReceived -= SerialPortParserDataReceived;
            RaiseEventStatusChanged();
        }

        private RecordedLapData CurrentRecordedLapData
        {
            get { return _lapDataList[_lapDataList.Count - 1]; }
        }

        public RecordedLapData LastValidRecordedLapData
        {
            get
            {
                RecordedLapData lastRecordedLapData = null;

                foreach (RecordedLapData recordedLapData in _lapDataList)
                {
                    if (recordedLapData.Valid)
                        lastRecordedLapData = recordedLapData;
                }
                return lastRecordedLapData;
            }
        }

        private void RaiseEventStatusChanged()
        {
            if (StatusChanged != null)
                StatusChanged(this, new RecorderEventArgs(_recorderStatus));
        }

        private void RaiseEventLapDataChanged()
        {
            if (LapDataChanged != null)
                LapDataChanged(this, null);
        }

        public RecorderStatus GetStatus()
        {
            return _recorderStatus;
        }

        public void Clear()
        {
            Stop();
            _lapDataList.Clear();
            RaiseEventStatusChanged();
            RaiseEventLapDataChanged();
        }
    }
}
