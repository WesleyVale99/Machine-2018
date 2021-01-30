using System;
namespace AsyncRun.protocol.Auth.ACK
{
    public class BASE_GET_SOURCE_ACK : ClinitProcess
    {
        public BASE_GET_SOURCE_ACK() : base(2678)
        {
        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}