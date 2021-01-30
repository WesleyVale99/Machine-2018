namespace AsyncRun.Model
{
    public class ClanWork
    {
        static readonly ClanWork INTS = new ClanWork();
        public static ClanWork ITNs() => INTS;
        public int clan_id;
        public string nome;
        public string info;
        public string Notice;
        public int clanDate;
        public int lengthName, lengthInfo, lengthNotice;
    }
}
