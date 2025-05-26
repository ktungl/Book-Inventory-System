using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.BookStage
{
    public partial class Fiction : Form
    {
        public Fiction()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            Form1.GoToHome(this);
        }

    }
}

