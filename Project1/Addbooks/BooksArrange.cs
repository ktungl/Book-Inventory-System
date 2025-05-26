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
using Project1.login;

namespace Project1.Addbooks
{
    public partial class BooksArrange : Form
    {
        SqlDataAdapter _adapter = null;
        SqlCommandBuilder _builder = null;

        private List<BBook> _listBook = null;

        private int _position = -1;

        public BooksArrange()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=.;Initial Catalog=BookStore;Integrated Security=True";
            conn.Open();

            _adapter = new SqlDataAdapter("Select * from Books", conn);
            _builder = new SqlCommandBuilder();
            _builder.DataAdapter = _adapter;

            DataSet ds = new DataSet();
            _adapter.Fill(ds);
            conn.Close();

            dataGridView1.DataSource = ds.Tables[0];
            _listBook = new List<BBook>();

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                BBook bBook = new BBook();
                bBook.Title = r["Title"].ToString();
                bBook.Author = r["Author"].ToString();
                bBook.ISBN = r["ISBN"].ToString();
                bBook.Category = r["Category"].ToString();
                bBook.Price = Convert.ToInt32(r["Price"]);
                bBook.Stock = Convert.ToInt32(r["Stock"]);
                bBook.Description = r["Description"].ToString();
                if (r["Image"] != DBNull.Value)
                    bBook.Image = (byte[])r["Image"];
                _listBook.Add(bBook);
            }

            resetGridStyle();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddBooks a = new AddBooks();
            a.ShowDialog();
            if (!a.isOk)
                return;

            DataTable table = dataGridView1.DataSource as DataTable;
            DataRow row = table.NewRow();
            row["BookID"] = a.bbook.BookID;
            row["Title"] = a.bbook.Title;
            row["Author"] = a.bbook.Author;
            row["ISBN"] = a.bbook.ISBN;
            row["Category"] = a.bbook.Category;
            row["Price"] = (int)a.bbook.Price;
            row["Stock"] = (int)a.bbook.Stock;  
            row["Description"] = a.bbook.Description;
            row["Image"] = a.bbook.Image;
            table.Rows.Add(row);
            _listBook.Add(a.bbook);
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

            for (int i = 0; i <= 7; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
       
            dataGridView1.Columns[7].Width = 450; 
            DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dataGridView1.Columns[8];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

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

        private void BooksArrange_Load(object sender, EventArgs e)
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
            if (_position < 0 || _position >= _listBook.Count)
                return;
            AddBooks a = new AddBooks();
            a.bbook = _listBook[_position];
            a.ShowDialog();
            if (!a.isOk)
                return;
            DataTable table = dataGridView1.DataSource as DataTable;
            DataRow row = table.Rows[_position];
            row["BookID"] = a.bbook.BookID;
            row["Title"] = a.bbook.Title;
            row["Author"] = a.bbook.Author;
            row["ISBN"] = a.bbook.ISBN;
            row["Category"] = a.bbook.Category;
            row["Price"] = (int)a.bbook.Price;
            row["Stock"] = (int)a.bbook.Stock;
            row["Description"] = a.bbook.Description;
            row["Image"] = a.bbook.Image;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            editCustomer();
        }

        private void BooksArrange_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable table = dataGridView1.DataSource as DataTable;
            _adapter.Update(table);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
