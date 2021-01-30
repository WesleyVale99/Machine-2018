namespace AsyncRun.protocol.Auth.ACK
{
    public class BASE_GET_ENTER_SERVER_ACK : ClinitProcess
    {
        public BASE_GET_ENTER_SERVER_ACK() : base(2577)
        {
        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}