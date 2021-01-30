using System.Text;
using System.Threading.Tasks;

namespace AsyncRun.protocol.Game.ACK
{
    public class CLAN_CLIENT_LIST_ACK : ClinitProcess
    {
        public int index;
        public CLAN_CLIENT_LIST_ACK(int index) : base(1445)
        {
            this.index = index;
        }
        public override byte[] Write()
        {
            send.WriteD(index);
            return Process();
        }
    }
}