using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace pdsa_coursework
{
    public partial class minimumConnectorsGame : Form
    {


        private SqlCommand cmd;
        SqlConnection con = new SqlConnection("Data Source=15S-DU3039TX;Initial Catalog=pdsa2_cw;Integrated Security=True");

        public int save(string a)
        {
            try
            {
                openConnection();
                cmd = new SqlCommand(a, con);
                int i = cmd.ExecuteNonQuery();
                return i;
            }
            finally
            {
                closeConnection();
            }
        }
        public void openConnection()
        {
            con.Open();
        }
        public void closeConnection()
        {
            con.Close();
        }

        private Graph graph;
        int selectedNode;

        private void setGraph(Graph graph)
        {
            this.graph = graph;
        }

        private Graph getGraph()
        {
            return graph;
        }

        public minimumConnectorsGame()
        {
            InitializeComponent();
        }

        private void minimumConnectorsGame_Load(object sender, EventArgs e)
        {
            setGraph(new Graph());
            int[] edges = getGraph().getDistance();

            labelAB.Text = edges[0].ToString();
            labelBC.Text = edges[1].ToString();
            labelBE.Text = edges[2].ToString();
            labelAD.Text = edges[3].ToString();
            labelDE.Text = edges[4].ToString();
            labelCE.Text = edges[5].ToString();
            labelDF.Text = edges[6].ToString();
            labelDG.Text = edges[7].ToString();
            labelEG.Text = edges[8].ToString();
            labelFH.Text = edges[9].ToString();
            labelFG.Text = edges[10].ToString();
            labelGJ.Text = edges[11].ToString();
            labelFI.Text = edges[12].ToString();
            labelHI.Text = edges[13].ToString();
            labelIJ.Text = edges[14].ToString();
        }

        private void gameBord_Paint(object sender, PaintEventArgs e)
        {
            Random rnd = new Random();
            selectedNode = rnd.Next(0, 9);

            switch (selectedNode)
            {
                case 0:
                    panelA.BackColor = Color.Red; break;
                case 1:
                    panelB.BackColor = Color.Red; break;
                case 2:
                    panelC.BackColor = Color.Red; break;
                case 3:
                    panelD.BackColor = Color.Red; break;
                case 4:
                    panelE.BackColor = Color.Red; break;
                case 5:
                    panelF.BackColor = Color.Red; break;
                case 6:
                    panelG.BackColor = Color.Red; break;
                case 7:
                    panelH.BackColor = Color.Red; break;
                case 8:
                    panelI.BackColor = Color.Red; break;
                case 9:
                    panelJ.BackColor = Color.Red; break;
            }
        }

        private void labelCE_Click(object sender, EventArgs e)
        {

        }

        private void labelQuestion_Click(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var result = getGraph().primsAlgo(selectedNode);
            labelanswer.Text = result.Item1.ToString();
            List<String> shortestPath = result.Item2;

            foreach (String path in shortestPath)
            {
                Console.WriteLine(path);
                switch (path)
                {
                    case "AB":
                        panel10.BackColor = Color.Yellow; break;
                    case "BC":
                        panel12.BackColor = Color.Yellow; break;
                    case "BE":
                        panel26.BackColor = Color.Yellow;
                        panel27.BackColor = Color.Yellow;
                        panel28.BackColor = Color.Yellow; break;
                    case "AD":
                        panel16.BackColor = Color.Yellow;
                        panel17.BackColor = Color.Yellow; break;
                    case "DE":
                        panel11.BackColor = Color.Yellow; break;
                    case "CE":
                        panel18.BackColor = Color.Yellow;
                        panel19.BackColor = Color.Yellow; break;
                    case "DF":
                        panel20.BackColor = Color.Yellow; break;
                    case "EG":
                        panel21.BackColor = Color.Yellow; break;
                    case "DG":
                        panel29.BackColor = Color.Yellow;
                        panel30.BackColor = Color.Yellow;
                        panel31.BackColor = Color.Yellow; break;
                    case "FG":
                        panel13.BackColor = Color.Yellow; break;
                    case "HI":
                        panel14.BackColor = Color.Yellow; break;
                    case "IJ":
                        panel15.BackColor = Color.Yellow; break;
                    case "FH":
                        panel22.BackColor = Color.Yellow;
                        panel23.BackColor = Color.Yellow; break;
                    case "FI":
                        panel32.BackColor = Color.Yellow;
                        panel33.BackColor = Color.Yellow;
                        panel34.BackColor = Color.Yellow; break;
                    case "GJ":
                        panel24.BackColor = Color.Yellow;
                        panel25.BackColor = Color.Yellow; break;
                }
            }
        }

        private void textBoxAnswer_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelanswer_Click(object sender, EventArgs e)
        {

        }

        private void Submit_answer_Click(object sender, EventArgs e)
        {
            String correctAnswer = getGraph().primsAlgo(selectedNode).Item1.ToString();
            if (correctAnswer.Equals(textBoxAnswer.Text))
            {
                label_answer_status.Text = "Answer is correct!! " +
                    "Please enter your name to save.";
                label_answer_status.ForeColor = Color.Green;
                textBox1.Visible = true;
                button_save.Visible = true;
            }
            else
            {
                label_answer_status.Text = "Answer is wrong!!";
                label_answer_status.ForeColor = Color.Red;
            }

            if (textBoxAnswer.Text == "")
            {
                MessageBox.Show("Answer Cannot be blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxAnswer.Text.All(char.IsDigit) == false)
            {
                MessageBox.Show("Answer should be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Answer Cannot be blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text.All(char.IsDigit) == true)
            {
                MessageBox.Show("Name Cannot be Numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    String cd = "insert into gamedetails values ('" + textBox1.Text + "', '" + textBoxAnswer.Text + "', '" + DateTime.Now + "')";
                    int i = save(cd);
                    if (i == 1)
                        MessageBox.Show("Data Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (i == 2)
                        MessageBox.Show("Data Cannot Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (SqlException)
                {
                    MessageBox.Show("DataBase Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}

