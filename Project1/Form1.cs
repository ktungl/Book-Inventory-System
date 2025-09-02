using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project1.Addbooks;
using Project1.BookStage;
using Project1.Customer;
using Project1.login;
using Project1.Orders;

namespace Project1
{
    public partial class Form1 : Form
    {
      
     

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadUserControl(UserControl uc)
        {
            mainPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(uc);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            if (_loggedInUser != null)
            {
                labelWelcome.Text = "Welcome：" + _loggedInUser.Adminname;
                labelWelcome.Font = new Font("Arial", 12, FontStyle.Italic);
                buttonLogin.Visible = false;
                labelWelcome.Visible = true;

                // ✅ 只有登入後才啟用新增員工按鈕
                button2.Enabled = true;
                button3.Enabled = true;
                button1.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                buttonLogin.Visible = true;
                labelWelcome.Visible = false;

                // ⛔ 沒登入就禁用新增員工按鈕
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = false;
                button4.Enabled = false;
            }

            
        }


 
        public static void GoToHome(Form currentForm)
        {
            Form1 home = new Form1();
            home.Show();
            currentForm.Close();
        }




        private CEmployee _loggedInUser = null;

        // 新增一個建構式（接收登入使用者）
        public Form1(CEmployee user)
        {
            InitializeComponent();
            _loggedInUser = user;
        }




        private void createEmployee(CEmployee p)
        {
            

            string sql = "INSERT INTO Admin(";
            sql += " Adminname,";
            sql += " Password,";
            sql += " Email,";
            sql += " EmployeeId";
            sql += ")Values(";
            sql += "@K_ADMINNAME,";
            sql += " @K_PASSWORD,";
            sql += " @K_EMAIL,";
            sql += "@K_EMPLOYEEID)";


            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=.;Initial Catalog=BookStore;Integrated Security=True";
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.Parameters.Add(new SqlParameter("K_ADMINNAME", (object)p.Adminname));
            cmd.Parameters.Add(new SqlParameter("K_PASSWORD", (object)p.Password));
            cmd.Parameters.Add(new SqlParameter("K_FEMAIL", (object)p.Email));
            cmd.Parameters.Add(new SqlParameter("K_EMPLOYEEID", (object)p.EmployeeId));
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            conn.Close();

        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }





        private void button1_Click_1(object sender, EventArgs e)
        {

            LoadUserControl(new OrdersArrange());
           

            if (Session.LoggedInUser != null)
            {
                labelWelcome.Text = "Welcome：" + Session.LoggedInUser.Adminname;
                labelWelcome.Font = new Font("Arial", 12, FontStyle.Italic); 
                buttonLogin.Visible = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadUserControl(new BooksArrange());

            if (Session.LoggedInUser != null)
            {
                labelWelcome.Text = "Welcome：" + Session.LoggedInUser.Adminname;
                labelWelcome.Font = new Font("Arial", 12, FontStyle.Italic); 
             
                buttonLogin.Visible = false;
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            LoadUserControl(new CustomerArrange());


            if (Session.LoggedInUser != null)
            {
                labelWelcome.Text = "Welcome：" + Session.LoggedInUser.Adminname;
                labelWelcome.Font = new Font("Arial", 12, FontStyle.Italic); 
 
                buttonLogin.Visible = false;
            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            LoadUserControl(new OrdersArrange());

            if (Session.LoggedInUser != null)
            {
                labelWelcome.Text = "Welcome：" + Session.LoggedInUser.Adminname;
                labelWelcome.Font = new Font("Arial", 12, FontStyle.Italic); 
       
                buttonLogin.Visible = false;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Session.LoggedInUser != null)
            {
                labelWelcome.Text = "Welcome：" + Session.LoggedInUser.Adminname;
                labelWelcome.Font = new Font("Arial", 12, FontStyle.Italic);

                buttonLogin.Visible = false;

                if (Session.LoggedInUser.IsAdmin)
                {
                    // ✅ 只有是管理員才載入 AdminEdit 畫面
                    LoadUserControl(new AdminEdit());
                }
                else
                {
                    // ❌ 一般使用者不載入畫面，只顯示警告
                    MessageBox.Show("您沒有權限進入員工管理系統！", "權限不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            LoadUserControl(new BookDisplay());
        }

        private void labelWelcome_Click_1(object sender, EventArgs e)
        {

        }
    }
}
