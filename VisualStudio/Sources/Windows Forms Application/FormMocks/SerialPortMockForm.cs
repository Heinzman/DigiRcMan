using System;
using System.Windows.Forms;
using Elreg.UnitTests.MockObjects.MockSerialPort;

namespace Elreg.WindowsFormsApplication.FormMocks
{
    public partial class SerialPortMockForm : Form
    {
        private readonly SerialPortReaderMock _serialPortReaderMock;

        public SerialPortMockForm(SerialPortReaderMock serialPortReaderMock)
        {
            _serialPortReaderMock = serialPortReaderMock;
            InitializeComponent();
        }

        private void BtnSendClick(object sender, EventArgs e)
        {
            _serialPortReaderMock.SendData(txtData.Text);
        }
    }
}
