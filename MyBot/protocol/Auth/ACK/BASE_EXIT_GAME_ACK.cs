namespace AsyncRun.protocol.Auth.ACK
{
    public class BASE_EXIT_GAME_ACK : ClinitProcess
    {
        public BASE_EXIT_GAME_ACK() : base(2654)
        {
        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}