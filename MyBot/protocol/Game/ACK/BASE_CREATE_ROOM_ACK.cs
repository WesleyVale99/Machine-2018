using AsyncRun.Model;

namespace AsyncRun.protocol.Game.ACK
{
    public class BASE_CREATE_ROOM_ACK : ClinitProcess
    {
        public Room r;
        public BASE_CREATE_ROOM_ACK(Room r) : base(3089)
        {
            this.r = r;
        }
        public override byte[] Write()
        {
            send.WriteD(0); //ERROR
            send.WriteS(r.Name, 23);
            if(!GetSession.INST().PleaseWait)
                send.WriteH(r.Map += 1);
            else
                send.WriteH(5000);
            send.WriteC(0); //stage4vs4
            send.WriteC(r.Type += 1); //type
            send.WriteC(0);
            send.WriteC(0);
            send.WriteC((byte)r.slots); //slots
            send.WriteC(0);
            send.WriteC(0);//all Weapons
            send.WriteC(r.randomMap);//randomMap
            send.WriteC(r.special);//special
            send.WriteS(player.nick, 33); // NICK DO PLAYER
            send.WriteC(66); //66
            send.WriteC(0);
            send.WriteC(0);
            send.WriteC(0);
            send.WriteC(0);
            send.WriteC(0);
            send.WriteH(r.balanceamento);
            send.WriteS(r.pass, 4); //PASSWORD
            if (r.special == 6 || r.special == 9)
            {
                send.WriteC(r.Count);// QUANTOS BOT
                send.WriteC(r.Level);// LEVEL DO BOT
            }
            return Process();
        }
    }
}
