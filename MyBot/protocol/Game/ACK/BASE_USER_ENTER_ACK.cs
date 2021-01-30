using System;

namespace AsyncRun.protocol.Game.ACK
{
    public class BASE_USER_ENTER_ACK : ClinitProcess
    {
        public BASE_USER_ENTER_ACK() : base(2579)
        {
        }
        public override byte[] Write()
        {
            send.WriteC((byte)(LOAD.USER.Length + 1));
            send.WriteS(LOAD.USER, LOAD.USER.Length + 1);
            send.WriteQ(player.ID);
            send.WriteC((byte)LOAD.CONNECTION);
            send.WriteB(player.ADDR);
            return Process();
        }
    }
}