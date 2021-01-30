using AsyncRun.protocol.Game.ACK;

namespace AsyncRun.protocol.Game.REQ
{
    public class BASE_CHANNEL_PASSWRD_REQ : ReadPacket
    {

        public BASE_CHANNEL_PASSWRD_REQ() : base()
        {
        }
        public override void Avoid()
        {
            int error = ReadD();
            if (error == 0 || error == 1)
            {
                Logger.Sucess("Senha correta.");
                clientGame.SendPacket(new BASE_USER_ENTER_ACK().Write());
            }
            else
            {
                Logger.Error("Senha Incorreta.");
                clientGame.SendPacket(new BASE_CHANNEL_PASSWRD_ACK().Write());
            }
            if (LOAD.LoggerReceive)
                Logger.Receive($"{GetType().Name},{error}");
        }
    }
}
