using System;

namespace Elreg.GhostCarService.Replay
{
    public interface IPlayer
    {
        void Start();
        void Stop();
        void Finish();
        void Pause();
        void Restart();
        int LapCount { get; }
        DateTime? TimeStampOfLastLap { get; }
        event EventHandler LapAdded;
        bool IsRecordedLapPlayerActiv { get; }
        bool ForceSuppressRecordedLap { get; set; }
        uint? ForcedSpeed { set; }
    }
}