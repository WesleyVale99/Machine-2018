namespace AsyncRun.protocol.Auth.ACK
{
    public class BASE_INVENTORY_ACK : ClinitProcess
    {
        public BASE_INVENTORY_ACK() : base(2698)
        {
        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}
