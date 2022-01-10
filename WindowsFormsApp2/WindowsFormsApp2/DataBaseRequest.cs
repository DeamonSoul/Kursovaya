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
            for (int i = 0; i < args.Length; i++)
                command.Parameters.Add("@P" + i.ToString(), MySqlDbType.VarChar).Value = args[i];
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public static void WriteNewUser(string inn, string name, string email, string password)
        {
            DataBaseInit DB = new DataBaseInit();
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

            command = new MySqlCommand("CREATE TABLE `users`.`list" + inn.ToString() + "` ( `Id` INT(5) UNSIGNED NOT NULL AUTO_INCREMENT , `CustomerInn` VARCHAR(12) NOT NULL , `CustomerType` VARCHAR(1) NOT NULL , `ProductName` VARCHAR(50) NOT NULL , `Price` VARCHAR(15) NOT NULL, PRIMARY KEY (`ID`) ) ENGINE = InnoDB", DB.GetConnector());

            command.ExecuteNonQuery();

            DB.CloseConnection();
        }
    }
}
