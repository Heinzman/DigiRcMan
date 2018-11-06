using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;
using Elreg.RaceControlService;
using Elreg.RaceOptionsService;
using Elreg.ResourcesService;
using Elreg.WindowsFormsView;
using Form = Elreg.WinFormsPresentationFramework.Forms.Form;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class SerialPortConfigForm : WinFormsPresentationFramework.Forms.Form, ISerialPortObserver, ISimpleView
    {
        private readonly ISerialPortReader _portReader;
        private readonly RaceKeyController _raceKeyController;
        private readonly SerialPortService _serialPortService;

        public SerialPortConfigForm(ISerialPortReader portReader, RaceKeyController raceKeyController,
                                    SerialPortService serialPortService)
        {
            _portReader = portReader;
            _raceKeyController = raceKeyController;
            _serialPortService = serialPortService;
            InitializeComponent();
            LanguageManager.LanguageChanged += LanguageManagerLanguageChanged;
            AdjustCultureStrings();
        }

        private void LanguageManagerLanguageChanged(object sender, EventArgs e)
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

        #region ISerialPortObserver Members

        public void SerialPortStatusChanged(object sender, SerialPortReaderStatus status)
        {
        }

        public void SerialPortDataReceived(object sender, string line, DateTime timeStamp)
        {
            try
            {
                if (IsDisposed == false)
                {
                    UpdateComPortLogHandler updateComPortLog = UpdateComPortLog;
                    txtLog.BeginInvoke(updateComPortLog, new object[] { this, line });
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        #endregion

        private void UpdateComPortLog(object sender, string line)
        {
            try
            {
                string text = line + "\n";

                if (txtLog.TextLength + text.Length > txtLog.MaxLength)
                    txtLog.Clear();
                txtLog.AppendText(text);
                txtLog.ScrollToCaret();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void StartPortReader()
        {
            try
            {
                SetPortReaderAttributes();
                _portReader.Start();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, @"Serial Port Setup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SetPortReaderAttributes()
        {
            _portReader.PortName = cbxComPort.Text.Trim();
        }

        private void PortReaderConfigFormLoad(object sender, EventArgs e)
        {
            try
            {
                _portReader.Attach(this);
                FillData();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            try
            {
                StartPortReader();
                _serialPortService.SerialPortSettings.PortName = cbxComPort.Text.Trim();
                _serialPortService.Save();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnStopClick(object sender, EventArgs e)
        {
            try
            {
                _portReader.Stop();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void PortReaderConfigFormFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _portReader.Detach(this);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void PortReaderConfigFormKeyDown(object sender, KeyEventArgs e)
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

        private void BtnCancelClick(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void FillData()
        {
            FillCbxComPorts();
            FillCbxParity();
            FillCbxStopBits();
            FillCbxHandshake();
            FillControlsWithSerialPortSettings();
        }

        private void FillCbxComPorts()
        {
            cbxComPort.Items.Clear();
            foreach (string s in _portReader.GetPortNames())
                cbxComPort.Items.Add(s);

            if (cbxComPort.Items.Contains(_serialPortService.SerialPortSettings.PortName))
                cbxComPort.Text = _serialPortService.SerialPortSettings.PortName;
            else if (cbxComPort.Items.Count > 0)
                cbxComPort.SelectedIndex = 0;
            else
            {
                MessageBox.Show(this,
                                @"There are no COM Ports detected on this computer.\nPlease install a COM Port and restart this app.",
                                @"No COM Ports Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void FillCbxParity()
        {
            var keyValuePairs = new List<KeyValuePair<string, Parity>>();

            foreach (Parity parity in Enum.GetValues(typeof (Parity)))
            {
                var keyValuePair = new KeyValuePair<string, Parity>(parity.ToString(), parity);
                keyValuePairs.Add(keyValuePair);
            }
            cbxParity.DataSource = keyValuePairs;
            cbxParity.ValueMember = "Value";
            cbxParity.DisplayMember = "Key";
        }

        private void FillCbxStopBits()
        {
            FillCbx<StopBits>(cbxStopBits);
        }

        private void FillCbxHandshake()
        {
            FillCbx<Handshake>(cbxHandshake);
        }

        private void FillCbx<T>(ComboBox comboBox)
        {
            var keyValuePairs = new List<KeyValuePair<string, T>>();

            foreach (T item in Enum.GetValues(typeof (T)))
            {
                var keyValuePair = new KeyValuePair<string, T>(item.ToString(), item);
                keyValuePairs.Add(keyValuePair);
            }
            comboBox.DataSource = keyValuePairs;
            comboBox.ValueMember = "Value";
            comboBox.DisplayMember = "Key";
        }

        private void FillControlsWithSerialPortSettings()
        {
            cbxParity.SelectedValue = _serialPortService.SerialPortSettings.Parity;
            cbxStopBits.SelectedValue = _serialPortService.SerialPortSettings.StopBits;
            cbxHandshake.SelectedValue = _serialPortService.SerialPortSettings.Handshake;
            txtBaudRate.Text = _serialPortService.SerialPortSettings.BaudRate.ToString();
            txtDataBits.Text = _serialPortService.SerialPortSettings.DataBits.ToString();
        }

        private void BtnSetClick(object sender, EventArgs e)
        {
            try
            {
                SaveSerialPortSettings();
                AssignSettingsToSerialPort();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void BtnResetClick(object sender, EventArgs e)
        {
            try
            {
                _serialPortService.Reset();
                FillControlsWithSerialPortSettings();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SaveSerialPortSettings()
        {
            _serialPortService.SerialPortSettings.PortName = cbxComPort.Text;
            _serialPortService.SerialPortSettings.Parity = (Parity) cbxParity.SelectedValue;
            _serialPortService.SerialPortSettings.StopBits = (StopBits) cbxStopBits.SelectedValue;
            _serialPortService.SerialPortSettings.Handshake = (Handshake) cbxHandshake.SelectedValue;
            _serialPortService.SerialPortSettings.BaudRate = int.Parse(txtBaudRate.Text);
            _serialPortService.SerialPortSettings.DataBits = int.Parse(txtDataBits.Text);
            _serialPortService.Save();
        }

        private void AssignSettingsToSerialPort()
        {
            _portReader.Assign(_serialPortService.SerialPortSettings);
        }

        private void AdjustCultureStrings()
        {
            Text = LanguageManager.GetString("SerialPortConfigFormCaption");
            btnSave.Text = LanguageManager.GetString("SerialPortConfigFormBtnSave");
            btnReset.Text = LanguageManager.GetString("SerialPortConfigFormBtnReset");
            btnStart.Text = LanguageManager.GetString("SerialPortConfigFormBtnStart");
            btnStop.Text = LanguageManager.GetString("SerialPortConfigFormBtnStop");
            btnClose.Text = LanguageManager.GetString("SerialPortConfigFormBtnClose");
        }

        #region Nested type: UpdateComPortLogHandler

        private delegate void UpdateComPortLogHandler(object sender, string line);

        #endregion
    }
}