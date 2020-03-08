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
    public partial class Main : Form
    {
        public static string account = "";
        public static string password = "";
        public static int roles = 0;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            account = Login.account;
            password = Login.password;
            roles = Login.roles;
            lblAccount.Text = "Xin chào " + account;
            if (roles == 1)
            {
                lblLinkUpdateToInfoUser.Visible = true;
                UpdateAccountToolStripMenuItem.Visible = true;
            }
            
            this.userTableAdapter.Fill(this.userManagementDataSet.user);
            userBindingSource.DataSource = this.userManagementDataSet.user;

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                this.userTableAdapter.Fill(this.userManagementDataSet.user);
                userBindingSource.DataSource = this.userManagementDataSet.user;
            }
            else
            {
                var query = from a in this.userManagementDataSet.user
                            where a.UserID.Contains(txtSearch.Text) || a.UserName.Contains(txtSearch.Text) || a.Address.Contains(txtSearch.Text) || a.Email.Contains(txtSearch.Text) || a.Gender.Contains(txtSearch.Text)
                            select a;
                userBindingSource.DataSource = query.ToList();
            }
        }

        private void Logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void UpdateToInfoUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormUser user = new FormUser();
            user.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account acc = new Account();
            acc.Show();
        }
    }
}
