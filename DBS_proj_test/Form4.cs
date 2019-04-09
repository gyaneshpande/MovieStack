using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace DBS_proj_test
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public void disp_det(DataRow dr)
        {
            //MessageBox.Show(dr["movie_title"].ToString());
            this.label1.Text = dr["movie_title"].ToString();
            runn_time.Text = dr["running_time"].ToString();
            int run_t = int.Parse(runn_time.Text);
           
            if(run_t <70)
                runn_time.Text = runn_time.Text + " episodes".ToString();
            else
                runn_time.Text = runn_time.Text + " mins".ToString();

            //string dt = dr["date"].ToString();
            // date.Text = dr["release_date"].ToString();
            date.Text = Convert.ToDateTime(dr["release_date"]).ToShortDateString();
            lang.Text = dr["language"].ToString();
            star_rating.Text = dr["star_rating"]+"/10 ".ToString();
            desc.Text = dr["description"].ToString();
           // pictureBox1.Image=Properties.Resources.
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //label1.Text = "test321";
        }

        private void back_b_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
