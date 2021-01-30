namespace AsyncRun.protocol.Game.ACK
{
    public class ROOM_GET_LOBBY_USER_LIST_ACK : ClinitProcess
    {
        public ROOM_GET_LOBBY_USER_LIST_ACK() : base(3854)
        {
        }
        public override byte[] Write()
        {
            return Process();
        }
    }
}
