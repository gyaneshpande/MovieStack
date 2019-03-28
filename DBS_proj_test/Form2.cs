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
    public partial class Form2 : Form
    {      
        public Form2()
        {
            InitializeComponent();
            //this.tab_p.Hide();
            timer1.Interval = 05;
            timer1.Start();
            button5.Location = new Point(button5.Location.X + button5.Width + 30,button5.Location.Y);
        }
        //login_form lf1 = new login_form();
        
        
       


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void movie_b_Click(object sender, EventArgs e)
        {
            
            this.tab_p.Show();
            tab_p.Size = movie_b.Size;
            tab_p.Left = movie_b.Left;
            tab_p.Height = 15;
            
        }

        private void tvshows_b_Click(object sender, EventArgs e)
        {
            this.tab_p.Show();
            tab_p.Size = tvshows_b.Size;
            tab_p.Left = tvshows_b.Left;
            tab_p.Height = 15;
            TVshows f1 = new TVshows();
            f1.Show();
            


        }

        private void watchlist_b_Click(object sender, EventArgs e)
        {
            this.tab_p.Show();
            tab_p.Size = watchlist_b.Size;
            tab_p.Left = watchlist_b.Left;
            tab_p.Height = 15;
        }

        private void searchbar_TextChanged(object sender, EventArgs e)
        {
            //searchbar.Text = null;
            searchbar.Font = new Font("Century", 10);
            searchbar.ForeColor = panel1.ForeColor;
           // searchbar.Font = new Font()
        }

        private void fb_b_Click(object sender, EventArgs e)
        {

        }

        private void Form2_MouseHover(object sender, EventArgs e)
        {

        }

        private void searchbar_Click(object sender, EventArgs e)
        {
            this.searchbar.Text = null;
        }

        private void signin_b_Click(object sender, EventArgs e)
        {
            tab_p.Hide();
            login_form lf1 = new login_form();
            lf1.Show();
            //lf1.
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Location = new Point(button1.Location.X - 1, button1.Location.Y);
            button2.Location = new Point(button2.Location.X - 1, button2.Location.Y);
            button3.Location = new Point(button3.Location.X - 1, button3.Location.Y);
            button4.Location = new Point(button4.Location.X - 1, button4.Location.Y);
            button5.Location = new Point(button5.Location.X - 1, button5.Location.Y);
        }

        private void button1_LocationChanged(object sender, EventArgs e)
        {
            if (button1.Right + button1.Width <= panel2.Left )
            {
                button1.Left = panel2.Width;            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String name = null;
            //if (sender is Button)
            //    name = (sender as Button).Name;
            //MessageBox.Show(name);
        }

        private void button2_LocationChanged(object sender, EventArgs e)
        {
            if (button2.Right + button2.Width <= panel2.Left)
            {
                button2.Left = panel2.Width;
               
            }
        }

        private void button3_LocationChanged(object sender, EventArgs e)
        {
            if (button3.Right + button3.Width <= panel2.Left)
            {
                button3.Left = panel2.Width;
            }
        }

        private void button4_LocationChanged(object sender, EventArgs e)
        {
            if (button4.Right + button4.Width <= panel2.Left)
            {
                button4.Left = panel2.Width;
            }
        }

        private void button5_LocationChanged(object sender, EventArgs e)
        {
            if (button5.Right + button5.Width <= panel2.Left)
            {
                button5.Left = panel2.Width;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void close_b_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_b_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void restoredown_b_Click(object sender, EventArgs e)
        {
            if (WindowState.ToString() == "Normal")
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void tab_p_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
