using System;

namespace AsyncRun.protocol.Game.ACK
{
    public class FLOOD_PACKET_BUFFER : ClinitProcess
    {
        public FLOOD_PACKET_BUFFER() : base(2575)
        {
        }
        public override byte[] Write()
        {
            byte[] bytes = new byte[300];
            send.WriteB(bytes);
            return Process();

        }
    }
}
