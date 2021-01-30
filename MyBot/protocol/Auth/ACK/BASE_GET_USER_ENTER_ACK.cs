namespace AsyncRun.protocol.Auth.ACK
{
    public class BASE_GET_USER_ENTER_ACK : ClinitProcess
    {
        public BASE_GET_USER_ENTER_ACK() : base(2579)
        {
        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}