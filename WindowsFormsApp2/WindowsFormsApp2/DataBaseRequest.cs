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
    }
}
