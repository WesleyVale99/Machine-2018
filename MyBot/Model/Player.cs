using AsyncRun.Enums;
using AsyncRun.protocol;
using System;
using System.Net;

namespace AsyncRun.Model
{
    public class Player : ICloneable
    {
        public long ID;
        public string nick;
        public int exp;
        public int rank;
        public int gold;
        public int cash;
        public PlayerACCESS acess;
        public byte revs;
        public Exception_Channel_Type channelId;
        public int roomId;
        public int Encrypt;
        public byte[] ADDR = new byte[4];
        public IPEndPoint server;
        public volatile AuthClient AuthClient;
        public volatile GameClient ClientGame;
        public object Clone() => MemberwiseClone();
    }
}