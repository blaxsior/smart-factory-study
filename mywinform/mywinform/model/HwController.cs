using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mywinform.model
{
    public class HwController
    {
        PlcData plcData;

        public HwController()
        {
            plcData = PlcData.Instance;
        }

        public void PutOne(int channel, bool value)
        {
            Debug.WriteLine($"write channel {channel}");
            if (value)
            {   // 비트열로 N번째 비트만 1인 것과 or
                plcData.FromPlc[0] |= (ushort)(1 << channel);
            }
            else
            {   // 비트열로 N번째 비트 빼고 1인 것과 and
                plcData.FromPlc[0] &= (ushort)~(1 << channel);
            }
        }

        public bool GetOne(int channel)
        {
            Debug.WriteLine($"read channel {channel}");
            return ((plcData.ToPlc[0] & (ushort)(1 << channel)) != 0);
        }
    }
}
