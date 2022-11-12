using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pdsa_coursework
{
    public partial class knapsackGame : Form
    {
        public knapsackGame()
        {
            InitializeComponent();
        }

        private void knapsackGame_Load(object sender, EventArgs e)
        {
        


            int[] weight = new int[10];
            int[] profit = new int[10];

            //item name assign
            String[] item = new string[10];
            item[0] = "A";
            item[1] = "B";
            item[2] = "C";
            item[3] = "D";
            item[4] = "E";
            item[5] = "F";
            item[6] = "G";
            item[7] = "H";
            item[8] = "I";
            item[9] = "J";
       



            Random rnd = new Random();

            //random weight assign
            for (int i = 0; i < 10; i++)
            {
                weight[i] = rnd.Next(1, 5);
            }

            //random profit assign
            for (int i = 0; i < 10; i++)
            {
                profit[i] = rnd.Next(5, 10);
            }

       


            //set table headings
            lstviewItems.Columns.Add("Item",50,HorizontalAlignment.Center);
            lstviewItems.Columns.Add("Weight",150, HorizontalAlignment.Center);
            lstviewItems.Columns.Add("Profit",150, HorizontalAlignment.Center);    


            lstviewItems.BackColor = Color.Lavender;
            lstviewItems.ForeColor = Color.Black;
            lstviewItems.View = View.Details;


            //fill table data
            for (int i = 0; i < 10; i++) 
            {
                lstviewItems.Items.Add(item[i]);
                lstviewItems.Items[i].SubItems.Add(weight[i].ToString());
                lstviewItems.Items[i].SubItems.Add(profit[i].ToString());
            }
            //////////////////////////////////////
           
            //knapsack max weight assign
            int capacity = 10;

            int[,] matrix = new int[10 + 1,capacity+1];


            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= capacity; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        matrix[i,j] = 0;
                    }
                    else if (weight[i - 1] <= j)
                    {
                        matrix[i,j] = Math.Max(profit[i - 1] + matrix[i - 1,j - weight[i - 1]], matrix[i - 1,j]);
                    }
                    else
                    {
                        matrix[i,j] = matrix[i - 1,j];
                    }
                }
            }

            label1.Text= matrix[10,capacity].ToString();


            //////////////////////////////


        }


      
    }
}
