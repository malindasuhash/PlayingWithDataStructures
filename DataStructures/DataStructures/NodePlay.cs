using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Node
    {
        public int Value { get; set; }

        public Node Next { get; set; }
    }

    class NodePlay
    {
        public void Play()
        {
            var node1 = new Node() { Value = 10 };

            var node2 = new Node() { Value = 20 };

            var node3 = new Node() { Value = 30 };

            // Link
            node1.Next = node2;

            node2.Next = node3;

            Print(node1);
        }

        private void Print(Node node)
        {
            while (node != null)
            {
                Console.WriteLine("Value = '{0}'", node.Value);

                node = node.Next;
            }
        }
    }
}
