using AsyncRun.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncRun.protocol.Game.ACK
{
    public class LOBBY_SHOP_LIST_ACK : ClinitProcess
    {
        public LOBBY_SHOP_LIST_ACK() : base(2821)
        {
        }
        public override byte[] Write()
        {
            send.WriteD(0);
            return Process();
        }
    }
}