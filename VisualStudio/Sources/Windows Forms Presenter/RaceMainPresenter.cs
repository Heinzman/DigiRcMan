using System;
using Elreg.DomainModels.RaceModel;
using Elreg.Log;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter
{
    public class RaceMainPresenter : RacePresenter
    {
        private readonly IRaceView _raceView;

        public RaceMainPresenter(IRaceView raceView, RaceModel raceModel)
            : base(raceModel)
        {
            try
            {
                _raceView = raceView;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public override void FillView()
        {
            try
            {
                _raceView.Race = RaceModel.Race;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        protected override void UpdateRace()
        {
            _raceView.Race = RaceModel.Race;

            if (RaceModel.StatusHandler.IsRacePausedByKeyboardOrArduino)
                _raceView.PauseRace();
            else if (RaceModel.StatusHandler.IsRaceStarted)
                _raceView.RestartRace();
            else if (RaceModel.StatusHandler.IsRaceInCountDown)
                _raceView.ShowCountDownForm();
        }

    }
}
