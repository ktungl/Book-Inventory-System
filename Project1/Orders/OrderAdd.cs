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

namespace Project1.Orders
{
    public partial class OrderAdd : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=BookStore;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int qty = 0;

        public OrderAdd()
        {
            InitializeComponent();
            InitializeCustomerGrid();
            InitializeProductGrid();
            LoadCustomer();
            LoadProduct();

        }
        private void InitializeCustomerGrid()
        {
            dgvCustomer.Columns.Clear();

            dgvCustomer.Columns.Add("fID", "No");
            dgvCustomer.Columns.Add("MemberID", "會員編號");
            dgvCustomer.Columns.Add("Name", "姓名");

            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void InitializeProductGrid()
        {
            dgvProduct.Columns.Clear();

            dgvProduct.Columns.Add("No", "No");
            dgvProduct.Columns.Add("BookID", "書號");
            dgvProduct.Columns.Add("Title", "書名");
            dgvProduct.Columns.Add("Author", "作者");
            dgvProduct.Columns.Add("ISBN", "ISBN");
            dgvProduct.Columns.Add("Category", "類別");
            dgvProduct.Columns.Add("Price", "價格");
            dgvProduct.Columns.Add("Stock", "庫存");
            dgvProduct.Columns.Add("Descroption", "介紹");

            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();

            string query = "SELECT * FROM Books WHERE Title LIKE @search OR Author LIKE @search OR Category LIKE @search";
            cm = new SqlCommand(query, conn);
            cm.Parameters.AddWithValue("@search", "%" + txtSearchPro.Text + "%");

            conn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr["BookID"].ToString(), dr["Title"].ToString(), dr["Author"].ToString(),
                                    dr["ISBN"].ToString(), dr["Category"].ToString(), dr["Price"].ToString(),
                                    dr["Stock"].ToString(), dr["Description"].ToString());
            }
            dr.Close();
            conn.Close();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("Select MemberID, Name From Customer Where CONCAT(MemberID, Name) LIKE @search", conn);
            cm.Parameters.AddWithValue("@search", "%" + txtSearchCust.Text + "%");
            conn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            conn.Close();
        }




        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchPro_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }



        private void GetQty()
        {
            using (SqlCommand cm = new SqlCommand("SELECT Stock FROM Books WHERE BookID = @BookID", conn))
            {
                cm.Parameters.AddWithValue("@BookID", txtBID.Text);

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlDataReader dr = cm.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        qty = Convert.ToInt32(dr["Stock"]);
                    }
                }

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCID.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtcName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBID.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtBTitle.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCID.Text == "")
                {
                    MessageBox.Show("請選擇客戶!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtBID.Text == "")
                {
                    MessageBox.Show("請選擇書籍!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("確定要新增本筆訂單嗎?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO Orders(MemberID, OrderDate, TotalAmount, BookID, Qty, Price, Name, BookTitle) " +
                     "VALUES(@MemberID, @OrderDate, @TotalAmount, @BookID, @Qty, @Price, @Name, @BookTitle)", conn);

                    cm.Parameters.AddWithValue("@OrderDate", dtOrder.Value);
                    cm.Parameters.AddWithValue("@BookID", Convert.ToInt32(txtBID.Text));
                    cm.Parameters.AddWithValue("@MemberID", Convert.ToInt32(txtCID.Text));
                    cm.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                    cm.Parameters.AddWithValue("@TotalAmount", Convert.ToInt32(txtTotal.Text));
                    cm.Parameters.AddWithValue("@Name", txtcName.Text);
                    cm.Parameters.AddWithValue("@BookTitle", txtBTitle.Text);
                    cm.Parameters.AddWithValue("@Qty", Convert.ToInt32(UDQty.Value));

                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("成功新增");

                    cm = new SqlCommand("UPDATE Books SET Stock = Stock - @Stock WHERE BookID = @BookID", conn);
                    cm.Parameters.AddWithValue("@Stock", Convert.ToInt32(UDQty.Value));
                    cm.Parameters.AddWithValue("@BookID", txtBID.Text);

                    conn.Open();
                    cm.ExecuteNonQuery();
                    conn.Close();
                    Clear();
                    LoadProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     



        private void Clear()
        {
            txtCID.Clear();
            txtcName.Clear();

            txtBID.Clear();
            txtBTitle.Clear();

            txtPrice.Clear();
            UDQty.Value = 0;
            txtTotal.Clear();
            dtOrder.Value = DateTime.Now;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtBTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void UDQty_ValueChanged_1(object sender, EventArgs e)
        {
            GetQty();
            if (Convert.ToInt16(UDQty.Value) > qty)
            {
                MessageBox.Show("剩餘數量不足!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UDQty.Value = UDQty.Value - 1;
                return;
            }
            if (Convert.ToInt16(UDQty.Value) > 0)
            {
                int total = Convert.ToInt16(txtPrice.Text) * Convert.ToInt16(UDQty.Value);
                txtTotal.Text = total.ToString();
            }

        }
    }

}

