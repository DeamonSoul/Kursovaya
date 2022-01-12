using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal static class DataBaseRequest
    {
        /// <summary>
        /// Выполняет команду и возвращает данные в виде DataTable
        /// </summary>
        /// <param name="commandStr">
        /// Командная строка, в которой аргументы обозначаются как @P0, @P1 и т.д.
        /// </param>
        /// <param name="args">
        /// Последовательность строковых значений соответствующих аргументов
        /// </param>
        /// <returns></returns>
        public static DataTable AskForData(string commandStr, params string[] args)
        {
            DataBaseInit DB = new DataBaseInit();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(commandStr, DB.GetConnector());
            for (int i = 0; i< args.Length; i++)
                command.Parameters.Add("@P" + i.ToString(), MySqlDbType.VarChar).Value = args[i];
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
        /// <summary>
        /// Добавляет нового пользователя в таблицу usersdata и создает новую таблицу List<ИНН пользователя> для хранения чеков
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <param name="name">ФИО</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="password">Пароль</param>
        public static void WriteNewUser(string inn, string name, string email, string password)
        {
            DataBaseInit DB = new DataBaseInit();
            //команда, вставляющая новую строку в таблицу usersdata
            MySqlCommand command = new MySqlCommand("INSERT INTO `usersdata` (`Inn`, `Name`, `Email`, `Password`, `Bonus`, `Income`, `Credit`, `Ask`, `Answer`) VALUES (@P0, @P1, @P2, @P3, '10000', '0', '0', '', '')", DB.GetConnector());

            command.Parameters.Add("@P0", MySqlDbType.VarChar).Value = inn;
            command.Parameters.Add("@P1", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@P2", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@P3", MySqlDbType.VarChar).Value = password;

            DB.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт был создан");
            else
            {
                MessageBox.Show("Аккаунт не был создан");
                return;
            }

            //Создать таблицу для чеков
            command = new MySqlCommand("CREATE TABLE `users`.`list" + inn.ToString() + "` ( `Id` INT(5) UNSIGNED NOT NULL AUTO_INCREMENT, `Date` VARCHAR(10) NOT NULL , `CustomerInn` VARCHAR(12) NOT NULL , `CustomerType` VARCHAR(1) NOT NULL , `ProductName` VARCHAR(50) NOT NULL , `Price` VARCHAR(15) NOT NULL, PRIMARY KEY (`ID`) ) ENGINE = InnoDB", DB.GetConnector());

            command.ExecuteNonQuery();

            DB.CloseConnection();
        }

        /// <summary>
        /// Добавляет в таблицу List<ИНН пользователя> строку с информцией о новом чеке
        /// </summary>
        /// <param name="tableName">название таблицы чеков</param>
        /// <param name="cheque">Объект, описывающий чек</param>
        public static void WriteNewCheque(string tableName, Cheque cheque)
        {
            DataBaseInit DB = new DataBaseInit();

            //вставить в таблицу чеков новую строку
            MySqlCommand command = new MySqlCommand("INSERT INTO `" + tableName + "` (`Id`, `Date`, `CustomerInn`, `CustomerType`, `ProductName`, `Price`) VALUES(NULL, @P0, @P1, @P2, @P3, @P4)", DB.GetConnector());
            command.Parameters.Add("@P0", MySqlDbType.VarChar).Value = cheque.Date;
            command.Parameters.Add("@P1", MySqlDbType.VarChar).Value = cheque.CustomerInn;
            command.Parameters.Add("@P2", MySqlDbType.VarChar).Value = cheque.CustomerType;
            command.Parameters.Add("@P3", MySqlDbType.VarChar).Value = cheque.ProductName;
            command.Parameters.Add("@P4", MySqlDbType.VarChar).Value = cheque.Price;

            DB.OpenConnection();

            command.ExecuteNonQuery();

            DB.CloseConnection();
        }

        /// <summary>
        /// Обновляет даные о доходах пользователя в таблице usersdata
        /// </summary>
        /// <param name="ud"></param>
        public static void UploadUser(UserData ud)
        {
            DataBaseInit DB = new DataBaseInit();
            //обновить данные о задолженностях
            MySqlCommand command1 = new MySqlCommand("UPDATE `usersdata` SET `Credit` = @P0 WHERE `usersdata`.`Inn` = @P1", DB.GetConnector());
            //обновить данные о доходе
            MySqlCommand command2 = new MySqlCommand("UPDATE `usersdata` SET `Income` = @P0 WHERE `usersdata`.`Inn` = @P1", DB.GetConnector());
            //обновить данные о бонусе на уплату налога
            MySqlCommand command3 = new MySqlCommand("UPDATE `usersdata` SET `Bonus` = @P0 WHERE `usersdata`.`Inn` = @P1", DB.GetConnector());

            command1.Parameters.Add("@P0", MySqlDbType.VarChar).Value = ud.Credit.ToString();
            command1.Parameters.Add("@P1", MySqlDbType.VarChar).Value = ud.Inn;

            command2.Parameters.Add("@P0", MySqlDbType.VarChar).Value = ud.Income.ToString();
            command2.Parameters.Add("@P1", MySqlDbType.VarChar).Value = ud.Inn;

            command3.Parameters.Add("@P0", MySqlDbType.VarChar).Value = ud.Bonus.ToString();
            command3.Parameters.Add("@P1", MySqlDbType.VarChar).Value = ud.Inn;

            DB.OpenConnection();

            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();

            DB.CloseConnection();
        }
    }
    internal class DataBaseInit
    {
        private MySqlConnection connector = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=users");

        public MySqlConnection GetConnector()
        {
            return connector;
        }

        public void OpenConnection()
        {
            if (connector.State == System.Data.ConnectionState.Closed)
                connector.Open();
        }

        public void CloseConnection()
        {
            if (connector.State == System.Data.ConnectionState.Open)
                connector.Close();
        }
    }
}
