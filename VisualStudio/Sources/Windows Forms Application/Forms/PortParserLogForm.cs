using System;
using System.Windows.Forms;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;
using Elreg.WindowsFormsView;
using Elreg.WindowsFormsPresenter;
using Elreg.DomainModels;
using Elreg.RaceControlService;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class PortParserLogForm : Form, IPortParserLogView
    {
        private readonly PortParserLogPresenter _portParserLogPresenter;
        private string _logText;
        private readonly RaceKeyController _raceKeyController;

        private delegate void UpdateDisplayHandler();

        public PortParserLogForm(ISerialPortParser serialPortParser, RaceKeyController raceKeyController)
        {
            InitializeComponent();
            _raceKeyController = raceKeyController;
            PortParserLogModel portParserLogModel = new PortParserLogModel(serialPortParser);
            _portParserLogPresenter = new PortParserLogPresenter(this, portParserLogModel);
        }

        public void UpdateLog(string logText)
        {
            if (Disposing)
            {
                _logText = logText;
                BeginInvoke(new UpdateDisplayHandler(UpdateDisplay));
            }
        }

        private void UpdateDisplay()
        {
            try
            {
                if (txtConsole.TextLength + _logText.Length > txtConsole.MaxLength)
                    txtConsole.Clear();
                txtConsole.AppendText(_logText);
                txtConsole.ScrollToCaret();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void PortParserLogFormFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _portParserLogPresenter.Detach();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void PortParserLogFormKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                _raceKeyController.HandleKey(e);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}
