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

namespace Project1.Customer
{
    public partial class CustomerArrange : UserControl
    {

        SqlDataAdapter _adapter = null;
        SqlCommandBuilder _builder = null;

        private List<CCustomer> _listCustomer = null;

        private int _position = -1;

        public CustomerArrange()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            queryBySql("Select * From Customer", null);

            resetGridStyle();
        }

        private void queryBySql(string sql, SqlParameter para)
        {
            string connStr = @"Data Source=.;Initial Catalog=BookStore;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                if (para != null)
                {
                    cmd.Parameters.Add(para);
                }

                _adapter = new SqlDataAdapter(cmd);
                _builder = new SqlCommandBuilder(_adapter);

                
                _adapter.UpdateCommand = _builder.GetUpdateCommand();
                _adapter.UpdateCommand.Connection = new SqlConnection(connStr);

                _adapter.InsertCommand = _builder.GetInsertCommand();
                _adapter.InsertCommand.Connection = new SqlConnection(connStr);

                _adapter.DeleteCommand = _builder.GetDeleteCommand();
                _adapter.DeleteCommand.Connection = new SqlConnection(connStr);

                DataSet ds = new DataSet();
                _adapter.Fill(ds);
                DataTable table = ds.Tables[0];
                table.PrimaryKey = new DataColumn[] { table.Columns["fID"] };  

                dataGridView1.DataSource = table;

                _listCustomer = new List<CCustomer>();
                foreach (DataRow r in table.Rows)
                {
                    CCustomer user = new CCustomer();
                    user.Name = r["Name"].ToString();
                    user.Email = r["Email"].ToString();
                    user.Phone = r["Phone"].ToString();
                    user.Address = r["Address"].ToString();
                    user.MemberID = r["MemberID"].ToString();
                    user.fID = Convert.ToInt32(r["fID"]);

                    _listCustomer.Add(user);
                }
            }
        }

        private void editCustomer()
        {
            if (_position < 0 || _position >= _listCustomer.Count)
                return;
            CustomerEdit a = new CustomerEdit();
            a.customer= _listCustomer[_position];
            a.ShowDialog();
            if (!a.isOk)
                return;
            DataTable table = dataGridView1.DataSource as DataTable;
            DataRow row = table.Rows[_position];
            row["MemberID"] = a.customer.MemberID;
            row["Name"] = a.customer.Name;
            row["Email"] = a.customer.Email;
            row["Phone"] = a.customer.Phone;
            row["Address"] = a.customer.Address;

            try
            {
                _adapter.Update(table);
              
                _listCustomer[_position] = a.customer;
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新資料失敗: " + ex.Message);
            }

            resetGridStyle();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CustomerEdit a = new CustomerEdit();
            a.ShowDialog();
            if (!a.isOk)
                return;


            DataTable table = dataGridView1.DataSource as DataTable;
            DataRow row = table.NewRow();
            row["MemberID"] = a.customer.MemberID;
            row["Name"] = a.customer.Name;
            row["Email"] = a.customer.Email;
            row["Phone"] = a.customer.Phone;
            row["Address"] = a.customer.Address;

            table.Rows.Add(row);
            _listCustomer.Add(a.customer);
            resetGridStyle();
            MessageBox.Show("新增資料完成");

            _adapter.Update(table);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Refresh();
            resetGridStyle();
        }

        private void resetGridStyle()
        {

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            for (int i = 0; i <= 5; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            dataGridView1.Columns[4].Width = 450;
       

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

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _position = e.RowIndex;
        }

        private void Customer_Load(object sender, EventArgs e)
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

            
            try
            {
                _adapter.Update(table);  
                MessageBox.Show("刪除資料成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("刪除資料失敗: " + ex.Message);
            }

            resetGridStyle();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            editCustomer();
            resetGridStyle();
        }

        private void Customer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable table = dataGridView1.DataSource as DataTable;
            _adapter.Update(table);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Customer WHERE ";
            sql += " Name LIKE @K_KEYWORD";
            sql += " OR Email LIKE @K_KEYWORD";
            sql += " OR Phone LIKE @K_KEYWORD";

            SqlParameter para = new SqlParameter("@K_KEYWORD", "%" + (object)tbSearch.Text + "%");
            queryBySql(sql, para);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            editCustomer();
            resetGridStyle();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            resetGridStyle();
        }
    }
}
