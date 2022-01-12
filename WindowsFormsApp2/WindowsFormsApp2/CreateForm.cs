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
    public partial class CreateForm : Form
    {
        UserForm uForm;
        public CreateForm(UserForm userform)
        {
            InitializeComponent();

            uForm = userform;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Cheque ch = new Cheque();

            ch.CustomerInn = InnTextBox.Text;
            ch.ProductName = ProductNameTextBox.Text;
            ch.Price = PriceTextBox.Text;
            ch.Date = DateTime.Now.ToString().Split(' ')[0];

            if (radioButton2.Checked)
                ch.CustomerType = "ю";
            else
                ch.CustomerType = "ф";

            if (InputAnalysis.CheckCheque(ch))
            {
                uForm.AddCheque(ch);
                MessageBox.Show("Чек успешно создан");
                this.Close();
            }
            else
                MessageBox.Show("Данные указаны неверно");
        }
    }
}
