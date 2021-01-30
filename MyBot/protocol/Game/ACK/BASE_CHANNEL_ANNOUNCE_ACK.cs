namespace AsyncRun.protocol.Game.ACK
{
    public class BASE_CHANNEL_ANNOUNCE_ACK : ClinitProcess
    {
        public int channelId;
        public BASE_CHANNEL_ANNOUNCE_ACK(int channelId) : base(2573)
        {
            this.channelId = channelId;
        }
        public override byte[] Write()
        {
            send.WriteD(channelId);
            return Process();
        }
    }
}