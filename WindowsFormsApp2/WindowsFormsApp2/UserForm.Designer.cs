namespace WindowsFormsApp2
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditIndicator = new System.Windows.Forms.Button();
            this.AskButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.PayButton = new System.Windows.Forms.Button();
            this.BonusIndicator = new System.Windows.Forms.Button();
            this.UserNameIndicator = new System.Windows.Forms.Button();
            this.DateLine = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.DateLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.ProductName,
            this.Price,
            this.Customer});
            this.dataGridView1.Location = new System.Drawing.Point(9, 130);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(448, 353);
            this.dataGridView1.TabIndex = 5;
            // 
            // Date
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Date.DefaultCellStyle = dataGridViewCellStyle2;
            this.Date.HeaderText = "дата";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 125;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Название товара";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 125;
            // 
            // Price
            // 
            this.Price.HeaderText = "Сумма сделки";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Покупатель";
            this.Customer.MinimumWidth = 6;
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            this.Customer.Width = 125;
            // 
            // CreditIndicator
            // 
            this.CreditIndicator.Enabled = false;
            this.CreditIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreditIndicator.Location = new System.Drawing.Point(9, 77);
            this.CreditIndicator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CreditIndicator.Name = "CreditIndicator";
            this.CreditIndicator.Size = new System.Drawing.Size(315, 49);
            this.CreditIndicator.TabIndex = 6;
            this.CreditIndicator.Text = "Задолженность: 0р";
            this.CreditIndicator.UseVisualStyleBackColor = true;
            // 
            // AskButton
            // 
            this.AskButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AskButton.Location = new System.Drawing.Point(233, 488);
            this.AskButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AskButton.Name = "AskButton";
            this.AskButton.Size = new System.Drawing.Size(224, 49);
            this.AskButton.TabIndex = 7;
            this.AskButton.Text = "Задать вопрос";
            this.AskButton.UseVisualStyleBackColor = true;
            // 
            // CreateButton
            // 
            this.CreateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateButton.Location = new System.Drawing.Point(9, 548);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(448, 49);
            this.CreateButton.TabIndex = 8;
            this.CreateButton.Text = "Новая продажа";
            this.CreateButton.UseVisualStyleBackColor = true;
            // 
            // PayButton
            // 
            this.PayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PayButton.Location = new System.Drawing.Point(328, 77);
            this.PayButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PayButton.Name = "PayButton";
            this.PayButton.Size = new System.Drawing.Size(127, 49);
            this.PayButton.TabIndex = 9;
            this.PayButton.Text = "Оплатить";
            this.PayButton.UseVisualStyleBackColor = true;
            // 
            // BonusIndicator
            // 
            this.BonusIndicator.Enabled = false;
            this.BonusIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BonusIndicator.Location = new System.Drawing.Point(9, 488);
            this.BonusIndicator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BonusIndicator.Name = "BonusIndicator";
            this.BonusIndicator.Size = new System.Drawing.Size(220, 49);
            this.BonusIndicator.TabIndex = 10;
            this.BonusIndicator.Text = "Бонус: 10000р";
            this.BonusIndicator.UseVisualStyleBackColor = true;
            // 
            // UserNameIndicator
            // 
            this.UserNameIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.UserNameIndicator.Location = new System.Drawing.Point(9, 13);
            this.UserNameIndicator.Name = "UserNameIndicator";
            this.UserNameIndicator.Size = new System.Drawing.Size(446, 59);
            this.UserNameIndicator.TabIndex = 11;
            this.UserNameIndicator.Text = "Здравствуйте, ";
            this.UserNameIndicator.UseVisualStyleBackColor = true;
            // 
            // DateLine
            // 
            this.DateLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.DateLine.Location = new System.Drawing.Point(0, 596);
            this.DateLine.Name = "DateLine";
            this.DateLine.Size = new System.Drawing.Size(468, 22);
            this.DateLine.TabIndex = 12;
            this.DateLine.Text = "Текущая дата: ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel1.Text = "Текущая дата: ";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 618);
            this.Controls.Add(this.DateLine);
            this.Controls.Add(this.UserNameIndicator);
            this.Controls.Add(this.BonusIndicator);
            this.Controls.Add(this.PayButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.AskButton);
            this.Controls.Add(this.CreditIndicator);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(484, 657);
            this.MinimumSize = new System.Drawing.Size(484, 657);
            this.Name = "UserForm";
            this.Text = "Плати налог";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.DateLine.ResumeLayout(false);
            this.DateLine.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CreditIndicator;
        private System.Windows.Forms.Button AskButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button PayButton;
        private System.Windows.Forms.Button BonusIndicator;
        private System.Windows.Forms.Button UserNameIndicator;
        private System.Windows.Forms.StatusStrip DateLine;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}