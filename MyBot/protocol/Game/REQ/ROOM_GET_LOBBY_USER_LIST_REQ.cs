using AsyncRun.Model;

namespace AsyncRun.protocol.Game.REQ
{
    public class ROOM_GET_LOBBY_USER_LIST_REQ : ReadPacket
    {
        public override void Avoid()
        {
            GetSession.INST().countPlayer = ReadD();
            if(GetSession.INST().countPlayer > 1)
            {
                for (int i = 0; i < GetSession.INST().countPlayer; i++)
                {
                    int sessionid = ReadD();
                    int Rank = ReadD();
                    int length = ReadC();
                    string name = ReadS(length);
                    Logger.Warnnig($"Conta: {sessionid}, {Rank}, {name}");
                    GetSession.INST().playerlobby.Add(name);
                }
            }
            Logger.Warnnig($"Tem { GetSession.INST().countPlayer} no Lobby; ");
        }
    }
}
