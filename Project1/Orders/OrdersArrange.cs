using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.Orders
{
    public partial class OrdersArrange : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=BookStore;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;


        public OrdersArrange()
        {
            InitializeComponent();
         

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OrderAdd f = new OrderAdd();
            f.ShowDialog();
            LoadOrder();

        }

        public void LoadOrder()
        {
            double total = 0;
            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT OrderID, Orderdate, O.BookID, P.Title, O.MemberID, C.Name, Qty, P.Price, TotalAmount " +
                    "FROM Orders AS O " +
                    "JOIN Customer AS C ON O.MemberID = C.MemberID " +
                    "JOIN Books AS P ON O.BookID = P.BookID " +
                    "WHERE CONCAT(OrderID, Orderdate, O.BookID, P.Title, O.MemberID, C.Name, Qty, P.Price) LIKE @search", con);
            cm.Parameters.AddWithValue("@search", "%" + tbSearch.Text + "%");

            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), Convert.ToDouble(dr[8]).ToString("N2"));
                
                if (double.TryParse(dr[8].ToString(), out double amount))
                {
                    total += amount;
                }
            }
            dr.Close();
            con.Close();

            label1.Text = i.ToString();
            label2.Text = total.ToString("N2");

            dgvOrder.Columns["colBookId"].ReadOnly = false;
            dgvOrder.Columns["colMemberId"].ReadOnly = false;
            dgvOrder.Columns["colQty"].ReadOnly = false;
            dgvOrder.Columns["colPrice"].ReadOnly = false;
            dgvOrder.Columns["colTotal"].ReadOnly = true;
        }





        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }





        private void OrdersArrange_Load(object sender, EventArgs e)
        {
            dgvOrder.ReadOnly = false;
            dgvOrder.AllowUserToAddRows = false;
            dgvOrder.EditMode = DataGridViewEditMode.EditOnEnter;

            this.dgvOrder.CellValueChanged += dgvOrder_CellValueChanged;
            this.dgvOrder.CellEndEdit += dgvOrder_CellEndEdit;
           

            if (dgvOrder.Columns.Count == 0)
            {
                dgvOrder.Columns.Add("colNo", "編號");
                dgvOrder.Columns.Add("colOrderId", "訂單ID");
                dgvOrder.Columns.Add("colDate", "日期");
                dgvOrder.Columns.Add("colBookId", "書籍ID");
                dgvOrder.Columns.Add("colTitle", "書名");
                dgvOrder.Columns.Add("colMemberId", "會員ID");
                dgvOrder.Columns.Add("colName", "會員名稱");
                dgvOrder.Columns.Add("colQty", "數量");
                dgvOrder.Columns.Add("colPrice", "單價");
                dgvOrder.Columns.Add("colTotal", "總金額");

                if (!dgvOrder.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                    deleteBtn.Name = "Delete";
                    deleteBtn.HeaderText = "刪除";
                    deleteBtn.Text = "刪除";
                    deleteBtn.UseColumnTextForButtonValue = true;
                    dgvOrder.Columns.Add(deleteBtn);
                }
            }

            // 初始化完欄位後，再載入資料
            LoadOrder();

      
        }

        private void dgvOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvOrder_CellValueChanged(sender, e);
        }

        private void dgvOrder_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this order?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM Orders WHERE OrderID = @OrderID", con);
                    cm.Parameters.AddWithValue("@OrderID", dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");

                    cm = new SqlCommand("UPDATE Books SET Stock = Stock + @Stock WHERE BookID = @BookID", con);
                    cm.Parameters.AddWithValue("@Stock", Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[7].Value.ToString()));  // Qty
                    cm.Parameters.AddWithValue("@BookID", dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString());


                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                }
            }
            LoadOrder();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvOrder.Rows)
                {
                    if (row.IsNewRow) continue;

                    string orderId = row.Cells["colOrderId"].Value?.ToString();
                    string bookId = row.Cells["colBookId"].Value?.ToString();
                    string memberId = row.Cells["colMemberId"].Value?.ToString();
                    string qty = row.Cells["colQty"].Value?.ToString();
                    string price = row.Cells["colPrice"].Value?.ToString();
                    string total = row.Cells["colTotal"].Value?.ToString();

                    using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=BookStore;Integrated Security=True"))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Orders SET BookID = @BookID, MemberID = @MemberID, Qty = @Qty, Price = @Price, TotalAmount = @TotalAmount WHERE OrderID = @OrderID", con);
                        cmd.Parameters.AddWithValue("@OrderID", orderId);
                        cmd.Parameters.AddWithValue("@BookID", bookId);
                        cmd.Parameters.AddWithValue("@MemberID", memberId);
                        cmd.Parameters.AddWithValue("@Qty", qty);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@TotalAmount", total);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("修改已儲存！");
                LoadOrder(); // 重新載入最新資料
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存錯誤：" + ex.Message);
            }
        }

        private void dgvOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvOrder.Rows[e.RowIndex];
                if (dgvOrder.Columns[e.ColumnIndex].Name == "colQty" || dgvOrder.Columns[e.ColumnIndex].Name == "colPrice")
                {
                    if (int.TryParse(row.Cells["colQty"].Value?.ToString(), out int qty) &&
                        decimal.TryParse(row.Cells["colPrice"].Value?.ToString(), out decimal price))
                    {
                        row.Cells["colTotal"].Value = (qty * price).ToString("N2");
                    }
                }
            }
        }
    }
}



