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
    public partial class login_form : Form
    {

        MySqlConnection connection;
        public login_form()
        {
            InitializeComponent();
            panel2.Hide();
            //textBox1.Clear();
            //textBox2.Clear();

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
            try
            {
                //login_button.Text = "test";
                String usr_id = textBox1.Text;
                //MessageBox.Show(usr_id);
                DBConnect();
                connection.Open();
                MySqlCommand com = new MySqlCommand();
                com.CommandText = "select user_id, password from user where user_id='" + usr_id + "' and password='" + textBox2.Text.ToString() + "'";
                com.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                DataRow dr;
                da.Fill(ds, "tbl_user");
                dt = ds.Tables["tbl_user"];
                if (dt.Rows.Count > 0)
                    dr = dt.Rows[0];
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful");
                    Class1.u1 = usr_id;

                    //Form4 f = new Form4(usr_id);
                    //f.get_user_id(usr_id);
                    //MessageBox.Show(usr_id);
                    //Form2 f2 = new Form2(usr_id);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User doesn't exist");
                }
                connection.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error in login connection" + ee.ToString());
            }




            /*if(textBox1.Text.Equals("admin") && textBox2.Text.Equals("password"))
            {
                MessageBox.Show("Login Successful");
                Form2 f2 = new Form2(usr_id);
                Form4 f4 = new Form4(usr_id);
                //f4.get_user_id(usr_id);

                this.Hide();
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String f_name = textBox4.Text;
            String l_name = textBox5.Text;
            String u_name = textBox3.Text;
            String pass_1 = textBox6.Text;
            String pass_2 = textBox7.Text;
            if (f_name == "" || l_name == "" || u_name == "" || pass_1 == "" || pass_2 == "")
            {
                MessageBox.Show("Some Fields are empty");

            }
            else
            {
                if (pass_1 != pass_2)
                {
                    MessageBox.Show("Passwords are not matching");
                }

                else
                {
                    try
                    {
                        DBConnect();
                        connection.Open();
                        MySqlCommand com = new MySqlCommand();
                        com.CommandText = "insert into user values ('" + u_name + "','" + f_name + "','" + l_name + "','" + pass_1 + "');";
                        com.CommandType = CommandType.Text;
                        com.Connection = connection;
                        com.ExecuteNonQuery();
                        MessageBox.Show("Registration Successfull");
                        panel2.Hide();
                        panel1.Show();
                        //MySqlDataAdapter da = new MySqlDataAdapter(com.CommandText, connection);
                        connection.Close();
                    }
                    catch (Exception aee)
                    {
                        MessageBox.Show("Username already taken");
                    }
                }
            }
        }
    }
}
