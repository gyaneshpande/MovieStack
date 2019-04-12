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
        String user_id= Class1.u1;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(string userr_id)
        {
            this.user_id = userr_id;
            MessageBox.Show(user_id);
        }
        int c = 0;
        MySqlConnection connection;

        

        public void get_user_id(String usr_id)
        {
            this.user_id = usr_id;
            
            //MessageBox.Show(user_id);
        }

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
            disp_genre(label8.Text.ToString());
            pictureBox2.ImageLocation = dr["image"].ToString();
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void signin_change()
        {

        }
        public void disp_genre(String movie_id)
        {
            DBConnect();
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            //MessageBox.Show(movie_id);
            com.CommandText = "select genre_desc from movie_genre natural join genre where movie_id ='" + movie_id + "';";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_gen");
            DataTable dt = new DataTable();
            dt = ds.Tables["tbl_gen"];
            //da.Fill(ds, "tbl_gen");
            DataRow dr;
            dr = dt.Rows[0];
            genre.Text = dr["genre_desc"].ToString();

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
            //disp_genre(label8.Text);
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
            //MessageBox.Show(user_id);
            try
            {
                DBConnect();
                connection.Open();
                MySqlCommand com = new MySqlCommand();
                com.CommandText = "insert into watchlist values ('" + user_id + "','" +mov_id+ "')";
                com.CommandType = CommandType.Text;
                com.Connection = connection;
                com.ExecuteNonQuery();
                MessageBox.Show("Added to Watchlist");
                connection.Close();

            }
            catch(Exception ex)
            {
                if (user_id == null)
                {
                    MessageBox.Show("Login first to add to watchlist");
                }
                else
                {
                    MessageBox.Show("Cannot be Added to watchlist");
                }
            }

            
        }

        private void actr1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            String name = actr1.Text;
            String[] fname = name.Split(' ');
            
            //MessageBox.Show(fname[0].ToString());

            com.CommandText = "WITH t1 AS( select movie_id from movie_people where person_id=(select person_id from people where first_name = '"+fname[0]+"' and last_name = '"+fname[1]+"') ) SELECT movie_title,star_rating,language FROM movies,t1 where movies.movie_id=t1.movie_id;";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Tbl_actdet1");
            DataTable dt = new DataTable();
            dt = ds.Tables["Tbl_actdet1"];
            DataView dv = new DataView();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_actdet1";
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

            com.CommandText = "WITH t1 AS( select movie_id from movie_people where person_id=(select person_id from people where first_name = '" + fname[0] + "' and last_name = '" + fname[1] + "') ) SELECT movie_title,star_rating,language FROM movies,t1 where movies.movie_id=t1.movie_id;";
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

            com.CommandText = "WITH t1 AS( select movie_id from movie_people where person_id=(select person_id from people where first_name = '" + fname[0] + "' and last_name = '" + fname[1] + "') ) SELECT movie_title,star_rating,language FROM movies,t1 where movies.movie_id=t1.movie_id;";
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

            com.CommandText = "WITH t1 AS( select movie_id from movie_people where person_id=(select person_id from people where first_name = '" + fname[0] + "' and last_name = '" + fname[1] + "') ) SELECT movie_title,star_rating,language FROM movies,t1 where movies.movie_id=t1.movie_id;";
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
            String str = Interaction.InputBox("Review", "Add your opinions", "Write here");
            //MessageBox.Show(str);
            try
            {
                DBConnect();
                connection.Open();
                MySqlCommand com = new MySqlCommand();
                com.CommandText = "insert into reviews values ('" + label8.Text + "','" + Class1.u1 + "','" + str + "');";
                com.CommandType = CommandType.Text;
                com.Connection = connection;
                com.ExecuteNonQuery();
                MessageBox.Show("Review Submitted Successfully");
                connection.Close();
            }
            catch(Exception ae)
            {
                if (Class1.u1 == null)
                {
                    MessageBox.Show("Please Login First");
                }
                else
                {
                    MessageBox.Show("Review not submitted");
                }
            }


            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void desc_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "select * from reviews where movie_id='" + label8.Text + "';";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_review");
                
            Form7 f7 = new Form7();
            f7.disp_rev(da);
            f7.Show();
            

            
        }

        private void genre_Click(object sender, EventArgs e)
        {

        }
    }
}
