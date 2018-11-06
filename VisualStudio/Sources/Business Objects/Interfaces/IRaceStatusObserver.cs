using System;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface IRaceStatusObserver
    {
        void RaceStarted(object sender, EventArgs e);
        void RaceRestarted(object sender, EventArgs e);
        void RacePaused(object sender, EventArgs e);
        void RaceInitialized(object sender, EventArgs e);
        void RaceFinished(object sender, EventArgs e);
        void RaceStopped(object sender, EventArgs e);
    }
}
