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
                    // ✅ 登入成功，建立使用者資料
                    CEmployee emp = new CEmployee
                    {
                        Adminname = reader["Adminname"].ToString(),
                        Password = reader["Password"].ToString()

                    };

                    MessageBox.Show("登入成功！");

                    // ✅ 設定 Session 的登入使用者
                    Session.LoggedInUser = emp;

                    // ✅ 將登入使用者傳給主畫面 Form1
                    Form1 mainForm = new Form1(emp);
                    mainForm.Show();

                    this.Hide(); // 隱藏登入表單
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
    }
}

