using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;
using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;
using Elreg.BusinessObjects.Options;

namespace MrcLapCounterBle
{
    public class MrcBluetoothReader : ISerialPortReader
    {
        private readonly Guid _serviceUuid = Guid.Parse("6e400001-b5a3-f393-e0a9-e50e24dcca9e");
        private readonly Guid _notifyCharUuid = Guid.Parse("6e400003-b5a3-f393-e0a9-e50e24dcca9e");

        private BluetoothLEDevice? _device;
        private GattDeviceService? _service;
        private GattCharacteristic? _notifyCharacteristic;

        private string _portName = string.Empty;

        public delegate void DataReceivedHandler(object sender, string line, DateTime timeStampOfLapAddition);
        public event DataReceivedHandler? DataReceived;

        public delegate void StatusChangedHandler(object sender, SerialPortReaderStatus status);
        public event StatusChangedHandler? StatusChanged;

        public event Delegates.DataReceivedAsTextHandler? DataReceivedAsText;

        public void Start()
        {
            SetStatus(SerialPortReaderStatus.Connecting);
            _ = ConnectAsync();
        }

        public void Stop()
        {
            Disconnect();
            SetStatus(SerialPortReaderStatus.Stopped);
        }

        public List<string> GetPortNames()
        {
            return new List<string> { "MRC BLE" };
        }

        public void Assign(SerialPortSettings serialPortSettings)
        {
            // BLE does not use serial port settings
        }

        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        public void Attach(ISerialPortObserver serialPortObserver)
        {
            DataReceived += serialPortObserver.SerialPortDataReceived;
            StatusChanged += serialPortObserver.SerialPortStatusChanged;
        }

        public void Detach(ISerialPortObserver serialPortObserver)
        {
            DataReceived -= serialPortObserver.SerialPortDataReceived;
            StatusChanged -= serialPortObserver.SerialPortStatusChanged;
        }

        public void InvokeDataReceivedAsText(string text)
        {
            DataReceivedAsText?.Invoke(this, text);
        }

        private async Task ConnectAsync()
        {
            try
            {
                var selector = BluetoothLEDevice.GetDeviceSelectorFromPairingState(false);
                var devices = await DeviceInformation.FindAllAsync(selector);

                foreach (var devInfo in devices)
                {
                    if (devInfo.Name.Contains("MRC", StringComparison.OrdinalIgnoreCase) ||
                        devInfo.Name.Contains("Mini Race", StringComparison.OrdinalIgnoreCase))
                    {
                        await ConnectToDevice(devInfo.Id);
                        return;
                    }
                }

                SetStatus(SerialPortReaderStatus.Stopped);
            }
            catch (Exception)
            {
                Stop();
                throw;
            }
        }

        private async Task ConnectToDevice(string deviceId)
        {
            _device = await BluetoothLEDevice.FromIdAsync(deviceId);
            if (_device == null)
            {
                SetStatus(SerialPortReaderStatus.Stopped);
                return;
            }

            var result = await _device.GetGattServicesForUuidAsync(_serviceUuid);
            if (result.Status != GattCommunicationStatus.Success || result.Services.Count == 0)
            {
                SetStatus(SerialPortReaderStatus.Stopped);
                return;
            }

            _service = result.Services[0];

            var charResult = await _service.GetCharacteristicsForUuidAsync(_notifyCharUuid);
            if (charResult.Status != GattCommunicationStatus.Success || charResult.Characteristics.Count == 0)
            {
                SetStatus(SerialPortReaderStatus.Stopped);
                return;
            }

            _notifyCharacteristic = charResult.Characteristics[0];
            _notifyCharacteristic.ValueChanged += NotifyCharacteristic_ValueChanged;

            var status = await _notifyCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                GattClientCharacteristicConfigurationDescriptorValue.Notify);

            if (status == GattCommunicationStatus.Success)
            {
                SetStatus(SerialPortReaderStatus.Started);
            }
            else
            {
                SetStatus(SerialPortReaderStatus.Stopped);
            }
        }

        private void NotifyCharacteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            var data = args.CharacteristicValue;
            var reader = DataReader.FromBuffer(data);
            byte[] bytes = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(bytes);

            DateTime timeStamp = DateTime.Now;
            string hexData = ByteArrayToHexString(bytes);

            if (hexData.Length > 0)
            {
                DataReceived?.Invoke(this, hexData, timeStamp);
                DataReceivedAsText?.Invoke(this, hexData);
            }
        }

        private void Disconnect()
        {
            if (_notifyCharacteristic != null)
            {
                _notifyCharacteristic.ValueChanged -= NotifyCharacteristic_ValueChanged;
                _ = _notifyCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                    GattClientCharacteristicConfigurationDescriptorValue.None);
                _notifyCharacteristic = null;
            }

            _service?.Dispose();
            _service = null;

            _device?.Dispose();
            _device = null;
        }

        private static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }

        private void SetStatus(SerialPortReaderStatus status)
        {
            StatusChanged?.Invoke(this, status);
        }
    }
}
