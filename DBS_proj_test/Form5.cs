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
    public partial class Form5 : Form
    {
        String search_tx = null;
        MySqlConnection connection;
        public Form5()
        {
            InitializeComponent();
        }
        DataTable dt;
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
        public Form5(String src_txt)
        {
            search_tx = src_txt;
            //label1.Text = src_txt;
            // MessageBox.Show(search_tx);
        }
        public void get_srcval(String str)
        {
            search_tx = str;
            //label1.Text = search_tx.ToString();
            searchbar.Text = search_tx;
        }
        public void dip_res()
        {
            
             
            
            if (comboBox1.SelectedIndex==0)
            {
                DBConnect();
                connection.Open();
                MySqlCommand com;

                com = new MySqlCommand();
                com.CommandText = "Select movie_title, star_rating, language from movies where m_type='m'";
                com.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
                dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr;
                da.Fill(ds, "Tbl_mov");
                dt = ds.Tables["Tbl_mov"];
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Tbl_mov";
                connection.Close();
            }
            else if (comboBox1.SelectedIndex==2)
            {
                DBConnect();
                connection.Open();
                MySqlCommand com;

                com = new MySqlCommand();

                com.CommandText = "Select first_name, last_name, gender, dob from people natural join movie_people where p_code='a' ;";
                com.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
                dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr;
                da.Fill(ds, "Tbl_mov");
                dt = ds.Tables["Tbl_mov"];
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Tbl_mov";
                connection.Close();
            }
            else if(comboBox1.SelectedIndex==3)
            {
                DBConnect();
                connection.Open();
                MySqlCommand com;

                com = new MySqlCommand();

                com.CommandText = "Select first_name, last_name, gender, dob from people natural join movie_people where p_code='d' ;";
                com.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
                dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr;
                da.Fill(ds, "Tbl_mov");
                dt = ds.Tables["Tbl_mov"];
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Tbl_mov";
                connection.Close();
            }
            else if (comboBox1.SelectedIndex==4)
            {
                DBConnect();
                connection.Open();
                MySqlCommand com;

                com = new MySqlCommand();

                com.CommandText = "Select first_name, last_name, gender, dob from people natural join movie_people where p_code='w' ;";
                com.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
                dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr;
                da.Fill(ds, "Tbl_mov");
                dt = ds.Tables["Tbl_mov"];
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Tbl_mov";
                connection.Close();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DBConnect();
                connection.Open();
                MySqlCommand com;

                com = new MySqlCommand();

                com.CommandText = "Select movie_title, star_rating, language from movies where m_type='s'";
                com.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
                dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr;
                da.Fill(ds, "Tbl_mov");
                dt = ds.Tables["Tbl_mov"];
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Tbl_mov";
                connection.Close();
            }
            else
            {
                DBConnect();
                connection.Open();
                MySqlCommand com;

                com = new MySqlCommand();

                com.CommandText = "Select * from movies;";
                com.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
                dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr;
                da.Fill(ds, "Tbl_mov");
                dt = ds.Tables["Tbl_mov"];
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Tbl_mov";
                connection.Close();
            }
           /* com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;
            da.Fill(ds, "Tbl_mov");
            dt = ds.Tables["Tbl_mov"];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_mov";
            connection.Close();*/
        }
        /*public void dip_actor()
        {
            DBConnect();
            connection.Open();
            MySqlCommand com = new MySqlCommand();

            com.CommandText = "Select first_name, last_name, gender, dob from people natural join movie_people; ";
            com.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
            dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;
            da.Fill(ds, "Tbl_mov");
            dt = ds.Tables["Tbl_mov"];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Tbl_mov";
            connection.Close();l
        }
        */


        private void Form5_Load(object sender, EventArgs e)
        {
            //label1.Text = search_tx.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void searchbar_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("movie_title LIKE '%{0}%'", searchbar.Text);
                dataGridView1.DataSource = dv;
            }
            else if (comboBox1.SelectedIndex==2 || comboBox1.SelectedIndex==3 || comboBox1.SelectedIndex==4)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("first_name LIKE '%{0}%'", searchbar.Text);
                dataGridView1.DataSource = dv;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = string.Format("movie_title LIKE '%{0}%'", searchbar.Text);
                dataGridView1.DataSource = dv;
            }

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

        private void search_b_Click(object sender, EventArgs e)
        {

                dip_res();
            searchbar.Clear();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

