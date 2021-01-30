namespace AsyncRun.protocol.Game.ACK
{
    public class LOBBY_ENTER_ACK : ClinitProcess
    {
        public LOBBY_ENTER_ACK() : base(3079)
        {
        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}