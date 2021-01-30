using System;
using System.IO;
using System.Windows.Forms;

namespace AsyncRun
{
    public class LoggerXML
    {
        public static void Log(string texto, string Causa)
        {
            try
            {
                string stream = $"BOT_Config//log//{Causa}//Logger.txt";
                string dateFormat = "[dd/MM/yy HH:mm:ss] //";
                Directory.CreateDirectory($"BOT_Config//log//{Causa}");
                StreamWriter streamwrite = new StreamWriter(new FileStream(stream, FileMode.Append));
                streamwrite.WriteLine($"{DateTime.Now.ToString(dateFormat)}{texto}");
                streamwrite.Close();
                GC.SuppressFinalize(streamwrite);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public static void DeleteLog(bool program)
        {
            if (Directory.Exists($"BOT_Config//log"))
            {
                Directory.Delete($"BOT_Config//log", true);
                if (program)
                    MessageBox.Show("Log Deletado com sucesso.");
                else
                    Logger.Sucess("Log Deletado com sucesso.");
            }
            else
            {
                if (program)
                    MessageBox.Show("Error ao deletar o log.");
                else
                    Logger.Error("Error ao deletar o log.");
            }

        }
    }
}
