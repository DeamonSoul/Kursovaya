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
        UserData[] Users; //Список пользователей
        StartForm MainForm; //ссылка на стартовое окно для завершения программы при закрытии текущего окна
        int currentUser = 0; // Индекс выделенного пользователя
        DateTime LastUpdate; // Дата и время последнего обновления

        public AdminForm(StartForm mainform)
        {
            InitializeComponent();

            MainForm = mainform;

            Users = UpdateUserData();
            UpdateFormData();
        }

        // форматирование таблиц при изменении окна
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

        // выделение пользователя
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                currentUser = dataGridView1.SelectedCells[0].RowIndex;
            }

            UpdateFormData();
        }


        private void AdminForm_Load(object sender, EventArgs e)
        {
        }

        // событие нажатия на кнопку Пересчитать все
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        // событие нажатия на кнопку Обновить данные
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Users = UpdateUserData();
            UpdateFormData();
        }

        // Загрузить информацию о пользователях из базы данных
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

                if (ud[i].Inn == "111111111111")// строке с ИНН = 111111111111 находится дата последнего обновления
                {
                    LastUpdate = DateTime.Parse(ud[i].Name);
                }

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

        // Обновляет содержание таблиц
        public void UpdateFormData()
        {
            int globalWidth = this.Size.Width - 40;
            dataGridView1.Size = new Size(globalWidth, dataGridView1.Size.Height);
            dataGridView2.Size = new Size(600, dataGridView2.Size.Height);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].Width = globalWidth / dataGridView1.ColumnCount;

            for (int i = 0; i < dataGridView2.ColumnCount; i++)
                dataGridView2.Columns[i].Width = 600 / dataGridView2.ColumnCount;

            dataGridView1.Rows.Clear();

            while (dataGridView1.Rows.Count < Users.Length)
            {
                dataGridView1.Rows.Add();
            }

            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i].Inn != "111111111111")
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
                    dataGridView2.Rows[i].SetValues(Users[currentUser].Cheques[i].Date, Users[currentUser].Cheques[i].ProductName, Users[currentUser].Cheques[i].CustomerType, Users[currentUser].Cheques[i].CustomerInn, Users[currentUser].Cheques[i].Price);
                }
            }
        }

        // закрытие формы
        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Close();
        }

        // Перебирает всех пользователей и пересчитывает их долг
        private void Calculate()
        {
            foreach (UserData u in Users)
            {

                if (u.Income > 0)
                {
                    double totalCredit = 0;
                    u.Income = 0;
                    foreach (Cheque c in u.Cheques)
                    {
                        if (DateTime.Parse(c.Date + " 0:00:00") > LastUpdate)
                        {
                            if (c.CustomerType == "ф")
                                totalCredit += double.Parse(c.Price) * 0.03;
                            else
                                totalCredit += double.Parse(c.Price) * 0.05;
                        }
                    }

                    if (totalCredit >= u.Bonus)
                    {
                        totalCredit -= u.Bonus;
                        u.Bonus = 0;
                    }
                    else
                    {
                        u.Bonus -= totalCredit;
                        totalCredit = 0;
                    }
                    DataBaseRequest.UploadUser(u);
                    EmailSender.Send(u);
                }
            }

            LastUpdate = DateTime.Now;
        }
    }
}
