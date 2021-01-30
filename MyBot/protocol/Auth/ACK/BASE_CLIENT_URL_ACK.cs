namespace AsyncRun.protocol.Auth.ACK
{
    public class BASE_CLIENT_URL_ACK : ClinitProcess
    {
        public BASE_CLIENT_URL_ACK() : base(2695)
        {
        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}
