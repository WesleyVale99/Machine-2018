namespace AsyncRun.protocol.Game.REQ
{
    public class ROOM_INVITE_SHOW_REQ : ReadPacket
    {
        public override void Avoid()
        {
            string nick = ReadS(33);
            int RoomID = ReadD();

            Logger.Receive($" NICK: [" + nick + "] ROOMID: [" + RoomID + "])");
        }
    }
}

