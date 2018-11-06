using System;
using System.Timers;
using System.Windows.Forms;
using Elreg.BusinessObjects.LoggingData;
using Timer = System.Timers.Timer;

namespace Elreg.WindowsFormsPresenter.RaceReplay
{
    public class ReplayByTimelineHandler : IReplayHandler
    {
        private readonly IRaceReplayPresenter _raceReplayPresenter;
        private Timer _timer;
        private TimeSpan _timeSpan;

        public ReplayByTimelineHandler(IRaceReplayPresenter raceReplayPresenter)
        {
            _raceReplayPresenter = raceReplayPresenter;
            InitTimer();
        }

        public void Play()
        {
            if (_raceReplayPresenter.RaceReplayModel != null &&_raceReplayPresenter.RaceReplayModel.RaceReplayDataList != null && 
                _raceReplayPresenter.IndexRaceReplayData < _raceReplayPresenter.RaceReplayModel.RaceReplayDataList.Count)
            {
                RaceReplayData nextRaceReplayData = _raceReplayPresenter.RaceReplayModel.RaceReplayDataList[_raceReplayPresenter.IndexRaceReplayData];
                _timeSpan = nextRaceReplayData.Race.RacingTime.NetTimeSpanFromStart;
            }
            _timer.Start();
        }

        public void Pause()
        {
            _timer.Stop();
        }

        public uint ReplaySpeed { get; set; }

        private void InitTimer()
        {
            _timer = new Timer();
            _timer.Elapsed += TimerElapsed;
            _timer.Interval = 300;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_raceReplayPresenter.RaceReplayModel == null || _raceReplayPresenter.RaceReplayModel.RaceReplayDataList == null ||
                _raceReplayPresenter.IndexRaceReplayData >= _raceReplayPresenter.RaceReplayModel.RaceReplayDataList.Count - 1)
            {
                _timer.Stop();
                _raceReplayPresenter.RaceGridView.Invoke((MethodInvoker)(_raceReplayPresenter.Pause));
            }
            else if (_raceReplayPresenter.RaceReplayModel != null && _raceReplayPresenter.RaceReplayModel.RaceReplayDataList != null &&
                     _raceReplayPresenter.IndexRaceReplayData < _raceReplayPresenter.RaceReplayModel.RaceReplayDataList.Count)
            {
                int nextIndexRaceReplayData = _raceReplayPresenter.IndexRaceReplayData + 1;
                RaceReplayData nextRaceReplayData = _raceReplayPresenter.RaceReplayModel.RaceReplayDataList[nextIndexRaceReplayData];
                TimeSpan timeSpan = nextRaceReplayData.Race.RacingTime.NetTimeSpanFromStart;

                if (_timeSpan >= timeSpan)
                    _raceReplayPresenter.RaceGridView.Invoke((MethodInvoker)(_raceReplayPresenter.ShowNextRaceReplayData));

            }
            UpdateTimeSpan();
        }

        private void UpdateTimeSpan()
        {
            int milliSecs = (int)_timer.Interval * (int)ReplaySpeed;
            _timeSpan = _timeSpan.Add(new TimeSpan(0, 0, 0, 0, milliSecs));
        }
    }
}
