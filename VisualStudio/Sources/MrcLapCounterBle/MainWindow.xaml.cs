using System.Windows;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;
using System.Text;
using System.Text.RegularExpressions;

namespace MrcLapCounterBle
{
    public partial class MainWindow : Window
    {
        // <<< HIER DIE UUIDs EINTRAGEN, die du mit nRF Connect gefunden hast >>>
        private readonly Guid _serviceUuid = Guid.Parse("6e400001-b5a3-f393-e0a9-e50e24dcca9e");           // z. B. "0000abcd-0000-1000-8000-00805f9b34fb"
        private readonly Guid _notifyCharUuid = Guid.Parse("6e400003-b5a3-f393-e0a9-e50e24dcca9e");

        private BluetoothLEDevice? _device;
        private GattDeviceService? _service;
        private GattCharacteristic? _notifyCharacteristic;

        public MainWindow()
        {
            InitializeComponent();
            Title = "MRC Lap Counter BLE Monitor";
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Log("Suche nach MRC Lap Counter...");

                // Gerät per Name suchen (genauer: Advertisement-Watch)
                var selector = BluetoothLEDevice.GetDeviceSelectorFromPairingState(false);
                var devices = await DeviceInformation.FindAllAsync(selector);

                foreach (var devInfo in devices)
                {
                    if (devInfo.Name.Contains("MRC", StringComparison.OrdinalIgnoreCase) ||
                        devInfo.Name.Contains("Mini Race", StringComparison.OrdinalIgnoreCase))
                    {
                        Log($"Gerät gefunden: {devInfo.Name} ({devInfo.Id})");
                        await ConnectToDevice(devInfo.Id);
                        return;
                    }
                }

                Log("Kein MRC Lap Counter gefunden. Stelle sicher, dass er eingeschaltet und nicht verbunden ist.");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private async Task ConnectToDevice(string deviceId)
        {
            _device = await BluetoothLEDevice.FromIdAsync(deviceId);
            if (_device == null)
            {
                Log("Konnte Gerät nicht öffnen.");
                return;
            }

            Log($"Verbunden mit {_device.Name}");

            // Service abrufen
            var result = await _device.GetGattServicesForUuidAsync(_serviceUuid);
            if (result.Status != GattCommunicationStatus.Success || result.Services.Count == 0)
            {
                Log("Service nicht gefunden. Überprüfe die SERVICE_UUID!");
                return;
            }

            _service = result.Services[0];
            Log("Service gefunden.");

            // Characteristic abrufen
            var charResult = await _service.GetCharacteristicsForUuidAsync(_notifyCharUuid);
            if (charResult.Status != GattCommunicationStatus.Success || charResult.Characteristics.Count == 0)
            {
                Log("Notify-Characteristic nicht gefunden. Überprüfe die NOTIFY_CHAR_UUID!");
                return;
            }

            _notifyCharacteristic = charResult.Characteristics[0];
            Log("Notify-Characteristic gefunden.");

            // Notifications aktivieren
            _notifyCharacteristic.ValueChanged += NotifyCharacteristic_ValueChanged;

            var status = await _notifyCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                GattClientCharacteristicConfigurationDescriptorValue.Notify);

            if (status == GattCommunicationStatus.Success)
            {
                Log("Notifications erfolgreich aktiviert! Warte auf Runden...");
            }
            else
            {
                Log($"Fehler beim Aktivieren der Notifications: {status}");
            }
        }

        private void NotifyCharacteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            var data = args.CharacteristicValue;
            var reader = DataReader.FromBuffer(data);
            byte[] bytes = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(bytes);

            // Rohdaten als Hex (zeigt die numeric value of each received byte)
            string hex = BitConverter.ToString(bytes).Replace("-", " ");
            Dispatcher.Invoke(() => { Log($"Runde erkannt! Rohdaten ({bytes.Length} Bytes): {hex}"); });

            string line = System.Text.Encoding.ASCII.GetString(bytes);
            // Ergebnis: "0,04A96DF2511F90,484734\n"

            string[] parts = line.Trim().Split(',');
            string type = parts[0];
            string carId = parts[1];
            string value = parts[2];
            // Hier kannst du die empfangenen Daten weiter verarbeiten, je nachdem,
            // welches Format deine MRC Lap Counter BLE-Daten haben.
            // Das Beispiel geht davon aus, dass die Daten als ASCII-Text kommen,
            // der dann weiter dekodiert wird.

            if (parts.Length >= 3)
            {
                Dispatcher.Invoke(() => { Log($"Typ: {type} | ID: {carId} | Wert: {value}"); });
            }
        }

        //// Die folgenden Zeilen sind ein Beispiel, wie man mit den empfangenen Daten
            //// umgehen könnte, falls sie als ASCII-codierte Hex-Strings kommen.
            //// Dies ist nur ein Beispiel und muss an das tatsächliche Datenformat angepasst werden.
            //// Die empfangenen Bytes sind ASCII-codierte Hex-Zeilen, z.B.:
            //// "48 65 6C 6C 6F\n"  => Hex-Bytes => "Hello"
            //try
            //{
            //    var decodedText = DecodeAsciiHexLines(bytes);
            //    if (!string.IsNullOrEmpty(decodedText))
            //    {
            //        Dispatcher.Invoke(() => Log($"Dekodierter Text:\n{decodedText}"));
            //    }

            //    // Falls die dekodierten Hex-Daten eine binäre Struktur enthalten
            //    // (z.B. 4B Transponder + 4B Zeit), dann können wir sie zusätzlich interpretieren.
            //    var binary = ParseHexAsciiToBytes(bytes);
            //    if (binary.Length >= 8)
            //    {
            //        uint transponderId = BitConverter.ToUInt32(binary, 0);
            //        uint lapTimeMs = BitConverter.ToUInt32(binary, 4);

            //        Dispatcher.Invoke(() =>
            //        {
            //            Log($"→ Transponder: {transponderId} | Rundenzeit: {lapTimeMs} ms");
            //        });
            //    }
        //    }
        //    //catch (Exception ex)
        //    //{
        //    //    Dispatcher.Invoke(() => Log($"Fehler beim Dekodieren der Hex-ASCII-Daten: {ex.Message}"));
        //    //}
        //}

        // Liest ASCII-Bytes, interpretiert jede Textzeile als Hex-String und gibt die dekodierten Textzeilen zurück.
        private static string DecodeAsciiHexLines(byte[] asciiHexBytes)
        {
            var ascii = Encoding.ASCII.GetString(asciiHexBytes);
            var lines = ascii.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            foreach (var line in lines)
            {
                var hexOnly = Regex.Replace(line, @"[^0-9A-Fa-f]", "");
                if (hexOnly.Length < 2) continue;
                if (hexOnly.Length % 2 == 1) hexOnly = hexOnly.Substring(0, hexOnly.Length - 1);

                var bin = new byte[hexOnly.Length / 2];
                for (int i = 0; i < bin.Length; i++)
                {
                    bin[i] = Convert.ToByte(hexOnly.Substring(i * 2, 2), 16);
                }

                // Versuch: UTF-8 zuerst, falls ungültig then ASCII
                string decoded;
                try
                {
                    decoded = Encoding.UTF8.GetString(bin);
                }
                catch
                {
                    decoded = Encoding.ASCII.GetString(bin);
                }

                sb.AppendLine(decoded);
            }

            return sb.ToString().TrimEnd();
        }

        // Hilfsfunktion: direkte Umwandlung der empfangenen ASCII-Hex-Bytes in das korrespondierende Binär-Array.
        private static byte[] ParseHexAsciiToBytes(byte[] asciiHexBytes)
        {
            var ascii = Encoding.ASCII.GetString(asciiHexBytes);
            var hexOnly = Regex.Replace(ascii, @"[^0-9A-Fa-f]", "");
            if (hexOnly.Length % 2 == 1) hexOnly = hexOnly.Substring(0, hexOnly.Length - 1);

            var result = new byte[hexOnly.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(hexOnly.Substring(i * 2, 2), 16);
            }
            return result;
        }

        private void Log(string message)
        {
            Dispatcher.Invoke(() =>
            {
                if (txtLog.Text.Length > 10000) txtLog.Clear(); // Speicherbegrenzung
                txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
                txtLog.ScrollToEnd();
            });
        }

        // Aufräumen beim Schließen
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            _notifyCharacteristic?.WriteClientCharacteristicConfigurationDescriptorAsync(
                GattClientCharacteristicConfigurationDescriptorValue.None);

            _service?.Dispose();
            _device?.Dispose();
            base.OnClosing(e);
        }
    }
}