using AsyncRun.protocol.Game.ACK;
using System;


namespace AsyncRun.protocol.Game.REQ
{
    public class BASE_USER_ENTER_REQ : ReadPacket
    {
        public override void Avoid()
        {
            int error = ReadD();
            if (error == 0)
            {
                if (LOAD.LoggerReceive)
                    Logger.Sucess($"Logando com sucesso[{error}]");
                Logger.Info("Channel especificado? [1 à 10]");
                int chnnl = int.Parse(Console.ReadLine());
                switch (chnnl -= 1)
                {
                    case 0:
                        {
                            clientGame.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(chnnl).Write());
                            break;
                        }
                    case 1:
                        {
                            clientGame.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(chnnl).Write());
                            break;
                        }
                    case 2:
                        {
                            clientGame.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(chnnl).Write());
                            break;
                        }
                    case 3:
                        {
                            clientGame.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(chnnl).Write());
                            break;
                        }
                    case 4:
                        {
                            clientGame.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(chnnl).Write());
                            break;
                        }
                    case 5:
                        {
                            clientGame.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(chnnl).Write());
                            break;
                        }
                    case 6:
                        {
                            clientGame.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(chnnl).Write());
                            break;
                        }
                    case 7:
                        {
                            clientGame.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(chnnl).Write());
                            break;
                        }
                    case 8:
                        {
                            clientGame.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(chnnl).Write());
                            break;
                        }
                    case 9:
                        {
                            clientGame.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(chnnl).Write());
                            break;
                        }
                    default:
                        {
                            clientGame.SendPacket(new BASE_USER_ENTER_ACK().Write());
                            break;
                        }

                }
            }
            else
            {
                Logger.Error($"Erro ao receber informações.{ error }");
            }
        }
    }
}