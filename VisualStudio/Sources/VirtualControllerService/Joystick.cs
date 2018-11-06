using System;
using System.Collections.Generic;
using Elreg.Log;
using Microsoft.DirectX.DirectInput;

namespace Elreg.VirtualControllerService
{
    public class Joystick
    {
        private readonly IntPtr _hWnd;
        private Device _joystickDevice;
        private JoystickState _state;

        public int Axes { get; set; }
        public Dictionary<int, bool> ButtonList { get; set; }
        public int Buttons { get; set; }
        public bool IsJoystickActiv { get; set; }
        public string Name { get; set; }
        public int Push { get; set; }
        public int Rz { get; set; }
        public int Views { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public delegate void OnDeviceChanged(bool found);

        public event OnDeviceChanged DeviceChanged;

        public static IEnumerable<string> FindDevices(IntPtr hWnd)
        {
            List<string> devices = new List<string>();

            try
            {
                DeviceList gameControllerList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);

                if (gameControllerList.Count > 0)
                {
                    foreach (DeviceInstance deviceInstance in gameControllerList)
                    {
                        Device joystickDevice = new Device(deviceInstance.InstanceGuid);
                        joystickDevice.SetCooperativeLevel(hWnd,
                                                           CooperativeLevelFlags.Background |
                                                           CooperativeLevelFlags.NonExclusive);
                        devices.Add(joystickDevice.DeviceInformation.InstanceName);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            return devices;
        }

        public Joystick(IntPtr hWnd, string deviceName)
        {
            _hWnd = hWnd;
            AcquireJoystick(deviceName);
        }

        private void AcquireJoystick(string name)
        {
            try
            {
                DeviceList gameControllerList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);
                bool found = false;
                // loop through the devices.
                foreach (DeviceInstance deviceInstance in gameControllerList)
                {
                    if (deviceInstance.InstanceName == name)
                    {
                        found = true;
                        IsJoystickActiv = true;
                        // create a device from this controller so we can retrieve info.
                        _joystickDevice = new Device(deviceInstance.InstanceGuid);
                        _joystickDevice.SetCooperativeLevel(_hWnd,
                            CooperativeLevelFlags.Background |
                            CooperativeLevelFlags.NonExclusive);
                        break;
                    }
                }

                if (!found)
                    return;

                _joystickDevice.SetDataFormat(DeviceDataFormat.Joystick);
                _joystickDevice.Acquire();

                // Find the capabilities of the joystick
                DeviceCaps cps = _joystickDevice.Caps;
                Axes = cps.NumberAxes;
                Buttons = cps.NumberButtons;
                Views = cps.NumberPointOfViews;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        public override string ToString()
        {
            if (!IsJoystickActiv)
                return "No joystick connected!";

            string data = "Name: " + Name + Environment.NewLine;
            data += "Axis: " + Axes + Environment.NewLine;
            data += "Buttons: " + Buttons + Environment.NewLine;
            data += "Views: " + Views;
            if (X != 0 || Y != 0 || Rz != 0 || Z != 0)
            {
                data += Environment.NewLine;
                data += "X-Axis: " + X + Environment.NewLine;
                data += "Y-Axis: " + Y + Environment.NewLine;
                data += "Z-Axis: " + Z + Environment.NewLine;
                data += "Rz-Axis: " + Rz + Environment.NewLine;
            }
            foreach (KeyValuePair<int, bool> button in ButtonList)
                data += "Button" + button.Key + ": " + button.Value + " ";
            return data;
        }

        public void UpdateData()
        {
            try
            {
                _joystickDevice.Poll();
                _state = _joystickDevice.CurrentJoystickState;
                OrderData();
            }
            catch
            {
                IsJoystickActiv = false;
                if (DeviceChanged != null)
                    DeviceChanged.Invoke(false);
            }
        }

        private void OrderData()
        {
            byte[] bButtons = _state.GetButtons();
            var lButtons = new Dictionary<int, bool>();

            for (int i = 0; i < Buttons; i++)
            {
                if (bButtons[i] >= 128)
                    lButtons.Add(i, true);
                else
                    lButtons.Add(i, false);
            }
            ButtonList = lButtons;

            //Axis
            X = _state.X;
            Y = _state.Y;
            Z = _state.Z;
            Rz = _state.Rz;
        }
    }
}
