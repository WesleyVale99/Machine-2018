using AsyncRun.Enums;
using AsyncRun.Model;
using AsyncRun.protocol.Auth.ACK;
namespace AsyncRun.protocol.Auth.REQ
{
    public class BASE_GET_MYINFO_REQ : ReadPacket
    {
        public BASE_GET_MYINFO_REQ() : base()
        {
        }
        public override void Avoid()
        {
            int error = ReadD();
            if (error > 1)
                Logger.Error("[ERROR] - Buscar informação do Usuario.");
            else
            {
                player.revs = ReadC();
                player.nick = ReadS(33);
                player.exp = ReadD();
                player.rank = ReadD();
                ReadD();
                player.gold = ReadD();
                player.cash = ReadD();
                ReadB(16);
                player.acess = (PlayerACCESS) ReadC();
                ReadB(161);
                if (GetSession.INST().floodAccounts == false)
                {
                    Logger.Info("[Async Templates]: Revision   : [" + player.revs +  "]");
                    Logger.Info("[Async Templates]: Nickname   : [" + player.nick + " ]");
                    Logger.Info("[Async Templates]: Experiencia: [" + player.exp + "  ]");
                    Logger.Info("[Async Templates]: Patente    : [" + player.rank + " ]");
                    Logger.Info("[Async Templates]: Dinheiro   : [" + player.cash + " ]");
                    Logger.Info("[Async Templates]: Ouro       : [" + player.gold + " ]");
                    Logger.Info("[Async Templates]: Acesso     : [" + player.acess + "]");
                }

                if (LOAD.LoggerReceive && GetSession.INST().floodAccounts == false)
                    Logger.Receive($"{GetType().Name} [{player.nick};{player.exp};{player.rank};{ player.acess };{player.revs};]");
            }
            AuthClient.SendPacket(new BASE_GET_SOURCE_ACK().Write());
            AuthClient.SendPacket(new BASE_GET_CONFIG_ACK().Write());
            AuthClient.SendPacket(new BASE_GET_ENTER_SERVER_ACK().Write());
        }
    }
}