namespace AsyncRun.protocol.Game.ACK
{
    public class LOBBY_GET_ROOMLIST_ACK : ClinitProcess
    {
        public LOBBY_GET_ROOMLIST_ACK() : base(3073)
        {

        }
        public override byte[] Write()
        {
            send.WriteH(0);
            return Process();
        }
    }
}
