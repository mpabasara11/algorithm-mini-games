using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdsa_coursework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this.Hide();
            Game1 game1 = new Game1();
            game1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // this.Hide();
            Game2 game2 = new Game2();
            game2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // this.Hide();
            Game3 game3 = new Game3();
            game3.Show();
        }
    }
}
