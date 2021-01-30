using System;

namespace AsyncRun.protocol.Game.ACK
{
    public class CAMPO_MINADO : ClinitProcess
    {
        public string msg;
        public CAMPO_MINADO(string msg,ushort opcode) : base(opcode)
        {
            this.msg = msg;
        }
        public override byte[] Write()
        {
            Byte[] bytes = new Byte[10000];
            send.WriteH(30);
            send.WriteS(msg, 35);
            send.WriteB(bytes);
            return Process();
        }
    }
}