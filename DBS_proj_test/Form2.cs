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

    public partial class Form2 : Form
    {
        //TVshows f1 = new TVshows();
        login_form lf1 = new login_form();
        MySqlConnection connection;
        String user_id= null;
        //if()

        
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


        public Form2()
        {
            InitializeComponent();
            //this.tab_p.Hide();
            timer1.Interval = 05;
            timer1.Start();
            button5.Location = new Point(button5.Location.X + button5.Width + 30,button5.Location.Y);
            button10.Location = new Point(button10.Location.X + button10.Width + 30, button10.Location.Y);
            panel3.Hide();

        }
        //login_form lf1 = new login_form();
        public Form2(String usr_id)
        {
            this.user_id = usr_id;
            
        }
        
        
       


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int a = comboBox1.SelectedIndex;
            //MessageBox.Show(a.ToString());
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void movie_b_Click(object sender, EventArgs e)
        {
            //f1.Hide();
            lf1.Hide();
            panel3.Visible = false;
            this.tab_p.Show();
            tab_p.Size = movie_b.Size;
            tab_p.Left = movie_b.Left;
            tab_p.Height = 15;
            
        }

        private void tvshows_b_Click(object sender, EventArgs e)
        {
            lf1.Hide();
            this.tab_p.Show();

            tab_p.Size = tvshows_b.Size;
            tab_p.Left = tvshows_b.Left;
            tab_p.Height = 15;
            panel3.Visible = true;
            panel3.BringToFront();


        }

        private void watchlist_b_Click(object sender, EventArgs e)
        {
            this.tab_p.Show();
            tab_p.Size = watchlist_b.Size;
            tab_p.Left = watchlist_b.Left;
            tab_p.Height = 15;
            if(signin_b.Text.Equals("Sign in"))
            {
                lf1.Show();
            }
        }

        private void searchbar_TextChanged(object sender, EventArgs e)
        {
            //searchbar.Text = null;
            searchbar.Font = new Font("Century", 10);
            searchbar.ForeColor = panel1.ForeColor;
            String str = searchbar.Text;
            //Form5 f5 = new Form5(str);
            //Form5 f1 = new Form5();
            //f1.Show();
            //f5.Show();
           // searchbar.Font = new Font()
        }

        private void fb_b_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.facebook.com");
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
            //tab_p.Hide();
            //DBConnect();
            //connection.Open();
            //this.Text = "" + user_id;

            //MessageBox.Show(user_id.ToString());
            lf1.clr_txtbox();
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
            button6.Location = new Point(button6.Location.X - 1, button6.Location.Y);
            button7.Location = new Point(button7.Location.X - 1, button7.Location.Y);
            button8.Location = new Point(button8.Location.X - 1, button8.Location.Y);
            button9.Location = new Point(button9.Location.X - 1, button9.Location.Y);
            button10.Location = new Point(button10.Location.X - 1, button10.Location.Y);
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
            /*
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'Shawshank Redemption'";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;
            da.Fill(ds, "tbl_movie");
            dt = ds.Tables["tbl_movie"];
            dr = dt.Rows[0];
            Form4 f4 = new Form4();
            f4.Show();
            f4.disp_det(dr);
            connection.Close();
            */
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'Shawshank Redemption'";
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
            f4.disp_det(dr);
            for (int j = 0; j < i; j++)
            {
                dr1 = dt1.Rows[j];
                f4.disp_people(dr1);

            }
            //f4.disp_people(dr1);
            connection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String name = null;
            //if (sender is Button)
            //    name = (sender as Button).Name;
            //MessageBox.Show(name);
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'Gangs of Wasseypur'";
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
            com1.CommandText = "select first_name, last_name, description from profession natural join people natural join movie_people where movie_people.movie_id=(select movie_id from movies where movie_title ='"+mov_nam+"')";
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
            f4.disp_det(dr);
            for (int j = 0; j < i; j++)
            {
                dr1 = dt1.Rows[j];
                f4.disp_people(dr1);

            }
            //f4.disp_people(dr1);
            connection.Close();
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
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'The Godfather'";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;
            da.Fill(ds, "tbl_movie");
            dt = ds.Tables["tbl_movie"];
            dr = dt.Rows[0];
            Form4 f4 = new Form4();
            f4.Show();
            f4.disp_det(dr);
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'The Usual Suspects'";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;
            da.Fill(ds, "tbl_movie");
            dt = ds.Tables["tbl_movie"];
            dr = dt.Rows[0];
            Form4 f4 = new Form4();
            f4.Show();
            f4.disp_det(dr);
            connection.Close();
            
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'Game Of Thrones'";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;
            da.Fill(ds, "tbl_movie");
            dt = ds.Tables["tbl_movie"];
            dr = dt.Rows[0];
            Form4 f4 = new Form4();
            f4.Show();
            f4.disp_det(dr);
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'Friends'";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;
            da.Fill(ds, "tbl_movie");
            dt = ds.Tables["tbl_movie"];
            dr = dt.Rows[0];
            Form4 f4 = new Form4();
            f4.Show();
            f4.disp_det(dr);
            connection.Close();
            */

            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'Friends'";
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
            f4.disp_det(dr);
            for (int j = 0; j < i; j++)
            {
                dr1 = dt1.Rows[j];
                f4.disp_people(dr1);

            }
            //f4.disp_people(dr1);
            connection.Close();
        }

        private void panel4_LocationChanged(object sender, EventArgs e)
        {

        }

        private void button9_LocationChanged(object sender, EventArgs e)
        {
            if (button9.Right + button9.Width <= panel4.Left)
            {
                button9.Left = panel4.Width;

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'Sacred Games'";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;
            da.Fill(ds, "tbl_movie");
            dt = ds.Tables["tbl_movie"];
            dr = dt.Rows[0];
            Form4 f4 = new Form4();
            f4.Show();
            f4.disp_det(dr);
            connection.Close();
        }

        private void button8_LocationChanged(object sender, EventArgs e)
        {
            if (button8.Right + button8.Width <= panel4.Left)
            {
                button8.Left = panel4.Width;

            }
        }

        private void button7_LocationChanged(object sender, EventArgs e)
        {
            if (button7.Right + button7.Width <= panel4.Left)
            {
                button7.Left = panel4.Width;

            }
        }

        private void button6_LocationChanged(object sender, EventArgs e)
        {
            if (button6.Right + button6.Width <= panel4.Left)
            {
                button6.Left = panel4.Width;

            }
        }

        private void button10_LocationChanged(object sender, EventArgs e)
        {
            if (button10.Right + button10.Width <= panel4.Left)
            {
                button10.Left = panel4.Width;

            }
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void insta_b_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");
        }

        private void twitter_b_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made with love by MovieStack team");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int i = 0;
            /*
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'Fight Club'";
            com.CommandType = CommandType.Text;
            MySqlCommand com1 = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            String mov_nam = dr["movie_title"].ToString();
            DataSet ds = new DataSet();
            DataSet d1 = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr ;
            da.Fill(ds, "tbl_movie");
            dt = ds.Tables["tbl_movie"];
            dr=dt.Rows[0];
            //com1.CommandText = "Select genre_dec from movie_genre natural join genre where movie_id=" + dr.["movie_id"];
            com1.CommandType = CommandType.Text;
            //MySqlDataAdapter da1 = new MySqlDataAdapter(com1.CommandText,connection);
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
            MessageBox.Show(i.ToString());

            Form4 f4 = new Form4();
            f4.Show();
            f4.disp_det(dr);
            for (int j = 0; j < i; j++)
            {
                dr1 = dt1.Rows[j];
                f4.disp_people(dr1);

            }
            connection.Close();
            */
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'Fight Club'";
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
            f4.disp_det(dr);
            for (int j = 0; j < i; j++)
            {
                dr1 = dt1.Rows[j];
                f4.disp_people(dr1);

            }
            //f4.disp_people(dr1);
            connection.Close();




        }

        private void search_b_Click(object sender, EventArgs e)
        {
            String search_text = searchbar.Text;
            //Form5 f1 = new Form5(search_text);
           /* DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select movie_title, star_rating, language from movies"; ;
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;
            da.Fill(ds, "Tbl_mov");
            */
            Form5 f2 = new Form5();
            
            f2.Show();
            f2.dip_res();
            f2.get_srcval(search_text);
            //connection.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'Breaking Bad'";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;
            da.Fill(ds, "tbl_movie");
            dt = ds.Tables["tbl_movie"];
            dr = dt.Rows[0];
            Form4 f4 = new Form4();
            f4.Show();
            f4.disp_det(dr);
            connection.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();
            com.CommandText = "Select * from movies where movie_title= 'Sherlock'";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;
            da.Fill(ds, "tbl_movie");
            dt = ds.Tables["tbl_movie"];
            dr = dt.Rows[0];
            Form4 f4 = new Form4();
            f4.Show();
            f4.disp_det(dr);
            connection.Close();
        }
    }
}
