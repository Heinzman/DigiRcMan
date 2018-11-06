using System;

// ReSharper disable UnusedMember.Global
namespace Elreg.GhostCarService.Replay
{
    public class PlayerNullObject : IPlayer
    {
        public event EventHandler LapAdded;

        public bool IsRecordedLapPlayerActiv
        {
            get { return false;}
        }

        public bool ForceSuppressRecordedLap
        {
            get { return false; }
            set { }
        }

        public uint? ForcedSpeed
        {
            set { }
        }

        public void Start()
        {
            
        }

        public void Stop()
        {
            
        }

        public void Finish()
        {
           
        }

        public void Pause()
        {
            
        }

        public void Restart()
        {
        }

        public int LapCount
        {
            get { return -1; }
        }

        public DateTime? TimeStampOfLastLap
        {
            get { return null; }
        }

        public void RaiseEventLapAdded()
        {
            if (LapAdded != null)
                LapAdded(this, null);
        }
    }
}
