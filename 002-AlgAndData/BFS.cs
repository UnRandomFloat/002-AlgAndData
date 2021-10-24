using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class BFS
    {

        public void BreadthFirstSearch(int whattoFind, BinaryTreeNode B_node)
        {
            Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
            if (B_node == null)
            {
                return;
            }
            queue.Enqueue(B_node);

            while (queue.Count != 0)
            {
                BinaryTreeNode temp = queue.Dequeue();
                if (temp.Left != null)
                {
                    queue.Enqueue(temp.Left);
                }
                if (temp.Right != null)
                {
                    queue.Enqueue(temp.Right);
                }

                if (temp.Data == whattoFind)
                {
                    Console.WriteLine($"{temp.Data} найдено");
                }
                else if (temp.visited == false)
                {
                    Console.WriteLine(temp.Data);
                }
            }
        }
        public void Graph_BFS(Graph grey) //Обход ссылочного графа 
        {
            Queue<GraphNode> queue = new Queue<GraphNode>();
            GraphNode gnTemp = null;
            queue.Enqueue(grey.Nodes[0]);

            while (queue.Count > 0)
            {
                gnTemp = queue.Dequeue();
                if (gnTemp.isVisited == false)
                {
                    gnTemp.isVisited = true;
                    Console.WriteLine(gnTemp.Name);
                    foreach (var item in gnTemp.Edges)
                    {
                        queue.Enqueue(item.ConnectedNode);
                    }
                }

            }
            foreach (var item in grey.Nodes)
            {
                item.isVisited = false;
            }
        }
        //public void Graph_BFS(int whattoFind, int[,] theMatrix)// Обход графа по матрице
        //{
        //    Queue<Graph> queue = new Queue<Graph>();
        //}
    }
}
