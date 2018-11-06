using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Options;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.RaceSoundService;
using Elreg.WindowsFormsPresenter;
using Elreg.WindowsFormsView;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class MaintainSoundsForm : WinFormsPresentationFramework.Forms.Form, IMaintainSoundsView
    {
        private readonly MaintainSoundsPresenter _maintainSoundsPresenter;
        private readonly TextToSpeechCreatorPresenter _textToSpeachCreatorPresenter;

        public MaintainSoundsForm(SoundOptionsService soundsService, ActionSoundsService actionSoundsService, 
                                  DriversService driversService, RaceSettings raceSettings)
        {
            InitializeComponent();
            _maintainSoundsPresenter = new MaintainSoundsPresenter(this, soundsService, actionSoundsService, driversService, raceSettings);
            _textToSpeachCreatorPresenter = new TextToSpeechCreatorPresenter(this, driversService);
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            try
            {
                _maintainSoundsPresenter.HandleCancel();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            try
            {
                _maintainSoundsPresenter.HandleOk();
                _textToSpeachCreatorPresenter.HandleOk();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void MaintainDriversFormLoad(object sender, EventArgs e)
        {
            try
            {
                _maintainSoundsPresenter.FillData();
                _textToSpeachCreatorPresenter.FillData();
                txtNumbersPath.Text = SpecialSoundHandler.SoundNumbersPath;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public ISoundOptionView CtlFinished
        {
            get { return ctlFinished; }
        }

        public ISoundOptionView CtlLapDetectedNotAdded
        {
            get { return ctlLapDetectedNotAdded; }
        }

        public ISoundOptionView CtlDisqualified
        {
            get { return ctlDisqualified; }
        }

        public ISoundOptionView CtlLap
        {
            get { return ctlLap; }
        }

        public ISoundOptionView CtlPenalty
        {
            get { return ctlPenalty; }
        }

        public Control BtnCancel
        {
            get { return btnCancel; }
        }

        public Control BtnOk
        {
            get { return btnOK; }
        }

        ITextToSpeechGrid IMaintainSoundsView.GrdCoundDown
        {
            get { return grdCoundDown; }
        }

        public ITextToSpeechGrid GrdSpecialSounds
        {
            get { return grdSpecialSounds; }
        }

        public ITextToSpeechGrid GrdDrivers
        {
            get { return grdDrivers; }
        }

        public CheckBox ChkCreateNumbers
        {
            get { return chkCreateNumbers; }
        }

        public Control BtnCreateWavs
        {
            get { return btnCreateWavs; }
        }

        private void BtnCreateWavsClick(object sender, EventArgs e)
        {
            try
            {
                _textToSpeachCreatorPresenter.CreateWavs();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}