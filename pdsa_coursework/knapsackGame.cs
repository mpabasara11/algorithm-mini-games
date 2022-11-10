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
    public partial class knapsackGame : Form
    {
        public knapsackGame()
        {
            InitializeComponent();
        }

        private void knapsackGame_Load(object sender, EventArgs e)
        {

        }


        public void calculate() 
        {
            // TODO Auto-generated method stub
            System.out.println("Maximum profit for 0/1 Knapsack Problem");
            System.out.println("Enter the number of items");
            Scanner sc = new Scanner(System.in);
            int n = sc.nextInt();
            int[] weight = new int[n];
            int[] profit = new int[n];
            System.out.println("Enter the weight of each item");
            for (int i = 0; i < n; i++)
            {
                weight[i] = sc.nextInt();
            }
            System.out.println("Enter the profit of each item");
            for (int i = 0; i < n; i++)
            {
                profit[i] = sc.nextInt();
            }
            System.out.println("Enter the capacity of the knapsack");
            int capacity = sc.nextInt();
            int[][] matrix = new int[n + 1][capacity + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= capacity; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        matrix[i][j] = 0;
                    }
                    else if (weight[i - 1] <= j)
                    {
                        matrix[i][j] = Math.max(profit[i - 1] + matrix[i - 1][j - weight[i - 1]], matrix[i - 1][j]);
                    }
                    else
                    {
                        matrix[i][j] = matrix[i - 1][j];
                    }
                }
            }
            System.out.println("The maximum profit is " + matrix[n][capacity]);
            System.out.println("The items selected are");
            int i = n;
            int j = capacity;
            while (i > 0 && j > 0)
            {
                if (matrix[i][j] != matrix[i - 1][j])
                {
                    System.out.println("Item " + i + " with weight " + weight[i - 1] + " and profit " + profit[i - 1]);
                    j = j - weight[i - 1];
                }
                i--;
            }

        }
    }
}
