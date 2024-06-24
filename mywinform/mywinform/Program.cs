using mywinform.model;

namespace mywinform
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //PlcComm plcComm = new PlcComm();
            ModbusServer modbusServer = new ModbusServer();
            //PlcComm plcComm = new PlcComm();

            HwController hwController = new HwController();
            Conveyor conveyor = new Conveyor(hwController);

            //Application.Run(new Form1(plcComm, modbusServer));
            Application.Run(new Form2(conveyor, modbusServer));
        }
    }
}