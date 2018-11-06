using System;
using System.Windows.Forms;
using Elreg.DomainModels;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Elreg.WindowsFormsView;

namespace Elreg.WindowsFormsPresenter
{
    public class TextToSpeechCreatorPresenter
    {
        private readonly IMaintainSoundsView _maintainSoundsForm;
        private readonly TextToSpeechCreatorModel _textToSpeachCreatorModel;

        public TextToSpeechCreatorPresenter(IMaintainSoundsView maintainSoundsForm, DriversService driversService)
        {
            try
            {
                _maintainSoundsForm = maintainSoundsForm;
                _textToSpeachCreatorModel = new TextToSpeechCreatorModel(driversService);
                AdjustCultureStrings();
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
                _textToSpeachCreatorModel.CreateCountDownSoundList();
                _textToSpeachCreatorModel.CreateSpecialSoundList();
                _textToSpeachCreatorModel.CreateDriverSoundList();
                _maintainSoundsForm.GrdCoundDown.DataList = _textToSpeachCreatorModel.CountDownSoundList;
                _maintainSoundsForm.GrdSpecialSounds.DataList = _textToSpeachCreatorModel.SpecialSoundList;
                _maintainSoundsForm.GrdDrivers.DataList = _textToSpeachCreatorModel.DriverSoundList;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void CreateWavs()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _maintainSoundsForm.BtnCreateWavs.Enabled = false;
                _textToSpeachCreatorModel.CreateWavs(CreateNumbers);
                MessageBox.Show(@"The wav files are created.", @"Text To Speech Creation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                _maintainSoundsForm.BtnCreateWavs.Enabled = true;
            }
        }

        public void HandleOk()
        {
            try
            {
                _textToSpeachCreatorModel.Save();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void AdjustCultureStrings()
        {
            // todo
        }

        private bool CreateNumbers
        {
            get { return _maintainSoundsForm.ChkCreateNumbers.Checked; }
        }
    }
}
