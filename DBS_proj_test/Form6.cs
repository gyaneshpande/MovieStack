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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public void watchlist_det(DataSet ds)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables["tbl_watchlist"];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_watchlist";

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

                if (e.RowIndex != -1)
                {
                    if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    {
                        string mov_name = dataGridView1.CurrentCell.Value.ToString();
                        //MessageBox.Show("Ghusa");
                        //MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
                        Form4 f1 = new Form4();
                        f1.disp_people(mov_name);
                        //f1.Show();


                    }
                }


            
        }
    }
}
