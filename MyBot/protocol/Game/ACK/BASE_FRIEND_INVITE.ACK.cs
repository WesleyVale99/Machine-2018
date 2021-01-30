using AsyncRun.Model;

namespace AsyncRun.protocol.Game.ACK
{
    public class BASE_FRIEND_INVITE : ClinitProcess
    {
        public string name;
		public BASE_FRIEND_INVITE(string name) : base(282)
        {
            this.name = name;
        }
        public override byte[] Write()
        {
            send.WriteS(name, 33);
            return Process();
        }
    }
}
