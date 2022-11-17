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
    public partial class minimumConnectorsGame : Form
    {
        public minimumConnectorsGame()
        {
            InitializeComponent();
        }

        private void minimumConnectorsGame_Load(object sender, EventArgs e)
        {
            int[] distance = new int[15];
            Random rnd = new Random();

            //random distance assign
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);    
                labelAB.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelBC.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelBE.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelAD.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelDE.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelCE.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelDF.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelDG.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelEG.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelFH.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelFG.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelGJ.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelFI.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelHI.Text = distance[i].ToString();
            }
            for (int i = 0; i < 1; i++)
            {
                distance[i] = rnd.Next(10, 100);
                labelIJ.Text = distance[i].ToString();
            }
        }


        private void panelA_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void gameBord_Paint(object sender, PaintEventArgs e)
        {
            int[] panel = new int[10];
            Random rnd = new Random();
            int  i = 0;
            panel[i] = rnd.Next(0, 9);

            if (panel[i] == 0)
                panelA.BackColor = Color.Red;
            else if (panel[i] == 1)
                panelB.BackColor = Color.Red;
            else if (panel[i] == 2)
                panelC.BackColor = Color.Red;
            else if (panel[i] == 3)
                panelD.BackColor = Color.Red;
            else if (panel[i] == 4)
                panelE.BackColor = Color.Red;
            else if (panel[i] == 5)
                panelF.BackColor = Color.Red;
            else if (panel[i] == 6)
                panelG.BackColor = Color.Red;
            else if (panel[i] == 7)
                panelH.BackColor = Color.Red;
            else if (panel[i] == 8)
                panelI.BackColor = Color.Red;
            else if (panel[i] == 9)
                panelJ.BackColor = Color.Red;
        }
    }
}
