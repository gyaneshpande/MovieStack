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
using Microsoft.VisualBasic;

namespace DBS_proj_test
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        int c = 0;
        MySqlConnection connection;

        public void disp_det(DataRow dr)
        {
            //MessageBox.Show(dr["movie_title"].ToString());
            this.label1.Text = dr["movie_title"].ToString();
            runn_time.Text = dr["running_time"].ToString();
            int run_t = int.Parse(runn_time.Text);
           
            if(run_t <70 || run_t > 210)
                runn_time.Text = runn_time.Text + " episodes".ToString();
            else
                runn_time.Text = runn_time.Text + " mins".ToString();

            //string dt = dr["date"].ToString();
            // date.Text = dr["release_date"].ToString();
            date.Text = Convert.ToDateTime(dr["release_date"]).ToShortDateString();
            lang.Text = dr["language"].ToString();
            star_rating.Text = dr["star_rating"]+"/10 ".ToString();
            desc.Text = dr["description"].ToString();
            label8.Text = dr["movie_id"].ToString();
            pictureBox2.ImageLocation = dr["image"].ToString();
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void signin_change()
        {

        }

        public void disp_people (DataRow dr)
        {
            //DataRow dr;
            //int i = 0;
            //dr = dt.Rows[0];
            //int count = dt.Rows.Count;
            //MessageBox.Show(c.ToString());
            //int c = 0;
            if(dr["description"].Equals("Actor"))
            {
                if(c==0)
                    actr1.Text = dr["first_name"].ToString()+" "+ dr["last_name"].ToString();
                if(c==1)
                    actr2.Text= dr["first_name"].ToString() +" "+dr["last_name"].ToString();
                if (c == 2)
                    actr3.Text = dr["first_name"].ToString() + " " + dr["last_name"].ToString();
            }
            if (dr["description"].Equals("Director"))
                dir.Text= dr["first_name"].ToString() +" "+ dr["last_name"].ToString();
            if (dr["description"].Equals("Writer"))
                wri.Text = dr["first_name"].ToString() + " " + dr["last_name"].ToString();
            c++;
        }
        public void disp_people(string mov)
        {
            try
            {
                DBConnect();
                connection.Open();
                MySqlCommand com = new MySqlCommand();
                com.CommandText = "Select * from movies where movie_title= '" + mov + "'";
                com.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;
                da.Fill(ds, "tbl_movie");
                dt = ds.Tables["tbl_movie"];
                dr = dt.Rows[0];
                String mov_nam = dr["movie_title"].ToString();
                //MessageBox.Show(mov_nam);
                MySqlCommand com1 = new MySqlCommand();
                com1.CommandText = "select first_name, last_name, description from profession natural join people natural join movie_people where movie_people.movie_id=(select movie_id from movies where movie_title ='" + mov_nam + "')";
                com1.CommandType = CommandType.Text;
                MySqlDataAdapter da1 = new MySqlDataAdapter(com1.CommandText, connection);
                DataSet ds1 = new DataSet();
                DataTable dt1 = new DataTable();
                DataRow dr1;
                int i = 0;
                da1.Fill(ds1, "tbl_peeps");
                dt1 = ds1.Tables["tbl_peeps"];
                //dr1 = dt1.Rows[i];
                i = dt1.Rows.Count;
                //MessageBox.Show(i.ToString());


                Form4 f4 = new Form4();
                f4.Show();
                f4.Focus();
                f4.disp_det(dr);
                for (int j = 0; j < i; j++)
                {
                    dr1 = dt1.Rows[j];
                    f4.disp_people(dr1);


                }
                //f4.disp_people(dr1);
                connection.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Please select the correct Cell");
            }

            }
        public void DBConnect()
        {
            string server;
            string database;
            string uid;
            string password;
            server = "localhost";
            database = "movie_stack";
            uid = "root";
            password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //label1.Text = "test321";
        }

        private void back_b_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void wishlist_Click(object sender, EventArgs e)
        {
            //Form2 f = new Form2();
            String mov_id = label8.Text;
            
        }

        private void actr1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            String name = actr1.Text;
            String[] fname = name.Split(' ');
            //MessageBox.Show(fname[0].ToString());

            com.CommandText = "select movie_title,star_rating,language from movies natural join movie_people natural join people where first_name='"+fname[0]+"' group by person_id;";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_actdet");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_actdet";
            connection.Close();

        }

        private void actr2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            String name = actr2.Text;
            String[] fname = name.Split(' ');
            //MessageBox.Show(fname[0].ToString());

            com.CommandText = "select movie_title,star_rating,language from movie_people natural join movies natural join people where first_name='" + fname[0] + "' group by person_id;";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_actdet");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_actdet";
            connection.Close();
        }

        private void actr3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            String name = actr3.Text;
            String[] fname = name.Split(' ');
            //MessageBox.Show(fname[0].ToString());

            com.CommandText = "select movie_title,star_rating,language from movie_people natural join movies natural join people where first_name='" + fname[0] + "' group by person_id;";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_actdet");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_actdet";
            connection.Close();
        }

        private void dir_Click(object sender, EventArgs e)
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            String name = dir.Text;
            String[] fname = name.Split(' ');
            //MessageBox.Show(fname[0].ToString());

            com.CommandText = "select movie_title,star_rating,language from movie_people natural join movies natural join people where first_name='" + fname[0] + "' group by person_id;";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_actdet");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_actdet";
            connection.Close();
        }

        private void wri_Click(object sender, EventArgs e)
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            String name = wri.Text;
            String[] fname = name.Split(' ');
            //MessageBox.Show(fname[0].ToString());

            com.CommandText = "select movie_title,star_rating,language from movie_people natural join movies natural join people where first_name='" + fname[0] + "' group by person_id;";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_actdet");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_actdet";
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string str = Interaction.InputBox("Review", "Add your opinions", "Write here");
            MessageBox.Show(str);

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
