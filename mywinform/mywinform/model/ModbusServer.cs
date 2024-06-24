using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace mywinform.model
{
    public class ModbusServer
    {
        //연결 여부
        public bool IsConnected
        {
            get; protected set;
        }
        PlcData plcData;
        Thread thread;


        public ModbusServer()
        {
            plcData = PlcData.Instance;
            thread = new Thread(ThreadFunc);
            thread.IsBackground = true;
            thread.Start();
        }

        private void ThreadFunc()
        {
            byte[] recv = new byte[512];
            byte[] send = new byte[512];

            // 
            IPAddress addr = IPAddress.Parse("127.0.0.1");
            int port = 505; // 기본 Modbus Port는 502

            TcpListener tcpListener = new TcpListener(addr, port);
            tcpListener.Start();

            while (true)
            {
                Debug.WriteLine("hello");
                using TcpClient tc = tcpListener.AcceptTcpClient();
                NetworkStream stream = tc.GetStream();

                while (stream.Read(recv, 0, recv.Length) > 0)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        send[i] = recv[i];
                    }

                    switch (recv[7]) // Function Code
                    {
                        case 4: // Modbus -> Simulator
                            send[8] = (byte)160;
                            for (int i = 0; i < 80; i++)
                            {
                                send[9 + (i * 2)] = (byte)(plcData.FromPlc[i] / 256);
                                send[10 + (i * 2)] = (byte)(plcData.FromPlc[i] % 256);
                            }
                            stream.Write(send, 0, 169);
                            break;
                        case 16: // Simulator -> Modbus
                            for (int i = 0; i < 4; i++)
                            {
                                send[8 + i] = recv[8 + i];
                            }
                            stream.Write(send, 0, 12);
                            for (int i = 0; i < 80; i++)
                            {
                                plcData.ToPlc[i] = (ushort)((recv[13 + i * 2] << 8) | recv[14 + i * 2]);
                            }
                            break;

                    }
                    Debug.WriteLine("Modbus Server Running");
                    Thread.Sleep(100);
                }
            }
        }
    }
}
