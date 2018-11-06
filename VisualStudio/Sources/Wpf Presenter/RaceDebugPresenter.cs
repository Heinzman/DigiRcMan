using Heinzman.RaceDebugService;
using Heinzman.WpfApplication;

namespace Heinzman.WpfPresenter
{
    public class RaceDebugPresenter
    {
        private readonly RaceDebugger _raceDebugger;

        public RaceDebugPresenter(RaceDebugger raceDebugger)
        {
            _raceDebugger = raceDebugger;
        }

        public void ShowRaceDebugWindow()
        {
            _raceDebugger.Start();
            RaceDebugWindow raceDebugWindow = new RaceDebugWindow();
            raceDebugWindow.Closed += RaceDebugWindowClosed;
            raceDebugWindow.SetDataContext(_raceDebugger.LaneSnapshots);
            raceDebugWindow.Show();
        }

        private void RaceDebugWindowClosed(object sender, System.EventArgs e)
        {
            _raceDebugger.Stop();
        }
    }
}
