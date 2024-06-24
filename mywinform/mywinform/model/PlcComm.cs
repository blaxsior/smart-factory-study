using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XIMUTILLib;

namespace mywinform.model
{
    public class PlcComm : IDisposable
    {
        DeviceInterface deviceInterface;
        PlcData data;
        System.Windows.Forms.Timer timer;
        public bool IsConnected
        {
            get;
            protected set;
        }


        public PlcComm()
        {
            deviceInterface = new DeviceInterface();
            data = PlcData.Instance;
            timer = new System.Windows.Forms.Timer();
            // 100ms마다 수행
            timer.Interval = 100;
            timer.Enabled = true;
            // Tick 처리
            timer.Tick += OnTimerTick; 
            IsConnected = false;
        }

        private int step = 0;
        private void OnTimerTick(object? sender, EventArgs e)
        {
            if(IsConnected)
            {
                switch(step)
                {
                    case 0:
                        ReadWord();
                        break;
                    case 1:
                        writeWord();
                        break;
                }
            }

            step = (step + 1) % 2;
        }

        public void Connect()
        {
            if (IsConnected) return;
            deviceInterface.Connect();
            IsConnected = true;
        }

        public void Disconnect()
        {
            IsConnected = false;
        }

        public void Dispose()
        {
            Disconnect();
        }

        public void ReadWord() // 100 ~ 199
        {
            byte[] buf = new byte[200];
            deviceInterface.ReadDevice("D", 200, 200, ref buf[0]);
            for (int i = 0; i < 100; i++)
            {
                data.FromPlc[i] = (ushort)((buf[i * 2 + 1] << 8) | buf[i * 2]);
            }

        }

        public void writeWord() // 0 ~ 99
        {
            byte[] buf = new byte[200];
            for (int i = 0; i < 100; i++)
            {
                buf[i * 2] = (byte)(data.ToPlc[i] & 0xFF);
                buf[i * 2 + 1] = (byte)(data.ToPlc[i] >> 8);
            }

            deviceInterface.WriteDevice("D", 0, 200, ref buf[0]);
        }
    }
}
