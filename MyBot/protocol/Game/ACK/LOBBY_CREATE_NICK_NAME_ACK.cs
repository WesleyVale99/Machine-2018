namespace AsyncRun.protocol.Game.ACK
{
    public class LOBBY_CREATE_NICK_NAME_ACK : ClinitProcess
    {
        protected string NickName;
        public LOBBY_CREATE_NICK_NAME_ACK(string NickName) : base(3101)
        {
            this.NickName = NickName;
        }
        public override byte[] Write()
        {
            Connection.INSTs().player.nick = NickName;
            send.WriteC((byte)(NickName.Length + 1));
            send.WriteS(NickName, NickName.Length + 1);
            return Process();
        }
    }
}