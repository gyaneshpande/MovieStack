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
            //textBox1.Clear();
            //textBox2.Clear();

        }
        public void clr_txtbox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
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

        private void login_button_Click(object sender, EventArgs e)
        {
            //login_button.Text = "test";
            
            
            if(textBox1.Text.Equals("admin") && textBox2.Text.Equals("password"))
            {
                MessageBox.Show("Login Successful");
                this.Hide();
            }
        }
    }
}
