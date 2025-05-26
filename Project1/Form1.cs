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
using Project1.login;
using Project1.Orders;

namespace Project1
{
    public partial class Form1 : Form
    {
        public static List<BBook> AllBooks = new List<BBook>();

        public Fiction fFiction = new Fiction();
        public SocialS science = new SocialS();

        public Form1()
        {
            InitializeComponent();
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {

            if (_loggedInUser != null)
            {
                labelWelcome.Text = "歡迎：" + _loggedInUser.Adminname;
                buttonLogin.Visible = false;
                labelWelcome.Visible = true;

                // ✅ 只有登入後才啟用新增員工按鈕
                button2.Enabled = true;
                button3.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                buttonLogin.Visible = true;
                labelWelcome.Visible = false;

                // ⛔ 沒登入就禁用新增員工按鈕
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = false;
            }

            
        }


 
        public static void GoToHome(Form currentForm)
        {
            Form1 home = new Form1();
            home.Show();
            currentForm.Close();
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();

         
        }



        private void label3_Click(object sender, EventArgs e)
        {
           
        }




        private void label8_Click(object sender, EventArgs e)
        {
         
        }

        private CEmployee _loggedInUser = null;

        // 新增一個建構式（接收登入使用者）
        public Form1(CEmployee user)
        {
            InitializeComponent();
            _loggedInUser = user;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AdminEdit a = new AdminEdit();
            a.Show();

            if (Session.LoggedInUser != null)
            {
                labelWelcome.Text = "歡迎：" + Session.LoggedInUser.Adminname;
                buttonLogin.Visible = false;
            }

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
            cmd.Parameters.Add(new SqlParameter("K_PASSWORDE", (object)p.Password));
            cmd.Parameters.Add(new SqlParameter("K_FEMAIL", (object)p.Email));
            cmd.Parameters.Add(new SqlParameter("K_EMPLOYEEID", (object)p.EmployeeId));
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            conn.Close();

        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            BooksArrange a = new BooksArrange();
            a.Show();

            if (Session.LoggedInUser != null)
            {
                labelWelcome.Text = "歡迎：" + Session.LoggedInUser.Adminname;
                buttonLogin.Visible = false;
            }

            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SocialS g = new SocialS();
            g.Show();

         
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Fiction g = new Fiction();
            g.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            OrdersArrange a = new OrdersArrange();
            a.Show();

            if (Session.LoggedInUser != null)
            {
                labelWelcome.Text = "歡迎：" + Session.LoggedInUser.Adminname;
                buttonLogin.Visible = false;
            }
        }
    }
}
