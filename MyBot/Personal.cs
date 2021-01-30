using System.Management;

namespace AsyncRun
{
    public class Personal
    {
        public string _MAC;
        public string _IP;
        public string _HardWarePC;
        public string HardWarePC => _HardWarePC;
        public string Mac => _MAC;

        public string IP => _IP;

        public Personal()
        {
            //IP
            ManagementObjectSearcher ObjMOS = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
            ManagementObjectCollection ObjMOC = ObjMOS.Get();

            //HWID
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in ObjMOC)
            {
                string[] addresses = (string[])mo["IPAddress"];
                _IP = addresses[0];
                _MAC = addresses[1];
                break;
            }
            foreach (ManagementObject mo in moc)
            {
                string HardWarePC = mo.Properties["processorID"].Value.ToString();
                _HardWarePC = HardWarePC;
                mc.Dispose();
                break;
            }
        }
        static readonly Personal INTS = new Personal();
        public static Personal INTs() => INTs();
    }
}

