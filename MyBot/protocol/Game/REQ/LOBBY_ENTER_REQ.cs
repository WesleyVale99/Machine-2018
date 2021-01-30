using AsyncRun.Enums;
using AsyncRun.protocol.Game.ACK;
using System;


namespace AsyncRun.protocol.Game.REQ
{
    public class LOBBY_ENTER_REQ : ReadPacket
    {
        public override void Avoid()
        {
            int error = 0;
            if (reader.BaseStream.Length >= 4)
                error = ReadD();
            if (LOAD.LoggerReceive)
                Logger.Sucess("Entrou no lobby.");
            if (player.nick.Length == 0)
            {
                Logger.Warnnig("Digite um Novo apelido?");
                string nick = Console.ReadLine();
                if (nick.Length < 23)
                {
                    clientGame.SendPacket(new LOBBY_CREATE_NICK_NAME_ACK(nick).Write());
                }
                else
                {
                    Logger.Warnnig($"apelido Incorreto![{nick}]");
                    clientGame.SendPacket(new LOBBY_ENTER_ACK().Write());
                }
            }
            else
            {
                if (flods)
                {
                    Logger.Info("Nick: [" + player.nick + "]");
                    BASE_CHATTING.control = ControlEnum.LOBBY_CHAT;
                    Commands.LiberacaoChat();
                    Program.chatadaptado.textBox1.Enabled = false;
                }
            }
        }
    }
}