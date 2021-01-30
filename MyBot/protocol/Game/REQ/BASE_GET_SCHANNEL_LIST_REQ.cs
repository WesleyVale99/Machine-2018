using AsyncRun.Enums;
using AsyncRun.Model;
using AsyncRun.protocol.Game.ACK;
using System.Net;


namespace AsyncRun.protocol.Game.REQ
{
    public class BASE_GET_SCHANNEL_LIST_REQ : ReadPacket
    {
        public override void Avoid()
        {
            int clientId = ReadD();
            IPAddress addr = new IPAddress(ReadB(4));
            short securityKey = ReadU();
            GetSession.INST().seed = ReadU();
            ReadB(10);
            byte value = ReadC();
            int serverSize = ReadD();
            player.ADDR = IPAddress.Parse(LOAD.fakeIP).GetAddressBytes();
            player.Encrypt = ((clientId + securityKey) % 7) + 1;
            if (LOAD.LoggerReceive)
                Logger.Receive($"{GetType().Name} [{clientId};{addr.ToString()};{securityKey};");
            for (int i = 0; i < serverSize; i++)
            {
                int actived = ReadD();
                IPAddress serverIp = new IPAddress(ReadB(4));
                ushort serverPort = ReadUH();
                Exception_Servers_Type serverType = (Exception_Servers_Type) ReadC();
                short serverMax = ReadU();
                int serverPlayers = ReadD();
                if (serverType == Exception_Servers_Type.Server_Championship)
                {
                    Logger.Sucess($"o ChannelType é {serverType}");
                    Logger.Error("o Servidor: " + i + " está com senha...");
                    clientGame.SendPacket(new BASE_CHANNEL_PASSWRD_ACK().Write());
                    break;
                }
                if (serverType != Exception_Servers_Type.Server_Championship)
                {
                    Logger.Sucess($"o ChannelType é {serverType}");
                    Logger.Warnnig($"SessionSeed: [{GetSession.INST().seed}]");
                    clientGame.SendPacket(new BASE_USER_ENTER_ACK().Write());
                    break;
                }
            }
        }
    }
}