using AsyncRun.Enums;
using AsyncRun.Model;
using AsyncRun.protocol.Auth.ACK;

namespace AsyncRun.protocol.Auth.REQ
{
    public class BASE_GET_LOGIN_REQ : ReadPacket
    {
        public BASE_GET_LOGIN_REQ() : base()
        {
        }
        public override void Avoid()
        {
            LoginAcess result = (LoginAcess) ReadD();
            ReadC();
            player.ID = ReadQ();
            string login = ReadS(ReadC());
            ReadC();
            ReadC();
            if (LOAD.LoggerReceive && GetSession.INST().floodAccounts == false)
                Logger.Receive($"{GetType().Name} [{result}; SEU ID: {player.ID}]");

            if (result != LoginAcess.LOGIN_SUCESSO && result != LoginAcess.LOGIN_SUCESSO_ACEITO && AuthClient != null)
                Logger.Error("Erro ao logar: " + result + ";");

            if (result == LoginAcess.LOGIN_SUCESSO || result == LoginAcess.LOGIN_SUCESSO_ACEITO)
            {
                AuthClient.SendPacket(new BASE_GET_MYINFO_ACK().Write());
                GetSession.INST().byPass = true;
            }

        }
    }
}