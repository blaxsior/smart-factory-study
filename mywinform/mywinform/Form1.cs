using mywinform.model;
using System.Data;
using System.Diagnostics;

namespace mywinform
{
    public partial class Form1 : Form
    {
        PlcComm plcComm;
        PlcData plcData;
        ModbusServer modbusServer;

        DataTable dtToPlc;
        DataTable dtFromPlc;
        public Form1(PlcComm plcComm, ModbusServer modbusServer)
        {
            InitializeComponent();

            plcData = PlcData.Instance;
            this.plcComm = plcComm;
            this.modbusServer = modbusServer;
            initDataTables();
        }

        private void initDataTables()
        {
            // 0 ~ 100
            dtToPlc = new DataTable("D0000");
            dtToPlc.Columns.Add("Address", typeof(string));
            dtToPlc.Columns.Add("Value", typeof(ushort));
            for (int i = 0; i < 100; i++)
            {
                dtToPlc.Rows.Add($"D{i:D4}", plcData.ToPlc[i]);
            }

            dataGridView1.DataSource = dtToPlc;

            // 100 ~ 199
            dtFromPlc = new DataTable("D0100");
            dtFromPlc.Columns.Add("Address", typeof(string));
            dtFromPlc.Columns.Add("Value", typeof(ushort));
            for (int i = 0; i < 100; i++)
            {
                dtFromPlc.Rows.Add($"D{i + 100:D4}", plcData.FromPlc[i]);
            }

            dataGridView2.DataSource = dtFromPlc;

        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("connect clicked");
            plcComm.Connect();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("disconnect clicked");
            plcComm.Disconnect();
        }


        private int step = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (step == 0)
            {
                //Debug.WriteLine("D0000");
                for (int i = 0; i < 100; i++)
                {
                    dtFromPlc.Rows[i]["Value"] = plcData.FromPlc[i];
                }
            }
            else if (step == 1)
            {
                //Debug.WriteLine("D0100");
                for (int i = 0; i < 100; i++)
                {
                    dtToPlc.Rows[i]["Value"] = plcData.ToPlc[i];
                }
            }
            step = (step + 1) % 2;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int address);
            ushort.TryParse(textBox2.Text, out ushort value);

            if (address < 0 || address >= 100) return;

            plcData.ToPlc[address] = value;
        }
    }
}
