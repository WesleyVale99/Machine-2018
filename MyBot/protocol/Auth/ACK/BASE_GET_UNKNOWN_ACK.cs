using AsyncRun.Model;
using System;
using System.Linq;

namespace AsyncRun.protocol.Auth.ACK
{
    public class BASE_GET_UNKNOWN_ACK : ClinitProcess
    {
        public static byte[] Buffer = new byte[6]; //MAC
        public BASE_GET_UNKNOWN_ACK() : base(517)
        {
        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}