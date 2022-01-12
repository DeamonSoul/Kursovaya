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
    public partial class AdminForm : Form
    {
        UserData[] Users;
        StartForm MainForm;
        int currentUser = 0;

        public AdminForm(StartForm mainform)
        {
            InitializeComponent();

            MainForm = mainform;

            Users = UpdateUserData();
            UpdateFormData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (e.ColumnIndex == 7)
            {
                string str = "Привет, ";
                str += dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                MessageBox.Show(str);
            }
            */
        }

        private void AdminForm_Resize(object sender, EventArgs e)
        {
            int globalWidth = this.Size.Width - 40;
            dataGridView1.Size = new Size(globalWidth, dataGridView1.Size.Height);
            dataGridView2.Size = new Size(900, dataGridView1.Size.Height);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].Width = globalWidth / dataGridView1.ColumnCount;

            for (int i = 0; i < dataGridView2.ColumnCount; i++)
                dataGridView2.Columns[i].Width = 900 / dataGridView1.ColumnCount;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

        }

        public UserData[] UpdateUserData()
        {
            DataTable UserTable = DataBaseRequest.AskForData("SELECT * FROM `usersdata`");

            UserData[] ud = new UserData[UserTable.Rows.Count];

            for (int i = 0; i < UserTable.Rows.Count; i++)
            {
                ud[i] = new UserData();

                ud[i].Inn = UserTable.Rows[i][0].ToString();
                ud[i].Name = UserTable.Rows[i][1].ToString();
                ud[i].Email = UserTable.Rows[i][2].ToString();
                ud[i].Password = UserTable.Rows[i][3].ToString();
                ud[i].Bonus = double.Parse(UserTable.Rows[i][4].ToString());
                ud[i].Income = double.Parse(UserTable.Rows[i][5].ToString());
                ud[i].Credit = double.Parse(UserTable.Rows[i][6].ToString());
                ud[i].Ask = UserTable.Rows[i][7].ToString();
                ud[i].Answer = UserTable.Rows[i][8].ToString();

                DataTable ChequeTable = DataBaseRequest.AskForData("SELECT * FROM `List" + ud[i].Inn + "`");

                ud[i].Cheques = new Cheque[ChequeTable.Rows.Count];

                for (int j = 0; j < ChequeTable.Rows.Count; j++)
                {
                    ud[i].Cheques[j] = new Cheque();
                    ud[i].Cheques[j].Id = int.Parse(ChequeTable.Rows[j][0].ToString());
                    ud[i].Cheques[j].Date = ChequeTable.Rows[j][1].ToString();
                    ud[i].Cheques[j].CustomerInn = ChequeTable.Rows[j][2].ToString();
                    ud[i].Cheques[j].CustomerType = ChequeTable.Rows[j][3].ToString();
                    ud[i].Cheques[j].ProductName = ChequeTable.Rows[j][4].ToString();
                    ud[i].Cheques[j].Price = ChequeTable.Rows[j][5].ToString();
                }
            }

            return ud;
        }

        public void UpdateFormData()
        {
            int globalWidth = this.Size.Width - 40;
            dataGridView1.Size = new Size(globalWidth, dataGridView1.Size.Height);
            dataGridView2.Size = new Size(900, dataGridView1.Size.Height);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].Width = globalWidth / dataGridView1.ColumnCount;

            for (int i = 0; i < dataGridView2.ColumnCount; i++)
                dataGridView2.Columns[i].Width = 900 / dataGridView1.ColumnCount;

            dataGridView1.Rows.Clear();

            while (dataGridView1.Rows.Count < Users.Length)
            {
                dataGridView1.Rows.Add();
            }

            for (int i = 0; i < Users.Length; i++)
            {
                dataGridView1.Rows[i].SetValues(Users[i].Inn, Users[i].Name, Users[i].Income, Users[i].Credit, Users[i].Bonus);
            }

            dataGridView2.Rows.Clear();
            
            if (Users.Length > 0)
            {
                while (dataGridView2.Rows.Count < Users[currentUser].Cheques.Length)
                {
                    dataGridView2.Rows.Add();
                }

                for (int i = 0; i < Users[currentUser].Cheques.Length; i++)
                {
                    dataGridView1.Rows[i].SetValues(Users[currentUser].Cheques[i].Date, Users[currentUser].Cheques[i].ProductName, Users[currentUser].Cheques[i].Price, Users[currentUser].Cheques[i].CustomerInn, Users[currentUser].Cheques[i].CustomerType);
                }
            }
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Close();
        }
    }
}
