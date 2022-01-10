using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace NetConsoleApp
{
    class Program
    {
        static void Main()
        {
            string smtpHost = "smtp.mail.ru";
            int smtpPort = 465;
            string login = "islammusin@mail.ru";
            string pass = "TJRZG";
            SmtpClient client = new SmtpClient(smtpHost, smtpPort);
            client.Credentials = new NetworkCredential(login, pass);
            string from = "islammusin@mail.ru";
            string to = "islammusin.musin@yandex.ru";
            string subject = "Письмо от C Sharp";
            string body = "Привет! \n\n\n Это тестовое письмо";
            MailMessage mess = new MailMessage(from, to, subject, body);
        }
    }
}