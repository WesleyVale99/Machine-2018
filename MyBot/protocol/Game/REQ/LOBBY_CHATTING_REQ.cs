namespace AsyncRun.protocol.Game.REQ
{
    public class LOBBY_CHATTING_REQ : ReadPacket
    {
        public override void Avoid()
        {
            ReadD();//ChannelID
            string Nick = ReadS(ReadC());
            ReadC(); //Color
            ReadC();//Access
            string Message = ReadString(ReadU());
            Program.chatadaptado.Mensagem("[" + Nick + "]: " + Message + "\n");
        }
    }
}
