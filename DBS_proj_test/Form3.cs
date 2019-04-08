using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBS_proj_test
{
    public partial class login_form : Form
    {
        
        public login_form()
        {
            InitializeComponent();
            panel2.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            panel2.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void new_user_b_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel2.BringToFront();
        }
    }
}
