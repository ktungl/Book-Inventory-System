using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.Customer
{
    public partial class CustomerEdit : Form
    {
        private bool _isOk;
        public bool isOk
        {
            get { return _isOk; }
            set { _isOk = value; }
        }

        private CCustomer _customer;

        public CustomerEdit()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        public CCustomer customer
        {
            get
            {
                if (this._customer == null) 
                    _customer = new CCustomer();
                _customer.MemberID = textBox6.Text;
                _customer.Name = textBox1.Text;
                _customer.Email = textBox3.Text;
                _customer.Phone = textBox4.Text;
                _customer.Address = textBox2.Text;
                return _customer;
            }
            set { _customer = value;
                if (this._customer != null)
                {
                    textBox6.Text = _customer.MemberID;
                    textBox1.Text = _customer.Name;
                    textBox3.Text = _customer.Email;
                    textBox4.Text = _customer.Phone;
                    textBox2.Text = _customer.Address;
                }
            
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _isOk = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
