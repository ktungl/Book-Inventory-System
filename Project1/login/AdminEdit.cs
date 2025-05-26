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

namespace Project1.login
{
    public partial class AdminEdit : Form
    {
        SqlDataAdapter _adapter = null;
        SqlCommandBuilder _builder = null;

        private List<CEmployee> _listAdmin = null;

        private int _position = -1;

        public AdminEdit()
        {
            InitializeComponent();
        }
        private void Refresh()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=.;Initial Catalog=BookStore;Integrated Security=True";
            conn.Open();

            _adapter = new SqlDataAdapter("Select * from Admin", conn);
            _builder = new SqlCommandBuilder();
            _builder.DataAdapter = _adapter;

            DataSet ds = new DataSet();
            _adapter.Fill(ds);
            conn.Close();

            dataGridView1.DataSource = ds.Tables[0];
            _listAdmin = new List<CEmployee>();

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                CEmployee em= new CEmployee();
                em.Adminname = r["Adminname"].ToString();
                em.Email = r["Email"].ToString();
                em.EmployeeId = r["EmployeeID"].ToString();
                em.Password = r["Password"].ToString();
            }

            resetGridStyle();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.ShowDialog();
            if (!em.isOk)
                return;

            DataTable table = dataGridView1.DataSource as DataTable;
            DataRow row = table.NewRow();
            row["Adminname"] = em.employee.Adminname;
            row["Email"] = em.employee.Adminname;
            row["EmployeeId"] = em.employee.EmployeeId;
            row["Password"] = em.employee.Password;

            table.Rows.Add(row);
            _listAdmin.Add(em.employee);
            resetGridStyle();
            MessageBox.Show("新增資料完成");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void resetGridStyle()
        {

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            for (int i = 0; i <= 4; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            bool isColorChanged = false;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                r.DefaultCellStyle.Font = new Font("微軟正黑體", 13);
                r.Height = 35;
                r.DefaultCellStyle.BackColor = Color.MistyRose;
                isColorChanged = !isColorChanged;
                if (isColorChanged)
                {
                    r.DefaultCellStyle.BackColor = Color.FromArgb(237, 237, 237);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _position = e.RowIndex;
        }

        private void AdminEdit_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (_position < 0)
                return;
            DataTable table = dataGridView1.DataSource as DataTable;
            if (_position >= table.Rows.Count)
                return;
            DataRow row = table.Rows[_position];
            row.Delete();
            resetGridStyle();
            MessageBox.Show("刪除資料成功");
        }

        private void editCustomer()
        {
            if (_position < 0 || _position >= _listAdmin.Count)
                return;
            Employee em = new Employee();
            em.employee = _listAdmin[_position];
            em.ShowDialog();
            if (!em.isOk)
                return;
            DataTable table = dataGridView1.DataSource as DataTable;
            DataRow row = table.Rows[_position];
            row["Adminname"] = em.employee.Adminname;
            row["Email"] = em.employee.Adminname;
            row["EmployeeId"] = em.employee.EmployeeId;
            row["Password"] = em.employee.Password;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            editCustomer();
        }

        private void AdminEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable table = dataGridView1.DataSource as DataTable;
            _adapter.Update(table);
        }
    }
}
