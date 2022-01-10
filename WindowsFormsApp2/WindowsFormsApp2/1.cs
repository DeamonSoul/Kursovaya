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
            //smtp сервер
            string smtpHost = "smtp.mail.ru";
            //smtp порт
            int smtpPort = 465;
            //логин
            string login = "islammusin@mail.ru";
            //пароль
            string pass = "TJRZG";

            //создаем подключение
            SmtpClient client = new SmtpClient(smtpHost, smtpPort);
            client.Credentials = new NetworkCredential(login, pass);

            //От кого письмо
            string from = "islammusin@mail.ru";
            //Кому письмо
            string to = "islammusin.musin@yandex.ru";
            //Тема письма
            string subject = "Письмо от C Sharp";
            //Текст письма
            string body = "Привет! \n\n\n Это тестовое письмо";

            //Создаем сообщение
            MailMessage mess = new MailMessage(from, to, subject, body);

            try
            {
                client.Send(mess);
                Console.WriteLine("Message send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}