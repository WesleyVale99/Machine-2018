namespace AsyncRun.protocol.Auth.ACK
{
    public class BASE_GET_MYINFO_ACK : ClinitProcess
    {
        public BASE_GET_MYINFO_ACK() : base(2565)
        {
        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}