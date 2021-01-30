using AsyncRun.Model;
using AsyncRun.protocol;
using AsyncRun.protocol.Game.ACK;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AsyncRun
{
    public partial class Base : Form
    {
        public static Loader loader = Loader.INTs();
        public Room r = Room.ITNs();
        public bool pause = true;
        public Player p = Connection.INSTs().player;
        public Base()
        {
            InitializeComponent();
            new Thread(Initial).Start();
            button4.Enabled = false;
        }
        public void CreateRoom()
        {
            if (p != null)
            {
                Room_Valor();
                if (r.slots <= 16)
                {
                    LoggerXML.Log("[COMANDOS] Criando uma sala.", "Comandos");
                    p.ClientGame.SendPacket(new BASE_CREATE_ROOM_ACK(r).Write());
                    textBox4.Text = "Sala Criada com sucesso...";
                    new Thread(CloseChating).Start();
                    comboBox3.Enabled = false;
                    textBox1.Enabled = false;
                    new Thread(new ThreadStart(Program.chatadaptado.Fechada_da_room)).Start();
                    button4.Enabled = true;
                }
                else
                {
                    MessageBox.Show("slot não pode ser maior que 16.");
                }
            }
            else
            {
                MessageBox.Show("Error de verificação.");
            }
        }
        public void FlodRoom()
        {
            Room_Valor();
            comboBox1.Enabled = false;
            comboBox3.Enabled = false;
            textBox1.Enabled = false;
            for (int i = 1; i < 4; i++)
            {
                Refresh();
                if (p != null && r.slots <= 16)
                {
                    textBox4.Text = "Sala Criada com sucesso...";
                    ReadPacket.flods = false;
                    p.ClientGame.SendPacket(new BASE_CREATE_ROOM_ACK(r).Write());
                    p.ClientGame.SendPacket(new LOBBY_ENTER_ACK().Write());
                    Logger.Info($"Tentando Flodar sala... [{i}]");
                    Thread.Sleep(300);
                }
                else
                {
                    MessageBox.Show("Error de verificação / slot não pode ser maior que 16.");
                }
            }
            Close();
            new Thread(CloseChating).Start();
            ReadPacket.flods = true;
            p.ClientGame.SendPacket(new LOBBY_ENTER_ACK().Write());
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length <= 4)
            {
                new Thread(PreCreateRoom).Start();
                new Thread(CreateRoom).Start();
            }
            else
            {
                MessageBox.Show("Password incorreta!");
            }

        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (p != null && p.ClientGame != null)
            {
                new Thread(CloseChating).Start();
                Close();
                p.ClientGame.SendPacket(new LOBBY_ENTER_ACK().Write());
                Logger.Info("Você voltou para o lobby");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                if (MessageBox.Show("Essa comando é infinito, deseja continuar?", "FLODAR CONVITES", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    p.ClientGame.SendPacket(new ROOM_GET_LOBBY_USER_LIST_ACK().Write());
                    Logger.Receive($"Quantidades de players no lobby: {GetSession.INST().countPlayer}");
                    if (GetSession.INST().countPlayer > 0)
                    {
                        Logger.Comandos("Digite quantas vezes o repetirar. (1 até 300)");
                        int size = int.Parse(Console.ReadLine());
                        if (size <= 300 && size >= 1)
                        {
                            for (; ; )
                            {
                                count++;
                                Logger.Sucess($"Contagens total de convites: {count}");
                                Thread.Sleep(500);
                                for (int jogador = 0; jogador < GetSession.INST().countPlayer; jogador++)
                                    p.ClientGame.SendPacket(new ROOM_INVITES_PLAYERS_ACK(jogador).Write());
                                if (count == size)
                                    break;
                            }
                        }
                        else
                        {
                            Logger.Error("Error ao Digitar a quantidade.");
                            Logger.Error("programa Finalizado.");
                        }
                    }
                    else
                    {
                        Logger.Error("Não há players suficientes para flodar!");
                        Logger.Error("programa Finalizado.");
                    }
                }
                else
                {
                    new Thread(CloseChating).Start();
                    Close();
                    p.ClientGame.SendPacket(new LOBBY_ENTER_ACK().Write());
                    Logger.Info("Você voltou para o lobby");
                }
            }
            catch (Exception Ex)
            {
                Ex.ToString();
            }
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox5.Enabled = true;
                MessageBox.Show("Senha Ativada!");
                r.pass = textBox5.Text;
            }
            else
            {
                textBox5.Visible = false;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            r.Map = short.Parse(comboBox1.SelectedIndex.ToString());
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            r.Type = byte.Parse(comboBox2.SelectedIndex.ToString());
        }
        public void PreCreateRoom()
        {
            button1.Enabled = true;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            textBox4.Enabled = false;
            button2.Visible = false;
        }
        public void Initial()
        {
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            button1.Enabled = false;
        }
        public void Room_Valor()
        {
            r.Name = textBox1.Text;
            r.slots = comboBox3.SelectedIndex;
        }
        public void CloseChating()
        {
            Program.chatadaptado.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                GetSession.INST().PleaseWait = true;
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