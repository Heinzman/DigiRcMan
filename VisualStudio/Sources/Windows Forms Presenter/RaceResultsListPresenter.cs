using System;
using System.Windows.Forms;
using Elreg.Log;
using Elreg.ResourcesService;
using Elreg.WindowsFormsPresenter.RaceControl;
using Elreg.WindowsFormsView;
using Elreg.DomainModels;

namespace Elreg.WindowsFormsPresenter
{
    // ReSharper disable CoVariantArrayConversion
    public class RaceResultsListPresenter
    {
        private readonly IRaceResultsListView _raceResultsListView;
        private readonly IRaceControlView _raceControlView;
        private readonly RaceResultsListModel _raceResultsListModel = new RaceResultsListModel();
        private IRaceResultsView _raceResultsForm;
        private string _lastFileName = string.Empty;

        public RaceResultsListPresenter(IRaceResultsListView raceResultsListView, IRaceControlView raceControlView)
        {
            try
            {
                _raceResultsListView = raceResultsListView;
                _raceControlView = raceControlView;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void FillData()
        {
            try
            {
                _raceResultsListModel.DetermineRaceResultsFileList();
                FillListBox();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ShowSelectedRaceResult()
        {
            try
            {
                if (_raceResultsListView.ListBoxRaceResults.SelectedItems.Count > 0)
                {
                    FormHelper.StartForm.Invoke((MethodInvoker)delegate
                    {
                        _raceResultsListView.TopMost = false;
                        string fileName = _raceResultsListView.ListBoxRaceResults.SelectedItem.ToString();
                        if (_lastFileName != fileName || _raceResultsListView.ListBoxRaceResults.SelectedItems.Count == 1)
                        {
                            RaceResultsForm.LoadAndShow(fileName);
                            _raceResultsListView.TopMost = true;
                            SetFormToHalfOpacity();
                            _lastFileName = fileName;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void SetFormToFullOpacity()
        {
            try
            {
                _raceResultsListView.Opacity = 1f;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void AdjustCultureStrings()
        {
            try
            {
                _raceResultsListView.Text = LanguageManager.GetString("RaceResultsListFormCaption");
                _raceResultsListView.BtnRefresh.Text = LanguageManager.GetString("RaceResultsListFormBtnRefresh");
                _raceResultsListView.BtnClose.Text = LanguageManager.GetString("RaceResultsListFormBtnClose");
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void SetFormToHalfOpacity()
        {
            try
            {
                _raceResultsListView.Opacity = 0.4f;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void FillListBox()
        {
            _raceResultsListView.ListBoxRaceResults.Items.Clear();
            _raceResultsListView.ListBoxRaceResults.Items.AddRange(_raceResultsListModel.RaceResultsFileList.ToArray());
        }

        private IRaceResultsView RaceResultsForm
        {
            get
            {
                if (_raceResultsForm == null)
                    _raceResultsForm = _raceControlView.CreateRaceResultsForm();
                return _raceResultsForm;
            }
        }
    }
}
