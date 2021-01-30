using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncRun.protocol.Game.ACK
{
   public class LOBBY_JOIN_ROOM_ACK : ClinitProcess
    {
        public LOBBY_JOIN_ROOM_ACK() : base(3081)
        {

        }

        public override byte[] Write()
        {
            Logger.Warnnig("Digite o ID da Room Para entrar: ");
            int id = int.Parse(Console.ReadLine());
            send.WriteD(id);
            Logger.Warnnig("Digite a senha da Room Para entrar: [Se nao tiver senha só pressione ok]");
           // send.WriteS(Console.ReadLine(), 4);
           // send.WriteD(0);
            return Process();
        }
    }
}
