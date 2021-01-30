namespace AsyncRun.protocol.Game.REQ
{
    public class BASE_CHAT_ROOM_REQ : ReadPacket
    {
        public override void Avoid()
        {
            ReadU();
            int Slot = ReadD();//slot
            ReadC(); //access
            string Message = ReadString(ReadD());
            Program.chatadaptado.Mensagem("[" + Slot + "]: " + Message + "\n");
        }
    }
}
