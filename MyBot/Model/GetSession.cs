using System.Collections.Generic;

namespace AsyncRun.Model
{
    public class GetSession
    {
        public List<string> playerlobby = new List<string>();
        public int seed, countPlayer;
        public int sessionID;

        public bool PleaseWait;
        public bool floodAccounts = false;
        public bool byPass = false;
        public bool Process = true;
        public string channelAnnounce, name;


        public int GetNextSessionSeed()
        {
            seed = (ushort)((((seed * 214013) + 2531011) >> 16) & 0x7FFF);
            return seed;
        }
        static readonly GetSession INSTANCE = new GetSession();
        public static GetSession INST() => INSTANCE;
    }
}
