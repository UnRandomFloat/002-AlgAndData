using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class BFS
    {
        Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
        public void BreadthFirstSearch(int whattoFind, BinaryTreeNode B_node)
        {
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
    }
}
