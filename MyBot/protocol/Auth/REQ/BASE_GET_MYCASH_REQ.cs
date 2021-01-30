using AsyncRun.Model;
using AsyncRun.protocol.Auth.ACK;


namespace AsyncRun.protocol.Auth.REQ
{
    public class BASE_GET_MYCASH_REQ : ReadPacket
    {
        public BASE_GET_MYCASH_REQ() : base()
        {
        }
        public override void Avoid()
        {
            ReadD();
            int gold = ReadD();
            int cash = ReadD();
            if (LOAD.LoggerReceive && GetSession.INST().floodAccounts == false)
                Logger.Receive($"{GetType().Name} Gold: [{gold}; Cash: {cash}]");
        }
    }
}