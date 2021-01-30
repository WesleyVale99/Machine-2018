using System;

namespace AsyncRun.Model
{
    public class Room
    {
        static readonly Room INTS = new Room();

        static Random random = new Random();
        //public int RoomID = random.Next(0, 50);
        public string Name;
        public short Map; //MSTATION
        public byte stage4v4; //Supressão 4x4
        public byte Type; //DEATH MATCH
        public int slots; // 16slots
        public byte Allweapons;
        public byte randomMap;
        public byte special = 0;
        public int killMask;
        public byte seeConf;
        public short balanceamento;
        public string pass;
        public byte Count = 8; // BOTS
        public byte Level = 10; //LEVEL BOTS

        public static Room ITNs() => INTS;
    }
}
