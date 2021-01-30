using System;
using System.Net.Sockets;

namespace AsyncRun.protocol
{
    public class AuthClient
    {
        public volatile Socket socket;
        public ReadPacket pacotes;

        public AuthClient(Socket socket, ReadPacket pacotes)
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
                    AskSocket();
                }
                data = null;
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
        public void Receive()
        {
            try
            {
                if (socket != null && socket.Connected && socket.Available >= 0)
                {
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
                                            SyncPackage.INST().GetPacketAuth(this, buffer);
                                            Util.IniciarThead(Receive);

                                        }
                                        else
                                        {
                                            AskSocket();
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
                                AskSocket();
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
                    AskSocket();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
        public void AskSocket()  //VERIFICAÇÃO DO SOCKET
        {
            if (socket != null && !socket.Connected || socket == null)
            {
                Logger.Warnnig("Connexão Bloqueada!");
            }
            else
            {
                Logger.Warnnig("Conexão com o Auth Fechada!");
            }
        }
        public void SocketMessage(SocketError error)
        {
            error.ToString();
        }
    }
}