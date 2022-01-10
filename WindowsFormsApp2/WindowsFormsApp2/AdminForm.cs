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
        

        public AdminForm(DataTable userData)
        {
            InitializeComponent();
            
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
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].Width = globalWidth / dataGridView1.ColumnCount;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
