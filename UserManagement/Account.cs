using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManagement
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void Display()
        {
            this.accountTableAdapter.Fill(this.userManagementDataSet.account);
            ResetTextBox();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.accountTableAdapter.InsertQueryAccount(txtID.Text, txtAccount.Text, txtPassword.Text, Int32.Parse(txtRole.Text));
                accountBindingSource.MoveLast();
                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                MessageBox.Show("ID không được đển trống", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    this.accountTableAdapter.UpdateQueryAccount( txtAccount.Text, txtPassword.Text, Int32.Parse(txtRole.Text), txtID.Text);
                    Display();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("ID không được đển trống", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn là muốn xóa bản ghi không?", "Message", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    try
                    {
                        this.accountTableAdapter.DeleteQueryAccount(txtID.Text);
                        Display();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }  
            }
        }

        private void ResetTextBox()
        {
            txtAccount.Text = "";
            txtID.Text = Text = "";
            txtPassword.Text = "";
            txtRole.Text = "";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAccount.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); 
            txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtRole.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTextBox();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }
    }
}
