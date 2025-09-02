using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.Addbooks
{
    public partial class fieldbox : UserControl
    {
        public void Clear()
        {
            this.fieldValue = "";
        }
        public fieldbox()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                this.label1.Font = value;
                this.textBox1.Font = value;
            }
        }

        public string fieldName
        {

            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public string fieldValue
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
