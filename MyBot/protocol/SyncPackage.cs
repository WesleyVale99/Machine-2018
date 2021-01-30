using AsyncRun.protocol.Game.REQ;
using AsyncRun.protocol.Auth.REQ;
using System;
using System.IO;
using System.Threading;

namespace AsyncRun.protocol
{
    public class SyncPackage
    {
        public ReadPacket read;
        public SyncPackage()
        {
        }
        static readonly SyncPackage INSTANCE = new SyncPackage();
        public static SyncPackage INST() => INSTANCE;
        public void GetPacketAuth(AuthClient AuthClient, byte[] data)
        {
            try
            {
                lock (this)
                {
                    BinaryReader reader = new BinaryReader(new MemoryStream(data));
                    ushort opcode = reader.ReadUInt16();
                    switch (opcode)
                    {
                        case 514 : read = new BASE_UNK_REQ(); break;
                        case 529: read = new BASE_USER_GIFT_LIST_REQ(); break;
                        case 545 : read = new BASE_GET_MYCASH_REQ(); break;
                        case 2049: read = new Auth.REQ.BASE_GET_SCHANNEL_LIST_REQ(); break;
                        case 2062: read = new BASE_GET_LOGIN_ERROR_REQ(); break;
                        case 2564: read = new BASE_GET_LOGIN_REQ(); break;
                        case 2566: read = new BASE_GET_MYINFO_REQ(); break;
                        case 2578: read = new BASE_GET_ENTER_SERVER_REQ(); break;
                        case 2694: read = new BASE_CLIENT_URL_REQ(); break;
                        case 2699: read = new BASE_INVENTORY_REQ(); break;
                    }
                    if (read != null)
                    {
                        read.SetReader(AuthClient, null, reader, data);
                        new Thread(new ThreadStart(read.Run)).Start();
                        read = null;
                    }
                    else
                    {
                        if (opcode.ToString().Length == 3 || opcode.ToString().Length == 4)
                        {
                            if(Loader.INTs().LoggerReceive)
                                Logger.Receive("Opcodes: " + opcode.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
        public void GetPacketGame(GameClient clientgame, byte[] data)
        {
            try
            {
                lock (this)
                {
                    BinaryReader reader = new BinaryReader(new MemoryStream(data));
                    ushort opcode = reader.ReadUInt16();
                    switch (opcode)
                    {
                        case 274 : read = new FRIEND_INFO_REQ(); break;
                        case 1311: read = new CLAN_CREATE_REQ(); break;
                        case 2049: read = new Game.REQ.BASE_GET_SCHANNEL_LIST_REQ(); break;
                        case 2055: read = new SERVER_MESSAGE_ANNOUNCE_REQ();break;
                        case 2580: read = new BASE_USER_ENTER_REQ(); break;
                        case 2574: read = new BASE_CHANNEL_ANNOUNCE_REQ(); break;
                        case 2645: read = new BASE_CHANNEL_PASSWRD_REQ(); break;
                        case 2822: read = new LOBBY_SHOP_LIST_REQ(); break;
                        case 3047: read = new LOBBY_GET_ROOMLIST_REQ(); break;
                        case 3080: read = new LOBBY_ENTER_REQ(); break;
                        case 3090: read = new BASE_CREATE_ROOM_REQ(); break;
                        case 3093: read = new LOBBY_CHATTING_REQ(); break;
                        case 3102: read = new LOBBY_CREATE_NICK_NAME_REQ(); break;
                        case 3851: read = new BASE_CHAT_ROOM_REQ(); break;
                        case 3855: read = new ROOM_GET_LOBBY_USER_LIST_REQ(); break;
                    }
                    if (read != null)
                    {
                        read.SetReader(null, clientgame, reader, data);
                        new Thread(new ThreadStart(read.Run)).Start();
                        read = null;
                    }
                    else
                    {
                        if (opcode.ToString().Length == 3 || opcode.ToString().Length == 4)
                        {
                            if (Loader.INTs().LoggerReceive)
                                Logger.Receive("Opcodes: " + opcode.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
    }
}