using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.DerivedEventArgs;
using Elreg.BusinessObjects.Interfaces;
using Elreg.Log;
using Elreg.RaceOptionsService;
using Timer = System.Timers.Timer;

namespace Elreg.WindowsFormsApplication.Forms
{
    public partial class VcuSettingsForm : Controls.Forms.Form, ISerialPortObserver
    {
        private readonly ISerialPortReader _serialPortReader;
        private readonly VcuSerialPortService _serialPortService;
        private readonly List<Timer> _timers = new List<Timer>();

        private enum TimerIndex
        {
            Id1 = 0,
            Id2 = 1,
            Id3 = 2,
            Id4 = 3,
            Id5 = 4,
            Id6 = 5,
            StartStop = 6
        }

        private delegate void UpdateComPortLogHandler(object sender, string line);

        public VcuSettingsForm(ISerialPortReader serialPortReader, VcuSerialPortService serialPortService, ISerialPortParser vcuSerialPortParser)
        {
            InitializeComponent();
            _serialPortReader = serialPortReader;
            _serialPortService = serialPortService;
            vcuSerialPortParser.DataReceived += VcuSerialPortParserDataReceived;
            vcuSerialPortParser.StartStopRequested += VcuSerialPortParserStartStopRequested;
        }

        private void InitTimers()
        {
            AddTimer(lblLapOfId1);
            AddTimer(lblLapOfId2);
            AddTimer(lblLapOfId3);
            AddTimer(lblLapOfId4);
            AddTimer(lblLapOfId5);
            AddTimer(lblLapOfId6);
            AddTimer(lblPauseStart);
        }

        private void AddTimer(Label label)
        {
            Timer timer = new Timer
            {
                Interval = 1000
            };

            timer.Elapsed += (sender, elapsedEventArgs) =>
            {
                Timer timer1 = (Timer)sender;
                timer1.Stop();
                Invoke((MethodInvoker)(() => label.BackColor = Color.White));
            };

            _timers.Add(timer);
        }

        private void VcuSerialPortParserStartStopRequested(object sender, EventArgs e)
        {
            lblPauseStart.BackColor = Color.Green;
            _timers[(int)TimerIndex.StartStop].Start();
        }

        private void VcuSerialPortParserDataReceived(object sender, PortParserEventArgs e)
        {
            if (e.LapDetectionAction != null)
            {
                Label label = null;
                TimerIndex timerIndex = TimerIndex.StartStop;
                if (e.LapDetectionAction.Car1)
                {
                    label = lblLapOfId1;
                    timerIndex = TimerIndex.Id1;
                }
                else if (e.LapDetectionAction.Car2)
                {
                    label = lblLapOfId2;
                    timerIndex = TimerIndex.Id2;
                }
                else if (e.LapDetectionAction.Car3)
                {
                    label = lblLapOfId3;
                    timerIndex = TimerIndex.Id3;
                }
                else if (e.LapDetectionAction.Car4)
                {
                    label = lblLapOfId4;
                    timerIndex = TimerIndex.Id4;
                }
                else if (e.LapDetectionAction.Car5)
                {
                    label = lblLapOfId5;
                    timerIndex = TimerIndex.Id5;
                }
                else if (e.LapDetectionAction.Car6)
                {
                    label = lblLapOfId6;
                    timerIndex = TimerIndex.Id6;
                }

                if (label != null)
                {
                    label.BackColor = Color.Green;
                    _timers[(int)timerIndex].Start();                    
                }
            }
        }

        public void SerialPortDataReceived(object sender, string line, DateTime timeStamp)
        {
            try
            {
                if (IsDisposed == false)
                {
                    UpdateComPortLogHandler updateComPortLog = UpdateComPortInLog;
                    BeginInvoke(updateComPortLog, new object[] { this, line });
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void UpdateComPortInLog(object sender, string line)
        {
            try
            {
                if (txtLogReceived.Text.Length + line.Length > txtLogReceived.MaxLength)
                    txtLogReceived.Clear();
                txtLogReceived.AppendText(line+ "\r\n");

                Application.DoEvents();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public void SerialPortStatusChanged(object sender, SerialPortReaderStatus status)
        {}

        private void BtnStartClick(object sender, EventArgs e)
        {
            try
            {
                StartPortReader();
                _serialPortService.VcuSerialPortSettings.PortName = cbxComPort.Text.Trim();
                _serialPortService.Save();
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
                _serialPortReader.Start();
                EnableButtonsDueIsStartedIs(true);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void EnableButtonsDueIsStartedIs(bool isStarted)
        {
            btnStart.Enabled = !isStarted;
            btnStop.Enabled = isStarted;
        }

        private void SetPortReaderAttributes()
        {
            _serialPortReader.PortName = cbxComPort.Text.Trim();
        }

        private void BtnStopClick(object sender, EventArgs e)
        {
            try
            {
                _serialPortReader.Stop();
                EnableButtonsDueIsStartedIs(false);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void TestFormLoad(object sender, EventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    _serialPortReader.DataReceivedAsText += SerialPortReaderDataReceivedAsText;
                    _serialPortReader.Attach(this);
                    FillData();
                    InitTimers();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void SerialPortReaderDataReceivedAsText(object sender, string text)
        {
            try
            {
                if (IsDisposed == false)
                {
                    UpdateComPortLogHandler updateComPortLog = UpdateComPortInLog;
                    BeginInvoke(updateComPortLog, new object[] { this, text });
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void FillData()
        {
            FillCbxComPorts();
        }

        private void FillCbxComPorts()
        {
            cbxComPort.Items.Clear();
            foreach (string s in _serialPortReader.GetPortNames())
                cbxComPort.Items.Add(s);

            if (cbxComPort.Items.Contains(_serialPortService.VcuSerialPortSettings.PortName))
                cbxComPort.Text = _serialPortService.VcuSerialPortSettings.PortName;
            else if (cbxComPort.Items.Count > 0)
                cbxComPort.SelectedIndex = 0;
            else
            {
                MessageBox.Show(this,
                                @"There are no COM Ports detected on this computer.\nPlease install a COM Port and restart this app.",
                                @"No COM Ports Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Close();
            }
        }

        private void BtnCloseClick(object sender, EventArgs e)
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

        private void TestFormFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _serialPortReader.Detach(this);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

    }
}
