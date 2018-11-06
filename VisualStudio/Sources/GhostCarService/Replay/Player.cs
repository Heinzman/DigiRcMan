using System;
using System.Threading;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.PortActions;
using Elreg.Log;

namespace Elreg.GhostCarService.Replay
{
    public class Player : IPlayer
    {
        public event EventHandler LapAdded;

        private static readonly object Locker = new object();
        private readonly ReplayOptions _replayOptions;
        private readonly IArduinoWriter _arduinoWriter;
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());
        private readonly TimeSpan _buttonPressedMinTimeSpan = new TimeSpan(0, 0, 0, 0, 500);
        private bool _buttonPressed;
        private bool _started;
        private DateTime _buttonChangedDateTime;
        private GhostController _ghostController;
        private bool _forceSuppressButton;
        private bool _forceSuppressRecordedLap;
        private DateTime _lapStartDateTime;
        private int _lapCount;
        private DateTime? _timeStampOfLastLap;
        private bool _finished;
        private uint? _forcedSpeed;

        private const int MilliSecsToSleepRecordedLap = 5;
        private const int MilliSecsToSleepDefaultSpeed = 10;
        private const int MilliSecsToSleepDecreasingFinishSpeed = 2000;

        public Player(ReplayOptions replayOptions, IArduinoWriter arduinoWriter, ISerialPortParser serialPortParser)
        {
            LapCount = -1;
            ButtonChangedDateTime = DateTime.Now;
            _replayOptions = replayOptions;
            _arduinoWriter = arduinoWriter;
            GhostController = new GhostController {LaneId = _replayOptions.LaneId};
            serialPortParser.DataReceived += PortParserDataReceived;
        }

        private bool Started
        {
            get
            {
                lock(Locker)
                    return _started;
            }
            set
            {
                lock (Locker) 
                    _started = value;
            }
        }

        private DateTime ButtonChangedDateTime
        {
            get
            {
                lock (Locker)
                    return _buttonChangedDateTime;
            }
            set
            {
                lock (Locker)
                    _buttonChangedDateTime = value;
            }
        }

        private bool Finished
        {
            get
            {
                lock (Locker)
                    return _finished;
            }
            set
            {
                lock (Locker)
                    _finished = value;
            }
        }

        private bool ButtonPressed
        {
            get
            {
                lock (Locker)
                    return _buttonPressed;
            }
            set
            {
                lock (Locker)
                    _buttonPressed = value;
            }
        }

        private DateTime LapStartDateTime
        {
            get
            {
                lock (Locker)
                    return _lapStartDateTime;
            }
            set
            {
                lock (Locker)
                    _lapStartDateTime = value;
            }
        }

        private bool ForceSuppressButton
        {
            get
            {
                lock (Locker)
                    return _forceSuppressButton;
            }
            set
            {
                lock (Locker)
                    _forceSuppressButton = value;
            }
        }

        private void PortParserDataReceived(object sender, BusinessObjects.DerivedEventArgs.PortParserEventArgs e)
        {
            try
            {
                LapDetectionAction lapDetectionAction = e.LapDetectionAction;
                LapDetectionAction lapDetection = null;
                if (lapDetectionAction != null)
                    lapDetection = lapDetectionAction.Clone() as LapDetectionAction;

                if (lapDetection != null)
                {
                    if (_replayOptions.LaneId == LaneId.Lane1 && lapDetection.Car1 ||
                        _replayOptions.LaneId == LaneId.Lane2 && lapDetection.Car2 ||
                        _replayOptions.LaneId == LaneId.Lane3 && lapDetection.Car3 ||
                        _replayOptions.LaneId == LaneId.Lane4 && lapDetection.Car4 ||
                        _replayOptions.LaneId == LaneId.Lane5 && lapDetection.Car5 ||
                        _replayOptions.LaneId == LaneId.Lane6 && lapDetection.Car6)
                    {
                        LapCount++;
                        TimeStampOfLastLap = DateTime.Now;
                        if (LapAdded != null)
                            LapAdded(this, null);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private uint DefaultSpeed
        {
            get
            {
                uint defaultSpeed = _replayOptions.DefaultSpeed;
                if (_forcedSpeed.HasValue)
                    defaultSpeed = _forcedSpeed.Value;
                return defaultSpeed;
            }
        }

        public uint? ForcedSpeed
        {
            set
            {
                _forcedSpeed = value;
                if (Started)
                {
                    CalcDefaultControllerValues();
                    SendValue();
                }
            }
        }

        public void Start()
        {
            Started = true;
            Finished = false;
            _arduinoWriter.SendIsArduinoControlled(GhostController.LaneId, false);
            _arduinoWriter.Attach(GhostController.LaneId);
            Thread thread = new Thread(Replay);
            thread.Start();
        }

        private GhostController GhostController
        {
            get
            {
                lock (Locker)
                    return _ghostController;
            }
            set
            {
                lock (Locker)
                    _ghostController = value;
            }
        }

        private int CalcLevel(uint speed)
        {
            int level;

            switch (speed)
            {
                case 1:
                    level = 1;
                    break;
                case 2:
                    level = 2;
                    break;
                case 3:
                    level = 3;
                    break;
                case 4:
                    level = 5;
                    break;
                case 5:
                    level = 7;
                    break;
                case 6:
                    level = 9;
                    break;
                case 7:
                    level = 11;
                    break;
                case 8:
                    level = 12;
                    break;
                case 9:
                    level = 13;
                    break;
                case 10:
                case 11:
                    level = 14;
                    break;
                case 12:
                    level = 15;
                    break;
                default:
                    level = 0;
                    break;
            }
            return level;
        }

        public bool ForceSuppressRecordedLap
        {
            get
            {
                lock (Locker)
                    return _forceSuppressRecordedLap;
            }
            set
            {
                lock (Locker)
                    _forceSuppressRecordedLap = value;
            }
        }

        public DateTime? TimeStampOfLastLap
        {
            get
            {
                lock (Locker)
                    return _timeStampOfLastLap;
            }
            private set
            {
                lock (Locker)
                    _timeStampOfLastLap = value;
            }
        }

        public int LapCount
        {
            get
            {
                lock (Locker)
                    return _lapCount;
            }
            private set
            {
                lock (Locker)
                    _lapCount = value;
            }
        }

        private void CalcAndWriteDefaultValues()
        {
            CalcDefaultControllerValues();
            SendValue();
        }

        private void SendValue()
        {
            _arduinoWriter.Update(GhostController);
        }

        private void CalcDefaultControllerValues()
        {
            GhostController.Level = CalcLevel(DefaultSpeed);
            GhostController.IsButtonPressed = false;
        }

        public bool IsRecordedLapPlayerActiv
        {
            get { return _replayOptions.IsRecordedLapActivated && _replayOptions.RecordedLapData != null; }
        }

        public void Stop()
        {
            Started = false;
            _arduinoWriter.SendIsArduinoControlled(GhostController.LaneId, true);
            _arduinoWriter.Detach(GhostController.LaneId);
            ResetGhostControllerValues();
            SendValue();
            ForceSuppressRecordedLap = false;
        }

        public void Finish()
        {
            Finished = true;
            ForceSuppressRecordedLap = false;
        }

        private void ResetGhostControllerValues()
        {
            lock (Locker)
            {
                GhostController.Level = 0;
                GhostController.IsButtonPressed = false;
            }
        }

        public void Pause()
        {
            Stop();
            ForceSuppressRecordedLap = false;
        }

        public void Restart()
        {
            Start();
        }

        private void Replay()
        {
            int lapCount = LapCount;
            CalcAndWriteDefaultValues();
            //Debug.WriteLine("before  WaitForANewLap(lapCount) " + DateTime.Now);
            WaitForANewLap(lapCount);
            LapStartDateTime = DateTime.Now;
            lapCount = LapCount;
            int index = 0;
            DateTime startControllerTimeStamp = DateTime.Now;

            //Debug.WriteLine("before while (Started) " +  DateTime.Now);
            while (Started)
            {
                //Debug.WriteLine("before if (LapCount > lapCount " + DateTime.Now);
                if (LapCount > lapCount)
                {
                    index = 0;
                    LapStartDateTime = DateTime.Now;
                    lapCount = LapCount;
                }
                if (Finished)
                    ReplayGettingSlower();
                else if (IsRecordedLapAllowed(index))
                {
                    //Debug.WriteLine("before ReplayRecordedLap(ref index, ref startControllerTimeStamp) " + DateTime.Now);
                    ReplayRecordedLap(ref index, ref startControllerTimeStamp);
                }
                else
                {
                    //Debug.WriteLine("before index = ReplayDefaultSpeed(); " + DateTime.Now);
                    index = ReplayDefaultSpeed();
                }
            }
            ResetGhostControllerValues();
            SendValue();
        }

        private bool IsRecordedLapAllowed(int index)
        {
            return !ForceSuppressRecordedLap && IsRecordedLapPlayerActiv && index < _replayOptions.RecordedLapData.CarControllers.Count - 1;
        }

        private void ReplayGettingSlower()
        {
            uint defaultSpeed = DefaultSpeed;
            for (uint speed = defaultSpeed; speed > 0; speed--)
            {
                WritePortValueIfValuesChanged(speed);
                Thread.Sleep(MilliSecsToSleepDecreasingFinishSpeed);
            }
            Started = false;
        }

        private int ReplayDefaultSpeed()
        {
            WritePortValueIfValuesChanged(DefaultSpeed);
            Thread.Sleep(MilliSecsToSleepDefaultSpeed);
            return int.MaxValue;
        }

        private void WritePortValueIfValuesChanged(uint speed)
        {
            int level = CalcLevel(speed);
            bool isButtonPressed = CalcLaneChangeButton();
            if (level != GhostController.Level || isButtonPressed != GhostController.IsButtonPressed)
            {
                GhostController.Level = level;
                GhostController.IsButtonPressed = isButtonPressed;
                SendValue();
            }
        }

        private void ReplayRecordedLap(ref int index, ref DateTime startControllerTimeStamp)
        {
            CarController carController = _replayOptions.RecordedLapData.CarControllers[index];
            DateTime controllerTimeStamp = carController.TimeStamp;
            if (index == 0)
                startControllerTimeStamp = carController.TimeStamp;
            while (DateTime.Now - LapStartDateTime < controllerTimeStamp - startControllerTimeStamp)
            {
                //Debug.WriteLine("before Thread.Sleep(MilliSecsToSleepRecordedLap) " + DateTime.Now);
                Thread.Sleep(MilliSecsToSleepRecordedLap);
            }
            //Debug.WriteLine("before WritePortValueIfValuesChanged(carController.Speed) " + DateTime.Now);
            //Debug.WriteLine("carController.Speed " + carController.Speed);
            WritePortValueIfValuesChanged(carController.Speed);
            index++;
        }

        private void WaitForANewLap(int lapCount)
        {
            ForceSuppressButton = true;
            while (Started && !Finished && lapCount == LapCount)
                ReplayDefaultSpeed();
            ForceSuppressButton = false;
        }

        private bool CalcLaneChangeButton(CarController carController = null)
        {
            bool isButtonPressed;
            if (!_replayOptions.IsLaneChangeActivated || 
                    _replayOptions.LaneChangeFrequency == GhostCarLaneChangeFrequency.Never ||
                    ShouldButtonBeSuppressed)
                isButtonPressed = false;
            else if (_replayOptions.LaneChangeFrequency == GhostCarLaneChangeFrequency.AsRecorded && carController != null)
                isButtonPressed = carController.LaneChange;
            else
                isButtonPressed = CalcChangeButtonRandomly();
            return isButtonPressed && !Finished;
        }

        private bool CalcChangeButtonRandomly()
        {
            if (ButtonPressed)
            {
                if ((DateTime.Now - ButtonChangedDateTime) > _buttonPressedMinTimeSpan)
                {
                    ButtonPressed = false;
                    ButtonChangedDateTime = DateTime.Now;
                }
            }
            else
            {
                if ((DateTime.Now - ButtonChangedDateTime) > _buttonPressedMinTimeSpan)
                {
                    if (_replayOptions.LaneChangeFrequency == GhostCarLaneChangeFrequency.Seldom)
                        ButtonPressed = GetRandomProbabilityOfOneTo(10);
                    else if (_replayOptions.LaneChangeFrequency == GhostCarLaneChangeFrequency.Medium)
                        ButtonPressed = GetRandomProbabilityOfOneTo(6);
                    else if (_replayOptions.LaneChangeFrequency == GhostCarLaneChangeFrequency.Often)
                        ButtonPressed = GetRandomProbabilityOfOneTo(2);
                    ButtonChangedDateTime = DateTime.Now;
                }
            }
            return ButtonPressed;
        }

        private bool ShouldButtonBeSuppressed
        {
            get
            {
                TimeSpan timeSinceLapStart = DateTime.Now - LapStartDateTime;
                decimal secondsSinceLapStart = (decimal) timeSinceLapStart.TotalSeconds;
                return ForceSuppressButton ||
                       _replayOptions.IsLaneChangeSupressed && 
                       secondsSinceLapStart >= _replayOptions.SuppressLaneChangeFrom && 
                       secondsSinceLapStart <= _replayOptions.SuppressLaneChangeTo;
            }
        }

        private bool GetRandomProbabilityOfOneTo(int maxValue)
        {
            int value = _random.Next(maxValue);
            return value == 1;
        }

    }
}
