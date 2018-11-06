using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Windows.Forms;

namespace Elreg.HelperLib
{
    public class SystemHelper
    {
        private string _userId = string.Empty;
        private static readonly SystemHelper Inst = new SystemHelper();
        public const float Epsilon = 0.0001f;

        public static string UserId
        {
            get
            {
                if (Inst._userId == "")
                {
                    // without domain
                    string userId = string.Empty;
                    WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                    if (windowsIdentity != null)
                    {
                        userId = windowsIdentity.Name;
                        int pos = userId.IndexOf("\\");
                        if (pos > 0 && pos < userId.Length)
                            userId = userId.Substring(pos + 1);
                    }
                    Inst._userId = userId;
                }
                return Inst._userId;
            }
            set { Inst._userId = value; }
        }

        public static string ComputerName
        {
            get { return Dns.GetHostName(); }
        }

        public static string GetRelativeSubPath(string absolutePath)
        {
            string path = absolutePath;
            string appPath = Application.StartupPath;

            if (absolutePath != null && absolutePath.StartsWith(appPath))
                path = absolutePath.Substring(appPath.Length);
            return path;
        }

        public static string GetAbsolutePath(string relativeOrAbsolutePath)
        {
            string absolutePath = relativeOrAbsolutePath;
            string appPath = Application.StartupPath;

            if (relativeOrAbsolutePath != null && (relativeOrAbsolutePath.StartsWith("\\") || relativeOrAbsolutePath.StartsWith("/")))
                absolutePath = Path.GetFullPath(appPath + relativeOrAbsolutePath);
            return absolutePath;
        }

        public static string GetMacAddress()
        {
            string macAddress = null;
            NetworkInterface[] networkAdapters = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in networkAdapters)
            {
                PhysicalAddress physicalAddress = adapter.GetPhysicalAddress();
                string address = physicalAddress.ToString();
                if (address.Length == 12)
                {
                    macAddress = address;
                    break;
                }
            }
            return macAddress;
        }

        public static string UserSettingsPath
        {
            get { return GetAppDataPath() + "\\" + "DigiSlotMan\\"; }
        }

        private static string GetAppDataPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
    }
}
