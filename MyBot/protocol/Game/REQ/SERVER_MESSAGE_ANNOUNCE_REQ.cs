namespace AsyncRun.protocol.Game.REQ
{
    public class SERVER_MESSAGE_ANNOUNCE_REQ : ReadPacket
    {
        public override void Avoid()
        {
            int type = ReadD();
            short length = ReadU();
            string mensagem = ReadUS(length);
            if (mensagem != null && length > 0)
            {
                Program.chatadaptado.textBox9.AppendText("\n");
                Program.chatadaptado.textBox9.AppendText(mensagem);
            }
            if(LOAD.LoggerReceive)
                Logger.Receive($"{GetType().Name} [{type};{length};{mensagem}]");
        }
    }
}
