using System;

namespace AsyncRun.protocol.Game.REQ
{
    public class LOBBY_SHOP_LIST_REQ : ReadPacket
    {
        public override void Avoid()
        {
            int Date = ReadD();
            if (LOAD.LoggerReceive) { Logger.Receive($"{GetType().Name}; Date: {Date}"); }
          //  Commands.LiberacaoChat();
        }
    }
}
