using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncRun.protocol.Auth.ACK
{
    public class BASE_USER_GIFTLIST_ACK : ClinitProcess
    {
        public BASE_USER_GIFTLIST_ACK() : base (528)
        {

        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}
