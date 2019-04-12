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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public void disp_rev(MySqlDataAdapter da)
        {
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_reviews");
            //DataTable dt = new DataTable();
            
            //dt = ds.Tables["Tbl_review1"];
            //DataView dv = new DataView(dt);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_reviews";
            //dataGridView1.DataMember = dv;
      

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
