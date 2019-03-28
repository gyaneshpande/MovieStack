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
    public partial class TVshows : Form
    {
        public TVshows()
        {
            InitializeComponent();
            timer1.Interval = 05;
            timer1.Start();
            button5.Location = new Point(button5.Location.X + button5.Width + 35, button5.Location.Y);
        }

        private void TVshows_Load(object sender, EventArgs e)
        {
            //this.SetDisplayRectLocation(190, 210);
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
            if (button1.Right <= panel1.Left)
            {
                button1.Left = panel1.Width;
                //button1.lo
            }
        }

        private void button2_LocationChanged(object sender, EventArgs e)
        {
            if (button2.Right <= panel1.Left)
            {
                button2.Left = panel1.Width;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_LocationChanged(object sender, EventArgs e)
        {
            if (button3.Right <= panel1.Left)
            {
                button3.Left = panel1.Width;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_LocationChanged(object sender, EventArgs e)
        {
            if (button4.Right <= panel1.Left)
            {
                button4.Left = panel1.Width;
            }
        }

        private void button5_LocationChanged(object sender, EventArgs e)
        {
            if (button5.Right  <= panel1.Left)
            {
                button5.Left = panel1.Width;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
