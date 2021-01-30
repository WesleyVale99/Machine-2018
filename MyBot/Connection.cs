using AsyncRun.Model;
using AsyncRun.protocol;
using System;
using System.Net;
using System.Net.Sockets;

namespace AsyncRun
{
    public class Connection 
    {
        public volatile Player player;
        public Loader loader = Loader.INTs();
        public static IPAddress addr;
        public static IPEndPoint remote;
        public Connection()
        {
        }
        public void SocketClientAuth()
        {
            try
            {
                if (IPAddress.TryParse(loader.IP, out addr)) // 2586
                {
                    remote = new IPEndPoint(addr, loader.PORT);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Logger.Warnnig("Recebendo Informação do Servidor!");
                    if (socket == null)
                        return;
                    else
                        socket.Connect(remote);
                    if (socket.Connected)
                    {
                        LoggerXML.Log($"Iniciando a conexão auth.[{socket.RemoteEndPoint.ToString()}]", "CONEXAO");
                        Logger.Warnnig("[Async Socket] " + socket.RemoteEndPoint.ToString() + "");
                        socket.NoDelay = true;
                        player = new Player
                        {
                            AuthClient = new AuthClient(socket, SyncPackage.INST().read)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerXML.Log(ex.ToString(), "ERROR");
                Logger.Error($"[Aynsc Error Socket] Error ao conectar ao Socket, Vefique sua conexão!");
            }
        }
        public void SocketClientGame()
        {
            try
            {
                if (player.AuthClient != null)
                {
                    BeginDisconnect(player.AuthClient.socket);
                    GC.SuppressFinalize(player.AuthClient);
                    player.AuthClient = null;
                }
                Logger.Warnnig("Recebendo Informação do Servidor!");
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.BeginConnect(player.server, (result) =>
                {
                    socket.EndConnect(result);

                    if (socket.Connected)
                    {
                        Logger.Warnnig("[Async Socket] " + socket.RemoteEndPoint.ToString() + "");
                        LoggerXML.Log($"Iniciando a conexão Game.[{remote}]", "CONEXAO");
                        Console.Beep();
                        player.ClientGame = new GameClient(socket, SyncPackage.INST().read);
                    }
                    else
                    {
                        socket.Close();
                    }
                },
                socket);
            }
            catch (Exception ex)
            {
                LoggerXML.Log(ex.ToString(), "ERROR");
            }
        }
        public void AutoAccounts()
        {
            try
            {
                if (IPAddress.TryParse(loader.IP, out addr)) // 2586
                {
                    remote = new IPEndPoint(addr, 39190);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Logger.Receive("Recebendo Informação do Servidor!");
                    if (socket == null)
                        return;
                    else
                        socket.Connect(remote);
                    if (socket.Connected)
                    {
                        Random r = new Random();
                        if(GetSession.INST().Process)
                        {
                            loader.USER = "Wesley" + r.Next(0, 1000);
                            loader.PASS = "Wesley" + r.Next(0, 1000);
                        }
                        LoggerXML.Log($"Iniciando a conexão auth. [{remote}]", "CONEXAO");
                        Logger.Warnnig("[Async Socket] " + socket.RemoteEndPoint.ToString() + "");
                        socket.NoDelay = true;
                        ReadPacket.flods = false;
                        player = new Player
                        {
                            AuthClient = new AuthClient(socket, SyncPackage.INST().read)
                        };
                        r = null;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerXML.Log(ex.ToString(), "ERROR");
            }
        }
        public void BeginDisconnect(Socket socket)
        {
            try
            {
                if (socket != null)
                {
                    socket.BeginDisconnect(false, (result) =>
                    {
                        try
                        {
                            socket.EndDisconnect(result);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    },
                    socket);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
            finally
            {
                try
                {
                    if (socket != null)
                    {
                        socket.Disconnect(false);
                        socket.Shutdown(SocketShutdown.Both);
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
        static readonly Connection INSTS = new Connection();
        public static Connection INSTs() => INSTS;
    }

}
