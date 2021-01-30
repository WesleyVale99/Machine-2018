namespace AsyncRun.Model
{
    public class Patente : Player
    {
        static readonly Patente INSTANCE = new Patente();
        public static Patente Gi() => INSTANCE;
        public void Pats(int patente)
        {
            Program.chatadaptado.textBox8.Visible = true;
            Program.chatadaptado.textBox8.Enabled = false;
            switch (patente)
            {
                case 0:
                    Program.chatadaptado.textBox8.Text = "Novato";
                    break;
                case 1:
                    Program.chatadaptado.textBox8.Text = "Recruta";
                    break;
                case 2:
                    Program.chatadaptado.textBox8.Text = "Soldado";
                    break;
                case 3:
                    Program.chatadaptado.textBox8.Text = "Cabo";
                    break;
                case 4:
                    Program.chatadaptado.textBox8.Text = "Sargento";
                    break;
                case 5:
                    Program.chatadaptado.textBox8.Text = "Terceiro Sargento 1";
                    break;
                case 6:
                    Program.chatadaptado.textBox8.Text = "Terceiro Sargento 2";
                    break;
                case 7:
                    Program.chatadaptado.textBox8.Text = "Terceiro Sargento 3";
                    break;
                case 8:
                    Program.chatadaptado.textBox8.Text = "Segundo Sargento 1";
                    break;
                case 9:
                    Program.chatadaptado.textBox8.Text = "Segundo Sargento 2";
                    break;
                case 10:
                    Program.chatadaptado.textBox8.Text = "Segundo Sargento 3";
                    break;
                case 11:
                    Program.chatadaptado.textBox8.Text = "Segundo Sargento 4";
                    break;
                case 12:
                    Program.chatadaptado.textBox8.Text = "Primeiro Sargento 1";
                    break;
                case 13:
                    Program.chatadaptado.textBox8.Text = "Primeiro Sargento 2";
                    break;
                case 14:
                    Program.chatadaptado.textBox8.Text = "Primeiro Sargento 3";
                    break;
                case 15:
                    Program.chatadaptado.textBox8.Text = "Primeiro Sargento 4";
                    break;
                case 16:
                    Program.chatadaptado.textBox8.Text = "Primeiro Sargento 5";
                    break;
                case 17:
                    Program.chatadaptado.textBox8.Text = "Segundo Tenente 1";
                    break;
                case 18:
                    Program.chatadaptado.textBox8.Text = "Segundo Tenente 2";
                    break;
                case 19:
                    Program.chatadaptado.textBox8.Text = "Segundo Tenente 3";
                    break;
                case 20:
                    Program.chatadaptado.textBox8.Text = "Segundo Tenente 4";
                    break;
                case 21:
                    Program.chatadaptado.textBox8.Text = "Primeiro Tenente 1";
                    break;
                case 22:
                    Program.chatadaptado.textBox8.Text = "Primeiro Tenente 2";
                    break;
                case 23:
                    Program.chatadaptado.textBox8.Text = "Primeiro Tenente 3";
                    break;
                case 24:
                    Program.chatadaptado.textBox8.Text = "Primeiro Tenente 4";
                    break;
                case 25:
                    Program.chatadaptado.textBox8.Text = "Primeiro Tenente 5";
                    break;
                case 26:
                    Program.chatadaptado.textBox8.Text = "Capitão 1";
                    break;
                case 27:
                    Program.chatadaptado.textBox8.Text = "Capitão 2";
                    break;
                case 28:
                    Program.chatadaptado.textBox8.Text = "Capitão 3";
                    break;
                case 29:
                    Program.chatadaptado.textBox8.Text = "Capitão 4";
                    break;
                case 30:
                    Program.chatadaptado.textBox8.Text = "Capitão 5";
                    break;
                case 31:
                    Program.chatadaptado.textBox8.Text = "Major 1";
                    break;
                case 32:
                    Program.chatadaptado.textBox8.Text = "Major 2";
                    break;
                case 33:
                    Program.chatadaptado.textBox8.Text = "Major 3";
                    break;
                case 34:
                    Program.chatadaptado.textBox8.Text = "Major 4";
                    break;
                case 35:
                    Program.chatadaptado.textBox8.Text = "Major 5";
                    break;
                case 36:
                    Program.chatadaptado.textBox8.Text = "Tenente Coronel 1";
                    break;
                case 37:
                    Program.chatadaptado.textBox8.Text = "Tenente Coronel 2";
                    break;
                case 38:
                    Program.chatadaptado.textBox8.Text = "Tenente Coronel 3";
                    break;
                case 39:
                    Program.chatadaptado.textBox8.Text = "Tenente Coronel 4";
                    break;
                case 40:
                    Program.chatadaptado.textBox8.Text = "Tenente Coronel 5";
                    break;
                case 41:
                    Program.chatadaptado.textBox8.Text = "Coronel 1";
                    break;
                case 42:
                    Program.chatadaptado.textBox8.Text = "Coronel 2";
                    break;
                case 43:
                    Program.chatadaptado.textBox8.Text = "Coronel 3";
                    break;
                case 44:
                    Program.chatadaptado.textBox8.Text = "Coronel 4";
                    break;
                case 45:
                    Program.chatadaptado.textBox8.Text = "Coronel 5";
                    break;
                case 46:
                    Program.chatadaptado.textBox8.Text = "General de Brigada";
                    break;
                case 47:
                    Program.chatadaptado.textBox8.Text = "General de Divisão";
                    break;
                case 48:
                    Program.chatadaptado.textBox8.Text = "General de Exército";
                    break;
                case 49:
                    Program.chatadaptado.textBox8.Text = "Marechal";
                    break;
                case 50:
                    Program.chatadaptado.textBox8.Text = "Herói de Guerra";
                    break;
                case 51:
                    Program.chatadaptado.textBox8.Text = "Hero";
                    break;
                case 52:
                    Program.chatadaptado.textBox8.Text = "unk";
                    break;
                case 53:
                    Program.chatadaptado.textBox8.Text = "GameMaster";
                    break;
                case 54:
                    Program.chatadaptado.textBox8.Text = "MODERADOR";
                    break;

                default:
                    Program.chatadaptado.textBox8.Text = "Unknown";
                    break;

            }
        }
    }
}
