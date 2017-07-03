﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Windows;

namespace GUI_1
{
    class Device
    {
        public string DeviceName { get; set; }
        public bool Authenticated { get; set; }
        public bool Connected { get; set; }
        public ushort Nap { get; set; }
        public uint Sap { get; set; }
        public DateTime LastSeen { get; set; }
        public DateTime LastUsed { get; set; }
        public bool Remembered { get; set; }
        public string DeviceType { get; set; }
        public object MacID { get; set; }

        public Device(BluetoothDeviceInfo device_info)
        {
            this.Authenticated = device_info.Authenticated;
            this.Connected = device_info.Connected;
            this.DeviceName = device_info.DeviceName;
            this.LastSeen = device_info.LastSeen;
            this.LastUsed = device_info.LastUsed;
            this.Nap = device_info.DeviceAddress.Nap;
            this.Sap = device_info.DeviceAddress.Sap;
            this.Remembered = device_info.Remembered;
            this.DeviceType = device_info.ClassOfDevice.Device.ToString();
            this.MacID = device_info.DeviceAddress;
        }

        public override string ToString()
        {
            return this.DeviceName;
        }
    }
}
