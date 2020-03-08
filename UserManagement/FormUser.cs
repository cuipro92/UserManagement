using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManagement
{
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void ResetTextBox()
        {
            txtID.Text = "";
            txtUserName.Text = "";
            //txtBirthday.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtGender.Text = "";
            
        }
        private void Display()
        {
            this.userTableAdapter.Fill(this.userManagementDataSet.user);
            ResetTextBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.userTableAdapter.InsertQueryUser(txtID.Text, txtUserName.Text, DateTime.ParseExact(dateTimePicker1.Text, "yyyy-MM-dd", null), txtAddress.Text, txtEmail.Text, txtGender.Text) ;
                userBindingSource.MoveLast();
                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("ID không được đển trống", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    this.userTableAdapter.UpdateQueryUser(txtUserName.Text, DateTime.ParseExact(dateTimePicker1.Text, "yyyy-MM-dd", null), txtAddress.Text, txtEmail.Text, txtGender.Text,txtID.Text);
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
                if (MessageBox.Show("Bạn có chắc chắn là muốn xóa bản ghi không?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this.userTableAdapter.DeleteQueryUser(txtID.Text);
                        Display();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTextBox();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUserName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //txtBirthday.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtGender.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }
    }
}
