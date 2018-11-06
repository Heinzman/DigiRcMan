using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Elreg.WindowsFormsPresenter.RaceReplay
{
    public class ReplayByEventHandler : IReplayHandler
    {
        private readonly IRaceReplayPresenter _raceReplayPresenter;
        private Timer _timer;
        private uint _replaySpeed = 1;

        public ReplayByEventHandler(IRaceReplayPresenter raceReplayPresenter)
        {
            _raceReplayPresenter = raceReplayPresenter;
            InitTimer();
        }

        public void Play()
        {
            _timer.Start();
        }

        public void Pause()
        {
            _timer.Stop();
        }

        public uint ReplaySpeed
        {
            get { return _replaySpeed; }
            set
            {
                _replaySpeed = value;
                SetTimerInterval();
            }
        }

        private void InitTimer()
        {
            _timer = new Timer();
            _timer.Elapsed += TimerElapsed;
            SetTimerInterval();
        }

        private void SetTimerInterval()
        {
            _timer.Interval = 1000 / ReplaySpeed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _raceReplayPresenter.RaceGridView.Invoke((MethodInvoker)(_raceReplayPresenter.ShowNextRaceReplayData));
            if (_raceReplayPresenter.RaceReplayModel.RaceReplayDataList == null || 
                _raceReplayPresenter.IndexRaceReplayData >= _raceReplayPresenter.RaceReplayModel.RaceReplayDataList.Count - 1)
            {
                _timer.Stop();
                _raceReplayPresenter.RaceGridView.Invoke((MethodInvoker)(_raceReplayPresenter.Pause));
            }
        }


    }
}
