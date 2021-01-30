using AsyncRun.Enums;
using AsyncRun.protocol.Auth.ACK;

namespace AsyncRun.protocol.Auth.REQ
{
    public class BASE_CLIENT_URL_REQ : ReadPacket
    {
        public override void Avoid()
        {
            ReadD();
            ReadD();
            Regions r = (Regions) ReadD();
            string link = ReadS(256);
            Logger.Receive($"Link: {link} e Region: {r}");
            player.AuthClient.SendPacket(new BASE_CLIENT_URL_ACK().Write());
        }
    }
}
