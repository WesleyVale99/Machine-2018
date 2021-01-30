using AsyncRun.Model;
using AsyncRun.protocol.Auth.ACK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncRun.protocol.Auth.REQ
{
    public class BASE_USER_GIFT_LIST_REQ : ReadPacket
    {
        public override void Avoid()
        {
           int date = ReadD();
            ReadD();
            int error = ReadD();
            if (error == 0)
                player.AuthClient.SendPacket(new BASE_USER_GIFTLIST_ACK().Write());
            if (GetSession.INST().floodAccounts == false)
                Logger.Receive($"{GetType().Name}, {error}");

        }
    }
}
