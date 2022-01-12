using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class EmailSender
    {
        /// <summary>
        /// Отправляет электронное письмо указанному пользователю
        /// </summary>
        /// <param name="ud">Объект, описывающий пользователя</param>
        public static void Send(UserData ud)
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
            string to = ud.Email;
            //Тема письма
            string subject = "Плати налог";
            //Текст письма
            string body = "Здравствуйте, " + ud.Name + " \n\n\n Ваш долг составляет" + ud.Credit;

            //Создаем сообщение
            MailMessage mess = new MailMessage(from, to, subject, body);

            try
            {
                client.Send(mess);
                //Console.WriteLine("Message send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Console.ReadKey();
            }
        }
    }
}
