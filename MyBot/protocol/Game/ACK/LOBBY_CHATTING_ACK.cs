using AsyncRun.Enums;
using System;

namespace AsyncRun.protocol.Game.ACK
{
    public class LOBBY_CHATTING_ACK : ClinitProcess
    {
        protected string Mensagem;
        public Chat_Type type;
        public LOBBY_CHATTING_ACK(string Mensagem, Chat_Type type) : base(2627)
        {
            this.Mensagem = Mensagem;
            this.type = type;
        }
        public override byte[] Write()
        {
            send.WriteH((short)type); //CHATTING_TYPE_ALL
            send.WriteH((short)Mensagem.Length);
            send.WriteS(Mensagem, Mensagem.Length);
            return Process();
        }
    }
}