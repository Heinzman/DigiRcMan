using System;
using System.Windows.Forms;
using Elreg.Log;
using Elreg.WindowsFormsPresenter;
using Elreg.WindowsFormsView;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class ChampionshipListForm : WinFormsPresentationFramework.Forms.Form, IChampionshipListView
    {
        private readonly ChampionshipListPresenter _championshipListPresenter;

        public ChampionshipListForm(ChampionshipForm championshipList)
        {
            InitializeComponent();
            _championshipListPresenter = new ChampionshipListPresenter(this, championshipList);
        }

        #region IChampionshipListView Members

        public ListBox ListBoxChampionships
        {
            get { return listBox1; }
        }

        public Button BtnRefresh
        {
            get { return btnRefresh; }
        }

        public Button BtnClose
        {
            get { return btnClose; }
        }

        public override void InvokeShowAndFocus()
        {
            _championshipListPresenter.AdjustCultureStrings();
            _championshipListPresenter.FillData();
            base.InvokeShowAndFocus();
        }

        public string Caption
        {
            get { return Text; }
            set { Text = value; }
        }

        #endregion

        private void ListBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _championshipListPresenter.ShowSelectedChampionship();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
                Hide();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnRefreshClick(object sender, EventArgs e)
        {
            try
            {
                _championshipListPresenter.FillData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ChampionshipListFormActivated(object sender, EventArgs e)
        {
            try
            {
                _championshipListPresenter.SetFormToFullOpacity();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void ChampionshipListFormDeactivate(object sender, EventArgs e)
        {
            try
            {
                _championshipListPresenter.SetFormToHalfOpacity();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}