using AsyncRun.Enums;
using AsyncRun.protocol.Game.ACK;
using System;
using System.Threading;

namespace AsyncRun.protocol.Game.REQ
{
    public class LOBBY_CREATE_NICK_NAME_REQ : ReadPacket
    {
        public override void Avoid()
        {
            int error = ReadD();
            if (LOAD.LoggerReceive)
                Logger.Receive($"{GetType().Name} [{error}]");
            if (error == 0 || error == 1)
            {
                Logger.Sucess($"Apelido [{ player.nick }] adicionado com Sucesso. [{error}]");
                BASE_CHATTING.control = ControlEnum.LOBBY_CHAT;
                new Thread(new ThreadStart(Commands.LiberacaoChat)).Start();
                // client.BeginSend(new LOBBY_SHOP_LIST_ACK().Write());
            }
            else
            {
                Logger.Error("Apelido Falhado!");
                Logger.Error(Environment.NewLine);
                Logger.Error("Digite novamente um nick!");
                string nick = Console.ReadLine();
                clientGame.SendPacket(new LOBBY_CREATE_NICK_NAME_ACK(nick).Write());
            }
        }
    }
}