using System;
using System.IO;
using System.Management;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;

namespace AsyncRun.protocol
{
    public static class Util
    {
        public static char[] HEX_DIGITS = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        //public static string toHexString(byte[] array, int offset, int length)
        //{
        //    char[] buf = new char[length * 2];
        //    int bufIndex = 0;
        //    for (int i = offset; i < offset + length; i++)
        //    {
        //        byte b = array[i];
        //        buf[bufIndex++] = HEX_DIGITS[(b >> 4) & 15];
        //        buf[bufIndex++] = HEX_DIGITS[b & 15];
        //    }
        //    return new string(buf);
        //}
        public static void IniciarThead(ThreadStart start) => NewDelegate(new Thread(new ThreadStart(start)));
        public static void NewDelegate(Thread thread)
        {
            try
            {
                thread.Start(); //APRENDE COM O HENRIQUEEEEEEEEE 
            }
            catch
            {
                thread.Abort();
                thread.Interrupt();
                thread = null;
            }
        }
        public static T Clone<T>(T obj)
        {
            Type type = obj.GetType();
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var cloned = Activator.CreateInstance(type);
            for (int i = 0; i < fields.Length; i++)
                fields[i].SetValue(cloned, fields[i].GetValue(obj));
            return (T)cloned;
        }
        //public static T DeepClone<T>(T a)
        //{
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        formatter.Serialize(stream, a);
        //        stream.Position = 0;
        //        return (T)formatter.Deserialize(stream);
        //    }
        //}
        //public static string MyMAC()
        //{
        //    ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        //    ManagementObjectCollection moc = mc.GetInstances();
        //    string MACAddress = string.Empty;
        //    foreach (ManagementObject mo in moc)
        //    {
        //        if (MACAddress == string.Empty)
        //        {
        //            if ((bool)mo["IPEnabled"])
        //                MACAddress = mo["MacAddress"].ToString();
        //        }
        //        mo.Dispose();
        //    }
        //    mc.Dispose();
        //    return MACAddress;
        //}
        public static string MyHwid()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            string Id = string.Empty;
            foreach (ManagementObject mo in moc)
            {
                Id = mo.Properties["processorID"].Value.ToString();
                mo.Dispose();
                break;
            }
            mc.Dispose();
            return Id;
        }
        //public static string MyIPv()
        //{
        //    //5 - IP
        //    //6 - Hamachi
        //    string nome = Dns.GetHostName();
        //    IPAddress[] ip = Dns.GetHostAddresses(nome);
        //    return ip[5].ToString();
        //}
        public static string GetHashFile(string fileName)
        {
            string str = string.Empty;
            if (File.Exists(fileName) && fileName != string.Empty && fileName.Length != 0)
            {
                using (FileStream FS = File.OpenRead(fileName))
                {
                    str = BitConverter.ToString((new MD5CryptoServiceProvider()).ComputeHash(FS)).Replace("-", string.Empty);
                    FS.Flush();
                    FS.Close();
                }
            }
            return str;
        }
        public static void Close(BinaryReader reader)
        {
            try
            {
                if (reader != null)
                {
                    if (reader.BaseStream != null)
                        reader.BaseStream.Close();
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static byte[] Encrypt(byte[] buffer, int shift)
        {
            int length = buffer.Length;
            byte first = buffer[0];
            byte current;
            for (int i = 0; i < length; i++)
            {
                if (i >= (length - 1))
                    current = first;
                else
                    current = buffer[i + 1];
                buffer[i] = (byte)(current >> (8 - shift) | (buffer[i] << shift));
            }
            return buffer;
        }
        //public static byte[] Decrypt(byte[] data, int shift)
        //{
        //    byte lastElement = data[data.Length - 1];
        //    for (int i = data.Length - 1; i > 0; --i)
        //        data[i] = (byte)(((data[i - 1] & 255) << (8 - shift)) | ((data[i] & 255) >> shift));
        //    data[0] = (byte)((lastElement << (8 - shift)) | ((data[0] & 255) >> shift));
        //    return data;
        //}
    }
}