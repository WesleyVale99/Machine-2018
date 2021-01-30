using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncRun.protocol.Game.ACK
{
    public class ROOM_INVITES_PLAYERS_ACK : ClinitProcess
    {
        public int Jogador;
        public ROOM_INVITES_PLAYERS_ACK(int Jogador) : base (2053)//3884
        {
            this.Jogador = Jogador;
        }
        public override byte[] Write()
        {
            send.WriteD(Jogador);
            return Process();
        }
    }
}
