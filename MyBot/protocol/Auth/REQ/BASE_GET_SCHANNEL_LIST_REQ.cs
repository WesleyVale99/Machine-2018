using AsyncRun.Model;
using AsyncRun.protocol.Auth.ACK;
using System.Net;

namespace AsyncRun.protocol.Auth.REQ
{
    public class BASE_GET_SCHANNEL_LIST_REQ : ReadPacket
    {
        GetSession s = GetSession.INST();
        public BASE_GET_SCHANNEL_LIST_REQ() : base()
        {
        }
        public override void Avoid()
        {
            s.sessionID = ReadD();
            IPAddress addr = new IPAddress(ReadB(4));
            short securityKey = ReadU();
            GetSession.INST().seed = ReadU();
            
            ReadB(10);
            byte value = ReadC();
            int serverSize = ReadD();
            player.ADDR = IPAddress.Parse(LOAD.fakeIP).GetAddressBytes();
            player.Encrypt = ((s.sessionID + securityKey) % 7) + 1;
            if (LOAD.LoggerReceive && GetSession.INST().floodAccounts == false)
            {
                Logger.Receive($"{GetType().Name} ClientID: [{ s.sessionID }];");
                Logger.Warnnig("ClientID: " + s.sessionID + " P.Encrypt: " + player.Encrypt);
            }
            for (int i = 0; i < serverSize; i++)
            {
                int actived = ReadD();
                IPAddress serverIp = new IPAddress(ReadB(4));
                ushort serverPort = ReadUH();
                byte serverType = ReadC();
                short serverMax = ReadU();
                int serverPlayers = ReadD();
                if (actived == 1 && i > 0)
                {
                    player.server = new IPEndPoint(serverIp, serverPort);
                    if (GetSession.INST().floodAccounts == false)
                    {
                        Logger.Warnnig($"SessionSeed: [{ GetSession.INST().seed}]");
                        Logger.Warnnig($"Jogadores Online: { serverPlayers}.");
                    }
                    AuthClient.SendPacket(new BASE_GET_LOGIN_ACK().Write());
                    break;
                }
            }
        }
    }
}