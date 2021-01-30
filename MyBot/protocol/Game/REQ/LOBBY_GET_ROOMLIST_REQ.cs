using AsyncRun.Model;

namespace AsyncRun.protocol.Game.REQ
{
    public class LOBBY_GET_ROOMLIST_REQ : ReadPacket
    {
        public override void Avoid()
        {
            int SalaSize = ReadD();
            ReadD();
            ReadD();
            for (int i = 0; i < SalaSize; i++)
            {
                int RoomID = ReadD();
                string Name = ReadS(23);
                short map = ReadU();
                int stage4v4 = ReadC();
                int type = ReadC();
                int rstate = ReadC();
                int getPlayers = ReadC();
                int slots = ReadC();
                int ping = ReadC();
                int allWeapons = ReadC();
                int restrictions = ReadC();
                int special = ReadC();
                Logger.Receive("[ROOMLIST] GET PLAYERS ROOM LIST");
                Logger.Info("RoomID: " + RoomID);
                Logger.Info("Name: " + Name);
                Logger.Info("map: " + map);
                Logger.Info("ping: " + ping);
                Logger.Info("getPlayers:" + getPlayers);
                Logger.Receive("===============================");
            }
            int Jogadores = ReadD();
            ReadD();
            ReadD();
            for (int i = 0; i < Jogadores; i++)
            {
                int channelIdx = ReadD();
                int Logo = ReadD();
                string NameClan = ReadS(17);
                int Rank = ReadD();
                string Nome = ReadS(33);
                int color = ReadC();
                int Country = ReadC();
                //   if (player != null && !player.PlayerSizes.Contains(channelIdx))
                //   {
                //       player.PlayersLobby.Add(channelIdx);
                //}
                Logger.Receive("[PLAYERLIST] GET PLAYERS ROOM LIST");
                Logger.Info("Jogadores: " + i);
                Logger.Info("Logo: " + Logo);
                Logger.Info("NameClan: " + NameClan);
                Logger.Info("Rank:" + Rank);
                Logger.Info("Country:" + Country);
                Logger.Receive("===============================");
            }
            BASE_CHATTING.control = Enums.ControlEnum.LOBBY_CHAT;
            Program.LobbyChatting();
        }
    }
}