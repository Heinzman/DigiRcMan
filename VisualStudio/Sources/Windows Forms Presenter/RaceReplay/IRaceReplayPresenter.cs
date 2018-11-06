using Elreg.DomainModels.RaceReplay;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter.RaceReplay
{
    public interface IRaceReplayPresenter
    {
        IRaceReplayView RaceGridView { get; }
        int IndexRaceReplayData { get; }
        RaceReplayModel RaceReplayModel { get; }
        void ShowNextRaceReplayData();
        void Pause();
    }
}