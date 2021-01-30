using AsyncRun.Enums;
using AsyncRun.protocol;
using System;

namespace AsyncRun
{
    public class Loader : LoadingFile
    {
        static readonly Loader INTS = new Loader();
        public static Loader INTs()
        {
            return INTS;
        }

        //STRINGS
        public string USER = "WesleyDoMal";
        public string PASS = "92403944";
        public string IP;
        public string meuMac;
        public string FILELISTDAT;
        public string fakeIP;
        public string HARDWAREID;
        public string CLIENTEVERSION;

        //int
        public int IPINDEX = 3;
        public int InternalMilisegundos;
        public int Encoding;

        //bool
        public bool HARDWAREIDConfig;
        public bool MacWesley;
        public bool AutoCreate;
        public bool MASKIP = true;
        public bool DEBUG;
        public bool LoggerReceive;


        // byte, byte[], ushort and ulong
        public Connection_type CONNECTION;
        public byte[] CLIENTE = new byte[3];
        public ushort PORT = 39190;
        public ulong KEY = 0;
        public Regions region;


        //GET CONFIG
        public Loader() : base("BOT_Config//BOT_Config.ini")
        {
        }
        public void Run()
        {
            if (list.Count > 0)
                Load();

            //int byte and Ulong
            //IPINDEX = int.Parse(Get("idx"));
            KEY = ulong.Parse(Get("LauncherKey"));
            InternalMilisegundos = int.Parse(Get("Seconds"));
            CONNECTION = (Connection_type) byte.Parse(Get("Connection"));
            region = (Regions) byte.Parse(Get("Localidade"));
            Encoding = int.Parse(Get("Encoding"));



            //strings
            IP = Get("IP");
            //fakeIP = $"164.{new Random().Next(0, 100)}.1.0";
            fakeIP = "127.0.0.1";

            //FUNÇÃO CLIENT 
            for (int i = 0; i < CLIENTE.Length; i++)
                CLIENTE[i] = byte.Parse((CLIENTEVERSION = Get("Version")).Split('.')[i]);

            //bool
            MacWesley = bool.Parse(Get("Mac"));
            AutoCreate = bool.Parse(Get("AutoCreate"));
            DEBUG = bool.Parse(Get("Debug"));
            LoggerReceive = bool.Parse(Get("Logger"));
            HARDWAREIDConfig = bool.Parse(Get("Hwid"));

            //userfilelist
            FILELISTDAT = Util.GetHashFile("BOT_Config//UserFileList.dat");

            //RANDOMstrings
            if (AutoCreate)
            {
                USER += string.Concat(new Random().Next(0, 1000));
                PASS += string.Concat(new Random().Next(0, 1000));
            }

            //if
            if (MacWesley)
                meuMac = "5C:C9:D3:7B:DD:CA";// Mac Henrique = 00:30:67:1F:CE:3C  //Mac Uzu 7A:79:19:04:3B:DE // MAC WESLEY FIX MY SERVERS EDITED // 5C:C9:D3:7B:DD:CA
            else
                meuMac = "7A:79:19:04:3B:D1";

            if (HARDWAREIDConfig)
                HARDWAREID = Util.MyHwid();
            else
            {
                HARDWAREID = "Me Respita Novatinhos, Aqui é o Wesley Mais conhecido como, come seu cu!";
            }

            //ChannelPasswrd = get("ChannelPasswrd");
        }
    }
}