using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class DFS
    {

   
        public void DeepFirstSearch(int whattoFind, BinaryTreeNode B_node)
        {
            Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
            if (B_node == null)
            {
                return;
            }
            stack.Push(B_node);
            while (stack.Count > 0)
            {
                BinaryTreeNode temp = stack.Pop();
                if (temp.Right != null)
                {
                    stack.Push(temp.Right);
                }
                if (temp.Left != null)
                {
                    stack.Push(temp.Left);
                }
                if (temp.Data == whattoFind)
                {
                    Console.WriteLine($"{temp.Data} -найдено!");
                }
                else
                {
                    Console.WriteLine(temp.Data);
                }
            }

        }
        public void Graph_DFS(Graph grey)
        {
            Stack<GraphNode> stack = new Stack<GraphNode>();
            GraphNode gnTemp = null;
            stack.Push(grey.Nodes[0]);
            while (stack.Count > 0)
            {
                gnTemp = stack.Pop();
                if (gnTemp.isVisited == false)
                {
                    gnTemp.isVisited = true;
                    Console.WriteLine(gnTemp.Name);
                    foreach (var item in gnTemp.Edges)
                    {
                        stack.Push(item.ConnectedNode);
                    }
                }

            }
            foreach (var item in grey.Nodes)
            {
                item.isVisited = false;
            }
        }
    }
}
