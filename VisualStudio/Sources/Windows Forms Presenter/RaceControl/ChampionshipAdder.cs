using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Championships;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;
using Elreg.WinFormsPresentationFramework;

namespace Elreg.WindowsFormsPresenter.RaceControl
{
    public class ChampionshipAdder
    {
        private readonly IRaceResult _raceResult;
        private readonly IChampionshipView _championshipForm;
        private string MessageAddToChampionship { get; set; }
        private string MessageUseLastChampionship { get; set; }
        private string MessageCreateChampionship { get; set; }

        public ChampionshipAdder(IRaceResult raceResult, IChampionshipView championshipForm)
        {
            _raceResult = raceResult;
            _championshipForm = championshipForm;
            LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
            AdjustCultureStrings();
        }

        private void LanguageManagerLanguageChanged(object sender, System.EventArgs e)
        {
            try
            {
                AdjustCultureStrings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void DecideToAddToChampionship()
        {
            if (DecidedToAddToChampionship)
                DecideToCreateOrUseExisting();
        }

        private bool DecidedToAddToChampionship
        {
            get
            {
                LargeMessageBoxHandler largeMessageBoxHandler = new LargeMessageBoxHandler();
                DialogResult dialogResult = largeMessageBoxHandler.ShowDialog(MessageAddToChampionship);
                return dialogResult == DialogResult.Yes;
            }
        }

        private void DecideToCreateOrUseExisting()
        {
            if (DecidedToUsePreviousChampionship)
                AddToExistingChampionship();
            else if (DecidedToCreateNewChampionship)
                CreateNewChampionship();
        }

        private bool DecidedToUsePreviousChampionship
        {
            get
            {
                LargeMessageBoxHandler largeMessageBoxHandler = new LargeMessageBoxHandler();
                DialogResult dialogResult = largeMessageBoxHandler.ShowDialog(MessageUseLastChampionship);
                return dialogResult == DialogResult.Yes;
            }
        }

        private bool DecidedToCreateNewChampionship
        {
            get
            {
                LargeMessageBoxHandler largeMessageBoxHandler = new LargeMessageBoxHandler();
                DialogResult dialogResult = largeMessageBoxHandler.ShowDialog(MessageCreateChampionship);
                return dialogResult == DialogResult.Yes;
            }
        }

        private void AddToExistingChampionship()
        {
            var raceResult = _raceResult as RaceResult;
            if (raceResult != null)
            {
                _championshipForm.AddToLatest(raceResult);
                FormHelper.ShowModalDialog(_championshipForm);
            }
        }

        private void CreateNewChampionship()
        {
            var raceResult = _raceResult as RaceResult;
            if (raceResult != null)
            {
                _championshipForm.AddToNew(raceResult);
                FormHelper.ShowModalDialog(_championshipForm);
            }
        }

        private void AdjustCultureStrings()
        {
            MessageAddToChampionship = LanguageManager.GetString("ChampionshipAdderMessageAddToChampionship");
            MessageUseLastChampionship = LanguageManager.GetString("ChampionshipAdderMessageUseLastChampionship");
            MessageCreateChampionship = LanguageManager.GetString("ChampionshipAdderMessageCreateChampionship");
        }

    }
}