using System;

namespace AsyncRun.protocol.Game.REQ
{
    public class FRIEND_INFO_REQ : ReadPacket
    {
        public override void Avoid()
        {
            if (LOAD.LoggerReceive) Logger.Receive($"{GetType().Name} [{ReadC()}]");
        }
    }
}