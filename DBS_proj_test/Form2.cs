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
            this.tab_p.Hide();
        }

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
            login_form lf1 = new login_form();
            lf1.Show();
        }
    }
}
