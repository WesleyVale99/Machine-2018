
namespace AsyncRun.protocol.Auth.ACK
{
    public class BASE_GET_CONFIG_ACK : ClinitProcess
    {
        public BASE_GET_CONFIG_ACK() : base(2567)
        { 
        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}