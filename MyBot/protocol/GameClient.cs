using AsyncRun;
using AsyncRun.Model;
using AsyncRun.protocol.Auth.ACK;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace AsyncRun.protocol
{
    public class GameClient
    {
        public volatile Socket socket;
        public ReadPacket pacotes;

        public GameClient(Socket socket, ReadPacket pacotes)
        {
            this.socket = socket;
            this.pacotes = pacotes;
            Util.IniciarThead(Receive);
        }
        public void SendPacket(byte[] data)
        {
            try
            {
                if (socket != null && socket.Connected)
                {
                    SocketError error = SocketError.InProgress;
                    socket.BeginSend(data, 0, data.Length, SocketFlags.None, out error, (result) =>
                    {
                        try
                        {
                            if (result.IsCompleted)
                                socket.EndSend(result, out error);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    },
                    socket);
                    SocketMessage(error);
                }
                else
                {
                    SockerVerific(null);
                }
                data = null;
            }
            catch (Exception e)
            {
                LoggerXML.Log(e.ToString(), "ERROR");
            }
        }
        public void Receive()
        {
            try
            {
                if (socket != null && socket.Connected && socket.Available >= 0)
                {
                    SyncPackage pacotes = SyncPackage.INST();
                    byte[] buffer = new byte[2];
                    SocketError error = SocketError.InProgress;
                    socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, out error, (result) =>
                    {
                        try
                        {
                            if (result.IsCompleted && socket.EndReceive(result, out error) >= 0)
                            {
                                buffer = new byte[BitConverter.ToUInt16(buffer, 0) + 2];
                                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, out error, (IAsyncResult) =>
                                {
                                    try
                                    {
                                        if (IAsyncResult.IsCompleted && socket.EndReceive(IAsyncResult, out error) >= 0)
                                        {
                                            SyncPackage.INST().GetPacketGame(this, buffer);
                                            Util.IniciarThead(Receive);

                                        }
                                        else
                                        {
                                            SockerVerific(null);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                },
                                socket);
                            }
                            else
                            {
                                SockerVerific(null);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    },
                    socket);
                    SocketMessage(error);
                }
                else
                {
                    SockerVerific(null);
                }
            }
            catch (Exception e)
            {
                LoggerXML.Log(e.ToString(), "ERROR");
            }
        }
        public void SockerVerific(Player p)  //VERIFICAÇÃO DO SOCKET
        {
            if (socket != null && !socket.Connected || socket == null)
            {
                p.ClientGame.SendPacket(new BASE_EXIT_GAME_ACK().Write());
                Logger.Warnnig("Connexão Bloqueada!");
            }
            else
            {
                if(p != null)
                    p.ClientGame.SendPacket(new BASE_EXIT_GAME_ACK().Write());
                Logger.Warnnig("Jogo Finalizado!");
            }
        }
        public void SocketMessage(SocketError error)
        {
            error.ToString();
        }
    }
}