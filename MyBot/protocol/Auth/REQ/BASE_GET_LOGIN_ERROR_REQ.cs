using AsyncRun.Enums;
using AsyncRun.Model;

namespace AsyncRun.protocol.Auth.REQ
{
    public class BASE_GET_LOGIN_ERROR_REQ : ReadPacket
    {
        public BASE_GET_LOGIN_ERROR_REQ() : base()
        {
        }
        public override void Avoid()
        {
            int mask = ReadD();
            LoginAcess error = (LoginAcess) ReadD();
            int unk = ReadD();
            if (LOAD.LoggerReceive && GetSession.INST().floodAccounts == false)
                Logger.Receive($"{GetType().Name} Mask: [{mask} ;Error: {error}]");
            if (AuthClient != null || error != 0)
                AuthClient.AskSocket();
        }
    }
}