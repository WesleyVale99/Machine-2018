using AsyncRun.Enums;
using AsyncRun.Model;
using AsyncRun.protocol.Game.ACK;

namespace AsyncRun.protocol.Game.REQ
{
    public class BASE_CHANNEL_ANNOUNCE_REQ : ReadPacket
    {
        public GetSession get = GetSession.INST();
        public BASE_CHANNEL_ANNOUNCE_REQ() : base()
        {
        }
        public override void Avoid()
        {
            player.channelId =  (Exception_Channel_Type) ReadD();
            if (player.channelId >= Exception_Channel_Type.Channel_1 && player.channelId <= Exception_Channel_Type.Channel_9)
            {
                short length = ReadU();
                get.channelAnnounce = LOAD.CLIENTE[2] >= 34 ? ReadUS(length) : ReadS(length);
                LoggerXML.Log($"[ANNOUNCE SERVER]{get.channelAnnounce}", "Anuncio");
                if (LOAD.LoggerReceive)
                    Logger.Receive($"{GetType().Name} [{  player.channelId }]");
                Logger.Sucess($"Entrou no canal {  player.channelId }.");
                if (flods)
                    clientGame.SendPacket(new LOBBY_ENTER_ACK().Write());
            }
            else
            {
                Logger.Error($"{GetType().Name} [{  player.channelId }]");
            }
        }
    }
}