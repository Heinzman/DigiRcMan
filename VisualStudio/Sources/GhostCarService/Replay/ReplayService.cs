using System;
using System.Timers;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;

namespace Elreg.GhostCarService.Replay
{
    public class ReplayService
    {
        private readonly IRaceModel _raceModel;
        private readonly ISerialPortParser _serialPortParser;
        private readonly IArduinoWriter _arduinoWriter;
        private readonly GhostcarsService _ghostcarsService;
        private IPlayer PlayerA { get; set; }
        private IPlayer PlayerB { get; set; }
        private readonly Timer _timer = new Timer();
        private StartFunctionDelegate _startFunction;
 
        private delegate void StartFunctionDelegate();

        public ReplayService(IRaceModel raceModel, ISerialPortParser serialPortParser, IArduinoWriter arduinoWriter, GhostcarsService ghostcarsService)
        {
            _raceModel = raceModel;
            _serialPortParser = serialPortParser;
            _arduinoWriter = arduinoWriter;
            _ghostcarsService = ghostcarsService;
            _timer.Elapsed += TimerElapsed;
            AttachToRaceModelEvents();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            _startFunction();
        }

        private void RestartPlayers()
        {
            try
            {
                PlayerA.Restart();
                PlayerB.Restart();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void StartPlayers()
        {
            try
            {
                PlayerA.Start();
                PlayerB.Start();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AttachToRaceModelEvents()
        {
            _raceModel.RaceFinished += RaceModelRaceFinished;
            _raceModel.RaceStarted += RaceModelRaceStarted;
            _raceModel.RaceStopped += RaceModelRaceStopped;
            _raceModel.RacePaused += RaceModelRacePaused;
            _raceModel.RaceInitialized += RaceModelRaceInitialized;
            _raceModel.RaceRestarted += RaceModelRaceRestarted;
        }

        private void RaceModelRaceInitialized(object sender, EventArgs e)
        {
            try
            {
                PlayerA = new PlayerNullObject();
                PlayerB = new PlayerNullObject();

                foreach (var lane in _raceModel.InitialLanes)
                {
                    if (lane.Driver.IsGhostcar)
                    {
                        Ghost ghost = _ghostcarsService.GetGhostBy(lane.Driver);
                        ReplayOptions replayOptions = _ghostcarsService.GetReplayOptionsBy(ghost);
                        replayOptions.LaneId = lane.Id;
                        Player player = new Player(replayOptions, _arduinoWriter, _serialPortParser);
                        player.LapAdded += PlayerLapAdded;
                        if (ghost == Ghost.GhostA)
                            PlayerA = player;
                        else
                            PlayerB = player;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void PlayerLapAdded(object sender, EventArgs e)
        {
            try
            {
                Player player = sender as Player;
                if (player != null && _ghostcarsService.GhostcarsOptions.DistanceHandlerActivated)
                    HandleDistance(player);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void HandleDistance(Player secondPlayer)
        {
            Ghost secondGhost = Ghost.GhostB;
            Player firstPlayer = (Player)PlayerA;
            if (secondPlayer == PlayerA)
            {
                firstPlayer = (Player) PlayerB;
                secondGhost = Ghost.GhostA;
            }
            bool forceSuppressRecordedLap = false;
            uint? forcedSpeed = null;
            if (firstPlayer.TimeStampOfLastLap.HasValue && secondPlayer.TimeStampOfLastLap.HasValue)
            {
                TimeSpan distance = secondPlayer.TimeStampOfLastLap.Value - firstPlayer.TimeStampOfLastLap.Value;
                if (distance.TotalSeconds < _ghostcarsService.GhostcarsOptions.MinDistanceInSecs)
                {
                    if (secondPlayer.IsRecordedLapPlayerActiv)
                        forceSuppressRecordedLap = true;
                    else
                    {
                        uint defaultSpeedByReplayOption = _ghostcarsService.GetReplayOptionsBy(secondGhost).DefaultSpeed;
                        if (defaultSpeedByReplayOption > 3)
                            forcedSpeed = defaultSpeedByReplayOption - 1;
                    }
                }
            }
            lock (secondPlayer)
            {
                secondPlayer.ForceSuppressRecordedLap = forceSuppressRecordedLap;
                secondPlayer.ForcedSpeed = forcedSpeed;
            }
            
        }

        private void RaceModelRaceRestarted(object sender, EventArgs e)
        {
            _startFunction = RestartPlayers;
            StartFunctionEvtlByTimer();
        }

        private void StartFunctionEvtlByTimer()
        {
            _timer.Stop();
            int milliSecs = _ghostcarsService.GhostcarsOptions.StartLatencyInMilliSecs;
            if (milliSecs > 0)
            {
                _timer.Interval = milliSecs;
                _timer.Start();
            }
            else
                _startFunction();
        }

        private void RaceModelRacePaused(object sender, EventArgs e)
        {
            try
            {
                _timer.Stop();
                PlayerA.Pause();
                PlayerB.Pause();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceModelRaceStopped(object sender, EventArgs e)
        {
            try
            {
                _timer.Stop();
                PlayerA.Stop();
                PlayerB.Stop();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void RaceModelRaceStarted(object sender, EventArgs e)
        {
            _startFunction = StartPlayers;
            StartFunctionEvtlByTimer();
        }

        private void RaceModelRaceFinished(object sender, EventArgs e)
        {
            try
            {
                _timer.Stop();
                PlayerA.Finish();
                PlayerB.Finish();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}
