using AsyncRun.Enums;

namespace AsyncRun.protocol.Game.REQ
{
    public class CLAN_CREATE_REQ : ReadPacket
    {

        public CLAN_CREATE_REQ() : base()
        {

        }
        public override void Avoid()
        {
            Exception_Clan Error = (Exception_Clan) ReadD();
            if (Error == 0)
            {
                int ID = ReadD();
                string name = ReadS(ReadD());
                Logger.Sucess($"Clan Criado com Sucesso!!! ClanID: {ID}, ClanName: {name}");
                // Program.LobbyChatting();
            }
            else
            {
                Logger.Error($"Error ao Criar clan, {Error.ToString()}");
            }
        }
    }
}
