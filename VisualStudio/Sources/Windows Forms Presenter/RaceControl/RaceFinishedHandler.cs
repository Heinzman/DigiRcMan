using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Interfaces;
using Elreg.DomainModels.RaceControl;
using Elreg.DomainModels.RaceModel;
using Elreg.Log;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter.RaceControl
{
    public class RaceFinishedHandler
    {
        private readonly IRaceControlView _raceControlView;
        private readonly ISimpleView _raceGridForm;
        private readonly IChampionshipView _championshipForm;
        private readonly RaceControlModel _raceControlModel;
        private readonly IPauseView _pauseForm;
        private readonly RaceModel _raceModel;
        private IRaceResult _raceResult;
        private bool _isHandlingInProcess;

        public RaceFinishedHandler(IRaceControlView raceControlView, ISimpleView raceGridForm, 
            IChampionshipView championshipForm, RaceControlModel raceControlModel, 
            IPauseView pauseForm, RaceModel raceModel)
        {
            _raceControlView = raceControlView;
            _raceGridForm = raceGridForm;
            _championshipForm = championshipForm;
            _raceControlModel = raceControlModel;
            _pauseForm = pauseForm;
            _raceModel = raceModel;
        }

        public void DoWork()
        {
            HandleRaceFinished();
        }

        private void HandleRaceFinished()
        {
            try
            {
                if (!_isHandlingInProcess)
                {
                    _isHandlingInProcess = true;

                    DecideToShowNewRaceResult();
                    FormHelper.HideForm(_raceGridForm);
                    FormHelper.ShowAndFocus(_raceControlView);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            finally
            {
                _isHandlingInProcess = false;
            }
        }

        private void DecideToShowNewRaceResult()
        {
            FormHelper.HideForm(_pauseForm);
            if (_raceControlModel.ShouldRaceResultBeShown)
                CreateAndShowNewRaceResult();
        }

        private void CreateAndShowNewRaceResult()
        {
            _raceResult = _raceModel.CreateRaceResult();
            if (ShowRaceResult())
                DecideToAddToChampionship();
        }

        private void DecideToAddToChampionship()
        {
            var championshipAdder = new ChampionshipAdder(_raceResult, _championshipForm); 
            championshipAdder.DecideToAddToChampionship();
        }

        private bool ShowRaceResult()
        {
            bool ret = false;
            FormHelper.StartForm.Invoke((MethodInvoker) delegate
            {
                IRaceResultsView raceResultsView = _raceControlView.CreateRaceResultsForm();
                raceResultsView.ShowDialog();
                ret = raceResultsView.Ok;
            });
            return ret;
        }

    }
}
