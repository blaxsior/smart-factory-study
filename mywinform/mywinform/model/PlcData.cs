using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mywinform.model
{
    internal class PlcData
    {
        private ushort[] toPlc;
        private ushort[] fromPlc;

        private PlcData()
        {
            toPlc = new ushort[100];
            fromPlc = new ushort[100];
        }

        private static PlcData? _instance;
        public static PlcData Instance {
            get
            {
                if( _instance == null )
                {
                    _instance = new PlcData();
                }
                return _instance;
            }
        }

        public ushort[] ToPlc
        {
            get { return toPlc; }
            set { toPlc = value; }
        }

        public ushort[] FromPlc
        {
            get { return fromPlc; }

            set { fromPlc = value; }
        }
    }
}
