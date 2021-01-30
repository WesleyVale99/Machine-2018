using AsyncRun.Model;
using AsyncRun.protocol;

namespace AsyncRun.protocol.Game.ACK
{
    public class CLAN_CREATE_ACK : ClinitProcess
    {
        public ClanWork c;
        public CLAN_CREATE_ACK(ClanWork c) : base(1310)
        {
            this.c = c;
        }
        public override byte[] Write()
        {
            send.WriteC((byte)c.nome.Length);
            send.WriteC((byte)c.Notice.Length);
            send.WriteC((byte)c.info.Length);
            send.WriteS(c.nome, c.nome.Length);
            send.WriteS(c.Notice, c.Notice.Length);
            send.WriteS(c.info, c.info.Length);
            send.WriteD(0);
            return Process();
        }
    }
}
