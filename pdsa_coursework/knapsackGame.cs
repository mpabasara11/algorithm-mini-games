using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace pdsa_coursework
{
    public partial class knapsackGame : Form
    {

        SqlConnection con =new SqlConnection( "Data Source=15S-DU3039TX;Initial Catalog=pdsa2_cw;Integrated Security=True");

        //subset kept global since its need to be accessed  from all methods
        int[] subsets = new int[10];
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

            
               int maxprofit= matrix[10,capacity];


            int a = 10;
            int b = capacity;

        // int[] subsets = new int[10];

            int x = 0;
            while (a > 0 && b > 0)
            {
              
                if (matrix[a,b] != matrix[a - 1,b])
                {
                  
                    Console.WriteLine(a);
                    subsets[x] = a; x = x + 1;
                   
                    b = b - weight[a - 1];
                 
                }
                a--;
                

            }

         



        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] answers=new int[10];
            String answers_toDb = "";
            int x = 0;

            if (chkbx1.Checked) 
            {
                answers[x] = 1;
                x++;
                answers_toDb = answers_toDb + " " + 1;
            }
            if (chkbx2.Checked)
            {
                answers[x] = 2;
                x++;
                answers_toDb = answers_toDb + " " + 2;
            }
            if (chkbx3.Checked)
            {
                answers[x] = 3;
                x++;
                answers_toDb = answers_toDb + " " + 3;
            }
            if (chkbx4.Checked)
            {
                answers[x] = 4;
                x++;
                answers_toDb = answers_toDb + " " + 4;
            }
            if (chkbx5.Checked)
            {
                answers[x] = 5;
                x++;
                answers_toDb = answers_toDb + " " + 5;
            }
            if (chkbx6.Checked)
            {
                answers[x] = 6;
                x++;
                answers_toDb = answers_toDb + " " + 6;
            }
            if (chkbx7.Checked)
            {
                answers[x] = 7;
                x++;
                answers_toDb = answers_toDb + " " + 7;
            }
            if (chkbx8.Checked)
            {
                answers[x] = 8;
                x++;
                answers_toDb = answers_toDb + " " + 8;
            }
            if (chkbx9.Checked)
            {
                answers[x] = 9;
                x++;
                answers_toDb = answers_toDb + " " + 9;
            }
            if (chkbx10.Checked)
            {
                answers[x] = 10;
                x++;
                answers_toDb = answers_toDb + " " + 10;
            }
            


         
          


            int matchedanswers = 0;
            for (int y = 0; y < answers.Length; y++) 
            {
                for(int z=0;z<subsets.Length;z++) 
                {
                    if (answers[y] == subsets[z] && (answers[y] != 0 && subsets[z] != 0)) 
                    {
                          matchedanswers++;
                 

                    }

                }
            

            }
            con.Open();
            if (matchedanswers == x)
            {
                // MessageBox.Show("wade goda bossa");

                string name = "";

                if (InputBox("Dialog Box", "What is your name?", ref name) == DialogResult.OK)
                {
                    SqlCommand cmd = new SqlCommand("insert into knapsack_winners values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + name + "','" + answers_toDb + "')", con);

                   int i= cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                
            }
            con.Close();

           

            
            
        }

 
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {

            Form form = new Form();
            Label label = new Label();
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            System.Windows.Forms.Button buttonOk = new System.Windows.Forms.Button();
            System.Windows.Forms.Button buttonCancel = new System.Windows.Forms.Button();

            form.Text = title;
            label.Text = promptText;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(36, 36, 372, 13);
            textBox.SetBounds(36, 86, 700, 20);
            buttonOk.SetBounds(228, 160, 160, 60);
            buttonCancel.SetBounds(400, 160, 160, 60);

            label.AutoSize = true;
            form.ClientSize = new Size(796, 307);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();

            value = textBox.Text;
            return dialogResult;
        }

        private void lstviewItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
