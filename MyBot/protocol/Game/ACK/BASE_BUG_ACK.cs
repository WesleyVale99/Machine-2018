using System;

namespace AsyncRun.protocol.Game.ACK
{
    public class BASE_BUG_ACK : ClinitProcess
    {
        public BASE_BUG_ACK() : base(2583)
        {
        }
        public override byte[] Write()
        {
            send.WriteB(BitConverter.GetBytes(new Random().Next(0, int.MaxValue)));
            return Process();
        }
    }
}
