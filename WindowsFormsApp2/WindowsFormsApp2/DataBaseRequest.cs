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

        
        public static DataTable AskForData(string commandStr, params string[] args)
        {
            DataTable table = new DataTable();
            
            return table;
        }
    }
}
