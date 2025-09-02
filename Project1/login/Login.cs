using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        


            private void button1_Click(object sender, EventArgs e)
        {
            string acc = fAccount.Text.Trim();
            string pwd = fPassword.Text.Trim();

            string sql = "SELECT * FROM Admin WHERE Adminname = @acc AND Password = @pwd";

            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=BookStore;Integrated Security=True"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@acc", acc);
                cmd.Parameters.AddWithValue("@pwd", pwd);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    CEmployee emp = new CEmployee
                    {
                        Adminname = reader["Adminname"].ToString(),
                        Password = reader["Password"].ToString(),
                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                    };

                    Session.LoggedInUser = emp;

                    this.DialogResult = DialogResult.OK; // ✅ 回傳結果，關閉表單
                    this.Close(); // ✅ 關閉 Login 表單
                }
                else
                {
                    MessageBox.Show("帳號或密碼錯誤！");
                }

                reader.Close();
            }

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            fPassword.UseSystemPasswordChar = !fPassword.UseSystemPasswordChar;

            if (fPassword.UseSystemPasswordChar)
            {
                btnTogglePassword.Text = "👁"; // 顯示
            }
            else
            {
                btnTogglePassword.Text = "👁‍🗨"; // 隱藏
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

