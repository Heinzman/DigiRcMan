namespace Elreg.WindowsFormsPresenter.RaceReplay
{
    public interface IReplayHandler
    {
        void Play();
        void Pause();
        uint ReplaySpeed { get; set; }
    }
}