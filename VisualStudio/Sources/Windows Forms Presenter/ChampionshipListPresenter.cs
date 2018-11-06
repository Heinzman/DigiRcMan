using System;
using Elreg.DomainModels.Championships;
using Elreg.Log;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter
{
    public class ChampionshipListPresenter
    {
        private readonly IChampionshipListView _championshipListView;
        private readonly ChampionshipListModel _championshipListModel = new ChampionshipListModel();
        private readonly IChampionshipView _championshipView;

        public ChampionshipListPresenter(IChampionshipListView championshipListView, IChampionshipView championshipView)
        {
            try
            {
                _championshipListView = championshipListView;
                _championshipView = championshipView;
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
                _championshipListModel.DetermineChampionshipFileList();
                FillListBox();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void ShowSelectedChampionship()
        {
            try
            {
                if (_championshipListView.ListBoxChampionships.SelectedItems.Count > 0)
                {
                    _championshipListView.TopMost = false;
                    string fileName = _championshipListView.ListBoxChampionships.SelectedItem.ToString();
                    _championshipView.LoadAndShow(fileName);
                    _championshipListView.TopMost = true;
                    SetFormToHalfOpacity();
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
                _championshipListView.Opacity = 1f;
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
                _championshipListView.Opacity = 0.4f;
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
                _championshipListView.Text = LanguageManager.GetString("ChampionshipListFormCaption");
                _championshipListView.BtnRefresh.Text = LanguageManager.GetString("ChampionshipListFormBtnRefresh");
                _championshipListView.BtnClose.Text = LanguageManager.GetString("ChampionshipListFormBtnClose");
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        // ReSharper disable CoVariantArrayConversion
        private void FillListBox()
        {
            _championshipListView.ListBoxChampionships.Items.Clear();
            if (_championshipListModel != null && _championshipListModel.ChampionshipFileList != null)
                _championshipListView.ListBoxChampionships.Items.AddRange(_championshipListModel.ChampionshipFileList.ToArray());
        }
    }
}
