using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project1.Addbooks
{
    public partial class AddBooks : Form
    {


        private bool _isOk;
        private BBook _bbook;

        public bool isOk
        {
            get { return _isOk; }
            set { _isOk = value; }

        }


        public BBook bbook
        {

            get
            {
                if (_bbook == null)
                    _bbook = new BBook();


                _bbook.BookID = Convert.ToInt32(fbBookID.fieldValue);
                _bbook.Title = fbTitle.fieldValue;
                _bbook.Author = fbAuthor.fieldValue;
                _bbook.ISBN = fbISBN.fieldValue;
                _bbook.Category = cbCategory.Text;
                _bbook.Price = Convert.ToInt32(fbPrice.fieldValue);
                _bbook.Stock = Convert.ToInt32(fbStock.fieldValue);
                _bbook.Description = fbDes.fieldValue;
                return _bbook;
            }
            set
            {
                _bbook= value;
                fbBookID.fieldValue = _bbook.BookID.ToString();
                fbTitle.fieldValue = _bbook.Title;
                fbAuthor.fieldValue = _bbook.Author;
                fbISBN.fieldValue = _bbook.ISBN;
                cbCategory.Text = _bbook.Category;
                fbPrice.fieldValue = _bbook.Price.ToString();
                fbStock.fieldValue= _bbook.Stock.ToString();
                fbDes.fieldValue = _bbook.Description;
                if (_bbook.Image == null)
                    return;
                try
                {
                    Stream streamImage = new MemoryStream(_bbook.Image);
                    Cover1.Image = Bitmap.FromStream(streamImage);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("無法載入書籍封面照片:");
                }

               
            }
        }
        public AddBooks()
        {
            InitializeComponent();

        }

        private void ValidateNumberOnLeave(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            int val;
            if (!int.TryParse(tb.Text, out val))
            {
                MessageBox.Show("請輸入數字！");
                tb.SelectAll();
                e.Cancel = true; 
            }
        }

        private bool isValidated()
        {
            string s = "";
            if (string.IsNullOrEmpty(fbTitle.fieldValue))
                s += "\r\n書名是必填欄位";
            if (string.IsNullOrEmpty(fbAuthor.fieldValue))
                s += "\r\n作者是必填欄位";
            if (string.IsNullOrEmpty(fbISBN.fieldValue))
                s += "\r\nISBN是必填欄位";
            if(string.IsNullOrEmpty(cbCategory.Text))
                s += "\r\n類別是必選欄位";
            if (string.IsNullOrEmpty(fbPrice.fieldValue))
                s += "\r\n價格是必填欄位";
            if (string.IsNullOrEmpty(fbStock.fieldValue))
                s += "\r\n數量是必填欄位";
            if (string.IsNullOrEmpty(fbDes.fieldValue))
                s += "\r\n介紹是必填欄位";
            if (_bbook.Image == null || _bbook.Image.Length == 0)
                s += "\r\n書籍封面必需上傳";
            if (!string.IsNullOrEmpty(s))
            {
                MessageBox.Show(s);
                return false;
            }
            return true;
        }

        private void fieldbox1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isValidated())
                return;
            _isOk = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cover1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "書籍封面 (*.jpg; *.png)|*.jpg;*.png";

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            Image b = Bitmap.FromFile(openFileDialog1.FileName);
            Cover1.Image = b;

            if (_bbook == null)
                _bbook = new BBook();

            try
            {
                using (FileStream imgStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader reader = new BinaryReader(imgStream))
                    {
                        _bbook.Image = reader.ReadBytes((int)imgStream.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("圖片讀取失敗");
            }
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }
    }
}
