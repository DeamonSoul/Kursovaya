using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal static class InputAnalysis
    {
        /// <summary>
        /// Проверка корректности ИНН
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static bool CheckLogin(string login)
        {
            if (login.Length != 12)
                return false;

            foreach (char c in login)
            {
                if (!(c >= '0' && c <= '9'))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// проверка корректности пароля
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckPassword(string password)
        {

            foreach (char c in password)
            {
                if (c == ' ')
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Проверка корректности введенной почты
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool CheckEmail(string email)
        {
            string[] strs = email.Split(new char[] { '@' });

            if (strs.Length != 2)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Проверка корректности вводимого ФИО
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CheckFio(string name)
        {
            //const string russianLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                    count++;
            }
            if (count == 2)
                return true;

            return false;
        }

        /// <summary>
        /// Проверка корректности данных чека
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool CheckCheque(Cheque c)
        {
            if (c.CustomerInn == "" || (c.CustomerType != "ф" && c.CustomerType != "ю") || c.ProductName == "" || c.Price == "")
                return false;

            return true;
        }
    }
}
