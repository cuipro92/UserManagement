using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManagement
{
    public partial class Login : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public static string account = "";
        public static string password = "";
        public static int roles = 0;
        
        public Login()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            con = new MySqlConnection("Server=localhost;Database=user_management;user=root;Pwd=123456;SslMode=none");
           
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM account where Account='" + txtAccount.Text + "' AND Password='" + txtPassword.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                account = dr["Account"].ToString();
                password = dr["Password"].ToString();
                roles = int.Parse(dr["Roles"].ToString());
                //string roles = 
                this.Hide();
                Main main = new Main();
                main.Show();
                
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại, xin kiểm tra lại tài khoản và mật khẩu !!!");
            }
            con.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
