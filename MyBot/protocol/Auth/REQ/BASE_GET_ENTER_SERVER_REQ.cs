using AsyncRun.Model;

namespace AsyncRun.protocol.Auth.REQ
{
    public class BASE_GET_ENTER_SERVER_REQ : ReadPacket
    {
        public BASE_GET_ENTER_SERVER_REQ() : base()
        {

        }
        public override void Avoid()
        {
            int error = ReadD();
            if (error == 0)
            {
                if (LOAD.LoggerReceive && GetSession.INST().floodAccounts == false)
                    Logger.Receive($"{GetType().Name} [{error}]");
                if (flods)
                    Connection.INSTs().SocketClientGame();
 
                else
                {
                    Player p = Connection.INSTs().player;
                    if (p != null && p.AuthClient != null)
                    {
                        p.AuthClient.AskSocket();
                        p.AuthClient = null;
                    }
                    p = null;
                }
            }
        }
    }
}