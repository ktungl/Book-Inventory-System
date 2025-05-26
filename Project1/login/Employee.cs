using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project1.login
{
    public partial class Employee : Form
    {
        private bool _isOk;
        public bool isOk
        { get { return _isOk; }
            set { _isOk = value; }
        }

        private CEmployee _employee;
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        public CEmployee employee
        {
            get
            {
                if (_employee == null)
                    _employee = new CEmployee();
                _employee.fID = Convert.ToInt32(textBox5.Text);
                _employee.Adminname = textBox1.Text;
                _employee.Email = textBox3.Text;
                _employee.EmployeeId = textBox4.Text;
                _employee.Password = textBox2.Text;
                return _employee;
            }
            set { _employee = value; }
        }

        private void label5_Click(object sender, EventArgs e)
        {

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
    }
}
