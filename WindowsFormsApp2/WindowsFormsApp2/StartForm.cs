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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string login = LogInnTextBox.Text;
            string password = LogPasswordTextBox.Text;

            if (InputAnalysis.CheckLogin(login) && InputAnalysis.CheckPassword(password))
            {
                /*  вынесено в отдельный класс DataBaseRequest
                DataBase DB = new DataBase();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `userdata` WHERE `INN` = @L AND `Password` = @P", DB.GetConnector());
                command.Parameters.Add("@L", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@P", MySqlDbType.VarChar).Value = password;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                */

                DataTable table = DataBaseRequest.AskForData("SELECT * FROM `usersdata` WHERE `INN` = @P0 AND `Password` = @P1", login, password);

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Авторизован");
                    UserForm uForm = new UserForm(table);
                    uForm.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Неверные данные");
                
            }
        }

        private void ButtonReg_Click(object sender, EventArgs e)
        {
            if (InputAnalysis.CheckLogin(RegInnTextBox.Text) &&
                InputAnalysis.CheckPassword(RegPasswordTextBox.Text) &&
                InputAnalysis.CheckEmail(RegMailTextBox.Text) &&
                InputAnalysis.CheckFio(RegFioTextBox.Text))
            {
                string login = RegInnTextBox.Text;
                DataTable table = DataBaseRequest.AskForData("SELECT * FROM `usersdata` WHERE `INN` = @P0", login);
                
                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Пользователь с таким ИНН уже заегистрирован");
                }
                else
                {
                    DataBaseRequest.WriteNewUser(RegInnTextBox.Text, RegFioTextBox.Text, RegMailTextBox.Text, RegPasswordTextBox.Text);
                }    
            }
            else
                MessageBox.Show("Данные указаны некорректно");
        }
    }
}
