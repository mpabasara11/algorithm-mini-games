using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pdsa_coursework
{
    internal class Graph
    {
        private const int INF = 999999999;
        private const int numNodes = 10;
        private const int numEdges = 15;
        private int[] distance = new int[numEdges];
        private int[,] matrix = new int[numNodes, numNodes];
        private List<String> shortestPath = new List<String>();

        Random rnd = new Random();

        public Graph()
        {
            initGraph();
        }

        public int[] getDistance()
        {
            return distance;
        }

        private void initGraph()
        {
            for (int i = 0; i < numEdges; i++)
            {
                distance[i] = rnd.Next(10, 100);
            }

            //distance = new int[numEdges] {53, 19, 31, 82, 11, 57, 38, 63, 85, 20, 60, 65, 11, 14, 76 };

            matrix[1, 0] = distance[0]; matrix[0, 1] = distance[0]; //AB
            matrix[2, 1] = distance[1]; matrix[1, 2] = distance[1]; //BC
            matrix[4, 1] = distance[2]; matrix[1, 4] = distance[2]; //BE
            matrix[3, 0] = distance[3]; matrix[0, 3] = distance[3]; //AD
            matrix[4, 3] = distance[4]; matrix[3, 4] = distance[4]; //DE
            matrix[4, 2] = distance[5]; matrix[2, 4] = distance[5]; //CE
            matrix[5, 3] = distance[6]; matrix[3, 5] = distance[6]; //DF
            matrix[6, 3] = distance[7]; matrix[3, 6] = distance[7]; //DG
            matrix[6, 4] = distance[8]; matrix[4, 6] = distance[8]; //EG
            matrix[7, 5] = distance[9]; matrix[5, 7] = distance[9]; //FH
            matrix[6, 5] = distance[10]; matrix[5, 6] = distance[10]; //FG
            matrix[8, 6] = distance[11]; matrix[6, 8] = distance[11]; //GJ
            matrix[9, 5] = distance[12]; matrix[5, 9] = distance[12]; //FI
            matrix[8, 7] = distance[13]; matrix[7, 8] = distance[13]; //HI
            matrix[9, 8] = distance[14]; matrix[8, 9] = distance[14]; //IJ
        }

        public Tuple<int, List<String>> primsAlgo(int selectedNode)
        {
            int shortestDistance = 0;

            int[,] currMtx = this.matrix;
            Boolean[] selected = new Boolean[numNodes];
            int no_edge = 0;

            selected[selectedNode] = true;

            while (no_edge < numNodes - 1)
            {
                int min = INF;
                int x = 0;
                int y = 0;
                for (int i = 0; i < numNodes; i++)
                {
                    if (selected[i] == true)
                    {
                        for (int j = 0; j < numNodes; j++)
                        {
                            if (!selected[j] && currMtx[i, j] != 0)
                            {
                                if (min > currMtx[i, j])
                                {
                                    min = currMtx[i, j];
                                    x = i;
                                    y = j;
                                }
                            }

                        }
                    }
                }

                switch (x.ToString() + y.ToString())
                {
                    case "10":
                    case "01":
                        shortestPath.Add("AB"); break;
                    case "21":
                    case "12":
                        shortestPath.Add("BC"); break;
                    case "41":
                    case "14":
                        shortestPath.Add("BE"); break;
                    case "30":
                    case "03":
                        shortestPath.Add("AD"); break;
                    case "43":
                    case "34":
                        shortestPath.Add("DE"); break;
                    case "42":
                    case "24":
                        shortestPath.Add("CE"); break;
                    case "53":
                    case "35":
                        shortestPath.Add("DF"); break;
                    case "63":
                    case "36":
                        shortestPath.Add("DG"); break;
                    case "64":
                    case "46":
                        shortestPath.Add("EG"); break;
                    case "75":
                    case "57":
                        shortestPath.Add("FH"); break;
                    case "65":
                    case "56":
                        shortestPath.Add("FG"); break;
                    case "86":
                    case "68":
                        shortestPath.Add("GJ"); break;
                    case "95":
                    case "59":
                        shortestPath.Add("FI"); break;
                    case "87":
                    case "78":
                        shortestPath.Add("HI"); break;
                    case "98":
                    case "89":
                        shortestPath.Add("IJ"); break;
                }
                shortestDistance += currMtx[x, y];
                selected[y] = true;
                no_edge++;
            }
            return Tuple.Create(shortestDistance, shortestPath);
        }

    }
}
