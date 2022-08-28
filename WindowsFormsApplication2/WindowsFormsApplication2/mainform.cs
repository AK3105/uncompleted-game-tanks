using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tanksgame
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
            this.ControlBox = false; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gs1.move(gs1.Width, gs1.Height);
            Refresh();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                gs1.Fire(0);
                label6.Text = null;
            }
            else if (e.KeyChar == 'k')
            {
                gs1.Fire(1);
                label5.Text = null;
            }
            else if (e.KeyChar == 'a')
            {
                gs1.rotateLeft(0);
                label6.Text = null;
            }
            else if (e.KeyChar == 'd')
            {
                gs1.rotateRight(0);
                label6.Text = null;
            }
            else if (e.KeyChar == 'j')
            {
                gs1.rotateLeft(1);
                label5.Text = null;
            }
            else if (e.KeyChar == 'l')
            {
                gs1.rotateRight(1);
                label5.Text = null;
            }

        }

        private void gameScreen1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Close window?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label3.Text = "STOPPED";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label3.Text = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
