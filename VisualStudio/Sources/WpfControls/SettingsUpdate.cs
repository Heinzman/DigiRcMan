using System.Configuration;
using System.IO;
using System.Reflection;

namespace Heinzman.WpfControls
{
    public class SettingsUpdate
    {
        private readonly WindowApplicationSettings _windowApplicationSettings;
        private FileInfo _latestConfigFile;
        private string _currentConfigFilePath;
        private string _destinationFile;

        public SettingsUpdate(WindowApplicationSettings windowApplicationSettings)
        {
            _windowApplicationSettings = windowApplicationSettings;
        }

        public void Update()
        {
            try
            {
                if (_windowApplicationSettings.UpgradeRequired)
                {
                    DetermineCurrentConfigFilePath();
                    DetermineLatestConfigFile();
                    DetermineDestinationFile();
                    if (!File.Exists(_destinationFile))
                        CopyLatestConfigFile();
                    _windowApplicationSettings.Upgrade();
                    _windowApplicationSettings.UpgradeRequired = false;
                    _windowApplicationSettings.Save();
                }
            }
            catch {}
        }

        private void CopyLatestConfigFile()
        {
            File.Copy(_latestConfigFile.FullName, _destinationFile);
        }

        private void DetermineDestinationFile()
        {
            var lastestConfigDirectoryName = Path.GetFileName(Path.GetDirectoryName(_latestConfigFile.FullName));
            _destinationFile = Path.GetDirectoryName(Path.GetDirectoryName(_currentConfigFilePath));
            _destinationFile = Path.Combine(_destinationFile, lastestConfigDirectoryName);
            if (!Directory.Exists(_destinationFile))
                Directory.CreateDirectory(_destinationFile);
            _destinationFile = Path.Combine(_destinationFile, _latestConfigFile.Name);
        }

        private void DetermineCurrentConfigFilePath()
        {
            var currentConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            _currentConfigFilePath = currentConfig.FilePath;
        }

        private void DetermineLatestConfigFile()
        {
            var exeName = Path.GetFileName(Assembly.GetEntryAssembly().Location);
            var companyFolder = new DirectoryInfo(_currentConfigFilePath).Parent.Parent.Parent;

            foreach (var diSubDir in companyFolder.GetDirectories("*" + exeName + "*", SearchOption.AllDirectories))
            {
                foreach (var file in diSubDir.GetFiles("user.config", SearchOption.AllDirectories))
                {
                    if (_latestConfigFile == null || file.LastWriteTime > _latestConfigFile.LastWriteTime)
                        _latestConfigFile = file;
                }
            }
        }
    }
}
