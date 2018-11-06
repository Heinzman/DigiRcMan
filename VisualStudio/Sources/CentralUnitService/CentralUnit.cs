using System;
using System.Collections.Generic;
using System.Threading;
using Elreg.ArduinoService;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Lanes;
using Elreg.Log;

namespace Elreg.CentralUnitService
{
    public class CentralUnit : ILaneObserver, IRaceStatusObserver, ICentralUnit
    {
        private readonly IRaceModel _raceModel;
        private readonly IArduinoReader _arduinoReader;
        private bool _started;
        private readonly Dictionary<LaneId, ArduinoDelayMode> _delayModeOfLanes;
        private readonly IArduinoWriter _arduinoWriter;

        private const int MilliSecsToSleep = 10;

        public CentralUnit(IRaceModel raceModel, ICentralUnitOptionsService optionsService, IArduinoWriter arduinoWriter,
                           ISerialPortReader vcuSerialPortReader)
        {
            OptionsService = optionsService;
            OptionsService.Options.PropertyChanged += OptionsPropertyChanged;
            _raceModel = raceModel;
            _arduinoWriter = arduinoWriter;
            _arduinoReader = new ArduinoReader(vcuSerialPortReader);
            new ArduinoEventHandler(_arduinoReader, raceModel, optionsService);

            _delayModeOfLanes = new Dictionary<LaneId, ArduinoDelayMode>
                                    {
                                        {LaneId.Lane1, ArduinoDelayMode.Undefined},
                                        {LaneId.Lane2, ArduinoDelayMode.Undefined},
                                        {LaneId.Lane3, ArduinoDelayMode.Undefined},
                                        {LaneId.Lane4, ArduinoDelayMode.Undefined},
                                        {LaneId.Lane5, ArduinoDelayMode.Undefined},
                                        {LaneId.Lane6, ArduinoDelayMode.Undefined}
                                    };
            CheckToStartControlling();
            _raceModel.Attach((ILaneObserver)this);
            _raceModel.Attach((IRaceStatusObserver)this);
        }

        private void CheckToStartControlling()
        {
            if (OptionsService.Options.IsCentralUnitActivated)
                StartControlling();
        }

        public ICentralUnitOptionsService OptionsService { get; private set; }

        private void StartControlling()
        {
            _started = true;
            Thread thread = new Thread(ControlArduino) {Priority = ThreadPriority.Highest};
            thread.Start();
        }

        private void ControlArduino()
        {
            while (_started)
            {
                HandleDelayModes();
                Thread.Sleep(MilliSecsToSleep);
            }
        }

        private void HandleDelayModes()
        {
            if (_raceModel.Race != null)
            {
                foreach (Lane lane in _raceModel.Race.Lanes)
                {
                    ArduinoDelayMode arduinoDelayMode = ArduinoDelayMode.DelayNone;

                    if (_raceModel.StatusHandler.IsRaceInitialized || _raceModel.StatusHandler.IsRaceNotSetuped)
                        arduinoDelayMode = ArduinoDelayMode.DelayNone;
                    else
                    {
                        int percent = (int)(lane.CurrentFuelLevelInLitres / lane.TankMaximumInLitres * 100);

                        if (OptionsService.Options.StutterOptions.IsActivated)
                        {
                            if (percent < PercentFuelForStutterMax)
                                arduinoDelayMode = ArduinoDelayMode.StutterMax;
                            else if (percent < PercentFuelForStutterMedium)
                                arduinoDelayMode = ArduinoDelayMode.StutterMedium;
                            else if (percent <= PercentFuelForStutterMin)
                                arduinoDelayMode = ArduinoDelayMode.StutterMin;
                        }
                        if (OptionsService.Options.DelayOptions.IsActivated)
                        {
                            float delayStep = (100 - PercentFuelForZeroDelay) / 11f;
                            if (percent > 100 - delayStep)
                                arduinoDelayMode = ArduinoDelayMode.DelayMax;
                            else if (percent > 100 - 2 * delayStep)
                                arduinoDelayMode = ArduinoDelayMode.Delay10;
                            else if (percent > 100 - 3 * delayStep)
                                arduinoDelayMode = ArduinoDelayMode.Delay9;
                            else if (percent > 100 - 4 * delayStep)
                                arduinoDelayMode = ArduinoDelayMode.Delay8;
                            else if (percent > 100 - 5 * delayStep)
                                arduinoDelayMode = ArduinoDelayMode.Delay7;
                            else if (percent > 100 - 6 * delayStep)
                                arduinoDelayMode = ArduinoDelayMode.Delay6;
                            else if (percent > 100 - 7 * delayStep)
                                arduinoDelayMode = ArduinoDelayMode.Delay5;
                            else if (percent > 100 - 8 * delayStep)
                                arduinoDelayMode = ArduinoDelayMode.Delay4;
                            else if (percent > 100 - 9 * delayStep)
                                arduinoDelayMode = ArduinoDelayMode.Delay3;
                            else if (percent > 100 - 10 * delayStep)
                                arduinoDelayMode = ArduinoDelayMode.Delay2;
                            else if (percent > 100 - 11 * delayStep)
                                arduinoDelayMode = ArduinoDelayMode.Delay1;
                            else if (percent > PercentFuelForStutterMin)
                                arduinoDelayMode = ArduinoDelayMode.DelayNone;
                        }
                    }

                    ArduinoDelayMode previousDelayMode;
                    if (_delayModeOfLanes.TryGetValue(lane.Id, out previousDelayMode))
                    {
                        if (previousDelayMode != arduinoDelayMode)
                        {
                            _delayModeOfLanes[lane.Id] = arduinoDelayMode;
                            _arduinoWriter.SendDelayMode(lane.Id, arduinoDelayMode);
                        }
                    }
                }
            }
        }

        private int PercentFuelForStutterMin
        {
            get { return OptionsService.Options.StutterOptions.PercentFuelForStuttering; }
        }

        private int PercentFuelForStutterMedium
        {
            get { return OptionsService.Options.StutterOptions.PercentFuelForStuttering * 2 / 3; }
        }

        private int PercentFuelForStutterMax
        {
            get { return OptionsService.Options.StutterOptions.PercentFuelForStuttering / 3; }
        }

        private int PercentFuelForZeroDelay
        {
            get { return OptionsService.Options.DelayOptions.PercentFuelForZeroDelay; }
        }

        public void StopControlling()
        {
            _started = false;
        }
    
        private void OptionsPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                SendOptionsToArduino();

                bool isCentralUnitActivated = OptionsService.Options.IsCentralUnitActivated;
                if (isCentralUnitActivated && !_started)
                    StartControlling();
                else if (!isCentralUnitActivated && _started)
                    StopControlling();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void SendOptionsToArduino()
        {
            bool isGlobalToggleModeOn = OptionsService.Options.IsToggleModeActivated;
            _arduinoWriter.SendGlobalToggleMode(isGlobalToggleModeOn);
            bool isGlobalTurboOn = OptionsService.Options.TurboOptions.IsActivated;
            _arduinoWriter.SendGlobalTurbo(isGlobalTurboOn);
            uint maxSpeedWithoutTurbo = OptionsService.Options.TurboOptions.MaxLevelWithoutTurbo;
            _arduinoWriter.SendMaxSpeedWithoutTurbo(maxSpeedWithoutTurbo);
            bool isDebugMode = OptionsService.Options.IsDebugMode;
            _arduinoWriter.SendDebugMode(isDebugMode);
            int delayAccelerationFactor = OptionsService.Options.DelayOptions.AccelerationFactor;
            _arduinoWriter.SendDelayAccelerationFactor(delayAccelerationFactor);
            int delayBrakeFactor = OptionsService.Options.DelayOptions.BrakeFactor;
            _arduinoWriter.SendDelayBrakeFactor(delayBrakeFactor);

            foreach (LaneId laneId in Enum.GetValues(typeof (LaneId)))
                _arduinoWriter.SendMaxSpeed(laneId, OptionsService.Options.GlobalMaxLevel);
        }

        public void EngineDamaged(LaneId laneId)
        {
            _arduinoWriter.SendMaxSpeed(laneId, OptionsService.Options.EngineDamageSettings.MaxSpeed);
        }

        public void EngineFixed(LaneId laneId)
        {
            _arduinoWriter.SendMaxSpeed(laneId, OptionsService.Options.GlobalMaxLevel);
        }

        public void CarDamagedByRocket(LaneId laneId)
        {
            _arduinoWriter.SendMaxSpeed(laneId, OptionsService.Options.RocketSettings.MaxSpeedWhenDamaged); 
        }

        public void RocketExplodedDueDefending(LaneId laneId)  {}

        public void RocketDamageFixed(LaneId laneId)
        {
            _arduinoWriter.SendMaxSpeed(laneId, OptionsService.Options.GlobalMaxLevel);
        }

        public void RocketStarted(LaneId laneId) { }

        public void AttackedByRocket(LaneId laneId) { }

        public void RaceStarted(object sender, EventArgs e)
        {
            _arduinoWriter.SendPause(false);
        }

        public void RaceRestarted(object sender, EventArgs e)
        {
            _arduinoWriter.SendPause(false);
        }

        public void RacePaused(object sender, EventArgs e)
        {
            _arduinoWriter.SendPause(true);
        }

        public void RaceBreaked(object sender, EventArgs e)
        {
            _arduinoWriter.SendPause(false);
        }

        public void RaceInitialized(object sender, EventArgs e)
        {
            _arduinoWriter.SendPause(false);
        }

        public void RaceFinished(object sender, EventArgs e)
        {
            _arduinoWriter.SendPause(false);
        }

        public void RaceStopped(object sender, EventArgs e)
        {
            _arduinoWriter.SendPause(false);
        }

        public void RaceUnbreaked(object sender, EventArgs e)
        {
            _arduinoWriter.SendPause(true);
        }
    }
}
